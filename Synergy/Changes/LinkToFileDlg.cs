using System;
using System.Windows.Forms;
using SynManager;

namespace Synergy18
{
    internal partial class LinkToFileDlg : Form
    {
        public LinkToFileDlg(string filepath)
        {
            InitializeComponent();

            aHelpProvider.HelpNamespace = MMUtils.instPath + "\\Synergy.chm";
            aHelpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
            aHelpProvider.SetHelpKeyword(this, "publishmap.htm"); // TODO

            // TODO
            Text = MMUtils.GetString("linktofiledlg.dlgtitle.text");
            lblLink.Text = String.Format(MMUtils.GetString("linktofiledlg.lblLink.text"), filepath);
        }

        private void btnYes_Click(object sender, EventArgs e)
        {

        }

        private void btnNo_Click(object sender, EventArgs e)
        {

        }
    }
}
