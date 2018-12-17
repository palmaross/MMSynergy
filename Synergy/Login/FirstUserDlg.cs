using System;
using System.Windows.Forms;
using SynManager;

namespace Login
{
    internal partial class FirstUserDlg : Form
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
            lblMessage.Text = MMUtils.GetString("firstuserdlg.lblMessage.text");
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
