using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SynManager;
using System.IO;

namespace Maps
{
    internal partial class MapReceivedDlg : Form
    {
        public MapReceivedDlg()
        {
            InitializeComponent();

            aHelpProvider.HelpNamespace = MMUtils.instPath + "\\Synergy.chm";
            aHelpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
            aHelpProvider.SetHelpKeyword(this, "receive.htm");

            Text = MMUtils.GetString("receivedmapdlg.dlgtitle.text");
            lblPlace.Text = MMUtils.GetString("receivedmapdlg.lblPlace.text");
            linkNewPlace.Text = MMUtils.GetString("receivedmapdlg.linkNewPlace.text");
            lblReceivedFolderPath.Text = MMUtils.GetString("receivedmapdlg.lblReceivedFolderPath.text");
            rbtnPlace.Text = MMUtils.GetString("receivedmapdlg.rbtnPlace.text");
            rbtnProject.Text = MMUtils.GetString("receivedmapdlg.rbtnProject.text");
            btnCancel.Text = MMUtils.GetString("buttonCancel.text");

            using (PlacesDB _db = new PlacesDB())
            {
                DataTable _dt = _db.ExecuteQuery("select * from PLACES");
                foreach (DataRow _row in _dt.Rows)
                    comboPlaces.Items.Add(_row["PLACENAME"]);
                aStorage = _dt.Rows[0]["STORAGE"].ToString();
                aPlacePath = _dt.Rows[0]["PLACEPATH"].ToString();

            }
            comboPlaces.SelectedIndex = 0;

            rbtnPlace.Checked = true;

            string LeaveInPlace = MMUtils.GetString("receivedmapdlg.rbtnLeaveInPlace.text");
            if (aStorage == "OneDrive")
            {
                LeaveInPlace = LeaveInPlace + MMUtils.GetString("receivedmapdlg.LeaveInPlaceRec.text");
                rbtnLeaveInPlace.Checked = true;
            }
            rbtnLeaveInPlace.Text = LeaveInPlace;

            if (comboProjects.Items.Count == 0)
            {
                comboProjects.Items.Add(MMUtils.GetString("receivedmapdlg.noprojects"));
                comboProjects.Enabled = false;
                rbtnProject.Enabled = false;
            }

            comboProjects.SelectedIndex = 0;

            // For FolderBrowser dialog
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(aPlacePath).Parent;
            initfolder = dir.FullName.ToString();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (txtFolderPath.Text == "")
            {
                lblReceivedFolderPath.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string aMapName = new DirectoryInfo(aMapFolderPath).Name;
            string aPlaceName = comboPlaces.Text;

            string mapStorage = "";
            string aGuid = "";
            string aProject = "";
            string aLocalPath = "";

            if (rbtnProject.Checked == true)
                aProject = comboProjects.Text;

            try
            {
                StreamReader sr = new StreamReader(aMapFolderPath + "info.ini");
                mapStorage = sr.ReadLine();
                sr.ReadLine();
                aGuid = sr.ReadLine();
                sr.Close();
            }
            catch 
            {
                MessageBox.Show("Не удается создать файл info.ini. Нет доступа к папке", "Сбой");
                return;
            }

            if (aMapName.IndexOf(".mmap") == -1)
            {
                if (aMapName.IndexOf("$$") == 0) // project folder
                    MessageBox.Show(MMUtils.GetString("receivemapdlg.project.message"), MMUtils.GetString("receivemapdlg.project.caption"));
                else // unknown folder
                    MessageBox.Show(MMUtils.GetString("receivemapdlg.nomap.message"), MMUtils.GetString("receivemapdlg.nomap.caption"));
                return;
            }

            if (!File.Exists(aMapFolderPath + "info.ini"))
            {
                MessageBox.Show(MMUtils.GetString("getplacedlg.nomapinfo.message"), MMUtils.GetString("getplacedlg.nomapinfo.caption"));
                return;
            }

            if (aStorage != mapStorage)
            {
                MessageBox.Show(String.Format(MMUtils.GetString("getplacedlg.storagenomatches.message"), aStorage, mapStorage),
                    MMUtils.GetString("getplacedlg.storagenomatches.caption"));
                return;
            }

            string _latestfile = "";

            try
            {
                _latestfile = Directory.GetFiles(aMapFolderPath, "*.mmap").Last().ToString();
            }
            catch
            {
                MessageBox.Show("Не удается найти файл карты", "Сбой");
                return;
            }

            _latestfile = Path.GetFileName(_latestfile);

            string _placePath = aPlacePath;
            aPlacePath = aPlacePath + aMapName + "\\";

            // TODO проверить, может такая карта есть!!!
            

            if (rbtnPlace.Checked == true)
            {
                aLocalPath = MMUtils.m_SynergyLocalPath + aPlaceName + "\\" + aMapName;

                string _newmapname = CheckMapExists(aLocalPath, aMapName);

                if (_newmapname == "cancel") return;

                if (_newmapname != "")
                {
                    aMapName = _newmapname;
                    aPlacePath = _placePath + aMapName + "\\";
                }

                Directory.Move(aMapFolderPath, aPlacePath);              
            }

            if (rbtnLeaveInPlace.Checked == true)
            {
                aLocalPath = MMUtils.m_SynergyLocalPath + aPlaceName + "\\" + aMapName;

                string _newmapname = CheckMapExists(aLocalPath, aMapName);

                if (_newmapname == "cancel") return;

                if (_newmapname != "")
                {
                    aMapName = _newmapname;

                    DirectoryInfo dir = new DirectoryInfo(aMapFolderPath).Parent;
                    string newplace = dir.FullName + "\\" + aMapName + "\\";
                    Directory.Move(aMapFolderPath, newplace);

                    aMapFolderPath = newplace;
                }
               
                aPlacePath = aMapFolderPath;
            }

            if (rbtnProject.Checked == true)
            {
                aLocalPath = MMUtils.m_SynergyLocalPath + aPlaceName + "\\" + aProject + "\\" + aMapName;
                string _newmapname = CheckMapExists(aLocalPath, aMapName);

                if (_newmapname == "cancel") return;

                if (_newmapname != "")
                {
                    aMapName = _newmapname;
                    aPlacePath = _placePath + aMapName + "\\";
                }

                Directory.Move(aMapFolderPath, aPlacePath + aProject);
            }

            try
            {
                File.Copy(aPlacePath + _latestfile, aLocalPath);
            }
            catch
            {
                MessageBox.Show("Не могу скопировать карту в локаль", "Сбой");
                return;
            }

            string _attrs = SUtils.TimeStamp + ";" + SUtils.currentUserName + ";" + SUtils.currentUserEmail;

            MapsDB.AddMapToDB(aPlaceName, aGuid, aMapName, aPlacePath, "", 0, 0, 0); // TODO 

            MMUtils.MindManager.AllDocuments.Open(aLocalPath);

            this.DialogResult = DialogResult.OK;
        }

        private void LinkNewPlace_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (Places.NewPlaceDlg _dlg = new Places.NewPlaceDlg())
            {
                DialogResult _result = _dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd));
                if (_result == DialogResult.Cancel)
                    this.DialogResult = DialogResult.Cancel;

                comboPlaces.Items.Add(_dlg.aPlaceName);
                comboPlaces.SelectedIndex = 0;
            }
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            lblReceivedFolderPath.ForeColor = System.Drawing.Color.Black;

            using (FolderBrowserDialog _fd = new FolderBrowserDialog())
            {
                //_fd.Description = "Описание";
                _fd.SelectedPath = initfolder;
                _fd.ShowNewFolderButton = false;
                _fd.ShowDialog();

                string slash = "\\";
                if (_fd.SelectedPath.Substring(_fd.SelectedPath.Length - 1) == "\\")
                    slash = "";

                aMapFolderPath = _fd.SelectedPath + slash;
                txtFolderPath.Text = aMapFolderPath;
            }
        }

        private void ComboPlaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (PlacesDB _db = new PlacesDB())
            {
                DataTable _dt = _db.ExecuteQuery("select * from PLACES where PLACENAME='" + comboPlaces.Text + "'");
                aStorage = _dt.Rows[0]["STORAGE"].ToString();
                aPlacePath = _dt.Rows[0]["PLACEPATH"].ToString();
            }

            string LeaveInPlace = MMUtils.GetString("receivedmapdlg.rbtnLeaveInPlace.text");
            if (aStorage == "OneDrive")
            {
                LeaveInPlace = LeaveInPlace + MMUtils.GetString("receivedmapdlg.LeaveInPlaceRec.text");
                rbtnLeaveInPlace.Checked = true;
                HelpRecommend.Visible = true;
            }
            else
            {
                rbtnPlace.Checked = true;
                HelpRecommend.Visible = false;
            }
            rbtnLeaveInPlace.Text = LeaveInPlace;

            // For FolderBrowser dialog
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(aPlacePath).Parent;
            initfolder = dir.FullName.ToString();
        }

        private void TxtFolderPath_Click(object sender, EventArgs e)
        {
            lblReceivedFolderPath.ForeColor = System.Drawing.Color.Black;
        }

        private string CheckMapExists(string _localpath, string _mapname)
        {
            if (File.Exists(_localpath))
            {
                using (MapExistsDlg _dlg = new MapExistsDlg(_mapname))
                {
                    DialogResult result = _dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd));

                    if (result == DialogResult.Cancel)
                    {
                        this.DialogResult = DialogResult.Cancel;
                        return "cancel";
                    }

                    return _dlg.aMapName;
                }
            }

            return "";
        }

        private string aMapFolderPath = "";
        private string initfolder = "";
        private string aStorage = "";
        private string aPlacePath = "";
    }
}
