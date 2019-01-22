using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Permissions;
using System.Windows.Forms;
using Maps;

namespace SynManager
{
    // When finish, will be completely destroyed in Maps.cs Destroy
    internal class Watchers : Object, IDisposable
    {
        public Watchers(string folder)
        {
            WatchSharedFolder(folder);
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private void WatchSharedFolder(string watch_folder)
        {
            wSharedFolder.Path = watch_folder;
            wSharedFolder.NotifyFilter = NotifyFilters.DirectoryName;
            wSharedFolder.IncludeSubdirectories = true;

            // What files to watch
            //wSharedFolder.Filter = "*.txt";

            wSharedFolder.Created += new FileSystemEventHandler(OnChanged);
            wSharedFolder.Deleted += new FileSystemEventHandler(OnChanged);
            wSharedFolder.Renamed += new RenamedEventHandler(OnRenamed);
            wSharedFolder.Error += new ErrorEventHandler(OnError);

            wSharedFile.Path = watch_folder;
            wSharedFile.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName;
            wSharedFile.IncludeSubdirectories = true;

            wSharedFile.Created += new FileSystemEventHandler(OnChanged);
            wSharedFile.Deleted += new FileSystemEventHandler(OnChanged);
            wSharedFile.Changed += new FileSystemEventHandler(OnChanged);
            wSharedFile.Renamed += new RenamedEventHandler(OnRenamed);
            wSharedFile.Error += new ErrorEventHandler(OnError);

            // Begin watching
            wSharedFolder.EnableRaisingEvents = true;
            wSharedFile.EnableRaisingEvents = true;
        }

        // Event handler for shared folder
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            foreach (string item in MyFiles)
                if (MyFiles.Contains(e.FullPath))
                {
                    // It's me who created, deleted or changed file or folder.
                    MyFiles.Remove(item);
                    return;
                }
            System.Threading.ThreadPool.QueueUserWorkItem((o) => ProcessFile(e, source == wSharedFolder));
        }

        private void OnRenamed(object source, RenamedEventArgs e)
        {
            foreach (string item in MyFiles)
                if (MyFiles.Contains(e.FullPath))
                {
                    // It's me who renamed file or folder.
                    MyFiles.Remove(item);
                    return;
                }
            System.Threading.ThreadPool.QueueUserWorkItem((o) => ProcessFile(e, source == wSharedFolder));
        }

        private void ProcessFile(FileSystemEventArgs e, bool folder)
        {
            string _whathappen = e.ChangeType.ToString().ToLower();
            string _path = e.FullPath.ToLower();
            string[] dirs;
            DirectoryInfo di = new DirectoryInfo(_path);
            string _parentDir = di.Parent.ToString();

            if (folder) // folder affected
            {
                switch (_whathappen)
                {
                    case "renamed":
                        dirs = Directory.GetDirectories(_path, SearchOption.AllDirectories.ToString());
                                                    // TODO exeptions!!
                        foreach (string dir in dirs)
                        {
                            if (dir.EndsWith(".mmap"))
                            {
                                // поправить соотв. нод в Synergy Explorer и путь в нем
                                // изменить путь к карте в БД документов
                                // в таймере карты изменения? - если она открыта в данный момент
                            }
                            else
                            {
                                // поправить соотв. ноды в Synergy Explorer и пути в них
                                // во всех картах (если есть) поправить пути в БД
                                // в таймерах этих карт изменения? - если они открыта в данный момент
                            }
                        }
                        break;

                    case "created":
                        // найти соотв. родительский нод в Synergy Explorer и перестроить его
                        using (SynergyExplorerDlg _dlg = new SynergyExplorerDlg())
                            foreach (TreeNode _node in _dlg.treeView1.Nodes)
                            {
                                if ((_node.Tag as TreeViewItem).m_path == _parentDir)
                                {
                                    _dlg.FillFoldersRecursive(_node, _parentDir, "", "", "");
                                    break;
                                }
                            }
                        break;

                    case "deleted":
                        dirs = Directory.GetDirectories(_path, SearchOption.AllDirectories.ToString());
                                                    // TODO exeptions!!
                        foreach (string dir in dirs)
                        {
                            if (dir.EndsWith(".mmap"))
                            {
                                
                            }
                            else
                            {
                                
                            }
                        }
                        break;
                }
            }
            else // file affected
            {
                switch (_whathappen)
                {
                    case "renamed":

                        break;

                    case "created":

                        break;

                    case "deleted":

                        break;
                    case "changed":

                        break;
                }
            }
        }

        private void OnError(object source, ErrorEventArgs e)
        {
            //  Show that an error has been detected.
            MessageBox.Show("The FileSystemWatcher has detected an error");
            //  Give more information if the error is due to an internal buffer overflow.
            if (e.GetException().GetType() == typeof(InternalBufferOverflowException))
            {
                //  This can happen if Windows is reporting many file system events quickly 
                //  and internal buffer of the  FileSystemWatcher is not large enough to handle this
                //  rate of events. The InternalBufferOverflowException error informs the application
                //  that some of the file system events are being lost.
                MessageBox.Show(("The file system watcher experienced an internal buffer overflow: " + e.GetException().Message));
            }
        }

        ~Watchers()
		{
			Dispose();
		}
	
        public void Dispose()
        {
            wSharedFolder.Dispose();
            wSharedFile.Dispose();
        }

        public FileSystemWatcher wSharedFolder = new FileSystemWatcher();
        public FileSystemWatcher wSharedFile = new FileSystemWatcher();

        List<string> MyFiles = new List<string>();
    }

    // Class for opened synergy maps
    internal class MapWatchers : Object, IDisposable
    {
        public MapWatchers(string mapfolder)
        {
            WatchMapFolder(mapfolder);
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private void WatchMapFolder(string watch_folder)
        {
            wMapFolder.Path = watch_folder;
            wMapFolder.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName;
            wMapFolder.IncludeSubdirectories = false;

            //wMapFolder.Changed += new FileSystemEventHandler(mfOnChanged);
            wMapFolder.Created += new FileSystemEventHandler(OnChanged);
            wMapFolder.Deleted += new FileSystemEventHandler(OnChanged);
            wMapFolder.Error += new ErrorEventHandler(OnError);
            // Begin watching
            wMapFolder.EnableRaisingEvents = true;
        }

        // Event handler for MapFolder
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            //if (Path.GetExtension(e.FullPath).ToLower().ToString() == ".mmap")
            //    return;
            System.Threading.ThreadPool.QueueUserWorkItem((o) => ProcessFile(e)); //, Path.GetDirectoryName(e.FullPath) == "Share"));                                                                               // true = changes in Share folder
        }

        private void ProcessFile(FileSystemEventArgs e)
        {
            FileInfo f = new FileInfo(e.FullPath);

            if (f.Extension.Equals(".mc")) // process map changes
            {
                string _filename = Path.GetFileNameWithoutExtension(e.FullPath);
                int a = _filename.IndexOf("&") + 1;
                string _user = _filename.Substring(a);

                if (_user == SUtils.currentUserName || SUtils.currentUserName == "")
                    return;

                System.Threading.Thread.Sleep(100); // иначе файл не успевает освободится и в ReceiveChanges : System.IO.StreamReader 
                                                    // происходит exeption (занят другим процессом)
                Changes.ReceiveChanges.GetChanges(doc, e.FullPath);
                return;
            }

            // process users 
            string _whathappen = e.ChangeType.ToString().ToLower(); // "created" or "deleted" or "changed"

            if (f.Extension.Equals(".online"))
            {
                string _username = Path.GetFileNameWithoutExtension(e.FullPath);

                // Conflict in cloud storage
                if (_username.ToLower().Contains(MMUtils.GetString("cloud.conflict.text")))
                {
                    f.Delete();
                    return;
                }

                foreach (MapTimers _item in MapsGroup.TIMERS)
                {
                    if (_item.m_Guid == MapGuid)
                    {
                        if (!_item.UsersOnline.Contains(_username))
                        {
                            if (_whathappen == "created")
                                _item.UsersOnline.Add(_username);
                            if (_whathappen == "deleted")
                                _item.UsersOnline.Remove(_username);
                        }
                        if (MMUtils.ActiveDocument.FullName == doc.FullName) // active map
                        {
                            MapUsersDlg.users = _item.UsersOnline;
                            _item.RefreshIndicator = true;
                        }
                        break;
                    }
                }
            }

            if (f.Extension.Equals(".locker"))
            {
                string _username = Path.GetFileNameWithoutExtension(e.FullPath);

                // Conflict in cloud storage
                if (_username.ToLower().Contains(MMUtils.GetString("cloud.conflict.text")))
                {
                    f.Delete();
                    return;
                }
            }

            f = null;
        }

        // TODO !!!
        private void OnError(object source, ErrorEventArgs e)
        {
            //  Show that an error has been detected.
            MessageBox.Show("The FileSystemWatcher has detected an error");
            //  Give more information if the error is due to an internal buffer overflow.
            if (e.GetException().GetType() == typeof(InternalBufferOverflowException))
            {
                //  This can happen if Windows is reporting many file system events quickly 
                //  and internal buffer of the  FileSystemWatcher is not large enough to handle this
                //  rate of events. The InternalBufferOverflowException error informs the application
                //  that some of the file system events are being lost.
                MessageBox.Show(("The file system watcher experienced an internal buffer overflow: " + e.GetException().Message));
            }
        }

        ~MapWatchers()
        {
            Dispose();
        }

        public void Dispose()
        {
            wMapFolder.Dispose();
            doc = null;
        }

        public FileSystemWatcher wMapFolder = new FileSystemWatcher();

        public Mindjet.MindManager.Interop.Document doc { get; set; }
        public string MapGuid { get; set; }
        //public string MapPath { get; set; }
    }
}
