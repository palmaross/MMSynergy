using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SynManager;
using Mindjet.MindManager.Interop;
using System.IO;

namespace Maps
{
    public partial class SynergyExplorerDlg : Form
    {
        public SynergyExplorerDlg()
        {
            InitializeComponent();
        }

        string m_maps = "";
        string m_projects = "";

        public void Init(bool bFirstTime)
        {
            // Fill in the content of the listbox
            // Get the content of the Local Storage directory
            treeView1.Nodes.Clear();
            treeView2.Nodes.Clear();
            try
            {
                m_maps = MMUtils.m_SynergyLocalPath + "Maps";
                m_projects = MMUtils.m_SynergyLocalPath + "Projects";

                // Fill local maps content
                TreeNode _rootStock = new TreeNode();
                SSTItem _tag = new SSTItem(MMUtils.GetString("synergyexplorer.maps"), "", true);
                _rootStock.Tag = _tag;
                _rootStock.NodeFont = new Font("Arial", 9, FontStyle.Bold);
                _rootStock.Text = MMUtils.GetString("synergyexplorer.maps");
                treeView1.Nodes.Add(_rootStock);
                FillFoldersRecursive(_rootStock, m_maps);

                // Fill local projects content
                _rootStock = new TreeNode();
                _tag = new SSTItem(MMUtils.GetString("synergyexplorer.projects"), "", true);
                _rootStock.Tag = _tag;
                _rootStock.NodeFont = new Font("Arial", 9, FontStyle.Bold);
                _rootStock.Text = MMUtils.GetString("synergyexplorer.projects");
                treeView2.Nodes.Add(_rootStock);
                FillFoldersRecursive(_rootStock, m_projects);
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
        private void FillFoldersRecursive(TreeNode pNode, String aPath)
        {
            DirectoryInfo _thisDir = new DirectoryInfo(aPath);
            SortedList<String, DirectoryInfo> _dirs = new SortedList<String, DirectoryInfo>();
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

            foreach (String _name in _dirs.Keys)
            {
                TreeNode _newNode = new TreeNode(_name);
                SSTItem _tag = new SSTItem(_name, "", true);
                _newNode.Tag = _tag;
                pNode.Nodes.Add(_newNode);
                FillFoldersRecursive(_newNode, aPath + "\\" + _name + "\\");
            }
        }
    }

    internal class SSTItem
    {
        public String m_comment = "";
        public String m_guid = "";
        public bool m_isDirectory = false;
        public String m_path = "";

        public SSTItem(String aComment = "", String aGuid = "", bool aIsDirectory = false)
        {
            m_comment = aComment;
            m_guid = aGuid;
            m_isDirectory = aIsDirectory;
        }

        public override string ToString() => m_comment;
    }
}
