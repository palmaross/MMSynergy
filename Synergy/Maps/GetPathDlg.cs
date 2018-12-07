using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynManager;
using System.IO;

namespace Maps
{
    public partial class GetPathDlg : Form
    {
        public GetPathDlg(string storage = "", string _place = "", string cause = "", string type = "")
        {
            InitializeComponent();

            btnCancel.Text = MMUtils.GetString("buttonCancel.text");
            btnBack.Text = MMUtils.GetString("buttonBack.text");

            aCause = cause;
            aPlace = _place;
            string aStorage = storage;

            if (cause == "receivemap")
            {
                btnBack.Enabled = false;
                Text = MMUtils.GetString("getpathdlg.receivemap.dlgtitle");
                lblFolder.Text = String.Format(MMUtils.GetString("getpathdlg.lblFolderReceiveMap.text"), aStorage);
            }

            if (cause == "publish")
            {
                Text = MMUtils.GetString("getpathdlg.publish.dlgtitle");
                lblFolder.Text = String.Format(MMUtils.GetString("getpathdlg.lblFolderForPublish.text"), aStorage);
            }

            if (cause == "newplace")
            {
                if (type == "cloud")
                {
                    Text = MMUtils.GetString("getpathdlg.newplace.dlgtitle");
                    lblFolder.Text = String.Format(MMUtils.GetString("getpathdlg.lblFolderNewPlace.text"), aStorage);
                }
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (txtFolderPath.Text == "")
            {
                lblFolder.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            lblFolder.ForeColor = System.Drawing.Color.Black;

            using (FolderBrowserDialog _fd = new FolderBrowserDialog())
            {
                //_fd.Description = "Описание";
                _fd.ShowNewFolderButton = true;

                if (aCause == "receivemap")
                    _fd.SelectedPath = aPlace;
                else
                    _fd.RootFolder = Environment.SpecialFolder.MyComputer;

                DialogResult result = _fd.ShowDialog();

                if (result == DialogResult.Cancel)
                    return;

                string slash = "\\";
                if (_fd.SelectedPath.Substring(_fd.SelectedPath.Length - 1) == "\\")
                    slash = "";

                txtFolderPath.Text = _fd.SelectedPath + slash;
                aFolder = txtFolderPath.Text;
            }
        }

        public string aFolder = "";
        private string aPlace = "";
        private string aCause = "";
    }
}
