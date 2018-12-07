using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynManager;

namespace Places
{
    public partial class NetworkDiskDlg : Form
    {
        public NetworkDiskDlg()
        {
            InitializeComponent();

            aHelpProvider.HelpNamespace = MMUtils.instPath + "\\Synergy.chm";
            aHelpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
            aHelpProvider.SetHelpKeyword(this, "publishmap.htm"); // TODO

            Text = MMUtils.GetString("networkdiskdlg.dlgtitle");
            lblChooseND.Text = MMUtils.GetString("networkdiskdlg.lblChooseND.text");
            btnAddNewDisk.Text = MMUtils.GetString("cloudstoragedlg.btnAddNewStorage.text");
            lblPlace.Text = MMUtils.GetString("networkdiskdlg.lblNetworkDisk.text");
            lblPlaceNameExists.Text = "";
            btnCancel.Text = MMUtils.GetString("buttonCancel.text");
            btnNext.Text = MMUtils.GetString("buttonNext.text");
            btnBack.Text = MMUtils.GetString("buttonBack.text");

            using (StoragesDB _db = new StoragesDB())
            {
                DataTable _dt = _db.ExecuteQuery("select * from STORAGES");

                foreach (DataRow _row in _dt.Rows)
                    if (_row["PROCESS"].ToString() != "" && _row["SITE"].ToString() == "")
                        comboDisks.Items.Add(_row["STORAGENAME"]);
            }

            if (comboDisks.Items.Count != 0)
            {
                comboDisks.SelectedIndex = 0;
            }
            else
            {
                using (NewNetworkDiskDlg _dlg = new NewNetworkDiskDlg())
                {
                    DialogResult result = _dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd));
                    aStorage = _dlg.txtDiskName.Text;

                    if (result == DialogResult.Cancel)
                    {
                        this.DialogResult = DialogResult.Cancel;
                        return;
                    }
                    if (result == DialogResult.Retry)
                    {
                        this.DialogResult = DialogResult.Retry;
                        return;
                    }

                    comboDisks.Items.Add(aStorage);
                    comboDisks.Text = aStorage;
                }
            }               
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            aPlaceName = txtNetworkDiskName.Text;

            // If Place with this name exists
            using (PlacesDB _db = new PlacesDB())
            {
                DataTable _dt = _db.ExecuteQuery("select * from PLACES");
                foreach (DataRow _row in _dt.Rows)
                    // Storage name exists
                    if (aPlaceName == _row["PLACENAME"].ToString())
                    {
                        lblPlaceNameExists.Text = MMUtils.GetString("cloudstoragedlg.lblPlaceNameExists.text");
                        return;
                    }
            }

            if (aPlaceName == "")
                lblPlace.ForeColor = System.Drawing.Color.Red;
            else
                this.DialogResult = DialogResult.OK;
        }

        private void txtNetworkDiskName_Click(object sender, EventArgs e)
        {
            lblPlace.ForeColor = System.Drawing.Color.Black;
            lblPlaceNameExists.Text = "";
        }

        private void btnAddNewDisk_Click(object sender, EventArgs e)
        {
            DialogResult result;

            using (NewNetworkDiskDlg _dlg = new NewNetworkDiskDlg())
            {
                result = _dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd));
                aStorage = _dlg.txtDiskName.Text;
            }

            if (result == DialogResult.Cancel)
                this.DialogResult = DialogResult.Cancel;
            if (result == DialogResult.Retry)
                return;

            comboDisks.Items.Add(aStorage);
            comboDisks.Text = aStorage;
        }

        public string aPlaceName = "";
        public string aStorage = "";

    }
}
