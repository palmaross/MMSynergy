using System;
using System.Collections.Generic;
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

        public void Init()
        {
            // Init SaveChanges
            SC = new Changes.SaveChanges();
            CHECKTIMERS = new CheckTimers();

            // There are the only exemplares of these dialogs!
            dlgUsersOnline = new MapUsersDlg();
            InternetChecking = new InternetCheckDlg();
         
            m_menus = new SubMenus();

            reopenmaps_timer = new System.Windows.Forms.Timer { Interval = 50 };
            reopenmaps_timer.Tick += new EventHandler(Reopenmaps_Timer_Tick);

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

                if (Login.LoginToSynergy.logged == false) // user not logged in Synergy yet
                {
                    if (System.Windows.Forms.MessageBox.Show(
                    MMUtils.GetString("maps.usernotlogged.message"), MMUtils.GetString("maps.synergywarning.caption"),
                    System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        Login.LoginToSynergy.m_cmdLogin_Click();

                    if (Login.LoginToSynergy.logged == false) // user don't want to log in Synergy
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

        /// <summary>
        /// Share map, project or folder
        /// </summary>
        /// <param name="_what">"map", "project" or "folder"</param>
        /// <param name="_localpath">local path to selected item</param>
        private void Share(string _what, string _localpath)
        {
            string mapGuid = SUtils.SynergyMapGuid(MMUtils.ActiveDocument);
            string placePath = "", folderName = "", storage = "";

            if (_what == "map")
            {
                using (MapsDB _db = new MapsDB())
                {
                    DataTable _dt = _db.ExecuteQuery("select * from MAPS where LOCALPATH='" + _localpath + "'");
                    if (_dt.Rows.Count != 0)
                    {
                        placePath = _dt.Rows[0]["PATHTOPLACE"].ToString();
                        folderName = Path.GetDirectoryName(placePath);
                        storage = _dt.Rows[0]["PLACE"].ToString();
                    }
                }
                using (PlacesDB _db = new PlacesDB())
                {
                    DataTable _dt = _db.ExecuteQuery("select * from PLACES where PLACE='" + storage + "'");
                    storage = _dt.Rows[0]["STORAGE"].ToString();
                }
            }
            else
            {
                folderName = Path.GetDirectoryName(_localpath);
            }

            using (ShareDlg _dlg = new ShareDlg(folderName, placePath, _what, storage))
                _dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd));
        }

        private void m_cmdReceiveMap_Click()
        {
            using (MapReceivedDlg dlg = new MapReceivedDlg())
                if (dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd)) == System.Windows.Forms.DialogResult.Cancel)
                    return;
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
            SC.Destroy();

            foreach (SubMenus item in OpenButtons)
                item.Destroy();
            OpenButtons.Clear();

            foreach (MapTimers item in TIMERS)
                item.Destroy();
            TIMERS.Clear();

            CHECKTIMERS.Destroy();

            //foreach (Watchers item in WATCHERS)
            //    item.Dispose();
            //WATCHERS.Clear();

            foreach (MapWatchers item in MAPWATCHERS)
                item.Dispose();
            MAPWATCHERS.Clear();

            dlgUsersOnline.Visible = false;
            dlgUsersOnline.Destroy();
            dlgUsersOnline.Dispose();
            dlgUsersOnline = null;

            InternetChecking.Visible = false;
            InternetChecking.Dispose();
            InternetChecking = null;
        }

        protected System.Windows.Forms.Timer reopenmaps_timer = null;

        private List<Document> _reopenmaps = new List<Document>();
        private SubMenus m_menus;
        public List<SubMenus> OpenButtons = new List<SubMenus>();

        public static List<MapTimers> TIMERS = new List<MapTimers>();
        public static CheckTimers CHECKTIMERS = new CheckTimers();
        //public static List<Watchers> WATCHERS = new List<Watchers>();
        public static List<MapWatchers> MAPWATCHERS = new List<MapWatchers>();

        public static MapUsersDlg dlgUsersOnline = null;
        public static InternetCheckDlg InternetChecking = null;
    }
}
