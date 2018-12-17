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
        protected Timer login_timer = null;

        public void Init()
        {
            login_timer = new Timer();
            login_timer.Interval = 50;
            login_timer.Tick += new EventHandler(Login_timer_Tick);

            // Init databases
            MapsDB _dbMaps = new MapsDB(); _dbMaps.Dispose();
            UsersDB _dbUsers = new UsersDB(); _dbUsers.Dispose();
            //StoragesDB _dbStorages = new StoragesDB(); _dbStorages.Dispose();
            PlacesDB _dbMyPlaces = new PlacesDB(); _dbMyPlaces.Dispose();
            ProjectsDB _dbMyProjects = new ProjectsDB(); _dbMyProjects.Dispose();

            CreateLogin();
        }

        private void Login_timer_Tick(object sender, EventArgs e) 
        {
            login_timer.Stop();

            if (docstoclose.Count > 0)
            {
                foreach (Document _doc in docstoclose)
                    _doc.Close();
                docstoclose.Clear();
            }

            Destroy(false);
            CreateLogin(logged);
        }

        private void CreateLogin(bool _logInSynergy = false)
        {
            string imagePath = MMUtils.imagePath;          
            string _caption = MMUtils.GetString("login.commands.login.caption");
            string _tooltip = MMUtils.GetString("login.commands.login.tooltip");

            if (_logInSynergy)
            {
                imagePath = imagePath + "user.png";
                SUtils.currentUserName = MMUtils.GetRegistry("", "CurrentUserName");
                _caption = SUtils.currentUserName + "    |";
                _tooltip = MMUtils.GetString("login.commands.logout.tooltip");
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

        public void m_cmdLogin_Click()
        {           
            DialogResult result = DialogResult.None;

            ////// LOG IN ///////////////////////////

            if (logged == false)
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
                bool _noplaces = false;
                using (PlacesDB _db = new PlacesDB())
                {
                    DataTable _dt = _db.ExecuteQuery("select * from PLACES");
                    if (_dt.Rows.Count == 0) // No places yet
                        _noplaces = true;                                               
                }
                if (_noplaces)
                    using (FirstUserDlg _dlg = new FirstUserDlg())
                    {
                        result = _dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd));
                        if (result == DialogResult.Cancel)
                            return;

                        MessageBox.Show(MMUtils.GetString("places.placecreated.message"));
                    }

                SUtils.currentUserName = MMUtils.GetRegistry("", "CurrentUserName");
                SUtils.currentUserEmail = MMUtils.GetRegistry("", "CurrentUserEmail");

                logged = true;
                SynergyRibbon.Visible = true;
                SendKeys.SendWait("%(S)"); // Opens Synergy Ribbon Tab
            }

            //////// LOG OUT ////////////////////////////
            else
            {
                using (LogOutDlg _dlg = new LogOutDlg())
                {
                    result = _dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd));
                }
                if (result == DialogResult.Cancel)
                    return;

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
                        System.Windows.Forms.MessageBoxButtons.YesNo) == DialogResult.No)
                            return;

                        _closeMaps = true;
                        docstoclose.Add(_doc);
                    }
                }

                logged = false;
                SynergyRibbon.Visible = false;
            }

            login_timer.Start();
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

        private ribbonTab SynergyRibbon => Maps.MapsGroup.m_myTab;

        private Command m_cmdLogin = null;
        private Mindjet.MindManager.Interop.Control m_ctrlLogin = null;

        private List<Document> docstoclose = new List<Document>();

        public bool logged = false;

    }
}
