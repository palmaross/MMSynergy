using System;
using System.Windows.Forms;
using SynManager;

namespace Places
{
    internal partial class NewPlaceDlg : Form
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

            ////////// Cloud Storage ///////////
            if (rbtnCloudStorage.Checked)
            {
                using (NewCloudStorageDlg _dlg = new NewCloudStorageDlg())
                {
                    result = _dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd));
                    aPlaceName = _dlg.txtPlaceName.Text;
                    aPlacePath = _dlg.txtFolderPath.Text;
                    aProcess = _dlg.comboBoxProcesses.Text;
                }

                if (result == DialogResult.Cancel)
                    DialogResult = DialogResult.Cancel;

                if (result == DialogResult.OK) // button Next pressed
                {
                    if (AddNewPlace("cloud", aPlacePath, aProcess))
                        DialogResult = DialogResult.OK;
                    else
                        DialogResult = DialogResult.Cancel;
                }
            }

            ////////// Network Disk ///////////
            if (rbtnNetworkDisk.Checked)
            {
                using (NetworkDiskDlg _dlg = new NetworkDiskDlg())
                {
                    result = _dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd));
                    aPlaceName = _dlg.aPlaceName;
                    aPlacePath = _dlg.txtFolderPath.ToString();
                }
                if (result == DialogResult.Cancel)
                    DialogResult = DialogResult.Cancel;

                if (result == DialogResult.OK)
                {
                    if (AddNewPlace("ND", aPlacePath))
                        DialogResult = DialogResult.OK;
                    else
                        DialogResult = DialogResult.Cancel;
                }
            }

            ////////// Website ///////////
            if (rbtnWebSite.Checked)
            {
                // TODO 
            }
        }

        private bool AddNewPlace(string placetype, string placepath, string process = "", string site = "")
        {
            if (placetype == "site")
            {
                // TODO 
            }

            // Create folder in Local Storage with place name
            try
            {
                System.IO.Directory.CreateDirectory(MMUtils.m_SynergyLocalPath + aPlaceName + "\\Maps");
                System.IO.Directory.CreateDirectory(MMUtils.m_SynergyLocalPath + aPlaceName + "\\Projects");
            }
            catch
            {
                // TODO 
            }

            using (PlacesDB _db = new PlacesDB())
                _db.AddPlaceToDB(aPlaceName, placetype, placepath, process, site);

            if (placetype == "cloud" || placetype == "ND")
                MessageBox.Show(MMUtils.GetString("newplacedlg.cloudstorage.message"), MMUtils.GetString("newplacedlg.cloudstorage.caption"));

            return true;
        }

        public string aPlaceName = "";
        private string aPlacePath = "";
        private string aProcess = "";
    }
}
