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
        }

        string m_maps = "";
        string m_projects = "";
        string m_selectedFolderMaps = "";
        string m_selectedFolderProjects = "";

        public void Init()
        {
            using (PlacesDB _db = new PlacesDB())
            {
                DataTable _dt = _db.ExecuteQuery("select * from PLACES order by PLACENAME");
                foreach (DataRow _row in _dt.Rows)
                    comboPlaces.Items.Add(_row["PLACENAME"]);
            }
            comboPlaces.SelectedIndex = 0;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeViewItem _tag = treeView1.SelectedNode.Tag as TreeViewItem;
            m_selectedFolderMaps = _tag.m_path;
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeViewItem _tag = treeView2.SelectedNode.Tag as TreeViewItem;
            m_selectedFolderProjects = _tag.m_path;
        }

        private void comboPlaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            string _place = comboPlaces.SelectedItem.ToString();
            string _pathtoplace = "";

            using (PlacesDB _db = new PlacesDB())
            {
                DataTable _dt = _db.ExecuteQuery("select * from PLACES where PLACENAME=`" + _place + "`");
                _pathtoplace = _dt.Rows[0]["PLACEPATH"].ToString();
            }

            // Fill in the content of the listboxs
            // Get the content of the Local Storage directory
            treeView1.Nodes.Clear();
            treeView2.Nodes.Clear();
            try
            {
                m_maps = MMUtils.m_SynergyLocalPath + comboPlaces.SelectedItem + "\\Maps";
                m_projects = MMUtils.m_SynergyLocalPath + comboPlaces.SelectedItem + "\\Projects";

                // Fill local maps content
                TreeNode _rootStock = new TreeNode();
                TreeViewItem _tag = new TreeViewItem(MMUtils.GetString("synergyexplorer.maps"), true, m_maps);
                _rootStock.Tag = _tag;
                _rootStock.NodeFont = new Font("Arial", 9, FontStyle.Bold);
                _rootStock.Text = MMUtils.GetString("synergyexplorer.maps");
                treeView1.Nodes.Add(_rootStock);
                FillFoldersRecursive(_rootStock, m_maps);
                treeView1.Nodes[0].Expand();

                // Fill local projects content
                _rootStock = new TreeNode();
                _tag = new TreeViewItem(MMUtils.GetString("synergyexplorer.projects"), true, m_projects);
                _rootStock.Tag = _tag;
                _rootStock.NodeFont = new Font("Arial", 9, FontStyle.Bold);
                _rootStock.Text = MMUtils.GetString("synergyexplorer.projects");
                treeView2.Nodes.Add(_rootStock);
                FillFoldersRecursive(_rootStock, m_projects);
                treeView2.Nodes[0].Expand();
            }
            catch (Exception _e)
            {
#if DEBUG
                MessageBox.Show("Exception: " + _e.Message + "\r\nSource: " + _e.Source + "\r\nStack: " + _e.StackTrace);
#endif
            }
        }

        /// <summary>
        /// Fill folder subtree
        /// </summary>
        /// <param name="pNode">Root node</param>
        /// <param name="aPath">Stored full path to root node</param>
        public void FillFoldersRecursive(TreeNode pNode, string aPath)
        {
            DirectoryInfo _thisDir = new DirectoryInfo(aPath);
            SortedList<string, DirectoryInfo> _dirs = new SortedList<string, DirectoryInfo>();
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
                _dirs.Add(_dir.Name, _dir);

            foreach (string _name in _dirs.Keys)
            {
                TreeNode _newNode = new TreeNode(_name);
                _newNode.NodeFont = new Font("Arial", 9, FontStyle.Regular);
                TreeViewItem _tag = new TreeViewItem(_name, true, aPath + "\\" + _name + "\\");
                _newNode.Tag = _tag;
                pNode.Nodes.Add(_newNode);
                FillFoldersRecursive(_newNode, aPath + "\\" + _name + "\\");
            }
        }

        private void pictSearch_Click(object sender, EventArgs e)
        {
            lblFileName.Visible = true;
            txtSearch.Visible = true;
        }
    }

    internal class TreeViewItem
    {
        public string m_name = "";
        public bool m_isDirectory = false;
        public string m_path = "";

        public TreeViewItem(string aName = "", bool aIsDirectory = false, string aPath = "")
        {
            m_name = aName;
            m_isDirectory = aIsDirectory;
            m_path = aPath;
        }

        public override string ToString() => m_name;
    }
}
