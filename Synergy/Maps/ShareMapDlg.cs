using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynManager;

namespace Maps
{
    public partial class ShareMapDlg : Form
    {
        public ShareMapDlg(string _mapname, string _mapfolderPath)
        {
            InitializeComponent();

            aHelpProvider.HelpNamespace = MMUtils.instPath + "\\Synergy.chm";
            aHelpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
            aHelpProvider.SetHelpKeyword(this, "share.htm");

            Text = MMUtils.GetString("sharemapdlg.dlgtitle.text");
            lblFolderToShare.Text = MMUtils.GetString("sharemapdlg.lblFolderToShare.text");
            lblMessage.Text = MMUtils.GetString("sharemapdlg.lblMessage.text");
            lblPath.Text = _mapfolderPath;
            txtMessage.Text = String.Format(MMUtils.GetString("sharemapdlg.txtMessage.text"), _mapname);
            btnOpenFolder.Text = MMUtils.GetString("sharemapdlg.btnOpenFolder.text");
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(lblPath.Text))
            {
                string argument = "/select, \"" + lblPath.Text + "\"";
                System.Diagnostics.Process.Start("explorer.exe", argument);
            }
        }
    }
}
