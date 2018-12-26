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
            lblPlaceExists.Text = "";
            txtNetworkDiskName.Text = MMUtils.GetString("networkdiskdlg.NetworkDiskName.text");
            lblPath.Text = MMUtils.GetString("newcloudstoragedlg.lblPath.text");
            lblPlaceTaken.Text = "";
            btnCancel.Text = MMUtils.GetString("buttonCancel.text");
            btnNext.Text = MMUtils.GetString("buttonNext.text");
            btnBack.Text = MMUtils.GetString("buttonBack.text");

            toolTip1.SetToolTip(helpPath, MMUtils.GetString("networkdiskdlg.helpPath.tooltip"));
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            aPlaceName = txtNetworkDiskName.Text;

            // Place name is empty
            if (aPlaceName == "")
            {
                lblPlace.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (txtFolderPath.Text == "")
            {
                lblPath.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // If Place with this name exists
            using (PlacesDB _db = new PlacesDB())
            {
                DataTable _dt = _db.ExecuteQuery("select * from PLACES"); // where PLACENAME=`" + aPlaceName + "`");
                if (_dt.Rows.Count > 0)
                {
                    foreach (DataRow _row in _dt.Rows)
                    {
                        if (_row["PLACENAME"].ToString() == aPlaceName)
                        {
                            lblPlaceExists.Text = MMUtils.GetString("newcloudstoragedlg.lblNameExists.text");
                            return;
                        }
                        if (_row["PLACEPATH"].ToString() == txtFolderPath.Text)
                        {
                            lblPlaceTaken.Text = MMUtils.GetString("newcloudstoragedlg.lblPlaceTaken.text");
                            return;
                        }
                        if (!System.IO.Directory.Exists(_row["PLACEPATH"].ToString()))
                        {
                            lblPlaceTaken.Text = MMUtils.GetString("newcloudstoragedlg.directorynotexists.text");
                            return;
                        }
                    }
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void txtNetworkDiskName_Click(object sender, EventArgs e)
        {
            lblPlace.ForeColor = System.Drawing.Color.Black;
            lblPlaceExists.Text = "";
        }

        public string aPlaceName = "";
        public string aStorage = "";

        /// <summary>
        /// Folder path with trail backslash
        /// </summary>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            txtFolderPath.Text = MMUtils.GetFolderPath();
        }
    }
}
