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
    public partial class FirstUserDlg : Form
    {
        public FirstUserDlg()
        {
            InitializeComponent();

            aHelpProvider.HelpNamespace = MMUtils.instPath + "\\Synergy.chm";
            aHelpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
            aHelpProvider.SetHelpKeyword(this, "synergy_struct.htm");

            btnOK.Text      = MMUtils.GetString("firstuserdlg.btnOK.text");
            btnCancel.Text  = MMUtils.GetString("buttonCancel.text");
            lblWelcome.Text = MMUtils.GetString("firstuserdlg.lblWelcome.text");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            using (Places.NewPlaceDlg _dlg = new Places.NewPlaceDlg())
            {
                DialogResult _result = _dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd));
                if (_result == DialogResult.Cancel)
                    this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
