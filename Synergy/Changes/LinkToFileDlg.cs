﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynManager;

namespace Synergy18
{
    public partial class LinkToFileDlg : Form
    {
        public LinkToFileDlg()
        {
            InitializeComponent();

            aHelpProvider.HelpNamespace = MMUtils.instPath + "\\Synergy.chm";
            aHelpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
            aHelpProvider.SetHelpKeyword(this, "publishmap.htm"); // TODO

            // TODO
            Text = MMUtils.GetString("publishmapdlg.dlgtitle.text");
            lblLink.Text = MMUtils.GetString("publishmapdlg.lblPickProject.text");
            btnYes.Text = MMUtils.GetString("publishmapdlg.lblOr.text");
            btnNo.Text = MMUtils.GetString("publishmapdlg.linkNewProject.text");
        }

        private void btnYes_Click(object sender, EventArgs e)
        {

        }

        private void btnNo_Click(object sender, EventArgs e)
        {

        }
    }
}
