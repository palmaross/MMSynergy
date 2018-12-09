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
            lblProcess.Text = MMUtils.GetString("newcloudstoragedlg.lblProcess.text");
            lblSiteUrl.Text = MMUtils.GetString("newcloudstoragedlg.lblSiteUrl.text");
            btnCancel.Text = MMUtils.GetString("buttonCancel.text");
            btnNext.Text = MMUtils.GetString("buttonNext.text");
            btnBack.Text = MMUtils.GetString("buttonBack.text");

            tltHelpProcess.SetToolTip(helpProcess, MMUtils.GetString("newcloudstoragedlg.tltHelpProcess.text"));
            tltHelpSite.SetToolTip(helpSite, MMUtils.GetString("newcloudstoragedlg.tltHelpSite.text"));
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
           // Storage name is empty
            if (txtNewStorageName.Text == "")
            {
                lblNewStorageName.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Process field is empty
            if (txtProcess.Text == "")
            {
                lblProcess.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Site url is empty
            if (txtSiteUrl.Text == "")
            {
                lblSiteUrl.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string aProcess = txtProcess.Text;
            string aStorageName = txtNewStorageName.Text;

            if (aProcess.Length > 4 && aProcess.Substring(aProcess.Length - 4) == ".exe")
                aProcess = aProcess.Substring(0, aProcess.Length - 4);

            // If Storage with this name exists
            using (StoragesDB _db = new StoragesDB())
            {
                DataTable _dt = _db.ExecuteQuery("select * from STORAGES where STORAGENAME=`" + aStorageName + "`");
                if (_dt.Rows.Count != 0)
                {
                    lblNameExists.Text = MMUtils.GetString("newcloudstoragedlg.lblNameExists.text");
                    return;
                }               
            }

            // Storage App verification failed
            if (!System.Diagnostics.Process.GetProcessesByName(aProcess).Any())
            {
                MessageBox.Show(
                    String.Format(MMUtils.GetString("newcloudstoragedlg.messagebox.text"), aStorageName),
                    MMUtils.GetString("newcloudstoragedlg.messagebox.caption"),
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Verify website 
            using (SiteVerificationDlg _dlg = new SiteVerificationDlg(txtSiteUrl.Text))
            {
                if (_dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd)) == DialogResult.Cancel)
                    return;
            }

            using (StoragesDB _db = new StoragesDB())
            {
                string _type = "cloud";
                _db.ExecuteNonQuery("INSERT INTO STORAGES VALUES(" +
                        "`" + aStorageName + "`," +
                        "`" + aProcess + "`," +
                        "`" + txtSiteUrl.Text + "`," +
                        "`" + _type + "`, ``, ``, 0, 0)");
            }

            this.DialogResult = DialogResult.OK;
        }

        private void txtNewStorageName_Click(object sender, EventArgs e)
        {
            lblNewStorageName.ForeColor = System.Drawing.Color.Black;
            lblNameExists.Text = "";
        }

        private void txtProcess_Click(object sender, EventArgs e)
        {
            lblProcess.ForeColor = System.Drawing.Color.Black;
        }

        private void txtSiteUrl_Click(object sender, EventArgs e)
        {
            lblSiteUrl.ForeColor = System.Drawing.Color.Black;
        }
    }
}
