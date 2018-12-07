using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynManager;
using Mindjet.MindManager.Interop;

namespace Maps
{
    public partial class MapUsersDlg : Form
    {
        public MapUsersDlg()
        {
            InitializeComponent();

            this.ShowInTaskbar = false;
            int a = 190;
            if (MMUtils.MindManager.Options.WorkbookTabPlacement == Mindjet.MindManager.Interop.MmMdiTabPlacement.mmMdiTabPlacementBottom ||
                MMUtils.MindManager.Options.ShowWorkbookTabs == false) a = 168;
            this.Location = new System.Drawing.Point(MMUtils.MindManager.Left + 6, MMUtils.MindManager.Top + a);

            this.MouseDown += new MouseEventHandler(Form_MouseDown);
            this.MouseMove += new MouseEventHandler(Form_MouseMove);

            lblTip.Text = "";

            clientSizeHeight = ClientSize.Height;
        }

        //Координаты мышки
        private int x = 0; private int y = 0;

        // Нажатие кнопки мышки
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X; y = e.Y;
        }
        // Движение мышки
        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Location = new System.Drawing.Point(this.Location.X + (e.X - x), this.Location.Y + (e.Y - y));
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MapUsersDlg_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                if (status == "online")
                {
                    foreach (Label user in Users)
                        user.Dispose();
                    Users.Clear();

                    indGreen.BringToFront();
                    lblStatus.Text = MMUtils.GetString("mapusersdlg.lblStatus.green.text");
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    pHelp.Visible = false;

                    lblTip.Text = MMUtils.GetRegistry("", "CurrentUserName");
                    UsersOnline();
                    int a = Users.Count;
                    ClientSize = new System.Drawing.Size(153, clientSizeHeight + a * 20);
                }
                else if (status == "offline")
                {
                    foreach (Label user in Users)
                        user.Dispose();
                    Users.Clear();

                    ClientSize = new System.Drawing.Size(171, 47);
                    indRed.BringToFront();
                    lblStatus.Text = MMUtils.GetString("mapusersdlg.lblStatus.red.text");
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblTip.Text = MMUtils.GetString("mapusersdlg.lblTip.red.text");
                    pHelp.Visible = true;

                    tltHelpLocked.RemoveAll(); tltHelpWait.RemoveAll();
                    tltHelpOffline.SetToolTip(pHelp, MMUtils.GetString("mapusersdlg.Offline.tooltip"));
                }
                else if (status == "waitonline")
                {
                    foreach (Label user in Users)
                        user.Dispose();
                    Users.Clear();

                    ClientSize = new System.Drawing.Size(171, 47);
                    indYellow.BringToFront();
                    lblStatus.Text = MMUtils.GetString("mapusersdlg.lblStatus.yellow.text");
                    lblStatus.ForeColor = System.Drawing.Color.Olive;
                    lblTip.Text = MMUtils.GetString("mapusersdlg.lblTip.yellow.text") + " " + waitTime;
                    pHelp.Visible = true;

                    tltHelpOffline.RemoveAll(); tltHelpLocked.RemoveAll();
                    tltHelpWait.SetToolTip(pHelp, MMUtils.GetString("mapusersdlg.WaitOnline.tooltip"));
                }
                else if (status == "locked")
                {
                    foreach (Label user in Users)
                        user.Dispose();
                    Users.Clear();

                    ClientSize = new System.Drawing.Size(171, 47);
                    indBlack.BringToFront();
                    lblStatus.Text = MMUtils.GetString("mapusersdlg.lblStatus.black.text");
                    lblStatus.ForeColor = System.Drawing.Color.Yellow;
                    lblTip.Text = ""; // TODO кто заблокировал
                    pHelp.Visible = true;

                    tltHelpOffline.RemoveAll(); tltHelpWait.RemoveAll();
                    tltHelpLocked.SetToolTip(pHelp, MMUtils.GetString("mapusersdlg.Locked.tooltip"));
                }
            }
        }

        private void UsersOnline()
        {
            int a = lblTip.Location.Y;
            foreach (string user in users)
            {
                Label lblUser = new Label();
                Users.Add(lblUser);
                Controls.Add(lblUser);
                a = a + 20; // TODO screen resolution!
                lblUser.AutoSize = true;
                lblUser.Location = new System.Drawing.Point(2, a);
                lblUser.Name = "lblUser";
                lblUser.TabIndex = 7; // TODO может, по нему и клик?
                lblUser.Text = user;
            }
        }

        public void Destroy()
        {
            foreach (Label _label in Users)
                _label.Dispose();
            Users.Clear();
            users.Clear();
        }

        public static string status = "";
        public static string blocker = "";
        public static string waitTime = "";

        private List<Label> Users = new List<Label>();
        public static List<string> users = new List<string>();

        int clientSizeHeight;
    }
}
