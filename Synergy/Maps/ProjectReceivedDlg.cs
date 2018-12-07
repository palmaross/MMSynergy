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
    partial class ProjectReceivedDlg : Form
    {
        public ProjectReceivedDlg()
        {
            InitializeComponent();

            aHelpProvider.HelpNamespace = MMUtils.instPath + "\\Synergy.chm";
            aHelpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
            aHelpProvider.SetHelpKeyword(this, "publishmap.htm"); // TODO

            Text = MMUtils.GetString("receivedprojectdlg.dlgtitle.text");
            lblProject.Text = MMUtils.GetString("receivedprojectdlg.lblPlace.text");
            lblOr.Text = MMUtils.GetString("publishmapdlg.lblOr.text");
            linkNewPlace.Text = MMUtils.GetString("receivedmapdlg.linkNewPlace.text");
            btnCancel.Text = MMUtils.GetString("buttonCancel.text");
        }
    }
}
