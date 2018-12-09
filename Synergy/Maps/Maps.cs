using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Mindjet.MindManager.Interop;
using SynManager;
using System.IO;
using System.Data;
using System.Linq;

namespace Maps
{
    internal class MapsGroup
    {
        private Changes.SaveChanges SC;
        public static Login.LoginToSynergy LOGIN;

        public void Create(ribbonTab myTab)
        {
            m_myTab = myTab;

            // Init SaveChanges
            SC = new Changes.SaveChanges();

            LOGIN = new Login.LoginToSynergy();
            LOGIN.Init();

            // There are the only exemplares of these dialogs!
            dlgUsersOnline = new MapUsersDlg();
            InternetChecking = new InternetCheckDlg();
         
            m_menus = new SubMenus();
            string imagePath = MMUtils.imagePath;

            reopenmaps_timer = new System.Windows.Forms.Timer { Interval = 50 };
            reopenmaps_timer.Tick += new EventHandler(Reopenmaps_Timer_Tick);
 
            try
            {
                m_rgMaps = m_myTab.Groups.Add(0, MMUtils.GetString("maps.group.name"), "www.palmaross.com", imagePath + "lists_s.png");

                m_cmdOpenMaps = MMUtils.MindManager.Commands.Add(MMUtils.AddinName, "OpenMap");
                m_cmdOpenMaps.Caption = MMUtils.GetString("maps.commands.open.caption");
                m_cmdOpenMaps.ToolTip = MMUtils.GetString("maps.commands.open.tooltip") + "\n" + m_cmdOpenMaps.Caption;
                m_cmdOpenMaps.LargeImagePath = MMUtils.imagePath + "common_stock.png";
                m_cmdOpenMaps.ImagePath = imagePath + "audio.png";
                m_cmdOpenMaps.UpdateState += new ICommandEvents_UpdateStateEventHandler(m_cmdOpenMaps_UpdateState);
                m_cmdOpenMaps.Click += new ICommandEvents_ClickEventHandler(m_cmdOpenMaps_Click);
                m_ctrlOpenMaps = m_rgMaps.GroupControls.AddButton(m_cmdOpenMaps);
                m_UpdateOpenMap = true;

                m_cmdPublishMap = MMUtils.MindManager.Commands.Add(MMUtils.AddinName, "PublishMap");
                m_cmdPublishMap.Caption = MMUtils.GetString("maps.commands.publish.caption");
                m_cmdPublishMap.ToolTip = MMUtils.GetString("maps.commands.publish.tooltip") + "\n" + m_cmdPublishMap.Caption;
                m_cmdPublishMap.LargeImagePath = imagePath + "common_stock.png";
                m_cmdPublishMap.ImagePath = imagePath + "audio.png";
                m_cmdPublishMap.UpdateState += new ICommandEvents_UpdateStateEventHandler(m_cmdPublishMap_UpdateState);
                m_cmdPublishMap.Click += new ICommandEvents_ClickEventHandler(m_cmdPublishMap_Click);
                m_ctrlPublishMap = m_rgMaps.GroupControls.AddButton(m_cmdPublishMap);

                m_cmdShareMaps = MMUtils.MindManager.Commands.Add(MMUtils.AddinName, "ShareMaps");
                m_cmdShareMaps.Caption = MMUtils.GetString("maps.commands.share.caption");
                m_cmdShareMaps.ToolTip = MMUtils.GetString("maps.commands.share.tooltip") + "\n" + m_cmdShareMaps.Caption;
                m_cmdShareMaps.LargeImagePath = imagePath + "common_stock.png";
                m_cmdShareMaps.ImagePath = imagePath + "common_stock_s.png";
                m_cmdShareMaps.UpdateState += new ICommandEvents_UpdateStateEventHandler(m_cmdShareMaps_UpdateState);
                //m_cmdShareMaps.Click += new ICommandEvents_ClickEventHandler(m_cmdShareMaps_Click);
                m_ctrlShareMaps = m_rgMaps.GroupControls.AddButton(m_cmdShareMaps);

                m_cmdShareMap = MMUtils.MindManager.Commands.Add(MMUtils.AddinName, "ShareMap");
                m_cmdShareMap.Caption = MMUtils.GetString("maps.commands.sharemap.caption");
                m_cmdShareMap.ImagePath = imagePath + "common_stock_s.png";
                m_cmdShareMap.UpdateState += new ICommandEvents_UpdateStateEventHandler(m_cmdShareMap_UpdateState);
                m_cmdShareMap.Click += new ICommandEvents_ClickEventHandler(m_cmdShareMap_Click);
                m_ctrlShareMap = m_ctrlShareMaps.Controls.AddButton(m_cmdShareMap);

                m_cmdReceiveMap = MMUtils.MindManager.Commands.Add(MMUtils.AddinName, "ReceiveMap");
                m_cmdReceiveMap.Caption = MMUtils.GetString("maps.commands.receivemap.caption");
                m_cmdReceiveMap.ImagePath = imagePath + "common_stock_s.png";
                m_cmdReceiveMap.UpdateState += new ICommandEvents_UpdateStateEventHandler(m_cmdReceiveMap_UpdateState);
                m_cmdReceiveMap.Click += new ICommandEvents_ClickEventHandler(m_cmdReceiveMap_Click);
                m_ctrlReceiveMap = m_ctrlShareMaps.Controls.AddButton(m_cmdReceiveMap);

                //m_cmdDeleteMap = MMUtils.MindManager.Commands.Add(MMUtils.AddinName, "DeleteMap");
                //m_cmdDeleteMap.Caption = MMUtils.getString("maps.commands.delete.caption");
                //m_cmdDeleteMap.ToolTip = MMUtils.getString("maps.commands.delete.tooltip") + "\n" + m_cmdDeleteMap.Caption;
                //m_cmdDeleteMap.LargeImagePath = imagePath + "common_stock.png";
                //m_cmdDeleteMap.ImagePath = imagePath + "common_stock_s.png";
                //m_cmdDeleteMap.UpdateState += new ICommandEvents_UpdateStateEventHandler(m_cmdDeleteMap_UpdateState);
                //m_cmdDeleteMap.Click += new ICommandEvents_ClickEventHandler(m_cmdDeleteMap_Click);
                //m_ctrlDeleteMap = m_rgMaps.GroupControls.AddButton(m_cmdDeleteMap);

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

            if (MMUtils.MindManager.AllDocuments.Count == 0)
            {
                DestroyTimer();
                return;
            }

            bool _closeSynergyMaps = false;

            // Reopen and process opened Synergy maps at MindManager start (if user wants to log in Synergy)
            // TODO возможно, придется итерировать через for - проверить закрытие на нескольких открытых при старте карт Synergy

            List<Document> _allmaps = new List<Document>();
            foreach (Document _doc in MMUtils.MindManager.AllDocuments)
                _allmaps.Add(_doc);

            for (int i = 0; i < _allmaps.Count; i++)
            {
                if (_allmaps[i].HasAttributesNamespace[SUtils.SYNERGYNAMESPACE] == false)
                    continue;

                if (_closeSynergyMaps)
                {
                    DocumentStorage.closeMap = true;
                    _allmaps[i].Close();
                    continue;
                }

                if (LOGIN.logged == false) // user not logged in Synergy yet
                {
                    if (System.Windows.Forms.MessageBox.Show(
                    MMUtils.GetString("maps.usernotlogged.message"), MMUtils.GetString("maps.synergywarning.caption"),
                    System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        LOGIN.m_cmdLogin_Click();

                    if (LOGIN.logged == false) // user don't want to log in Synergy
                    {
                        _closeSynergyMaps = true;
                        DocumentStorage.closeMap = true;
                        _allmaps[i].Close();
                        continue;
                    }
                }

                _reopenmaps.Add(_allmaps[i]);
            }

            // Timer to reopen maps (because from here we can't open maps)
            if (_reopenmaps.Count > 0)
                reopenmaps_timer.Start();
            else
                DestroyTimer();

            _allmaps.Clear();
        }

        private void m_cmdOpenMaps_Click() 
        {
            if (OpenButtons.Count == 0)
                System.Windows.Forms.MessageBox.Show(MMUtils.GetString("maps.nomapsyet.message"));
        }

        public void m_cmdOpenMaps_UpdateState(ref bool pEnabled, ref bool pChecked)
        {
            pEnabled = true;
            pChecked = false;

            if (!m_UpdateOpenMap)
                return;

            m_UpdateOpenMap = false;
            int a = 1;

            List<string> aProjects = new List<string>();
            List<string> aSingleMaps = new List<string>();

            if (OpenButtons.Count != 0)
            {
                foreach (SubMenus item in OpenButtons)
                    item.Destroy();

                for (int i = 0; i < Labels.Count; i++)
                {
                    Labels[i].Delete(); Marshal.ReleaseComObject(Labels[i]); Labels[i] = null;
                }                 
            }
            OpenButtons.Clear();
            Labels.Clear();

            using (ProjectsDB _db = new ProjectsDB())
            {
                DataTable _dt = _db.ExecuteQuery("select * from PROJECTS order by PROJECTNAME");
                foreach (DataRow _row in _dt.Rows)
                        aProjects.Add(_row["PROJECTNAME"].ToString());
            }

            using (PlacesDB _db = new PlacesDB())
            {
                DataTable _dt = _db.ExecuteQuery("select * from PLACES order by PLACENAME");
                foreach (DataRow _row in _dt.Rows)
                        aSingleMaps.Add(_row["PLACENAME"].ToString());
            }

            using (MapsDB _db = new MapsDB())
            {
                bool _label = true;
                Control m_label = null;

                // Get maps by projects
                foreach (string _project in aProjects)
                {
                    DataTable _dt = _db.ExecuteQuery("select * from MAPS where PROJECTNAME=`" + _project + "` order by MAPNAME");

                    foreach (DataRow _row in _dt.Rows)
                    {
                        if (_label)
                        {
                            m_label = m_ctrlOpenMaps.Controls.AddLabel(_project);
                            _label = false;
                            Labels.Add(m_label);
                        }

                        m_menus = new SubMenus();
                        OpenButtons.Add(m_menus);
                        m_menus.AddMapToOpenMenu(_row["MAPGUID"].ToString(), _row["MAPNAME"].ToString(), "map" + a++);
                    }
                    _label = true;
                }

                //_label = true;
                // Get single maps
                foreach (string _place in aSingleMaps)
                {
                    DataTable _dt = _db.ExecuteQuery("select * from MAPS where PROJECTNAME = `" + "" + "` and PLACENAME=`" + _place + "` order by MAPNAME");
                    //DataTable __dt = _db.ExecuteQuery("select * from MAPS");
                    foreach (DataRow _row in _dt.Rows)
                    {
                        if (_label)
                        {
                            m_label = m_ctrlOpenMaps.Controls.AddLabel(_place + ": " + SUtils.SingleMaps);
                            _label = false;
                            Labels.Add(m_label);
                        }

                        m_menus = new SubMenus();
                        OpenButtons.Add(m_menus);
                        m_menus.AddMapToOpenMenu(_row["MAPGUID"].ToString(), _row["MAPNAME"].ToString(), "map" + a++);
                    }
                    _label = true;
                }

                aProjects.Clear();
                aSingleMaps.Clear();
            }
        }

        private void m_cmdPublishMap_Click()
        {
            using (PublishMaptDlg _dlg = new PublishMaptDlg(MMUtils.ActiveDocument))
            {
                System.Windows.Forms.DialogResult result = _dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd));
                if (result == System.Windows.Forms.DialogResult.Cancel)
                    System.Windows.Forms.MessageBox.Show(MMUtils.GetString("maps.nosuccessmessage.text"));
                if (result == System.Windows.Forms.DialogResult.OK)
                    System.Windows.Forms.MessageBox.Show(MMUtils.GetString("maps.successmessage.text"));
            }
        }

        private void m_cmdPublishMap_UpdateState(ref bool pEnabled, ref bool pChecked)
        {
            if (MMUtils.MindManager.VisibleDocuments.Count == 0)
            {
                pEnabled = false;
                pChecked = false;
            }
            else
            {
                pEnabled = !MMUtils.ActiveDocument.ContainsAttributesNamespace(SUtils.SYNERGYNAMESPACE);
                pChecked = MMUtils.ActiveDocument.ContainsAttributesNamespace(SUtils.SYNERGYNAMESPACE);
            }
        }

        private void m_cmdShareMaps_UpdateState(ref bool pEnabled, ref bool pChecked)
        {
            pEnabled = true;
            pChecked = false;
        }

        private void m_cmdShareMap_Click()
        {
            string mapGuid = SUtils.SynergyMapGuid(MMUtils.ActiveDocument);

            foreach (Timers item in TIMERS)
            {
                if (item.m_Guid == mapGuid)
                {
                    using (ShareMapDlg _dlg = new ShareMapDlg(MMUtils.ActiveDocument.Name, item.m_PlacePath))
                        _dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd));
                    break;
                }
            }
        }

        private void m_cmdShareMap_UpdateState(ref bool pEnabled, ref bool pChecked)
        {
            if (MMUtils.MindManager.VisibleDocuments.Count == 0)
                pEnabled = false;
            else
                pEnabled = MMUtils.ActiveDocument.ContainsAttributesNamespace(SUtils.SYNERGYNAMESPACE);

            pChecked = false;
        }

        private void m_cmdReceiveMap_Click()
        {
            using (MapReceivedDlg dlg = new MapReceivedDlg())
                if (dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd)) == System.Windows.Forms.DialogResult.Cancel)
                    return;
        }

        private void m_cmdReceiveMap_UpdateState(ref bool pEnabled, ref bool pChecked)
        {
            pEnabled = true;
            pChecked = false;
        }

        private void m_cmdDeleteMap_Click()
        {

        }

        private void m_cmdDeleteMap_UpdateState(ref bool pEnabled, ref bool pChecked)
        {
            pEnabled = true;
            pChecked = false;
        }

        private void Reopenmaps_Timer_Tick(object sender, EventArgs e)
        {
            reopenmaps_timer.Stop();
            string mapPlacePath = "";

            for (int i = 0; i < _reopenmaps.Count; i++)
            {
                bool mapnotfound = true;
                string mapLocalPath = _reopenmaps[i].FullName;

                File.SetAttributes(mapLocalPath, System.IO.FileAttributes.Normal);

                using (MapsDB _db = new MapsDB())
                {
                    DataTable _dt = _db.ExecuteQuery("select * from MAPS where LOCALPATH='" + mapLocalPath + "'");
                    if (_dt.Rows.Count != 0)
                    {
                        mapnotfound = false;
                        mapPlacePath = _dt.Rows[0]["PATHTOPLACE"].ToString();
                    }
                }

                try
                {
                    mapPlacePath = Directory.GetFiles(mapPlacePath, "*.mmap").Last().ToString();
                }
                catch
                {
                    mapPlacePath = "";
                }

                if (i == _reopenmaps.Count - 1) // last document will be opened, it will be active
                    SUtils.skipActiveMap = false;
                else
                    SUtils.skipActiveMap = true;

                // We have to reopen map to get last map copy from its Place

                if (!mapnotfound && mapPlacePath != "") // map and its placepath found
                {
                    long localmap_lastwrite = Convert.ToInt64(File.GetLastWriteTimeUtc(mapLocalPath).ToString("yyyyMMddHHmmssfff"));
                    long placemap_time = Convert.ToInt64(Path.GetFileNameWithoutExtension(mapPlacePath));

                    if (placemap_time <= localmap_lastwrite)
                    {
                        string fail = SUtils.ProcessMap(_reopenmaps[i]);

                        if (fail == "")
                            SUtils.GetChanges(_reopenmaps[i]);

                        continue;
                    }
                }

                DocumentStorage.closeMap = true;
                _reopenmaps[i].Close();

                // if map or map place not found this will be resolved in the afterOpenMap event
                if (!mapnotfound && mapPlacePath != "")
                    File.Copy(mapPlacePath, mapLocalPath, true); // copy (overwrite) map from its Place to local Synergy

                DocumentStorage.reopenmap = false;
                MMUtils.MindManager.AllDocuments.Open(mapLocalPath);
            }

            _reopenmaps.Clear();
            DestroyTimer();
        }

        private void DestroyTimer()
        {
            reopenmaps_timer.Tick -= Reopenmaps_Timer_Tick;
            reopenmaps_timer = null;
        }

        public void Destroy()
        {
            LOGIN.Destroy();
            LOGIN = null;
            SC.Destroy();

            foreach (SubMenus item in OpenButtons)
                item.Destroy();
            OpenButtons.Clear();

            for (int i = 0; i < Labels.Count; i++)
            {
                Labels[i].Delete(); Marshal.ReleaseComObject(Labels[i]); Labels[i] = null;
            }
            Labels.Clear();

            foreach (Timers item in TIMERS)
                item.Destroy();
            TIMERS.Clear();

            foreach (Watchers item in WATCHERS)
                item.Dispose();
            WATCHERS.Clear();

            dlgUsersOnline.Visible = false;
            dlgUsersOnline.Destroy();
            dlgUsersOnline.Dispose();
            dlgUsersOnline = null;

            InternetChecking.Visible = false;
            InternetChecking.Dispose();
            InternetChecking = null;

            m_ctrlOpenMaps.Delete(); Marshal.ReleaseComObject(m_ctrlOpenMaps); m_ctrlOpenMaps = null;
            Marshal.ReleaseComObject(m_cmdOpenMaps); m_cmdOpenMaps = null;

            m_ctrlPublishMap.Delete(); Marshal.ReleaseComObject(m_ctrlPublishMap); m_ctrlPublishMap = null;
            Marshal.ReleaseComObject(m_cmdPublishMap); m_cmdPublishMap = null;

            m_ctrlShareMap.Delete(); Marshal.ReleaseComObject(m_ctrlShareMap); m_ctrlShareMap = null;
            Marshal.ReleaseComObject(m_cmdShareMap); m_cmdShareMap = null;
            m_ctrlReceiveMap.Delete(); Marshal.ReleaseComObject(m_ctrlReceiveMap); m_ctrlReceiveMap = null;
            Marshal.ReleaseComObject(m_cmdReceiveMap); m_cmdReceiveMap = null;
            m_ctrlShareMaps.Delete(); Marshal.ReleaseComObject(m_ctrlShareMaps); m_ctrlShareMaps = null;
            Marshal.ReleaseComObject(m_cmdShareMaps); m_cmdShareMaps = null;

            m_rgMaps.Delete();
            m_myTab = null;
        }

        protected System.Windows.Forms.Timer reopenmaps_timer = null;

        public static ribbonTab m_myTab = null;
        private RibbonGroup m_rgMaps = null;

        private Command m_cmdOpenMaps = null;
        public static Control m_ctrlOpenMaps = null;
        private Command m_cmdPublishMap = null;
        private Control m_ctrlPublishMap = null;

        private Command m_cmdShareMaps = null;
        private Control m_ctrlShareMaps = null;
        private Command m_cmdShareMap = null;
        private Control m_ctrlShareMap = null;
        private Command m_cmdReceiveMap = null;
        private Control m_ctrlReceiveMap = null;

        //private Command m_cmdDeleteMap = null;
        //private Control m_ctrlDeleteMap = null;

        public static bool m_UpdateOpenMap = false;

        private List<Document> _reopenmaps = new List<Document>();
        private SubMenus m_menus;
        public List<SubMenus> OpenButtons = new List<SubMenus>();
        private List<Control> Labels = new List<Control>();

        public static List<Timers> TIMERS = new List<Timers>();
        public static List<Watchers> WATCHERS = new List<Watchers>();

        public static MapUsersDlg dlgUsersOnline = null;
        public static InternetCheckDlg InternetChecking = null;
    }
}
