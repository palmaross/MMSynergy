using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IniParser;
using System.IO;
using Microsoft.Win32;
using System.Reflection;

namespace SynManager {
	public class I18n {
		public I18n(string sAddinName="Synergy18", int version=18) {
			m_appdata = System.Environment.GetEnvironmentVariable("LOCALAPPDATA") + "\\Mindjet\\MindManager\\" + version.ToString();
#if PLATFORM_X64
			m_sDLLName = (sAddinName.ToLower().Replace(".connect", "") + "_x64.dll");
#else
			m_sDLLName = (sAddinName.ToLower().Replace(".connect","") + ".dll");
#endif
			m_hashtable = new System.Collections.Hashtable();

			// Now try to load customization file, I18n.ini
			// located in the same folder as our .dll
			string clsid = "";

            if (version == 18)
            {
                clsid = "CLSID\\{38155112-4ED9-46D8-8A2D-BCB2ECB9A12F}\\InprocServer32";
            }

			if (version == 17)
			{
                clsid = "CLSID\\{7AEA005F-FA38-4421-8F5C-4110A4055AE9}\\InprocServer32";
			}

			RegistryKey rk = Registry.ClassesRoot.OpenSubKey(clsid, false);
			if (null == rk)
				return;
			if (null == rk.GetValue("CodeBase")) {
				rk.Close();
				return;
			}
			sPath = rk.GetValue("CodeBase").ToString().ToLower().Replace(m_sDLLName,"").Replace("file:///","").Replace("/","\\").Replace("\\x64", "");
			string I18nPath = sPath + "I18n.ini";
			rk.Close();
//			System.Windows.Forms.MessageBox.Show(I18nPath);
			if (File.Exists(sPath + "I18n.default.ini"))
			{
				FileIniDataParser _parser = new FileIniDataParser();
				IniData _parsedData = _parser.LoadFile(sPath + "I18n.default.ini");
				KeyDataCollection _sectionData = _parsedData["l18n.default"];
				if (_sectionData != null)
					foreach (KeyData _keyData in _sectionData)
					{
						m_hashtable[_keyData.KeyName] = _keyData.Value;
					}
			}
			
			if (File.Exists(I18nPath))
			{
				FileIniDataParser _parser = new FileIniDataParser();
				IniData _parsedData = _parser.LoadFile(I18nPath);
				KeyDataCollection _sectionData = _parsedData["l18n"];
				if (_sectionData != null)
					foreach (KeyData _keyData in _sectionData)
					{
						m_hashtable[_keyData.KeyName] = _keyData.Value;
					}
			}
		}

		public bool hasString(string aName)
		{
			return m_hashtable.Contains(aName);
		}

		public string getString(string sName, string quote="") {
			string rc;
			if (!m_hashtable.Contains(sName))
				rc = "{" + sName + "}";
			else
				rc = m_hashtable[sName].ToString();
			if (quote != "")
				rc = quote + rc.Replace(quote, "\\" + quote) + quote;
			return rc;
		}
		
		public string getDLLPath() {
			return sPath;
		}

		private System.Collections.Hashtable m_hashtable;
		private string sPath = "";
		private static string m_appdata = "";
		public static string appData
		{
			get
			{
				return m_appdata;
			}
		}
		private static string m_sDLLName = "";
	}
}
