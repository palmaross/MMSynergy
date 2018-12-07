using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynManager;

namespace Maps
{
    partial class MapExistsDlg : Form
    {
        public MapExistsDlg(string _mapname, string _project = "")
        {
            InitializeComponent();

            aHelpProvider.HelpNamespace = MMUtils.instPath + "\\Synergy.chm";
            aHelpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
            aHelpProvider.SetHelpKeyword(this, "publishmap.htm"); // TODO

            Text = MMUtils.GetString("mapexistsdlg.dlgtitle.text");
            btnCancel.Text = MMUtils.GetString("buttonCancel.text");

            aMapName = _mapname;
            if (_project == "project")
                _project = MMUtils.GetString("mapexistsdlg.project.text");
            else
                _project = MMUtils.GetString("mapexistsdlg.place.text");

            lblMapExists.Text = String.Format(MMUtils.GetString("mapexistsdlg.lblMapExists.text"), _mapname, _project);
        }

        private void btnOK_Click(object sender, EventArgs e)//
        {
            if (txtMapName.Text == "" || txtMapName.Text == aMapName)
            {
                lblMapExists.ForeColor = System.Drawing.Color.Red;
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        void txtMapName_Click(object sender, EventArgs e)
        {
            lblMapExists.ForeColor = System.Drawing.Color.Black;
        }

        public string aMapName;
    }
}
