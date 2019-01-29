using System;
using System.Windows.Forms;
using SynManager;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace Places
{
    internal partial class NewPlaceDlg : Form
    {
        public NewPlaceDlg()
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
                string aStorage, aProcess;
                using (NewCloudStorageDlg _dlg = new NewCloudStorageDlg())
                {
                    result = _dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd));
                    aPlaceName = _dlg.txtPlaceName.Text;
                    aPlacePath = _dlg.txtFolderPath.Text;
                    aProcess = _dlg.comboBoxProcesses.Text;
                    aStorage = _dlg.txtStorageName.Text;
                }

                if (result == DialogResult.Cancel)
                    DialogResult = DialogResult.Cancel;

                if (result == DialogResult.OK) // button Next pressed
                {
                    if (AddNewPlace(aStorage, aProcess))
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
                    aPlacePath = _dlg.txtFolderPath.Text;
                }
                if (result == DialogResult.Cancel)
                    DialogResult = DialogResult.Cancel;

                if (result == DialogResult.OK)
                {
                    if (AddNewPlace("ND"))
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

        private bool AddNewPlace(string storage = "", string process = "", string site = "")
        {
            if (storage == "site")
            {
                // TODO 
            }

            // Create folder with current user structure in the Place
            string _placePath = aPlacePath + SUtils.currentUserName + "\\";
            Directory.CreateDirectory(_placePath);
            try
            {
                using (StreamWriter sw = File.CreateText(_placePath + "\\folder.users"))
                    sw.WriteLine(SUtils.currentUserName);
            }
            catch
            {
                // TODO 
            }

            using (PlacesDB _db = new PlacesDB())
            {
                _db.ExecuteNonQuery("INSERT INTO PLACES VALUES(" +
                    "`" + aPlaceName + "`," +
                    "`" + storage + "`," +
                    "`" + aPlacePath + "`," +
                    "`" + process + "`," +
                    "`" + site + "`, ``, ``, 0, 0)");
            }

            if (storage != "synergysite" && storage != "usersite") // cloud or network disk
                MessageBox.Show(MMUtils.GetString("newplacedlg.cloudstorage.message"), MMUtils.GetString("newplacedlg.cloudstorage.caption"));

            return true;
        }

        public string aPlaceName = "";
        public string aPlacePath = "";
    }

    public static class EncryptionHelper
    {
        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "abc123";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "abc123";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}
