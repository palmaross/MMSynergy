using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SynManager;
using Mindjet.MindManager.Interop;
using System.IO;

namespace Maps
{
    internal partial class SynergyExplorerDlg : Form
    {
        public SynergyExplorerDlg()
        {
            InitializeComponent();

            helpProvider1.HelpNamespace = MMUtils.instPath + "\\MultiMaps.chm";
            helpProvider1.SetHelpNavigator(this, HelpNavigator.Topic);
            helpProvider1.SetHelpKeyword(this, "find_map.htm");

            Text = MMUtils.GetString("synergyexplorer.dlg.title");
            btnNewPlace.Text = MMUtils.GetString("synergyexplorer.btnNewPlace.caption");
            toolTip1.SetToolTip(btnNewPlace, MMUtils.GetString("synergyexplorer.btnNewPlace.tooltip"));

            treeView1.Sort();
        }

        string m_selectedFolderMaps = "";

        public void Init()
        {
            PlacesDB _db = new PlacesDB();           
            string _placename = "";
            string _pathtoplace = "";
            TreeNode _placeNode, _accountNode;
            string _path = "";
            string _owner = "";
            string _email = "";
            treeView1.Nodes.Clear();

            DataTable _dt = _db.ExecuteQuery("select * from PLACES order by PLACENAME");
            if (_dt.Rows.Count == 0)
            {
                _db.Dispose();
                btnAddFiles.Enabled = false;
                btnCopyFolder.Enabled = false;
                btnShareFolder.Enabled = false;
                return;
            }
            else
            {
                btnAddFiles.Enabled = true;
                btnCopyFolder.Enabled = true;
                btnShareFolder.Enabled = true;
            }

            SharedItemsDB _db1 = new SharedItemsDB();
            foreach (DataRow _row in _dt.Rows)
            {
                _placename = _row["PLACENAME"].ToString();
                _pathtoplace = _row["PLACEPATH"].ToString();

                // No access to Place
                if (!Directory.Exists(_pathtoplace))
                {
                    // TODO сообщить пользователю...
                    // TODO с сайтами другая проверка!
                    continue;
                }

                // Add Place to treeview.
                _placeNode = new TreeNode();
                _placeNode.NodeFont = new Font("Arial", 9, FontStyle.Bold);
                _placeNode.Text = _placename;
                treeView1.Nodes.Add(_placeNode);

                // Add current user account to treeview
                _accountNode = new TreeNode();
                _owner = SUtils.currentUserName;
                _email = SUtils.currentUserEmail;
                _path = _pathtoplace + _owner;
                TreeViewItem _tag = new TreeViewItem(_owner, _owner, _email, _path);
                _accountNode.Tag = _tag;
                _accountNode.NodeFont = new Font("Arial", 9, FontStyle.Bold);
                _accountNode.Text = _owner;
                _placeNode.Nodes.Add(_accountNode);
                FillFoldersRecursive(_accountNode, _path, _owner, _email);

                // Fill rest accounts
                DataTable _dt1 = _db1.ExecuteQuery("select * from SHARED where PLACE=`" + _placename + "` order by OWNER");
                foreach (DataRow _row1 in _dt1.Rows)
                {
                    _accountNode = null;
                    _path = _row1["PATH"].ToString();
                    _email = _row1["EMAIL"].ToString();
                    _owner = _row1["OWNER"].ToString();

                    foreach (TreeNode _node in _placeNode.Nodes)
                    {
                        TreeViewItem _tag1 = _node.Tag as TreeViewItem;
                        if (_tag1.m_email == _email)
                            _accountNode = _node;
                    }
                    if (_accountNode == null)
                        _accountNode = new TreeNode();

                    try // Fill account node    
                    {                                                   
                        TreeViewItem _tag2 = new TreeViewItem(_owner, _owner, _email, _path);
                        _accountNode.Tag = _tag2;
                        _accountNode.NodeFont = new Font("Arial", 9, FontStyle.Bold);
                        _accountNode.Text = _owner;
                        _placeNode.Nodes.Add(_accountNode);
                        FillFoldersRecursive(_accountNode, _path, _owner, _email);
                    }
                    catch (Exception _e)
                    {
#if DEBUG
                        MessageBox.Show("Exception: " + _e.Message + "\r\nSource: " + _e.Source + "\r\nStack: " + _e.StackTrace);
#endif
                    }
                }
                _placeNode.Expand();
            }
            _db.Dispose();
            _db1.Dispose();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            m_selectedFolderMaps = "";
            TreeViewItem _tag = treeView1.SelectedNode.Tag as TreeViewItem;
            if (_tag != null)
                m_selectedFolderMaps = _tag.m_path;
        }

        /// <summary>
        /// Fill folder subtree
        /// </summary>
        /// <param name="pNode">Root node</param>
        /// <param name="aPath">Stored full path to root node</param>
        public void FillFoldersRecursive(TreeNode pNode, string aPath, string aOwner, string aEmail)
        {
            DirectoryInfo _thisDir = new DirectoryInfo(aPath);
            //SortedList<string, DirectoryInfo> _dirs = new SortedList<string, DirectoryInfo>();
            IEnumerable<DirectoryInfo> _dirinfos;
            try
            {
                _dirinfos = _thisDir.EnumerateDirectories();
            }
            catch (Exception _e)
            {
#if DEBUG
                MessageBox.Show("Exception: " + _e.Message + "\r\nSource: " + _e.Source + "\r\nStack: " + _e.StackTrace);
#endif
                return;
            }

            //foreach (DirectoryInfo _dir in _dirinfos)
            //    _dirs.Add(_dir.Name, _dir);

            //foreach (string _name in _dirs.Keys)
            foreach (DirectoryInfo _dir in _dirinfos)
            {
                TreeNode _newNode = new TreeNode(_dir.Name);
                _newNode.NodeFont = new Font("Arial", 9, FontStyle.Regular);
                TreeViewItem _tag = new TreeViewItem(_dir.Name, aOwner, aEmail, _dir.FullName);
                _newNode.Tag = _tag;
                pNode.Nodes.Add(_newNode);
                FillFoldersRecursive(_newNode, _dir.FullName, aOwner, aEmail);
            }
        }

        private void pictSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Visible = true;
        }

        private void btnNewPlace_Click(object sender, EventArgs e)
        {
            string placename, _pathtoplace;
            using (Places.NewPlaceDlg _dlg = new Places.NewPlaceDlg())
            {
                if (_dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd)) == DialogResult.Cancel)
                    return;
                placename = _dlg.aPlaceName;
                _pathtoplace = _dlg.aPlacePath;
                MessageBox.Show(MMUtils.GetString("places.placecreated.message"));              
            }
            TreeNode _placeNode = treeView1.Nodes.Add(placename);

            // Add current user account to place node
            string _owner = SUtils.currentUserName;
            string _email = SUtils.currentUserEmail;
            TreeNode _accountNode = new TreeNode();
            TreeViewItem _tag = new TreeViewItem(_owner, _owner, _email, _pathtoplace + _owner);
            _accountNode.Tag = _tag;
            _accountNode.NodeFont = new Font("Arial", 9, FontStyle.Bold);
            _accountNode.Text = _owner;
            _placeNode.Nodes.Add(_accountNode);
            FillFoldersRecursive(_accountNode, _pathtoplace + _owner, _owner, _email);

            btnAddFiles.Enabled = true;
            btnCopyFolder.Enabled = true;
            btnShareFolder.Enabled = true;
        }

        private void Dlg_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panelPublish.Visible = false;
        }
    }

    internal class TreeViewItem
    {
        public string m_name = "";
        public bool m_isDirectory = false;
        public string m_path = "";
        public string m_owner = "";
        public string m_email = "";

        public TreeViewItem(string aName, string aOwner, string aEmail, string aPath, bool aIsDirectory = true)
        {
            m_name = aName;
            m_isDirectory = aIsDirectory;
            m_path = aPath;
            m_owner = aOwner;
            m_email = aEmail;
        }

        public override string ToString() => m_name;
    }
}
