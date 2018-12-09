using System;
using System.Data;
using System.Windows.Forms;
using SynManager;

namespace Projects
{
    internal partial class CreateProjectDlg : Form
    {
        public CreateProjectDlg()
        {
            InitializeComponent();

            aHelpProvider.HelpNamespace = MMUtils.instPath + "\\Synergy.chm";
            aHelpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
            aHelpProvider.SetHelpKeyword(this, "publishmap.htm"); // TODO

            Text = MMUtils.GetString("createprojectdlg.title");
            lblPlace.Text = MMUtils.GetString("createprojectdlg.lblPlace.text");
            lblProjectName.Text = MMUtils.GetString("createprojectdlg.lblProjectName.text");
            btnCreate.Text = MMUtils.GetString("createprojectdlg.btnOK.text");
            btnCancel.Text = MMUtils.GetString("buttonCancel.text");
            lblProjectNameError.Text = "";

            using (PlacesDB _db = new PlacesDB())
            {
                DataTable _dt = _db.ExecuteQuery("select * from PLACES");

                if (_dt.Rows.Count != 0)
                    foreach (DataRow _row in _dt.Rows)
                        comboPlaces.Items.Add(_row["PLACENAME"]);
            }

            // No places yet
            if (comboPlaces.Items.Count == 0)
            {
                if (MessageBox.Show(MMUtils.GetString("createprojectdlg.noplaces.text"),
                    MMUtils.GetString("createprojectdlg.noplaces.caption"), 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) 
                    == DialogResult.No)
                {
                    this.DialogResult = DialogResult.Cancel;
                    return;
                }

                using (Places.NewPlaceDlg _dlg = new Places.NewPlaceDlg())
                {
                    if (_dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd)) == DialogResult.Cancel)
                    {
                        this.DialogResult = DialogResult.Cancel;
                        return;
                    }
                    aPlaceName = _dlg.aPlaceName;
                }

                comboPlaces.Items.Add(aPlaceName);
            }

            comboPlaces.Text = comboPlaces.Items[0].ToString();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string aStorage = "";   // name of Storage
            string aProjectPath = "";
            string aPlaceName = comboPlaces.Text;   // name of selected Place
            string aPlacePath = "";
            string aProjectName = txtProjectName.Text; // project to which we have to save the map

            using (ProjectsDB _db = new ProjectsDB())
            {
                DataTable _dt = _db.ExecuteQuery("select * from PROJECTS where PROJECTNAME='" + aProjectName + "' and PLACENAME='" + aPlaceName + "'");
                if (_dt.Rows.Count > 0) // project with this name already exists
                {
                    lblProjectNameError.Text = MMUtils.GetString("createprojectdlg.projectexists.text");                        
                    return;
                }
            }

            // project name not entered
            if (aProjectName == "")
            {
                lblProjectNameError.Text = MMUtils.GetString("createprojectdlg.projectnameempty.text");
                return;
            }

            using (PlacesDB _db = new PlacesDB())
            {
                DataTable _dt = _db.ExecuteQuery("select * from PLACES where PLACENAME='" + aPlaceName + "'");
                aStorage = _dt.Rows[0]["STORAGE"].ToString();
                aPlacePath = _dt.Rows[0]["PLACEPATH"].ToString();
            }

            aProjectPath = aPlacePath + "$$" + aProjectName;
            string _localPath = MMUtils.m_SynergyLocalPath + aPlaceName + "\\" + aProjectName;

            try
            {
                System.IO.Directory.CreateDirectory(_localPath);
                System.IO.Directory.CreateDirectory(aProjectPath); // in the Place
            }
            catch (Exception _e) // TODO cause!!! read-only, etc...
            {
                MessageBox.Show(this, "Error " + _e.Message, "title", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel; // TODO 
            }

            ProjectsDB.AddProjectToDB(aStorage, aPlaceName, aProjectName, aProjectPath, _localPath);

            this.DialogResult = DialogResult.OK;
        }

        private void txtProjectName_Click(object sender, EventArgs e)
        {
                lblProjectNameError.Text = "";
        }

        private string aPlaceName = "";
    }
}
