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
    public partial class NewPlaceDlg : Form
    {
        public NewPlaceDlg(string _storage = "")
        {
            InitializeComponent();

            aHelpProvider.HelpNamespace = MMUtils.instPath + "\\Synergy.chm";
            aHelpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
            aHelpProvider.SetHelpKeyword(this, "synergy_struct.htm");

            Text = MMUtils.GetString("newplacedlg.dlgtitle");
            lblChoosePlace.Text = MMUtils.GetString("newplacedlg.lblChoosePlace.text");
            rbtnCloudStorage.Text = MMUtils.GetString("newplacedlg.rbtnCloudStorage.text");
            rbtnNetworkDisk.Text = MMUtils.GetString("newplacedlg.rbtnNetworkDisk.text");
            rbtnWebSite.Text = MMUtils.GetString("newplacedlg.rbtnWebSite.text");
            btnCancel.Text = MMUtils.GetString("buttonCancel.text");
            btnNext.Text = MMUtils.GetString("buttonNext.text");

            rbtnCloudStorage.Checked = true;
            rbtnWebSite.Enabled = false;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            DialogResult result;
A1:
            ////////// Cloud Storage ///////////
            if (rbtnCloudStorage.Checked)
            {
             
                using (CloudStorageDlg _dlg = new CloudStorageDlg())
                {
                    result = _dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd));
                    aPlaceName = _dlg.aPlaceName;
                    aStorage = _dlg.aStorage;
                }

                if (result == DialogResult.Cancel)
                    this.DialogResult = DialogResult.Cancel;

                if (result == DialogResult.OK) // button Next pressed
                {
                    string _res = AddNewPlace("cloud");

                    if (_res == "back")
                        goto A1;

                    if (_res == "cancel")
                        this.DialogResult = DialogResult.Cancel;
                    else
                        this.DialogResult = DialogResult.OK;
                }
            }

            ////////// Network Disk ///////////
            if (rbtnNetworkDisk.Checked)
            {
                using (NetworkDiskDlg _dlg = new NetworkDiskDlg())
                {
                    result = _dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd));
                    aPlaceName = _dlg.aPlaceName;
                    aStorage = "ND";
                }
                if (result == DialogResult.Cancel)
                    this.DialogResult = DialogResult.Cancel;

                if (result == DialogResult.OK)
                {
                    string _res = AddNewPlace("nd");
                    this.DialogResult = DialogResult.OK;
                }
            }

            if (rbtnWebSite.Checked)
            {
                
            }
        }

        string AddNewPlace(string storagetype)
        {
            using (Maps.GetPathDlg dlg = new Maps.GetPathDlg(aPlaceName, "", "newplace", storagetype))
            {
                DialogResult result = dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd));
                aPlacePath = dlg.aFolder;

                if (result == DialogResult.Cancel)
                    return "cancel";
                if (result == DialogResult.Retry)
                    return "back";             
            }

            aPlacePath = aPlacePath + "Synergy\\";

            try
            {
                System.IO.Directory.CreateDirectory(MMUtils.m_SynergyLocalPath + aPlaceName);
                System.IO.Directory.CreateDirectory(aPlacePath);
            }
            catch (Exception _e) // TODO cause!!! read-only, etc...
            {
                MessageBox.Show(this, "Error " + _e.Message, "title", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel; // TODO 
            }

            using (PlacesDB _db = new PlacesDB())
                _db.ExecuteNonQuery(
                    "INSERT INTO PLACES VALUES(" +
                    "`" + aStorage + "`," +
                    "`" + aPlaceName + "`," +
                    "`" + aPlacePath + "`, ``, ``, 0, 0)");

            if (storagetype == "cloud")
                MessageBox.Show(MMUtils.GetString("newplacedlg.cloudstorage.message"), MMUtils.GetString("newplacedlg.cloudstorage.caption"));

            return "ok";
        }

        public string aPlaceName = "";
        private string aPlacePath = "";
        private string aStorage = "";
    }
}
