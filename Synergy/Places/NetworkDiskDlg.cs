using System;
using System.Data;
using System.Windows.Forms;
using SynManager;

namespace Places
{
    internal partial class NetworkDiskDlg : Form
    {
        public NetworkDiskDlg()
        {
            InitializeComponent();

            aHelpProvider.HelpNamespace = MMUtils.instPath + "\\Synergy.chm";
            aHelpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
            aHelpProvider.SetHelpKeyword(this, "publishmap.htm"); // TODO

            Text = MMUtils.GetString("networkdiskdlg.dlgtitle");
            lblPlace.Text = MMUtils.GetString("networkdiskdlg.lblNetworkDisk.text");
            lblPlaceNameExists.Text = "";
            btnCancel.Text = MMUtils.GetString("buttonCancel.text");
            btnNext.Text = MMUtils.GetString("buttonNext.text");
            btnBack.Text = MMUtils.GetString("buttonBack.text");         
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
                        lblPlaceNameExists.Text = MMUtils.GetString("newcloudstoragedlg.lblNameExists.text");
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

        public string aPlaceName = "";
        public string aStorage = "";

    }
}
