using System;
using System.Windows.Forms;
using SynManager;

namespace Maps
{
    internal partial class NewMapDlg : Form
    {
        public NewMapDlg(string aFolderPath, string aMapName = "")
        {
            InitializeComponent();

            Text = MMUtils.GetString("newmapdlg.dlgtitle");
            btn_cancel.Text = MMUtils.GetString("buttonCancel.text");

            if (aMapName.EndsWith(".mmap"))
            {
                textBox_MapName.Text = System.IO.Path.GetFileNameWithoutExtension(MMUtils.MindManager.ActiveDocument.FullName);
                lblNotSaved.Text = MMUtils.GetString("newmapdlg.lblMapExists.text");
            }
            else
            {
                textBox_MapName.Text = MMUtils.MindManager.ActiveDocument.CentralTopic.Text;
                lblNotSaved.Text = MMUtils.GetString("newmapdlg.lblNotSaved.text");
            }

            _folderPath = aFolderPath + "\\";
            _mapName = aMapName;
        }

        string _folderPath = ""; string _mapName = "";
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (textBox_MapName.Text == "")
                return;

            if (System.IO.File.Exists(_folderPath + _mapName))
            {
                lblNotSaved.Text = MMUtils.GetString("newmapdlg.lblMapExists.text");
                MessageBox.Show(MMUtils.GetString("newmapdlg.lblMapExists.text"));
                return;
            }

            DialogResult = DialogResult.OK;
        }
    }
}
