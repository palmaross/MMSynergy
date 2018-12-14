using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SynManager;

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
            lblNewStorageName.Text = MMUtils.GetString("newcloudstoragedlg.lblNewStorageName.text");
            lblNameExists.ForeColor = System.Drawing.Color.Red;
            lblNameExists.Text = "";
            lblPath.Text = MMUtils.GetString("newcloudstoragedlg.lblPath.text");
            lblPlaceTaken.Text = "";
            lblProcess.Text = MMUtils.GetString("newcloudstoragedlg.lblProcess.text");
            btnCancel.Text = MMUtils.GetString("buttonCancel.text");
            btnNext.Text = MMUtils.GetString("buttonNext.text");
            btnBack.Text = MMUtils.GetString("buttonBack.text");

            toolTip1.SetToolTip(helpProcess, MMUtils.GetString("newcloudstoragedlg.tltHelpProcess.text"));
            toolTip1.SetToolTip(helpPath, MMUtils.GetString("newcloudstoragedlg.tltHelpPath.text"));

            System.Diagnostics.Process[] processes;
            processes = System.Diagnostics.Process.GetProcesses();

            comboBoxProcesses.Items.Add(MMUtils.GetString("newcloudstoragedlg.processignore.text"));
            foreach (System.Diagnostics.Process instance in processes)
            {
                comboBoxProcesses.Items.Add(instance.ProcessName);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
           // Storage name is empty
            if (txtPlaceName.Text == "")
            {
                lblNewStorageName.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (txtFolderPath.Text == "")
            {
                lblPath.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string aProcess = comboBoxProcesses.Text;
            string aPlaceName = txtPlaceName.Text;

            if (aProcess.Length > 4 && aProcess.Substring(aProcess.Length - 4) == ".exe")
                aProcess = aProcess.Substring(0, aProcess.Length - 4);

            // If Storage with this name exists
            using (PlacesDB _db = new PlacesDB())
            {
                DataTable _dt = _db.ExecuteQuery("select * from PLACES"); // where PLACENAME=`" + aPlaceName + "`");
                if (_dt.Rows.Count > 0)
                {
                    foreach (DataRow _row in _dt.Rows)
                    {
                        if (_row["PLACENAME"].ToString() == txtPlaceName.Text)
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

        private void txtNewStorageName_Click(object sender, EventArgs e)
        {
            lblNewStorageName.ForeColor = System.Drawing.Color.Black;
            lblNameExists.Text = "";
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
