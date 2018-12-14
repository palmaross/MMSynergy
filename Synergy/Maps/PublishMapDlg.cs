using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using SynManager;

namespace Maps
{
    internal partial class PublishMaptDlg : Form
    {
        public PublishMaptDlg(Mindjet.MindManager.Interop.Document _doc)
        {
            InitializeComponent();

            aHelpProvider.HelpNamespace = MMUtils.instPath + "\\Synergy.chm";
            aHelpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
            aHelpProvider.SetHelpKeyword(this, "publishmap.htm");

            Text                = MMUtils.GetString("publishmapdlg.dlgtitle.text");
            lblPickPlace.Text   = MMUtils.GetString("publishmapdlg.lblPickPlace.text");
            chBoxSingleMap.Text = MMUtils.GetString("publishmapdlg.chBoxSingleMap.text");
            lblPickProject.Text = MMUtils.GetString("publishmapdlg.lblPickProject.text");
            btnPublish.Text     = MMUtils.GetString("publishmapdlg.btn_publish.text");
            btnCancel.Text      = MMUtils.GetString("buttonCancel.text");

            using (PlacesDB _db = new PlacesDB())
            {
                DataTable _dt = _db.ExecuteQuery("select * from PLACES order by PLACENAME");
                foreach (DataRow _row in _dt.Rows)
                    comboMyPlaces.Items.Add(_row["PLACENAME"]);
            }

            comboMyPlaces.SelectedIndex = 0;

            GetProjects();

            if (comboMyProjects.Items.Count != 0)
            {
                comboMyProjects.Text = comboMyProjects.Items[0].ToString();
                hasProjects = true;
            }
            else
            {
                comboMyProjects.Items.Add(MMUtils.GetString("publishmapdlg.noprojects"));
                comboMyProjects.SelectedIndex = 0;
                comboMyProjects.Enabled = false;
                hasProjects = false;
            }

            publishDoc = _doc;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            string _docName = publishDoc.Name;
            string aPlaceName = comboMyPlaces.Text;
            string aGuid = publishDoc.Guid;
            string aLocalPath = "";
            string aPath = "";        // full path to published map
            string aSite = "";        // website to check for Internet connection
            string aProcess = "";     // cloud app process to check if started
            string _projectName = "";
            string aStorage = "";     // name of cloud app          
            string aProjectPath = "";
            bool singleMap = chBoxSingleMap.Checked;

            if (!singleMap)
                _projectName = comboMyProjects.Text;

            // Single Maps
            if (singleMap)
            {
                using (PlacesDB _db = new PlacesDB())
                {
                    DataTable _dt = _db.ExecuteQuery("select * from PLACES where PLACENAME='" + aPlaceName + "'");
                    aProjectPath = _dt.Rows[0]["PLACEPATH"].ToString();
                    aStorage = _dt.Rows[0]["STORAGE"].ToString();
                    aLocalPath = MMUtils.m_SynergyLocalPath + aPlaceName + "\\";
                }
            }
            // Projects
            else
            {
                using (ProjectsDB _db = new ProjectsDB())
                {
                    DataTable _dt = _db.ExecuteQuery(
                        "select * from PROJECTS where PROJECTNAME='" + _projectName + "' and PLACENAME='" + aPlaceName + "'");
                    aProjectPath = _dt.Rows[0]["PROJECTPATH"].ToString();
                    aStorage = _dt.Rows[0]["STORAGE"].ToString();
                    aLocalPath = MMUtils.m_SynergyLocalPath + aPlaceName + "\\" + _projectName + "\\";
                }
            }

            if (publishDoc.Path == "") // new map not saved yet
            {
                using (NewMapDlg _dlg = new NewMapDlg())
                {
                    if (_dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd)) == DialogResult.Cancel)
                        return;
                    _docName = _dlg.textBox_MapName.Text + ".mmap";
                }
            }

            aLocalPath = aLocalPath + _docName;

            using (StoragesDB _db = new StoragesDB())
            {
                DataTable _dt = _db.ExecuteQuery("select * from STORAGES where STORAGENAME='" + aStorage + "'");
                aProcess = _dt.Rows[0]["PROCESS"].ToString();
                aSite = _dt.Rows[0]["SITE"].ToString();
            }

            // Full path to map in Place
            aPath = Path.Combine(aProjectPath, _docName);

            // TODO предложить выбрать сохранение под другим именем
            if (Directory.Exists(aPath)) // map with this name is stored already in this place
            {
                DialogResult result = MessageBox.Show(
                    MMUtils.GetString("publishmapdlg.mapexists.message"),
                    MMUtils.GetString("publishmapdlg.mapexists.caption"),
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string fail = "";

            string messageSite = MMUtils.GetString("internet.sitefailed.message");
            string messageProcess = MMUtils.GetString("internet.processfailed.message");
            string messagePlace = MMUtils.GetString("internet.placefail.message");
            string endMessage = MMUtils.GetString("internet.failed.endpubmessage");

            while ((fail = Internet.CheckInternetAndProcess(aGuid, aStorage, aProcess, aSite, "", "publish")) != "")
            {
                string _message = "", arg = "";

                if (fail == "processfail")    { _message = messageProcess; arg = aStorage; }
                else if (fail == "placefail") { _message = messagePlace; arg = aPath; }
                else if (fail == "sitefail")  { _message = messageSite; arg = aSite; }

                if (MessageBox.Show(
                    String.Format(_message, arg) + endMessage, 
                    String.Format(MMUtils.GetString("internet.failed.caption"), _docName),
                    MessageBoxButtons.RetryCancel,MessageBoxIcon.Exclamation)
                    == DialogResult.Cancel)
                {
                    this.DialogResult = DialogResult.Cancel;
                    publishDoc = null;
                    return;
                }

                if (fail == "sitefail")
                    System.Diagnostics.Process.Start(arg); // launch website
            }

            try // Save map to Local
            {
                publishDoc.SaveAs(aLocalPath);
            }
            catch (Exception _e) // TODO cause!!! read-only, etc... имя файла уже исключено выше
            {
                MessageBox.Show("Error: " + _e.Message, "PublishMapDlg", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                publishDoc = null;
                return;
            }

            //// Publish Map = set attributes to map, topics, relationships and boundaries and process links ////
            SUtils.singleMap = singleMap;

            Mindjet.MindManager.Interop.Transaction _tr = publishDoc.NewTransaction("");
            _tr.IsUndoable = false;
            _tr.Execute += new Mindjet.MindManager.Interop.ITransactionEvents_ExecuteEventHandler(SUtils.PublishMap);
            _tr.Start();
            ///////////////////////////////////////////////////////////////////////////////////

            publishDoc.Save();

            if (SUtils.links.Count > 0)
            {
                using (LinkedFilesDlg _dlg = new LinkedFilesDlg(SUtils.links, publishDoc))
                {
                    DialogResult result = _dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd));
                    SUtils.links.Clear();
                    if (result == DialogResult.Cancel)
                    {
                        this.DialogResult = DialogResult.Cancel;
                        publishDoc = null;
                        return;
                    }
                }
            }

            aPath = aPath + "\\"; // Map folder
            string mapFile = SUtils.modtime + ".mmap";

            try // save map to Place
            {
                Directory.CreateDirectory(aPath + "share");
                File.Copy(aLocalPath, aPath + mapFile); // copy as file!!!

                StreamWriter sw = new StreamWriter(File.Create(aPath + "info.ini"));
                sw.WriteLine(aStorage); // чтобы если нет Интернета или Процесса, выдать сообщение с именем хранилища 
                sw.WriteLine(_projectName); // чтобы находить карту из Места в локальной папке Synergy
                sw.WriteLine(aGuid);
                sw.WriteLine(aProcess); // чтобы проверить Интернет и Процесс
                sw.WriteLine(aSite);    // чтобы проверить Интернет и Процесс
                sw.Close();
            }
            catch (Exception _e) // TODO cause!!! read-only, etc...
            {
                MessageBox.Show(this, "Error " + _e.Message, "title", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                publishDoc = null;
                return;
            }

            MapsDB.AddMapToDB(
                _projectName, aGuid, _docName,
                aPath, aLocalPath, SUtils.currentUserName, // aPath - map directory in Place, with backslash
                0, Convert.ToInt32(DateTime.UtcNow), Convert.ToInt32(DateTime.UtcNow)
                );

            MapsGroup.m_UpdateOpenMap = true; // update Open Map submenu

            SUtils.ProcessMap(publishDoc);

            // Share map
            using (ShareMapDlg _dlg = new ShareMapDlg(MMUtils.ActiveDocument.Name, aPath))
            {
                _dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd));
            }

            this.DialogResult = DialogResult.OK;
            publishDoc = null;
        }

        private void ComboboxReadonly_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)Keys.None;
        }

        private void LinkNewProject_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (Projects.CreateProjectDlg _dlg = new Projects.CreateProjectDlg())
            {
                DialogResult result = _dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd));
                if (DialogResult == DialogResult.Cancel)
                    return;
                if (!comboMyProjects.Enabled)
                    comboMyProjects.Items.Remove(MMUtils.GetString("publishmapdlg.noprojects"));

                comboMyProjects.Items.Add(_dlg.txtProjectName.Text);
                comboMyProjects.SelectedIndex = comboMyProjects.Items.Count - 1;
                comboMyProjects.Enabled = true;
            }   
        }

        private void ComboMyPlaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboMyPlaces.SelectedIndex == selIndex)
                return;
            selIndex = comboMyPlaces.SelectedIndex;
            GetProjects();
        }

        private void ChBoxSingleMap_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxSingleMap.Checked == true)
                comboMyProjects.Enabled = false;
            else
                if (hasProjects)
                    comboMyProjects.Enabled = true;
                else
                    chBoxSingleMap.Checked = true;
        }

        private void GetProjects()
        {
            using (ProjectsDB _db = new ProjectsDB())
            {
                DataTable _dt = _db.ExecuteQuery("select * from PROJECTS where PLACENAME=`" + comboMyPlaces.Text + "` order by PROJECTNAME");
                if (_dt.Rows.Count != 0)
                {
                    foreach (DataRow _row in _dt.Rows)
                        comboMyProjects.Items.Add(_row["PROJECTNAME"]);

                    comboMyProjects.Enabled = true;
                    chBoxSingleMap.Checked = false;
                }
                else
                {
                    comboMyProjects.Enabled = false;
                    chBoxSingleMap.Checked = true;
                }
            }
        }

        private bool hasProjects = false;
        private int selIndex = 0;

        private Mindjet.MindManager.Interop.Document publishDoc;
    }
}
