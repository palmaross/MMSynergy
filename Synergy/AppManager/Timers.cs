using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Mindjet.MindManager.Interop;
using System.IO;

namespace SynManager
{
    // When finish, will be completely destroyed in Maps.cs Destroy
    internal class Timers
    {
        public Timers(int _secToSaveMap, int _secToWait, int _minLockTime)
        {
            secToSaveMap = _secToSaveMap;
            secToWait = _secToWait;
            minLockTime = _minLockTime;

            saveMap_timer = new Timer() { Interval = 1000 * secToSaveMap };
            saveMap_timer.Tick += new EventHandler(SaveMap_timer_Tick);

            checkOnlineUsers_timer = new Timer() { Interval = 60000 * 5 }; // 5 min
            checkOnlineUsers_timer.Tick += new EventHandler(CheckOnlineUsers_timer_Tick);

            waitOnline_timer = new Timer() { Interval = 1000 * secToWait };
            waitOnline_timer.Tick += new EventHandler(WaitOnline_timer_Tick);

            IP_timer = new Timer() { Interval = 60000 * 2 }; // 2 min
            IP_timer.Tick += new EventHandler(IP_timer_Tick);

            lock_timer = new Timer() { Interval = minLockTime * 60000 };
            lock_timer.Tick += new EventHandler(Lock_timer_Tick);

            refreshIndicator_timer = new Timer() { Interval = 5000 };
            refreshIndicator_timer.Tick += new EventHandler(RefreshIndicator_timer_Tick);
        }

        // TODO а если это оффлайн и пр. карта??
        /// <summary>
        /// Save map every N seconds
        /// Remove map versions but three last
        /// Remove waste files in share folder
        /// </summary>
        private void SaveMap_timer_Tick(object sender, EventArgs e)
        {
            if (doc == null)
                return; // TODO 

            if (!doc.IsModified) 
                return;

            doc.Save();

            string lastwrite = File.GetLastWriteTimeUtc(m_LocalPath).ToString("yyyyMMddHHmmssfff");
            string _docpath = m_PlacePath + lastwrite + ".mmap";

            try
            {
                File.Copy(m_LocalPath, _docpath); // copy as file, don't save (because of map links)!
            }
            catch (Exception _e)
            {
                System.Windows.Forms.MessageBox.Show("Exception: " + _e.Message, "Timers:SaveMap_timer_Tick");
                return;
            }

            string[] files = Directory.GetFiles(m_PlacePath, "*.mmap");

            /////// Delete map versions but three last.
            for (int i = 0; i <= files.Count() - 4; i++)
            {
                try
                {
                    File.Delete(files[i]);
                }
                catch { }
            }

            /////// Delete waste files in share folder.
            long _timetodelete = Convert.ToInt64(DateTime.UtcNow.AddSeconds(secToSaveMap * -2).ToString("yyyyMMddHHmmssfff"));

            // All files! .txt and other, shared with map links
            string[] sharefiles = Directory.GetFiles(m_PlacePath + "share", "*");

            foreach (string sharefile in sharefiles)
            {
                string _filename = Path.GetFileNameWithoutExtension(sharefile);
                long _sharetime = 0;
                int a = _filename.IndexOf("&");

                if (a == -1)
                    Int64.TryParse(_filename, out _sharetime);
                else
                    Int64.TryParse(_filename.Substring(0, _filename.IndexOf("&")), out _sharetime);

                if (_sharetime == 0 || _sharetime < _timetodelete)
                {
                    try
                    {
                        File.Delete(sharefile);
                    }
                    catch { }
                }
            }
        }

        private void WaitOnline_timer_Tick(object sender, EventArgs e)
        {
            waitOnline_timer.Stop();

            if (Internet.CheckInternetAndProcess(m_Guid, m_Storage, m_Process, m_Site, m_PlacePath, "wait_timer") != "")
                return;

            MessageBox.Show(String.Format(MMUtils.GetString("internet.maponline.message"), doc.Name), 
                MMUtils.GetString("internet.maponline.caption"));

            string _lastfile = Directory.GetFiles(m_PlacePath, "*.mmap").Last().ToString();
            long placemap_time = Convert.ToInt64(Path.GetFileNameWithoutExtension(_lastfile));

            DocumentStorage.closeMap = true;
            doc.Close();

            File.SetAttributes(m_LocalPath, System.IO.FileAttributes.Normal);

            // Get last copy from Place
            if (placemap_time > m_FrozenTime)
            {
                File.Copy(_lastfile, m_LocalPath, true);                
            }
            // Or return frozen file
            else
            {
                File.Copy(m_FrozenPath, m_LocalPath, true);
            }

            DocumentStorage.openMap = true;
            MMUtils.MindManager.AllDocuments.Open(m_LocalPath);
            doc = MMUtils.ActiveDocument;

            m_Status = "online";
            GetOnlineUsers();

            DocumentStorage.Sync(doc, true, m_PlacePath); // subscribe map

            Watchers WW = new Watchers(m_PlacePath + "share", m_PlacePath, "") // TODO project path!
            {
                doc = doc,
                aMapGuid = m_Guid
            };
            Maps.MapsGroup.WATCHERS.Add(WW);

            SUtils.GetChanges(doc);

            saveMap_timer.Start();
            checkOnlineUsers_timer.Start();
            refreshIndicator_timer.Start();

            if (doc == MMUtils.ActiveDocument)
                refresh = true;
        }

        private void IP_timer_Tick(object sender, EventArgs e)
        {
            if (doc == null)
                return; // TODO 

            Internet.CheckInternetAndProcess(m_Guid, m_Storage, m_Process, m_Site, m_PlacePath, "IPtimer");
        }

        private void Lock_timer_Tick(object sender, EventArgs e)
        {
            
        }

        private void CheckOnlineUsers_timer_Tick(object sender, EventArgs e)
        {
            GetOnlineUsers();
        }

        private void RefreshIndicator_timer_Tick(object sender, EventArgs e)
        {
            if (doc == null)
                return; // TODO 

            if (refresh)
            {
                refresh = false;
                Maps.MapUsersDlg.users = UsersOnline;
                Maps.MapUsersDlg.status = m_Status;
                Maps.MapUsersDlg.waitTime = waitTime;

                Maps.MapsGroup.dlgUsersOnline.Visible = false;
                Maps.MapsGroup.dlgUsersOnline.Show(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd));
            }
        }

        public void GetOnlineUsers()
        {
            if (m_Status != "online")
                return;

            UsersOnline.Clear();

            DateTime _utcnow = DateTime.UtcNow;
            string _currentuser = m_PlacePath + SUtils.currentUserName + ".online";

            StreamWriter sw = null;
            try
            {
                if (File.Exists(_currentuser))
                    sw = new StreamWriter(_currentuser);
                else
                    sw = new StreamWriter(File.Create(_currentuser));

                sw.Write(_utcnow.ToString(), false); // false = overwrite
                sw.Close();
            }
            catch { } // TODO 

            string[] files = Directory.GetFiles(m_PlacePath, "*.online");

            for (int i = 0; i < files.Count(); i++)
            {
                if (files[i] == _currentuser)
                    continue;

                string _user = Path.GetFileNameWithoutExtension(files[i]);

                try
                {
                    StreamReader sr = new StreamReader(files[i]);
                    DateTime _time = Convert.ToDateTime(sr.ReadLine()).AddMinutes(10);
                    sr.Close();

                    if (_time < _utcnow)
                        File.Delete(files[i]); // user will be removed via Watcher
                    else
                        UsersOnline.Add(_user);

                }
                catch { } // TODO 
            }
        }
            
        public void Destroy()
        {
            saveMap_timer.Stop();
            saveMap_timer.Tick -= SaveMap_timer_Tick;
            saveMap_timer = null;

            checkOnlineUsers_timer.Stop();
            checkOnlineUsers_timer.Tick -= CheckOnlineUsers_timer_Tick;
            checkOnlineUsers_timer = null;         

            waitOnline_timer.Stop();
            waitOnline_timer.Tick -= WaitOnline_timer_Tick;
            waitOnline_timer = null;

            IP_timer.Stop();
            IP_timer.Tick -= IP_timer_Tick;
            IP_timer = null;

            lock_timer.Stop();
            lock_timer.Tick -= Lock_timer_Tick;
            lock_timer = null;

            refreshIndicator_timer.Stop();
            refreshIndicator_timer.Tick -= RefreshIndicator_timer_Tick;
            refreshIndicator_timer = null;

            doc = null;
            UsersOnline.Clear();
        }

        public Timer checkOnlineUsers_timer = null; // confirm current user online state and check rest users if they are online
        public Timer waitOnline_timer = null; // to wait Synergy maps set online after "karantin"
        public Timer saveMap_timer    = null; // to save opened Synergy map every N seconds
        public Timer IP_timer         = null; // IP = Internet & Process
        public Timer lock_timer       = null; // time to unlock map
        public Timer refreshIndicator_timer = null;

        public Document doc = null;

        public string m_LocalPath { get; set; }
        public string m_PlacePath { get; set; } // path to map folder in its Place
        public long m_FrozenTime { get; set; }
        public string m_FrozenPath { get; set; }

        public int secToSaveMap = 110;
        public int secToWait = 110;
        public int minLockTime = 1;
        public string unLockTime { get; set; }
        public string waitTime { get; set; }

        public string m_Guid { get; set; }
        public string m_Storage { get; set; }
        public string m_Process { get; set; }
        public string m_Site { get; set; }
        //public string m_OfflineCause { get; set; }

        public string m_Status { get; set; }

        public List<string> UsersOnline = new List<string>();
        public string MapBlocker { get; set; }

        public bool refresh { get; set; }
    }
}
