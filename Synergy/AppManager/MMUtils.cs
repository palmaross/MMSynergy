﻿using System;
using System.IO;
using Microsoft.Win32;
using Mindjet.MindManager.Interop;
using System.Linq;

namespace SynManager
{
    class MMUtils
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
                        Directory.CreateDirectory(m_SynergyLocalPath);
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

        public static void CopyPlaceToLocal()
        {

        }

        public static string m_SynergyAppDataPath;   // User/Appdata/Roaming/Palmaross/Synergy/ - with trailed slash!
        public static string m_SynergyLocalPath;  // User/Appdata/Roaming/Palmaross/Synergy/Local Storage/ - with trailed slash!
        public static string m_SynergyTempPath;      // User/Appdata/Local/Palmaross/Synergy/Temp/ - with trailed slash!
        public static string instPath = "";
        public static string imagePath = "";
        protected static I18n m_i18n;
        public static string AddinName;
        public static int Version;
        public static DateTime NULLDATE = new DateTime(1899, 12, 30, 0, 0, 0);
    }
}
