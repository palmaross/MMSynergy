using System;
using System.Runtime.InteropServices;
using Mindjet.MindManager.Interop;
using SynManager;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Login
{
    internal class LoginToSynergy
    {
        protected static Timer login_timer = null;

        public void Init()
        {
            login_timer = new Timer();
            login_timer.Interval = 50;
            login_timer.Tick += new EventHandler(Login_timer_Tick);

            m_explorerDlg = new Maps.SynergyExplorerDlg();

            // Init databases
            MapsDB _dbMaps = new MapsDB(); _dbMaps.Dispose();
            UsersDB _dbUsers = new UsersDB(); _dbUsers.Dispose();
            PlacesDB _dbMyPlaces = new PlacesDB(); _dbMyPlaces.Dispose();
            SharedItemsDB _dbMyAccounts = new SharedItemsDB(); _dbMyAccounts.Dispose();

            CreateLogin();
        }

        private void Login_timer_Tick(object sender, EventArgs e) 
        {
            login_timer.Stop();
            Destroy(false);
            CreateLogin(logged);
        }

        public void CreateLogin(bool _logInSynergy = false)
        {
            string imagePath = MMUtils.imagePath;          
            string _caption = MMUtils.GetString("login.commands.login.caption");
            string _tooltip = MMUtils.GetString("login.commands.login.tooltip");

            if (_logInSynergy)
            {
                imagePath = imagePath + "user.png";
                SUtils.currentUserName = MMUtils.GetRegistry("", "CurrentUserName");
                _caption = SUtils.currentUserName + "    |";
            }
            else // Log out
            {
                imagePath = imagePath + "connection.png";
            }

            m_cmdLogin = CreateCommand("synergylogin");
            m_cmdLogin.Caption = _caption;
            m_cmdLogin.ToolTip = _tooltip;
            m_cmdLogin.ImagePath = imagePath;
            m_cmdLogin.UpdateState += new ICommandEvents_UpdateStateEventHandler(m_cmdLogin_UpdateState);
            m_cmdLogin.Click += new ICommandEvents_ClickEventHandler(m_cmdLogin_Click);
            m_ctrlLogin = MMUtils.MindManager.StatusBarControls.AddButton(m_cmdLogin);
        }

        public static void m_cmdLogin_Click()
        {           
            DialogResult result;

            using (SynergyMenuDlg _dlg = new SynergyMenuDlg())
                result = _dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd));

            // Log In or Log Out.
            if (result == DialogResult.Yes)
                login_timer.Start();
            
            if (result == DialogResult.OK || result == DialogResult.Retry)
            {
                // Open Synergy Explorer.
                if (result == DialogResult.OK)
                    m_explorerDlg.panelPublish.Visible = false;
                // Publish current map.
                else
                    m_explorerDlg.panelPublish.Visible = true;

                if (!m_explorerDlg.Visible)
                {
                    m_explorerDlg.Init();
                    m_explorerDlg.Show(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd));
                }
                else
                {
                    m_explorerDlg.WindowState = FormWindowState.Normal;
                    m_explorerDlg.Focus();
                }
            }
            
            // Share current map.
            // Work with users.
        }

        private void m_cmdLogin_UpdateState(ref bool pEnabled, ref bool pChecked)
        {
            pEnabled = true;
            pChecked = false;
        }

        private Command CreateCommand(string aID)
        {
            Command command = null;
            for (int i = 1; i <= MMUtils.MindManager.Commands.Count; i++)
            {
                command = MMUtils.MindManager.Commands[i];
                if (command.RegisteredAddInName == MMUtils.AddinName &&
                    command.RegisteredName == aID)
                {
                    return command;
                }
                else
                {
                    Marshal.ReleaseComObject(command);
                    command = null;
                }
            }

            return MMUtils.MindManager.Commands.Add(MMUtils.AddinName, aID);
        }

        public void Destroy(bool exit = true)
        {
            m_ctrlLogin.Delete(); Marshal.ReleaseComObject(m_ctrlLogin); m_ctrlLogin = null;
            m_cmdLogin.Click -= m_cmdLogin_Click;
            Marshal.ReleaseComObject(m_cmdLogin); m_cmdLogin = null;

            if (exit)
            {
                login_timer.Stop();
                login_timer.Tick -= Login_timer_Tick;
                login_timer = null;
            }
        }

        private Command m_cmdLogin = null;
        private Mindjet.MindManager.Interop.Control m_ctrlLogin = null;

        private static List<Document> docstoclose = new List<Document>();

        public static bool logged = false;
        private static Maps.SynergyExplorerDlg m_explorerDlg;
    }
}
