using System;
using System.Collections.Generic;
using System.Linq;
using Mindjet.MindManager.Interop;
using System.IO;
using System.Collections;
using System.Data;

namespace SynManager
{
    internal class SUtils : MMEnums // Synergy Utilites
    {
        /////// Synergy attributes /////////

        public const string SYNERGYNAMESPACE = "PALMAROSS$$SYNERGY";
        public const string SYNERGYMESSAGE = "SYNERGY$$MESSAGE";
        public const string rollupuri = "http://schemas.iaresearch.com/JCVGantt";
        public const string numberinguri = "http://schemas.mindjet.com/MindManager/Mm5Numbering/2003";

        // Map's Attrs
        public const string MGUID = "MGUID"; // map guid
        public const string MATTRS = "MPUBATTRS"; // map guid
        // Topic's Attrs
        public const string OGUID = "OGUID"; // object guid
        public const string TADDED = "TADDED"; // topic added datetime
        public const string TMODIFIED = "TMODIFIED"; // topic last modified datetime

        public static void ProcessRelationship(Relationship r, string _path, string what)
        {
            string Guid1, Guid2;

            Boundary b1 = r.ConnectedObject1 as Boundary;
            Boundary b2 = r.ConnectedObject2 as Boundary;

            if (r.ConnectedObject1 is Topic t1)
                Guid1 = t1.get_Attributes(SUtils.SYNERGYNAMESPACE).GetAttributeValue(SUtils.OGUID);
            else
                Guid1 = b1.get_Attributes(SUtils.SYNERGYNAMESPACE).GetAttributeValue(SUtils.OGUID);

            if (r.ConnectedObject2 is Topic t2)
                Guid2 = t2.get_Attributes(SUtils.SYNERGYNAMESPACE).GetAttributeValue(SUtils.OGUID);
            else
                Guid2 = b2.get_Attributes(SUtils.SYNERGYNAMESPACE).GetAttributeValue(SUtils.OGUID);

            float CX1=0, CX2=0, CY1=0, CY2=0;
            if (what != "relationship:add")
                r.GetControlPoints (out CX1, out CY1, out CX2, out CY2); //TODO что-то не плавающие они, а integer...

            if (what != "relationship:modify")
                TransactionsWrapper.SetAttributes(r, r.Guid);

            try
            {
                StreamWriter sw = new StreamWriter(File.Create(_path));
                sw.WriteLine(what);
                sw.WriteLine(r.get_Attributes(SUtils.SYNERGYNAMESPACE).GetAttributeValue(SUtils.OGUID));
                sw.WriteLine(Guid1);
                sw.WriteLine(Guid2);
                //end if added new relationship
                if (what == "relationship:paste" || what == "relationship:modify")
                {
                    sw.WriteLine(CX1.ToString());
                    sw.WriteLine(CY1.ToString());
                    sw.WriteLine(CX2.ToString());
                    sw.WriteLine(CY2.ToString());
                    sw.WriteLine(r.Shape1);
                    sw.WriteLine(r.Shape2);
                    sw.WriteLine(r.LineColor.Value);
                    sw.WriteLine(r.LineDashStyle);
                    sw.WriteLine(r.LineShape);
                    sw.WriteLine(r.LineWidth);
                    sw.WriteLine(r.AutoRouting);
                }
                sw.Close();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Exception: " + e.Message, "SUtils:ProcessRelationship"); //TODO
            }
            finally
            {
                t1 = null; t2 = null; b1 = null; b2 = null; 
            }
        }

        public static void ProcessBoundary(Boundary b, string _path, string what)
        {
            Topic t = b.Topic;
            string _tguid = t.get_Attributes(SUtils.SYNERGYNAMESPACE).GetAttributeValue(SUtils.OGUID);
            TransactionsWrapper.SetAttributes(b, b.Guid);
            t = null;

            string s = b.Shape.ToString(); // boundary:add
            if (what == "boundary:modify")
            {
                s = s + ";" + 
                b.FillColor.Value.ToString() + ";" +
                b.LineColor.Value.ToString() + ";" +
                b.LineDashStyle.ToString() + ";" +
                b.LineWidth.ToString();
            }

            try
            {
                StreamWriter sw = new StreamWriter(File.Create(_path));
                sw.WriteLine(what);
                sw.WriteLine(_tguid);
                sw.WriteLine(s);
                sw.WriteLine(b.get_Attributes(SUtils.SYNERGYNAMESPACE).GetAttributeValue(SUtils.OGUID));
                sw.Close();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Exception: " + e.Message, "SUtils:ProcessBoundary"); //TODO поточнее ошибку!
            }
        }

        public static void SaveRelationships(Topic t) // TODO needed? release objects!
        {
            SavedRelationships = new ArrayList[t.AllRelationships.Count]; //array of lists, one list for each relationship
            int i = 0;
            foreach (Relationship r in t.AllRelationships)
            {
                SavedRelationships[i] = new ArrayList();  //i - list number in the array             
                Topic t1 = r.ConnectedObject1 as Topic;
                Topic t2 = r.ConnectedObject2 as Topic;
                SavedRelationships[i].Add(t1); //0
                SavedRelationships[i].Add(t2); //1
                SavedRelationships[i].Add(r.get_Attributes(SUtils.SYNERGYNAMESPACE).GetAttributeValue(SUtils.OGUID)); //2
                r.GetControlPoints(out float CX1, out float CY1, out float CX2, out float CY2);
                SavedRelationships[i].Add(CX1); //3-6
                SavedRelationships[i].Add(CY1);
                SavedRelationships[i].Add(CX2);
                SavedRelationships[i].Add(CY2);
                SavedRelationships[i].Add(r.Shape1); //7
                SavedRelationships[i].Add(r.Shape2); //8
                SavedRelationships[i].Add(r.LineColor.Value); //9
                SavedRelationships[i].Add(r.LineDashStyle); //10
                SavedRelationships[i].Add(r.LineShape); //11
                SavedRelationships[i].Add(r.LineWidth); //12
                SavedRelationships[i].Add(r.AutoRouting); //13
                SavedRelationships[i].Add("end"); //14
                //callouts if any + their offsets
                foreach (Topic callout in r.AllCalloutTopics)
                {
                    SavedRelationships[i].RemoveAt(SavedRelationships[i].Count - 1); //remove "end"
                    SavedRelationships[i].Add(callout.Xml);
                    callout.GetOffset(out float x, out float y);
                    SavedRelationships[i].Add(x);
                    SavedRelationships[i].Add(y);
                    SavedRelationships[i].Add("end");
                }
                i++;
            }
        }

        public static void RestoreRelationships(Topic t) // TODO needed? release objects!
        {
            foreach (ArrayList list in SavedRelationships)
            {
                Topic t1 = list[0] as Topic;
                Topic t2 = list[1] as Topic;
                Relationship r = t1.AllRelationships.AddToTopic(t2);
                r.get_Attributes(SUtils.SYNERGYNAMESPACE).SetAttributeValue(SUtils.OGUID, list[2].ToString());
                r.SetControlPoints(Convert.ToSingle(list[3]), Convert.ToSingle(list[4]), Convert.ToSingle(list[5]), Convert.ToSingle(list[6]));
                r.Shape1 = RelationshipShape(list[7].ToString());
                r.Shape2 = RelationshipShape(list[8].ToString());
                r.LineColor.Value = Convert.ToInt32(list[9]);
                r.LineDashStyle = LineDashStyle(list[10].ToString());
                r.LineShape = LineShape(list[11].ToString());
                r.LineWidth = Convert.ToSingle(list[12]);
                r.AutoRouting = Convert.ToBoolean(list[13].ToString());
                //restore callouts
                int i = 14;
                while (list[i].ToString() != "end")
                {
                    Topic _t = r.AllCalloutTopics.Add();
                    _t.Xml = list[i++].ToString();;
                    _t.SetOffset(Convert.ToSingle(list[i++]), Convert.ToSingle(list[i++]));
                }
            }
        }

        /// <summary>
        /// Get Storage name and Process and Site if map is in cloud storage
        /// </summary>
        /// <returns>
        /// true:  map is in cloud storage; get refs
        /// false: otherwise
        /// </returns>
        public static void GetMapData(string mapGuid, ref string aStorage, ref string aProcess, 
            ref string aSite, ref string aPath, ref string aPlaceName)
        {
            using (MapsDB _db = new MapsDB())
            {
                DataTable _dt = _db.ExecuteQuery("select * from MAPS where MAPGUID=`" + mapGuid + "`");
                if (_dt.Rows.Count != 0)
                {
                    aStorage = _dt.Rows[0]["STORAGE"].ToString();
                    aPath = _dt.Rows[0]["FOLDERPATH"].ToString();
                    aPlaceName = _dt.Rows[0]["PLACENAME"].ToString();
                }
            }

            if (aStorage == "ND")
                return;
        }

        /// <summary>
        /// Set map timers and watchers
        /// </summary>
        /// <param name="_doc">Map to process</param>
        /// <returns>fail</returns>
        public static string ProcessMap(Document _doc)
        {
            string _guid = SynergyMapGuid(_doc);
            string _storage = "", _process = "", _site = "",
            mapfolderpath = "", // full path to map folder in its Place
            _placename = "",        // place name - for Frozen Path
            _mapblocker = "",       // who blocks the map
            _unlocktime = "",       // hh:mm when map will be unlocked
            fail = "";

            int _secToSaveMap = 105, _secToWait = 100, _minLockTime = 1;

            string _docName = _doc.Name;
            FileInfo file = new FileInfo(_doc.FullName);
            float fileMBytesSize = file.Length / 1048576;
            file = null;

            _secToSaveMap = _secToSaveMap + Convert.ToInt32(fileMBytesSize * 15);
            _secToWait = _secToSaveMap + Convert.ToInt32(fileMBytesSize * 20);

            GetMapData(_guid, ref _storage, ref _process, ref _site, ref mapfolderpath, 
                ref _placename);

            if (mapfolderpath == "" || _placename == "")
                return "nomap";

            // TODO check if map is locked
            string blockerPath = mapfolderpath + "info.locker";
            if (File.Exists(blockerPath))
            {
                string _datetime;
                StreamReader sr = new StreamReader(blockerPath);
                _mapblocker = sr.ReadLine().Trim();
                _datetime = sr.ReadLine();
                _minLockTime = Convert.ToInt32(sr.ReadLine().Trim());
                sr.Close();

                // TODO UTC??
                DateTime.TryParse(_datetime, out DateTime _lockedtime);
                TimeSpan timeleft = _lockedtime.AddMinutes(_minLockTime) - DateTime.UtcNow;
                _minLockTime = timeleft.Minutes;
                _unlocktime = DateTime.UtcNow.AddMinutes(_minLockTime).ToLocalTime().ToString(); // hh:mm

                if (_minLockTime < 0) // время блокировки истекло
                {
                    _minLockTime = 1;
                    _mapblocker = "";
                    File.Delete(blockerPath);
                }
            }

            string _frozenPath = MMUtils.m_SynergyTempPath + _guid + "\\";

            try
            {
                Directory.CreateDirectory(_frozenPath);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(
                    "Невозможно создать папку\n\n" + _frozenPath, "Очень плохо. Прекратить работу");
                return "path";
            }

            _frozenPath = _frozenPath + _docName;

            MapTimers timer = new MapTimers(_secToSaveMap, _secToWait, _minLockTime)
            {
                doc = _doc,
                m_Guid = _guid,
                m_Storage = _storage,
                m_Process = _process,
                m_Site = _site,
                m_FolderPath = mapfolderpath,
                m_UserMapPath = _doc.FullName,
                m_FrozenPath = _frozenPath,
                MapBlocker = _mapblocker,
                unLockTime = _unlocktime,
                RefreshIndicator = false
            };

            Maps.MapsGroup.TIMERS.Add(timer);

            DocumentStorage.Sync(_doc, true, mapfolderpath);

            if (_mapblocker != "")
            {
                fail = "locked";
            }
            else
            {
                fail = "";
            }

            timer.refreshIndicator_timer.Start();
            Maps.MapsGroup.CHECKTIMERS.ProcessAndNetwork_timer.Start();

            if (fail == "")
            {
                timer.m_Status = "online";
                timer.GetOnlineUsers();
                Maps.MapsGroup.CHECKTIMERS.ProcessAndNetwork_timer.Start(); // start watching for Internet & Process
                Maps.MapsGroup.CHECKTIMERS.Internet_timer.Start();
                timer.saveMap_timer.Start();
                timer.checkOnlineUsers_timer.Start();             
            }
            else
            {
                if (fail == "sitefail")
                {
                    timer.m_Status = "offline";
                }

                if (fail == "processfail")
                {
                    timer.m_Status = "offline";
                }

                if (fail == "locked")
                {
                    timer.lock_timer.Start();
                    timer.m_Status = "locked";
                }
            }

            MapWatchers MW = new MapWatchers(mapfolderpath)
                {
                    doc = _doc,
                    MapGuid = _guid
                };
            Maps.MapsGroup.MAPWATCHERS.Add(MW);

            if (_doc == MMUtils.ActiveDocument && skipActiveMap == false)
            {
                Maps.MapUsersDlg.status = timer.m_Status;

                if (timer.m_Status == "online")
                    if (timer.UsersOnline.Count > 0)
                        Maps.MapUsersDlg.users = timer.UsersOnline;

                //if (timer.m_Status == "offline")
                //{
                //    // передать причину
                //}

                if (timer.m_Status == "locked")
                {
                    Maps.MapUsersDlg.blocker = _mapblocker;
                    // передать время окончания блокировки
                }

                Maps.MapsGroup.dlgUsersOnline.Show(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd));
            }

            skipActiveMap = false;

            return fail;
        }

        /// <summary>
        /// Get ultimate changes from "share" folder
        /// </summary>
        public static void GetChanges(Document _doc)
        {
            string mapFolderPath = "";
            string mapGuid = SUtils.SynergyMapGuid(_doc);

            using (MapsDB _db = new MapsDB())
            {
                DataTable _dt = _db.ExecuteQuery("select * from MAPS where MAPGUID=`" + mapGuid + "`");
                mapFolderPath = _dt.Rows[0]["PATHTOPLACE"].ToString();
            }

            string _latestfile = Directory.GetFiles(mapFolderPath, "*.mmap").Last().ToString();
            _latestfile = Path.GetFileNameWithoutExtension(_latestfile);

            string[] files = Directory.GetFiles(mapFolderPath + "share", "*.txt");

            long _latestfiletime = Convert.ToInt64(_latestfile);

            foreach (string file in files)
            {
                string _file = Path.GetFileNameWithoutExtension(file);
                string _user = _file.Substring(_file.IndexOf("&") + 1);
                if (_user == currentUserName)
                    continue;
                long _filetime = Convert.ToInt64(_file.Substring(0, _file.IndexOf("&")));

                if (_filetime > _latestfiletime)
                    Changes.ReceiveChanges.GetChanges(_doc, file);
            }
        }

        public static void PublishMap(Document _doc)
        {
            string _attrs = TimeStamp + ";" + currentUserName + ";" + currentUserEmail;
            string aGuid = _doc.Guid;

            _doc.GetAttributes(SYNERGYNAMESPACE).SetAttributeValue(MGUID, aGuid);
            _doc.GetAttributes(SYNERGYNAMESPACE).SetAttributeValue(MATTRS, _attrs);

            foreach (Topic t in _doc.Range(MmRange.mmRangeAllTopics, true))
            {
                if (!t.ContainsAttributesNamespace(SYNERGYNAMESPACE))
                {
                    t.get_Attributes(SYNERGYNAMESPACE).SetAttributeValue(OGUID, t.Guid);
                    t.get_Attributes(SYNERGYNAMESPACE).SetAttributeValue(TADDED, _attrs);
                    t.get_Attributes(SYNERGYNAMESPACE).SetAttributeValue(TMODIFIED, _attrs);
                }

                // Все ссылки (кроме веб-ссылок и ссылок на топики) превращаем в абсолютные
                if (!singleMap && t.Hyperlinks.Count > 0)  // is project
                    foreach (Hyperlink _h in t.Hyperlinks)
                    {
                        if (_h.Address.Substring(0, 4) == "http") // link to web-page
                            continue;
                        if (_h.TopicLabelGuid != "") // link to topic
                            continue;

                        _h.Absolute = true;

                        if (!MapLinks.Contains(_h.Address))
                            MapLinks.Add(_h.Address);
                    }
            }

            foreach (Boundary b in _doc.Range(MmRange.mmRangeAllBoundaries, true))
                if (!b.ContainsAttributesNamespace(SYNERGYNAMESPACE))
                    b.get_Attributes(SYNERGYNAMESPACE).SetAttributeValue(OGUID, b.Guid);

            foreach (Relationship r in _doc.Range(MmRange.mmRangeAllRelationships, true))
                if (!r.ContainsAttributesNamespace(SYNERGYNAMESPACE))
                    r.get_Attributes(SYNERGYNAMESPACE).SetAttributeValue(OGUID, r.Guid);
        }

        public static void AttrMap(Document _doc)
        {
            string _attrs = TimeStamp + ";" + currentUserName + ";" + currentUserEmail;
            string aGuid = _doc.Guid;

            if (!_doc.ContainsAttributesNamespace(SYNERGYNAMESPACE))
            {
                _doc.GetAttributes(SYNERGYNAMESPACE).SetAttributeValue(MGUID, aGuid);
                _doc.GetAttributes(SYNERGYNAMESPACE).SetAttributeValue(MATTRS, _attrs);
            }
        }

        public static Topic FindTopicByAttrGuid(Document aDocument, string aGuid)
        {
            if (aDocument == null)
                return null;

            foreach (Topic t in aDocument.Range(MmRange.mmRangeAllTopics, true))
            {
                if (t.get_Attributes(SUtils.SYNERGYNAMESPACE).GetAttributeValue(OGUID) == aGuid)
                    return t;
            }
            return null;
        }

        public static Relationship FindRelationshipByAttrGuid(Document aDocument, string aGuid)
        {
            if (aDocument == null)
                return null;

            foreach (Relationship r in aDocument.Range(MmRange.mmRangeAllRelationships, true))
            {
                if (r.get_Attributes(SYNERGYNAMESPACE).GetAttributeValue(OGUID) == aGuid)
                    return r;
            }
            return null;
        }

        public static Boundary FindBoundaryByAttrGuid(Document aDocument, string aGuid)
        {
            if (aDocument == null)
                return null;

            foreach (Boundary b in aDocument.Range(MmRange.mmRangeAllBoundaries, true))
            {
                if (b.get_Attributes(SYNERGYNAMESPACE).GetAttributeValue(OGUID) == aGuid)
                    return b;
            }
            return null;
        }

        public static DocumentObject FindObjectByAttrGuid(Document aDocument, string aGuid)
        {
            if (aDocument == null)
                return null;

            foreach (DocumentObject obj in aDocument.Range(MmRange.mmRangeAll, true))
            {
                if (obj.get_Attributes(SYNERGYNAMESPACE).GetAttributeValue(OGUID) == aGuid)
                    return obj;
            }
            return null;
        }

        public static string SynergyMapGuid(Document doc = null)
        {
            if (doc == null)
                doc = MMUtils.ActiveDocument;

            return doc.get_Attributes(SYNERGYNAMESPACE).GetAttributeValue(MGUID);
        }

        public static List<string> MapLinks = new List<string>();

        public static string currentUserName = "";
        public static string currentUserEmail = "";
        public static string TimeStamp { get { return DateTime.UtcNow.ToString(); } }
        public static string modtime { get { return DateTime.UtcNow.ToString("yyyyMMddHHmmssfff"); } }

        //private static List<Relationship> SavedRelationships = new List<Relationship>();
        public static ArrayList[] SavedRelationships = null;

        public static string SingleMaps = MMUtils.GetString("singlemaps.text"); // "single maps"

        public static bool skipActiveMap = false;
        public static bool singleMap = false;
    }
}
