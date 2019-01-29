using System;
using System.IO;
using Microsoft.Win32;
using Mindjet.MindManager.Interop;
using System.Linq;

namespace SynManager
{
    internal class MMUtils
    {
        // Initialize Synergy folders
        protected static Application m_MindManager;
        public static Application MindManager
        {
            get
            {
                return m_MindManager;
            }
            set
            {
                m_MindManager = value;
                if (m_MindManager != null)
                {
                    m_i18n = new I18n(AddinName, Version);

                    // Initialization loop
                    string _AppDataPath = System.Environment.GetEnvironmentVariable("APPDATA");

                    m_SynergyAppDataPath = _AppDataPath + "\\PalmaRoss\\Synergy\\";
                    m_SynergyLocalPath = m_SynergyAppDataPath + "Local Storage\\";
                    m_SynergyTempPath = m_SynergyAppDataPath + "Temp\\";

                    try
                    {
                        Directory.CreateDirectory(m_SynergyAppDataPath);
                        Directory.CreateDirectory(m_SynergyTempPath);
                    }
                    catch
                    {
                        System.Windows.Forms.MessageBox.Show(
                            "Увы, работа с Synergy невозможна. Не удается создать папки по пути:\n\n" + m_SynergyAppDataPath, "Катастрофа");
                    }

                    instPath = GetRegistry("", "InstPath");
                    imagePath = instPath + "\\images\\";
                }
            }
        }

        public static string CutEOLN(string aSrc)
        {
            string _s1 = aSrc;
            int _found = _s1.IndexOf('\r');
            if (_found >= 0)
                _s1 = _s1.Substring(0, _found);
            _found = _s1.IndexOf('\n');
            if (_found >= 0)
                _s1 = _s1.Substring(0, _found);
            return _s1;
        }

        public static string GetString(string aName, string aQuote = "")
        {
            return m_i18n.getString(aName, aQuote);
        }

        public static string GetRegistry(string aPath, string aKey, string aDefValue = "")
        {
            if (aPath == "")
                aPath = "Software\\PalmaRoss\\Synergy";
            RegistryKey _rk = Registry.CurrentUser.CreateSubKey(aPath, RegistryKeyPermissionCheck.ReadSubTree);
            if (null == _rk)
                return aDefValue;
            string rc = _rk.GetValue(aKey, aDefValue).ToString();
            _rk.Close();
            return rc;
        }

        public static bool SetRegistry(string aPath, string aKey, string aValue)
        {
            if (aPath == "")
                aPath = "Software\\PalmaRoss\\Synergy";
            RegistryKey _rk = Registry.CurrentUser.CreateSubKey(aPath, RegistryKeyPermissionCheck.ReadWriteSubTree);
            if (null == _rk)
                return false;
            _rk.SetValue(aKey, aValue);
            _rk.Close();

            return true;
        }

        public static Document ActiveDocument
        {
            get
            {
                return MindManager.ActiveDocument ?? null;
            }
        }

        public static Topic FindTopicByGuid(Document aDocument, string aGuid)
        {
            if (aDocument == null)
                return null;

            return aDocument.Range(MmRange.mmRangeAllTopics, true).FindByGuid(aGuid) as Topic;
        }

        public static string getCleanTopicXML(string xml) //TODO может проработать с XML?
        {
            int n = xml.LastIndexOf("</ap:SubTopics>");
            if (n < 0) //no subtopics
            {
                n = xml.IndexOf("<ap:");
                n = xml.IndexOf("<ap:", n + 1); //we need second instance of <ap:
                return xml.Substring(n);
            }
            else
                return xml.Substring(n + 15);
        }

        public static string TShortText(string _text)
        {
            int i = _text.Length;
            _text = _text.Replace('\n', ' ');
            _text = _text.Replace('\r', ' ');

            if (i > 40)
            {
                i = _text.IndexOf(" ", 40);
                if (i == -1) i = 40;
                return _text.Substring(0, i) + "...";
            }
            else
            {
                return _text;
            }
        }

        /// <summary>
        /// Defines topic position in his parent topic branch
        /// <para>Returns topix index in a branch</para>
        /// </summary>
        /// <param name="_t">topic to set attrs</param>
        /// <returns>Topic index in a branch</returns>
        public static int SubtopicIndex(Topic _t)
        {
            int a = 1;
            Topic _tt = _t;
            while (!_tt.IsFirstSibling)
            {
                _tt = _tt.PreviousSibling;
                a++;
            }

            _tt = null;
            return a;
        }

        public static string GetPlaceFile(string _pathtofolder)
        {
            try
            {
                return Directory.GetFiles(_pathtofolder, "*.mmap").Last().ToString();
            }
            catch // can't access to _pathtofolder
            {
                while (System.Windows.Forms.MessageBox.Show(
                    String.Format(MMUtils.GetString("synergy.placepathnotfound.message"), _pathtofolder),
                    MMUtils.GetString("synergy.placepathnotfound.caption"),
                    System.Windows.Forms.MessageBoxButtons.RetryCancel,
                    System.Windows.Forms.MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Retry)
                {
                    try
                    {
                        return Directory.GetFiles(_pathtofolder, "*.mmap").Last().ToString();
                    }
                    catch { }
                }
            }
            
            System.Windows.Forms.MessageBox.Show(
                    MMUtils.GetString("synergy.mapviewer.message"),
                    MMUtils.GetString("synergy.mapviewer.caption"));
            return "";
        }

        /// <summary>
        /// Folder path with trailing backslash
        /// </summary>
        /// <returns></returns>
        public static string GetFolderPath()
        {
            using (System.Windows.Forms.FolderBrowserDialog _fd = new System.Windows.Forms.FolderBrowserDialog())
            {
                //_fd.Description = "Описание";
                _fd.ShowNewFolderButton = true;

                //if (aCause == "receivemap")
                //    _fd.SelectedPath = aPlace;
                //else
                //    _fd.RootFolder = Environment.SpecialFolder.MyComputer;

                if (_fd.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    return "";

                string slash = "\\";
                if (_fd.SelectedPath.Substring(_fd.SelectedPath.Length - 1) == "\\")
                    slash = "";

                return _fd.SelectedPath + slash;
            }
        }

        /// <summary>
        /// Gets the icon for file.
        /// </summary>
        /// <param name="aPath">a filename</param>
        /// <returns>Path to the icon</returns>
        public static string GetIconForFile(string aPath)
        {
            FileInfo _fi = new FileInfo(aPath);
            switch (_fi.Extension.ToLower())
            {
                case ".wav":
                case ".mp3":
                case ".mid":
                case ".rmi":
                case ".m4a":
                case ".wma":
                    return getDLLPath() + "images\\audio.png";
                case ".chm":
                    return getDLLPath() + "images\\chm.png";
                case ".doc":
                case ".docx":
                case ".rtf":
                case "docm":
                case ".odt":
                    return getDLLPath() + "images\\doc.png";
                case ".exe":
                case ".dll":
                    return getDLLPath() + "images\\exe.png";
                case ".gif":
                case ".jpg":
                case ".jpeg":
                case ".png":
                case ".tif":
                case ".tiff":
                case ".bmp":
                    return getDLLPath() + "images\\img.png";
                case ".mmap":
                case ".mmat":
                    return getDLLPath() + "images\\map.png";
                case ".pdf":
                    return getDLLPath() + "images\\pdf.png";
                case ".txt":
                    return getDLLPath() + "images\\txt.png";
                case ".xls":
                case ".xlsx":
                case ".xlsm":
                case ".ods":
                    return getDLLPath() + "images\\xls.png";
            }

            return getDLLPath() + "images\\file.png";
        }

        public static string getDLLPath()
        {
            return m_i18n.getDLLPath();
        }

        /// <summary>
        /// User\Appdata\Roaming\Palmaross\Synergy\ - with trailed slash!
        /// </summary>
        public static string m_SynergyAppDataPath;
        /// <summary>
        /// User\Appdata\Roaming\Palmaross\Synergy\Local Storage\ - with trailed slash!
        /// </summary>
        public static string m_SynergyLocalPath;
        /// <summary>
        /// User\Appdata\Local\Palmaross\Synergy\Temp\ - with trailed slash!
        /// </summary>
        public static string m_SynergyTempPath;

        public static string instPath = "";
        public static string imagePath = "";
        protected static I18n m_i18n;
        public static string AddinName;
        public static int Version;
        public static DateTime NULLDATE = new DateTime(1899, 12, 30, 0, 0, 0);
    }
}
