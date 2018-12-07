using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynManager;

namespace Login
{
    public partial class LogOutDlg : Form
    {
        public LogOutDlg()
        {
            InitializeComponent();

            Text = MMUtils.GetString("logoutdlg.dlgtitle.text");
            btnExit.Text = MMUtils.GetString("logoutdlg.btnExit.text");
            checkBoxForgetMe.Text = MMUtils.GetString("logoutdlg.checkBoxForgetMe.text");

            tltForgetMe.SetToolTip(this.checkBoxForgetMe, MMUtils.GetString("logoutdlg.checkBoxForgetMe.tooltip"));

            this.Location = new System.Drawing.Point(MMUtils.MindManager.Left + MMUtils.MindManager.Width - 510,
                            MMUtils.MindManager.Top + MMUtils.MindManager.Height - this.Height - 17);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (checkBoxForgetMe.Checked == true)
            {
                MMUtils.SetRegistry("", "RememberMe", "0");
            }
        }
    }
}
