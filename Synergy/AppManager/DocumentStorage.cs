namespace SynManager
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Mindjet.MindManager.Interop;
    using System.Data;
    using System.IO;
    using Maps;
    using System.Linq;

    internal class DocumentStorage
    {
        public static void Init()
        {
            m_parent = new List<MMBase>();

            // Subscribe to events

            m_documentEventBefore = MMUtils.MindManager.Events.AddDocumentEvent(
                EventDocumentClosed + 
                EventDocumentSaved +
                //Event__All +
                EventDocumentClipboardDrag + 
                EventDocumentClipboardDrop +
                EventDocumentClipboardCopy +
                EventDocumentClipboardPaste,
                true, false, null);
            m_documentEventBefore.UndoCaption = "DocumentEvent-Before";
            m_documentEventBefore.AutomaticCallbackContext = false;
            m_documentEventBefore.Fire += new IEventEvents_FireEventHandler(m_documentEventBefore_Fire);

            m_documentEventAfter = MMUtils.MindManager.Events.AddDocumentEvent(
                //Event__All +
                //EventDocumentAdded + // not processed but needed to hide MapUsersDlg and stop IP_Timer
                EventDocumentActivated +
                EventDocumentOpened,
                false, true, null);
            m_documentEventAfter.UndoCaption = "DocumentEvent-After";
            m_documentEventAfter.AutomaticCallbackContext = false;
            m_documentEventAfter.Fire += new IEventEvents_FireEventHandler(m_documentEventAfter_Fire);

            m_timer200 = new Timer() { Interval = 500 };
            m_timer200.Tick += new EventHandler(m_timer200_Tick);

            closeMap_timer = new Timer() { Interval = 50 };
            closeMap_timer.Tick += new EventHandler(MapClose_timer_Tick);

            openMap_timer = new Timer() { Interval = 10 };
            openMap_timer.Tick += new EventHandler(MapOpen_timer_Tick);
        }

        public static void Sync(Document aDoc, bool _add, string _mapPlaceFolder = "")
        {
            if (_add)
            {
                MapCompanion startevents = new MapCompanion(aDoc) { mc_MapFolderPath = _mapPlaceFolder };

                SDocs.Add(new DocumentStorage()
                {
                    MGuid = SUtils.SynergyMapGuid(aDoc),
                    Sdoc = aDoc,
                    _mc = startevents
                });
            }
            else // unsubscribe map
            {
                foreach (DocumentStorage item in SDocs)
                    if (item.MGuid == SUtils.SynergyMapGuid(aDoc))
                    {
                        SDocs.Remove(item);
                        item.Sdoc = null;
                        item._mc.Dispose();
                        break;
                    }
            }
        }

        protected static void m_timer200_Tick(object sender, EventArgs e)
        {
            m_timer200.Stop();
            foreach (MMBase _parent in m_parent)
                _parent.onTimer200();
        }

        protected static void MapClose_timer_Tick(object sender, EventArgs e)
        {
            closeMap_timer.Stop();
            closeMap = true;
            docToClose.Close();
            docToClose = null;
            if (reopentimer)
            {
                File.Copy(docToCopy, docToOpen, true);
                openMap_timer.Start();
            }
        }
        protected static void MapOpen_timer_Tick(object sender, EventArgs e)
        {
            openMap_timer.Stop();
            reopentimer = false;
            reopenmap = false;     
            MMUtils.MindManager.AllDocuments.Open(docToOpen);
        }

        private static void m_documentEventAfter_Fire(int eventFlag, MmEventTime time, object pSource, ref object pExtra)
        {
            Document _doc = pSource as Document;

            Maps.MapsGroup.dlgUsersOnline.Visible = false;

            if (_doc == null || !_doc.HasAttributesNamespace[SUtils.SYNERGYNAMESPACE]) 
                return;

            string mapGuid = SUtils.SynergyMapGuid(_doc);

            if ((eventFlag & EventDocumentActivated) != 0)
            {
                foreach (DocumentStorage item in SDocs)
                    if (item.MGuid == mapGuid) // map was opened before 
                    {
                        foreach (MapTimers _item in Maps.MapsGroup.TIMERS)
                            if (_item.m_Guid == mapGuid)
                            {
                                Maps.MapUsersDlg.status = _item.m_Status;
                                Maps.MapUsersDlg.users = _item.UsersOnline;
                                Maps.MapUsersDlg.blocker = _item.MapBlocker;
                                Maps.MapsGroup.dlgUsersOnline.Show(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd));
                                break;
                            }
                        break;
                    }
                    //else - map is opening, handle it in EventDocumentOpened
                _doc = null;
            }

            if ((eventFlag & EventDocumentOpened) != 0)
            {
                if (openMap)
                {
                    openMap = false;
                    _doc = null;
                    return;
                }

                if (Login.LoginToSynergy.logged == false) // user not logged in Synergy yet
                {                   
                    if (MessageBox.Show(MMUtils.GetString("maps.openmapnosynergy.message"),
                    MMUtils.GetString("maps.synergywarning.caption"), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                        Login.LoginToSynergy.m_cmdLogin_Click();

                    if (Login.LoginToSynergy.logged == false)  
                        {
                            reopentimer = false;
                            docToClose = _doc;
                            _doc = null;
                            closeMap_timer.Start(); // we can't close document within this event
                            return;
                        }
                }

                bool mapnotfound = false;

                using (MapsDB _db = new MapsDB())
                {
                    DataTable _dt = _db.ExecuteQuery("select * from MAPS where MAPGUID='" + mapGuid + "'");
                    if (_dt.Rows.Count == 0)
                    {
                        MessageBox.Show(String.Format(MMUtils.GetString("maps.openmapillegal.message"), _doc.Name), 
                            MMUtils.GetString("maps.synergywarning.caption"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        mapnotfound = true;
                    }
                    else // map found in MapsDB
                    {
                        docToClose = _doc;
                        docToOpen = _dt.Rows[0]["LOCALPATH"].ToString();
                        docToCopy = _dt.Rows[0]["PATHTOPLACE"].ToString();
                        File.SetAttributes(docToOpen, System.IO.FileAttributes.Normal);
                    }
                }

                if (mapnotfound)
                {
                    _doc = null;
                    return;
                }

                try
                {
                    docToCopy = Directory.GetFiles(docToCopy, "*.mmap").Last().ToString();
                }
                catch // can't access to _pathtofolder
                {
                    docToCopy = "";
                }

                if (docToCopy != "" && reopenmap == true)
                {
                    long localmap_lastwrite = Convert.ToInt64(File.GetLastWriteTimeUtc(docToOpen).ToString("yyyyMMddHHmmssfff"));
                    long placemap_time = Convert.ToInt64(Path.GetFileNameWithoutExtension(docToCopy));

                    // reopen map to get last map copy from its Place
                    if (placemap_time > localmap_lastwrite)
                    {
                        reopentimer = true;
                        closeMap_timer.Start(); // we can't close document within this event
                        _doc = null;
                        return; // for reopen map
                    }
                }

                if (reopenmap == false)
                    reopenmap = true;

                docToClose = null;

                string fail = SUtils.ProcessMap(_doc);

                if (fail == "") // don't get changes if map offline
                    SUtils.GetChanges(_doc);

                _doc = null;
            }

            _doc = null;
        }

        private static void m_documentEventBefore_Fire(int eventFlag, MmEventTime time, object pSource, ref object pExtra)
        {
            Document _doc = pSource as Document;
            bool _notsynergy = true;          

            if (_doc == null || !_doc.HasAttributesNamespace[SUtils.SYNERGYNAMESPACE])
                return;

            string mapGuid = SUtils.SynergyMapGuid(_doc);

            foreach (DocumentStorage item in SDocs)
                if (mapGuid == item.MGuid)
                {
                    _notsynergy = false;
                    break;
                }

            if (_notsynergy)
            {
                _doc = null;
                return;
            }

            if (eventFlag == EventDocumentClosed)
            {
                if (closeMap)
                {
                    closeMap = false;
                    _doc = null;
                    return;
                }
              
                File.SetAttributes(_doc.FullName, FileAttributes.Normal);

                Sync(_doc, false); // Unsubscribe this map

                foreach (MapWatchers _item in MapsGroup.MAPWATCHERS)
                    if (_item.MapGuid == mapGuid)
                    {
                        _item.Dispose();
                        MapsGroup.MAPWATCHERS.Remove(_item);
                        break;
                    }

                string m_PlacePath = "";
                bool _isonline = true;

                foreach (MapTimers _item in MapsGroup.TIMERS)
                    if (_item.m_Guid == mapGuid)
                    {
                        _isonline = (_item.m_Status == "online");
                        m_PlacePath = _item.m_PlacePath;
                        string _folder = _item.m_PlacePath;
                        _folder = Path.GetDirectoryName(_folder) + "\\";

                        try
                        {
                            string _file = _folder + "info.locker";
                            if (File.Exists(_file))
                                File.Delete(_file);

                            _file = _folder + SUtils.currentUserName + ".online";
                            if (File.Exists(_file))
                                File.Delete(_file);
                        }
                        catch { }

                        _item.Destroy();
                        MapsGroup.TIMERS.Remove(_item);
                        break;
                    }

                if (MMUtils.MindManager.VisibleDocuments.Count == 1) // this map is the only document, so - it is last
                {
                    MapsGroup.dlgUsersOnline.Visible = false;
                    if (DocumentStorage.SDocs.Count > 0)
                        MessageBox.Show("All documents closed, but SDocs is not empty...", "Possible bug");

                    foreach (DocumentStorage item in SDocs)
                    {
                        item.Sdoc = null;
                        item._mc.Dispose();
                    }
                    SDocs.Clear();
                }

                if (_isonline)
                {
                    try
                    {
                        _doc.Save();
                        // Prepare last file for save in Place
                        string _path = m_PlacePath + File.GetLastWriteTimeUtc(_doc.FullName).ToString("yyyyMMddHHmmssfff") + ".mmap";
                        File.Copy(_doc.FullName, _path, true);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Exception: " + e.Message, "onBeforeClosed");
                    }
                    finally
                    {
                        _doc = null;
                    }
                }

                _doc = null;
            }

            if (eventFlag == EventDocumentSaved)
            {
                _doc = null;
            }

            if (eventFlag == EventDocumentClipboardDrag) // TODO needed?
            {
                //foreach (MMBase _parent in m_parent)
                //    _parent.onBeforeDocumentClipboardDragBase(new MMEventArgs(m_documentEventBefore, _doc));
                _doc = null;
            }

            if (eventFlag == EventDocumentClipboardDrop)
            {
                MapCompanion.paste = true;
                _doc = null;
            }

            if (eventFlag == EventDocumentClipboardCopy) // TODO needed?
            {
                //foreach (MMBase _parent in m_parent)
                //    _parent.onBeforeDocumentClipboardCopyBase(new MMEventArgs(m_documentEventBefore, _doc));
                _doc = null;
            }

            if (eventFlag == EventDocumentClipboardPaste)
            {
                MapCompanion.paste = true;
                _doc = null;
            }

            _doc = null;
        }

        private static void FillSubtopicsRecursive(Topic aTopic, ref List<string> pGuids) //TODO needed?
        {
            if (aTopic == null)
                return;
            pGuids.Add(aTopic.Guid);
            foreach (Topic _topic in aTopic.AllSubTopics)
                FillSubtopicsRecursive(_topic, ref pGuids);
        }

        public static void Subscribe(MMBase aParent)
        {
            if (m_parent.Contains(aParent))
                return;
            m_parent.Add(aParent);
        }

        public static void Unsubscribe(MMBase aParent)
        {
            if (!m_parent.Contains(aParent))
                return;
            m_parent.Remove(aParent);
        }

        public static string GetTargetType(Object aTarget)
        {
            if (aTarget == null)
                return "null";
            if (aTarget is Topic)
                return "topic";
            if (aTarget is Document)
                return "document";
            if (aTarget is KeyEventArgs)
                return "key";
            return "";
        }

        public static void Destroy()
        {
            m_timer200.Stop();
            m_timer200.Tick -= m_timer200_Tick;
            m_timer200 = null;

            closeMap_timer.Stop();
            closeMap_timer.Tick -= MapClose_timer_Tick;
            closeMap_timer = null;

            openMap_timer.Stop();
            openMap_timer.Tick -= MapOpen_timer_Tick;
            openMap_timer = null;

            m_documentEventBefore.Fire -= m_documentEventBefore_Fire;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(m_documentEventBefore);
            m_documentEventBefore = null;

            m_documentEventAfter.Fire -= m_documentEventAfter_Fire;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(m_documentEventAfter);

            foreach (DocumentStorage item in SDocs)
            {
                item.Sdoc = null;
                item._mc.Dispose();
            }
            SDocs.Clear();
        }

        public string MGuid { get; set; }
        public string MStorage { get; set; }
        public string MProcess { get; set; }
        public string MSite { get; set; }
        public string MStatus { get; set; }
        public Document Sdoc { get; set; }
        public MapCompanion _mc { get; set; }
        public static List<DocumentStorage> SDocs = new List<DocumentStorage>();

        protected static Event m_documentEventBefore = null;
        protected static Event m_documentEventAfter = null;

        public static Timer m_timer200 = null;
        protected static Timer closeMap_timer = null;
        protected static Timer openMap_timer = null;

        public const int EventObjectAdded = 1;                      // + object
        public const int EventObjectDeleted = 2;                    // - object
        public const int EventObjectModified = 4;                   // + object
        public const int EventDocumentAdded = 8;                    // + after
        public const int EventDocumentOpened = 16;                  // + after
        public const int EventDocumentSaved = 32;                   // + before
        public const int EventDocumentClosed = 64;                  // + before
        public const int EventDocumentActivated = 128;              // + after
        public const int EventDocumentDeactivated = 256;            // - after
        public const int EventDocumentViewModeChanged = 512;        // - after
        public const int EventDocumentStyleAssigned = 1024;         // - after
        public const int EventDocumentSelectionChanged = 2048;      // - after
        public const int EventDocumentClipboardCopy = 8192;         // + before
        public const int EventDocumentClipboardPaste = 16384;       // + before
        public const int EventDocumentClipboardDrag = 32768;        // + before
        public const int EventDocumentClipboardDrop = 65536;        // + before
        public const int EventDocumentMapMarkersAssigned = 131072;  // - after
        public const int EventDocumentStyleModified = 262144;       // - after
        public const int EventBeforeObjectDeleted = 524288;         // + object
        public const int EventDocumentProgressiveLoadingFinished = 1048576; // - after
        public const int EventDocumentCommandScope = 2097152;               // - after
        //public const int EventDocumentCoeditingInitialized = 0;             // ? from connect ?
        //public const int EventDocumentReadOnlyChanged = 0;                  // ?
        public const int Event__All = 4194303;

        public static List<MMBase> m_parent = null;

        public static string aStorage = "";
        public static string aPlaceName = "";
        public static string aProjectName = "";

        private static Document docToClose = null;
        private static string docToOpen = "";
        private static string docToCopy = "";

        public static bool reopenmap = true;
        private static bool reopentimer = false;
        public static bool closeMap = false;
        public static bool openMap = false;
    }
}
