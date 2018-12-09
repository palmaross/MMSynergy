using System;
using System.IO;
using System.Security.Permissions;

namespace SynManager
{
    // When finish, will be completely destroyed in Maps.cs Destroy
    internal class Watchers : Object, IDisposable
    {
        public Watchers(string mapsharefolder, string mapfolder, string projectfolder)
        {
            WatchMapFolder(mapfolder);
            WatchShareFolder(mapsharefolder);

            if (projectfolder != "")
                WatchProject(projectfolder);
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private void WatchProject(string watch_folder)
        {
            wProject.Path = watch_folder;
            wProject.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            wProject.IncludeSubdirectories = false;
            // What files to watch
            wProject.Filter = "*.*";

            wProject.Changed += new FileSystemEventHandler(wpOnChanged);
            wProject.Created += new FileSystemEventHandler(wpOnChanged);
            wProject.Deleted += new FileSystemEventHandler(wpOnChanged);
            //watcher.Renamed += new RenamedEventHandler(OnRenamed);
            wProject.Error += new ErrorEventHandler(OnError);

            // Begin watching
            wProject.EnableRaisingEvents = true;
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private void WatchMapFolder(string watch_folder)
        {
            wMapFolder.Path = watch_folder;
            wMapFolder.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            wMapFolder.IncludeSubdirectories = false;
            // What files to watch
            wMapFolder.Filter = "*.*";

            //wMapFolder.Changed += new FileSystemEventHandler(mfOnChanged);
            wMapFolder.Created += new FileSystemEventHandler(mfOnChanged);
            wMapFolder.Deleted += new FileSystemEventHandler(mfOnChanged);
            //watcher.Renamed += new RenamedEventHandler(OnRenamed);
            wMapFolder.Error += new ErrorEventHandler(OnError);

            // Begin watching
            wMapFolder.EnableRaisingEvents = true;
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private void WatchShareFolder(string watch_folder)
        {
            wShareFolder.Path = watch_folder;
            wShareFolder.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName; // | NotifyFilters.DirectoryName;
            wShareFolder.IncludeSubdirectories = false;

            // What files to watch
            wShareFolder.Filter = "*.txt";

            wShareFolder.Created += new FileSystemEventHandler(sfOnChanged);
            wShareFolder.Error += new ErrorEventHandler(OnError);

            // Begin watching
            wShareFolder.EnableRaisingEvents = true;
        }

        // Event handler for Project
        private void wpOnChanged(object source, FileSystemEventArgs e)
        {
            string _path = e.FullPath;
            string _whathappen = e.ChangeType.ToString().ToLower(); // "created" or "deleted" or "changed"
        }

        // Event handler for MapFolder
        private void mfOnChanged(object source, FileSystemEventArgs e)
        {
            string _username = Path.GetFileNameWithoutExtension(e.FullPath);
            string _whathappen = e.ChangeType.ToString().ToLower(); // "created" or "deleted" or "changed"

            FileInfo f = new FileInfo(e.FullPath);

            if (f.Extension.Equals(".online"))
            {
                string _conflict = MMUtils.GetString("cloud.conflict.text");

                if (_username.ToLower().IndexOf(_conflict) != -1)
                {
                    f.Delete();
                    f = null;
                    return;
                }

                if (_whathappen == "created")
                {
                    foreach (Timers _item in Maps.MapsGroup.TIMERS)
                        if (_item.m_Guid == aMapGuid)
                        {
                            if (!_item.UsersOnline.Contains(_username))
                                _item.UsersOnline.Add(_username);

                            string rr = MMUtils.ActiveDocument.FullName;
                            string ss = doc.FullName;

                            if (rr == ss) // active map
                            {
                                _item.refresh = true;
                                //_item.refreshIndicator_timer.Start();   
                            }
                            break;
                        }
                }

                if (_whathappen == "deleted")
                {
                    foreach (Timers _item in Maps.MapsGroup.TIMERS)
                        if (_item.m_Guid == aMapGuid)
                        {
                            if (_item.UsersOnline.Contains(_username))
                                _item.UsersOnline.Remove(_username);

                            string rr = MMUtils.ActiveDocument.FullName;
                            string ss = doc.FullName;

                            if (rr == ss) // active map
                            {
                                Maps.MapUsersDlg.users = _item.UsersOnline;
                                _item.refresh = true;
                                //_item.refreshIndicator_timer.Start();                              
                            }
                            break;
                        }
                }
            }

            if (f.Extension.Equals(".locker"))
            {

            }

            f = null;
        }

        // Event handler for Share folder
        private void sfOnChanged(object source, FileSystemEventArgs e)
        {
            //ThreadPool.QueueUserWorkItem((o) => ProcessFile(e));
            string _path = e.FullPath;
            string _filename = Path.GetFileNameWithoutExtension(_path);
            int a = _filename.IndexOf("&") + 1;
            string _user = _filename.Substring(a);

            if (_user == SUtils.currentUserName || SUtils.currentUserName == "")
                return;

            System.Threading.Thread.Sleep(100); // иначе файл не успевает освободится и в ReceiveChanges : System.IO.StreamReader 
                                               // происходит exeption (занят другим процессом)
            Changes.ReceiveChanges.GetChanges(doc, _path);
        }

        //private static void OnRenamed(object source, RenamedEventArgs e)
        //{
        //    string _oldPath = e.OldFullPath;
        //    string _path = e.FullPath;
        //    string _whathappen = e.ChangeType.ToString().ToLower(); // "renamed"
        //}

        private void ProcessFile(FileSystemEventArgs e)
        {

        }

        private void OnError(object source, ErrorEventArgs e)
        {
            //  Show that an error has been detected.
            System.Windows.Forms.MessageBox.Show("The FileSystemWatcher has detected an error");
            //  Give more information if the error is due to an internal buffer overflow.
            if (e.GetException().GetType() == typeof(InternalBufferOverflowException))
            {
                //  This can happen if Windows is reporting many file system events quickly 
                //  and internal buffer of the  FileSystemWatcher is not large enough to handle this
                //  rate of events. The InternalBufferOverflowException error informs the application
                //  that some of the file system events are being lost.
                System.Windows.Forms.MessageBox.Show(("The file system watcher experienced an internal buffer overflow: " + e.GetException().Message));
            }
        }

        ~Watchers()
		{
			Dispose();
		}
	
        public void Dispose()
        {
            wShareFolder.Dispose();
            wMapFolder.Dispose();
            wProject.Dispose();

            doc = null;
        }

        public FileSystemWatcher wShareFolder = new FileSystemWatcher();
        public FileSystemWatcher wMapFolder = new FileSystemWatcher();
        public FileSystemWatcher wProject = new FileSystemWatcher();

        public Mindjet.MindManager.Interop.Document doc { get; set; }
        public string aMapGuid { get; set; }
    }
}
