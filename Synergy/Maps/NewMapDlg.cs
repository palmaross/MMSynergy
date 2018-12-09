using System;
using System.Windows.Forms;
using SynManager;

namespace Maps
{
    internal partial class NewMapDlg : Form
    {
        public NewMapDlg()
        {
            InitializeComponent();

            Text = MMUtils.GetString("newmapdlg.dlgtitle");
            lblNotSaved.Text = MMUtils.GetString("newmapdlg.lblNotSaved.text");
            textBox_MapName.Text = MMUtils.MindManager.ActiveDocument.CentralTopic.Text;
            btn_cancel.Text = MMUtils.GetString("buttonCancel.text");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (textBox_MapName.Text != "")
                DialogResult = DialogResult.OK;
        }
    }
}
