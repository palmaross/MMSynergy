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
            SharedItemsDB _db = new SharedItemsDB();

            TreeNode _placeNode, _accountNode, _folderNode;
            treeView1.Nodes.Clear();

            Dictionary<string, string> Accounts = new Dictionary<string, string>();
            List<string> Places = new List<string>();

            DataTable _dtAccounts = _db.ExecuteQuery("select * from SHARED order by OWNER");
            if (_dtAccounts.Rows.Count == 0)
            {                
                btnAddFiles.Enabled = false; btnCopyFolder.Enabled = false; btnShareFolder.Enabled = false;
                _db.Dispose();
                return;
            }
            else
            {
                btnAddFiles.Enabled = true; btnCopyFolder.Enabled = true; btnShareFolder.Enabled = true;
            }

            foreach (DataRow _row in _dtAccounts.Rows)
            {
                if (!Accounts.ContainsKey(_row["OWNER"].ToString()))
                    Accounts.Add(_row["OWNER"].ToString(), _row["EMAIL"].ToString());
                if (!Places.Contains(_row["PLACE"].ToString()))
                    Places.Add(_row["PLACE"].ToString());
            }

            foreach (string owner in Accounts.Keys)
            {
                // Add Account to treeview.
                _accountNode = new TreeNode();
                string _email = Accounts[owner];
                TreeViewItem _tag = new TreeViewItem(owner, owner, _email, "");
                _accountNode.Tag = _tag;
                _accountNode.NodeFont = new Font("Arial", 9, FontStyle.Bold);
                _accountNode.Text = owner;
                treeView1.Nodes.Add(_accountNode);

                foreach (string place in Places)
                {
                    // Add Place to treeview.
                    _placeNode = new TreeNode();
                    _tag = new TreeViewItem(place, owner, _email, "");
                    _placeNode.Tag = _tag;
                    _placeNode.NodeFont = new Font("Arial", 9, FontStyle.Bold);
                    _placeNode.Text = place;
                    _accountNode.Nodes.Add(_placeNode);

                    DataTable _dt = _db.ExecuteQuery("select * from SHARED where OWNER=`" + owner + "` and PLACE =`" + place + "`");
                    foreach (DataRow _row in _dt.Rows)
                    {
                        string _path = _row["PATH"].ToString();
                        string _folderName = Path.GetFileName(_path);

                        // No access to Place
                        if (!Directory.Exists(_path))
                        {
                            using (PlacesDB _db1 = new PlacesDB())
                            {
                                DataTable _dt1 = _db1.ExecuteQuery("select * from PLACES where PLACENAME=`" + place + "`");
                                string storage = _row["STORAGE"].ToString();
                                string path = _row["PLACEPATH"].ToString();

                                if (storage == "ND") // it's network, check path to Place
                                    if (!Directory.Exists(path)) // network drive is not connected
                                    {
                                        // поставить значок блокировки на нод места

                                        // TODO сообщить пользователю

                                        break;
                                    }
                            }

                            // folder have been deleted, delete entry in SharedItemsDB

                            continue;
                            // TODO сообщить пользователю?
                        }

                        string userspath = _path + "\\users.syn";
                        if (File.Exists(userspath))
                        {
                            string line = "";
                            bool me = false;
                            StreamReader sr = new StreamReader(userspath);
                            while ((line = sr.ReadLine()) != null)
                            {
                                if (line == SUtils.currentUserName)
                                {
                                    me = true;
                                    break;
                                }
                            }
                            sr.Close();

                            if (!me) // This folder is not for me.
                                continue;
                        }

                        // Add shared folder to treeview.
                        try
                        {
                            _folderNode = new TreeNode();
                            _tag = new TreeViewItem(_folderName, owner, _email, _path);
                            _folderNode.Tag = _tag;
                            _folderNode.Text = _folderName;
                            _folderNode.NodeFont = new Font("Arial", 9, FontStyle.Regular);
                            _placeNode.Nodes.Add(_folderNode);
                            // And fill its subfolders.
                            FillFoldersRecursive(_folderNode, _path, owner, _email);
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
            }
            _db.Dispose();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            m_selectedFolderMaps = "";
            if (treeView1.SelectedNode.Tag as TreeViewItem != null)
                m_selectedFolderMaps = (treeView1.SelectedNode.Tag as TreeViewItem).m_path;
        }

        /// <summary>
        /// Fill folder subtree
        /// </summary>
        /// <param name="pNode">Root node</param>
        /// <param name="aPath">Stored full path to root node</param>
        public void FillFoldersRecursive(TreeNode pNode, string aPath, string aOwner, string aEmail)
        {
            DirectoryInfo _thisDir = new DirectoryInfo(aPath);
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
            string _owner = SUtils.currentUserName;
            string _email = SUtils.currentUserEmail;

            using (Places.NewPlaceDlg _dlg = new Places.NewPlaceDlg())
            {
                if (_dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd)) == DialogResult.Cancel)
                    return;
                placename = _dlg.aPlaceName;
                _pathtoplace = _dlg.aPlacePath;
                MessageBox.Show(MMUtils.GetString("places.placecreated.message"));              
            }

            string _placePath = _pathtoplace + SUtils.currentUserName + "\\";
            TreeNode _placeNode = new TreeNode();
            TreeNode _accountNode = null;

            foreach (TreeNode _accountnode in treeView1.Nodes)
                if (_accountnode.Name == _owner)
                    _accountNode = _accountnode;

            if (_accountNode == null)
            {
                _accountNode = new TreeNode();
                TreeViewItem _tag1 = new TreeViewItem(_owner, _owner, _email, _placePath);
                _accountNode.Tag = _tag1;
                _accountNode.NodeFont = new Font("Arial", 9, FontStyle.Bold);
                _accountNode.Text = _owner;
                _accountNode = treeView1.Nodes.Add(_owner);
            }

            TreeViewItem _tag = new TreeViewItem(placename, _owner, _email, "");
            _placeNode.Tag = _tag;
            _placeNode.NodeFont = new Font("Arial", 9, FontStyle.Bold);
            _placeNode.Text = placename;
            _accountNode.Nodes.Add(_placeNode);
            FillFoldersRecursive(_placeNode, _placePath, _owner, _email);

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

        private void btnPublish_Click(object sender, EventArgs e)
        {
            PublishMap.Publish(MMUtils.ActiveDocument, "", ""); // TODO !!
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
