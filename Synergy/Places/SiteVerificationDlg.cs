using System;
using System.Windows.Forms;
using SynManager;

namespace Places
{
    internal partial class SiteVerificationDlg : Form
    {
        public SiteVerificationDlg(string _site)
        {
            InitializeComponent();

            aHelpProvider.HelpNamespace = MMUtils.instPath + "\\Synergy.chm";
            aHelpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
            aHelpProvider.SetHelpKeyword(this, "publishmap.htm"); // TODO

            Text = MMUtils.GetString("siteverificationdlg.dlgtitle");
            btnCancel.Text = MMUtils.GetString("buttonCancel.text");
            btnOK.Text = MMUtils.GetString("siteverificationdlg.btnOK.text");
            btnVerify.Text = MMUtils.GetString("siteverificationdlg.btnVerify.text");

            lblMessage.Text = String.Format(MMUtils.GetString("siteverificationdlg.lblNewStorageName.text"),
                btnVerify.Text, btnOK.Text);

            aSite = _site;
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(aSite);
        }

        private string aSite = "";
    }
}
