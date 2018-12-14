using System;
using System.Data;
using System.Windows.Forms;
using SynManager;

namespace Places
{
    internal partial class CloudStorageDlg : Form
    {
        public CloudStorageDlg()
        {
            InitializeComponent();

            aHelpProvider.HelpNamespace = MMUtils.instPath + "\\Synergy.chm";
            aHelpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
            aHelpProvider.SetHelpKeyword(this, "publishmap.htm"); // TODO

            Text = MMUtils.GetString("cloudstoragedlg.dlgtitle");
            lblChooseStorage.Text = MMUtils.GetString("cloudstoragedlg.lblChooseStorage.text");
            btnAddNewStorage.Text = MMUtils.GetString("cloudstoragedlg.btnAddNewStorage.text");
            lblPlaceName.Text = MMUtils.GetString("cloudstoragedlg.lblPlaceName.text");
            lblPlaceNameExists.Text = "";
            btnCancel.Text = MMUtils.GetString("buttonCancel.text");
            btnNext.Text = MMUtils.GetString("buttonNext.text");
            btnBack.Text = MMUtils.GetString("buttonBack.text");         

            tltPlaceName.SetToolTip(help, MMUtils.GetString("cloudstoragedlg.PlaceName.tooltip"));

            using (StoragesDB _db = new StoragesDB())
            {
                DataTable _dt = _db.ExecuteQuery("select * from STORAGES");
                foreach (DataRow _row in _dt.Rows)
                {
                    if (_row["TYPE"].ToString() == "cloud")
                        comboStorageName.Items.Add(_row["STORAGENAME"]);
                }

                comboStorageName.SelectedIndex = 0;
                txtPlaceName.Text = comboStorageName.Text;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            aPlaceName = txtPlaceName.Text;
            aStorage = comboStorageName.Text;

            if (aPlaceName == "")
            {
                lblPlaceName.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Check Place if exists
            using (PlacesDB _db = new PlacesDB())
            {
                DataTable _dt = _db.ExecuteQuery("select * from PLACES where PLACENAME=`" + aPlaceName + "`");
                if (_dt.Rows.Count != 0)
                {
                    lblPlaceNameExists.Text = MMUtils.GetString("cloudstoragedlg.lblPlaceNameExists.text");
                    return;
                }
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnAddNewStorage_Click(object sender, EventArgs e)
        {
            using (NewCloudStorageDlg _dlg = new NewCloudStorageDlg())
            {
                DialogResult result = _dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd));
                aStorage = _dlg.txtPlaceName.Text;

                if (result == DialogResult.Cancel)
                    this.DialogResult = DialogResult.Cancel;
                if (result == DialogResult.Retry)
                    return;
            }
            comboStorageName.Items.Add(aStorage);
            comboStorageName.Text = aStorage;
        }

        private void txtPlaceName_Click(object sender, EventArgs e)
        {
            lblPlaceNameExists.Text = "";
            lblPlaceName.ForeColor = System.Drawing.Color.Black;
        }

        private void comboStorageName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPlaceName.Text = comboStorageName.Text;
        }

        public string aPlaceName = "";
        public string aStorage = "";
    }
}
