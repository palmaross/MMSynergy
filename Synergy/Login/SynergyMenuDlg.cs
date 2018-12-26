using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SynManager;
using Mindjet.MindManager.Interop;

namespace Login
{
    public partial class SynergyMenuDlg : Form
    {
        private List<Document> docstoclose = new List<Document>();

        public SynergyMenuDlg()
        {
            InitializeComponent();

            if (LoginToSynergy.logged == false)
            {
                cmdExplorer.Enabled = false;
                cmdPublish.Enabled = false;
                cmdShare.Enabled = false;
                cmdUsers.Enabled = false;
                cmdLogin.Text = MMUtils.GetString("synergymenudlg.cmdLogIn.text");
                checkBoxForgetMe.Visible = false;
                this.Size = new Size(this.Size.Width, this.Size.Height - checkBoxForgetMe.Height);
            }
            else
            {
                cmdLogin.Text = MMUtils.GetString("synergymenudlg.cmdLogOut.text");
                checkBoxForgetMe.Visible = true;
            }


            this.Location = new Point(MMUtils.MindManager.Left + MMUtils.MindManager.Width - this.Width - 360,
                            MMUtils.MindManager.Top + MMUtils.MindManager.Height - this.Height - 20);

            toolTip1.SetToolTip(checkBoxForgetMe, MMUtils.GetString("synergymenudlg.checkBoxForgetMe.tooltip"));
        }

        // Open Synergy Explorer.
        private void cmdExplorer_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        // Open Synergy Explorer with Publish Current Map panel.
        private void cmdPublish_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
        }

        // Share current map = message box with path to sharing folder + message for user.
        private void cmdShare_Click(object sender, EventArgs e)
        {

        }

        // Users dialog.
        private void cmdUsers_Click(object sender, EventArgs e)
        {

        }

        // About + License + Help + Settings.
        private void cmdHelp_Click(object sender, EventArgs e)
        {
            string chmPath = MMUtils.GetRegistry("", "InstPath") + "\\Synergy.chm";
            System.Diagnostics.Process.Start(chmPath);
        }

        // Log In or Log Out Sinergy
        private void cmdLogin_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.None;

            ////// LOG IN ///////////////////////////
            if (LoginToSynergy.logged == false)
            {
                if (MMUtils.GetRegistry("", "RememberMe") == "1")
                {
                    MMUtils.SetRegistry("", "CurrentUserName", MMUtils.GetRegistry("", "RememberedUserName"));
                    MMUtils.SetRegistry("", "CurrentUserEmail", MMUtils.GetRegistry("", "RememberedUserEmail"));
                }
                else
                {
                    using (LogInDlg _dlg = new LogInDlg())
                        result = _dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd));
                    if (result == DialogResult.Cancel)
                        return;
                }

                // Check for Places
                //bool _noplaces = false;
                //using (PlacesDB _db = new PlacesDB())
                //{
                //    DataTable _dt = _db.ExecuteQuery("select * from PLACES");
                //    if (_dt.Rows.Count == 0) // No places yet
                //        _noplaces = true;
                //}
                //if (_noplaces)
                //    using (FirstUserDlg _dlg1 = new FirstUserDlg())
                //    {
                //        result = _dlg1.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd));
                //        if (result == DialogResult.Cancel)
                //            return;

                //        MessageBox.Show(MMUtils.GetString("places.placecreated.message"));
                //    }

                SUtils.currentUserName = MMUtils.GetRegistry("", "CurrentUserName");
                SUtils.currentUserEmail = MMUtils.GetRegistry("", "CurrentUserEmail");

                LoginToSynergy.logged = true;
            }

            //////// LOG OUT ////////////////////////////
            else
            {
                if (checkBoxForgetMe.Checked == true)
                {
                    MMUtils.SetRegistry("", "RememberMe", "0");
                }

                // Close all Synergy maps
                bool _closeMaps = false;

                foreach (Document _doc in MMUtils.MindManager.AllDocuments)
                {
                    if (_doc.HasAttributesNamespace[SUtils.SYNERGYNAMESPACE])
                    {
                        if (_closeMaps)
                        {
                            docstoclose.Add(_doc);
                            continue;
                        }

                        if (MessageBox.Show(MMUtils.GetString("maps.userlogout.message"), "",
                        MessageBoxButtons.YesNo) == DialogResult.No)
                            return;

                        _closeMaps = true;
                        docstoclose.Add(_doc);
                    }
                }

                if (docstoclose.Count > 0)
                {
                    foreach (Document _doc in docstoclose)
                        _doc.Close();
                    docstoclose.Clear();
                }
                LoginToSynergy.logged = false;
            }

            this.DialogResult = DialogResult.Yes;
        }

        // Close menu when clicking outside it
        protected override void WndProc(ref Message m)
        {
            const UInt32 WM_NCACTIVATE = 0x0086;

            if (m.Msg == WM_NCACTIVATE && m.WParam.ToInt32() == 0)
            {
                this.Close();
            }
            else
            {
                base.WndProc(ref m);
            }
        }
    }
}
