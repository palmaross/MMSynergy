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
    public partial class NewNetworkDiskDlg : Form
    {
        public NewNetworkDiskDlg()
        {
            InitializeComponent();

            aHelpProvider.HelpNamespace = MMUtils.instPath + "\\Synergy.chm";
            aHelpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
            aHelpProvider.SetHelpKeyword(this, "publishmap.htm"); // TODO

            Text = MMUtils.GetString("newnetworkdiskdlg.dlgtitle");
            lblDiskName.Text = MMUtils.GetString("newnetworkdiskdlg.lblDiskName.text");
            lblDiskNameExists.Text = "";
            btnCancel.Text = MMUtils.GetString("buttonCancel.text");
            btnNext.Text = MMUtils.GetString("buttonNext.text");
            btnBack.Text = MMUtils.GetString("buttonBack.text");
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (txtDiskName.Text == "")
            {
                lblDiskName.ForeColor = System.Drawing.Color.Red;
                return;
            }

            using (StoragesDB _db = new StoragesDB())
            {
                DataTable _dt = _db.ExecuteQuery("select * from STORAGES where STORAGENAME=`" + txtDiskName.Text + "`");
                if (_dt.Rows.Count != 0)
                {
                    lblDiskNameExists.Text = MMUtils.GetString("newnetworkdiskdlg.lblDiskNameExists.text");
                    return;
                }

                _db.ExecuteNonQuery("insert into STORAGES values(" +
                "`" + txtDiskName.Text + "`," +
                "`" + "networkdisk" + "`," +
                "``, ``, ``, ``, 0, 0)");
            }

            this.DialogResult = DialogResult.OK;
        }

        private void txtDiskName_Click(object sender, EventArgs e)
        {
            lblDiskNameExists.Text = "";
            lblDiskName.ForeColor = System.Drawing.Color.Black;
        }
    }
}
