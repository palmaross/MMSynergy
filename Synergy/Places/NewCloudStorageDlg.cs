using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SynManager;
using System.Collections.Generic;

namespace Places
{
    internal partial class NewCloudStorageDlg : Form
    {
        public NewCloudStorageDlg()
        {
            InitializeComponent();

            aHelpProvider.HelpNamespace = MMUtils.instPath + "\\Synergy.chm";
            aHelpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
            aHelpProvider.SetHelpKeyword(this, "publishmap.htm"); // TODO

            Text = MMUtils.GetString("newcloudstoragedlg.dlgtitle");
            lblStorageName.Text = MMUtils.GetString("newcloudstoragedlg.lblStorageName.text");
            lblPlaceName.Text = MMUtils.GetString("newcloudstoragedlg.lblPlaceName.text");
            lblNameExists.ForeColor = System.Drawing.Color.Red;
            lblNameExists.Text = "";
            lblPath.Text = MMUtils.GetString("newcloudstoragedlg.lblPath.text");
            lblPlaceTaken.Text = "";
            lblProcess.Text = MMUtils.GetString("newcloudstoragedlg.lblProcess.text");
            btnCancel.Text = MMUtils.GetString("buttonCancel.text");
            btnNext.Text = MMUtils.GetString("buttonNext.text");
            btnBack.Text = MMUtils.GetString("buttonBack.text");

            toolTip1.SetToolTip(helpStorage, MMUtils.GetString("newcloudstoragedlg.helpStorage.tooltip"));
            toolTip1.SetToolTip(helpPlaceName, MMUtils.GetString("newcloudstoragedlg.helpPlaceName.tooltip"));
            toolTip1.SetToolTip(helpProcess, MMUtils.GetString("newcloudstoragedlg.helpProcess.tooltip"));
            toolTip1.SetToolTip(helpPath, MMUtils.GetString("newcloudstoragedlg.helpPath.tooltip"));

            System.Diagnostics.Process[] processes;
            processes = System.Diagnostics.Process.GetProcesses();

            List<string> Processes = new List<string>();

            foreach (System.Diagnostics.Process instance in processes)
                if (!Processes.Contains(instance.ProcessName))
                    Processes.Add(instance.ProcessName);

            Processes.Sort();
            Processes.Insert(0, MMUtils.GetString("newcloudstoragedlg.processignore.text"));

            foreach (string process in Processes)
                comboBoxProcesses.Items.Add(process);

            //comboBoxProcesses.DataSource = Processes;
            comboBoxProcesses.SelectedIndex = 0;
            Processes.Clear();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            // Place name is empty
            if (txtPlaceName.Text == "")
            {
                lblPlaceName.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (txtFolderPath.Text == "")
            {
                lblPath.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (txtStorageName.Text == "")
            {
                lblStorageName.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string aProcess = comboBoxProcesses.Text;
            string aPlaceName = txtPlaceName.Text;

            if (aProcess.Length > 4 && aProcess.Substring(aProcess.Length - 4) == ".exe")
                aProcess = aProcess.Substring(0, aProcess.Length - 4);

            // If Place with this name exists
            using (PlacesDB _db = new PlacesDB())
            {
                DataTable _dt = _db.ExecuteQuery("select * from PLACES"); // where PLACENAME=`" + aPlaceName + "`");
                if (_dt.Rows.Count > 0)
                {
                    foreach (DataRow _row in _dt.Rows)
                    {
                        if (_row["PLACENAME"].ToString() == aPlaceName)
                        {
                            lblNameExists.Text = MMUtils.GetString("newcloudstoragedlg.lblNameExists.text");
                            return;
                        }
                        if (_row["PLACEPATH"].ToString() == txtFolderPath.Text)
                        {
                            lblPlaceTaken.Text = MMUtils.GetString("newcloudstoragedlg.lblPlaceTaken.text");
                            return;
                        }
                        if (!System.IO.Directory.Exists(_row["PLACEPATH"].ToString()))
                        {
                            lblPlaceTaken.Text = MMUtils.GetString("newcloudstoragedlg.directorynotexists.text");
                            return;
                        }
                    }                   
                }
            }

            // Storage App verification failed
            if (aProcess == MMUtils.GetString("newcloudstoragedlg.processignore.text"))
            {
                MessageBox.Show(MMUtils.GetString("newcloudstoragedlg.messagebox.text"),
                    MMUtils.GetString("newcloudstoragedlg.messagebox.caption"),
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                aProcess = "";
            }

            this.DialogResult = DialogResult.OK;
        }

        private void txtPlaceName_Click(object sender, EventArgs e)
        {
            lblPlaceName.ForeColor = System.Drawing.Color.Black;
            lblNameExists.Text = "";
        }

        private void txtStorageName_Click(object sender, EventArgs e)
        {
            lblStorageName.ForeColor = System.Drawing.Color.Black;
        }

        /// <summary>
        /// Folder path with backslash
        /// </summary>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            txtFolderPath.Text = MMUtils.GetFolderPath();
        }
    }
}
