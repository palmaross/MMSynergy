using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mindjet.MindManager.Interop;
using SynManager;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace Maps
{
    internal class PublishMap
    {
        public static bool Publish(Document publishDoc, string aPlaceName, string aFolderPath, string aMapPath)
        {
            string _docName = publishDoc.Name;
            string aGuid = publishDoc.Guid;
            string aSite = "";      // website to check for Internet connection
            string aProcess = "";   // cloud app process to check if started
            string aPlacePath = "", aStorage = "";

            using (PlacesDB _db = new PlacesDB())
            {
                DataTable _dt = _db.ExecuteQuery("select * from PLACES where PLACENAME=`" + aPlaceName + "`");
                aPlacePath = _dt.Rows[0]["PLACEPATH"].ToString();
                aSite = _dt.Rows[0]["SITE"].ToString();
                aProcess = _dt.Rows[0]["PROCESS"].ToString();
                aStorage = _dt.Rows[0]["STORAGE"].ToString();
            }

            if (!Directory.Exists(aFolderPath))
            {
                MessageBox.Show(String.Format(MMUtils.GetString("synergyexplorer.publish.placenoexists"), aFolderPath));
                return false;
            }

            string endMessage1 = MMUtils.GetString("internet.failed.endpubmessage1");
            string endMessage2 = MMUtils.GetString("internet.failed.endpubmessage2");

            // Website.
            if (aSite != string.Empty)
                while (!Internet.IsConnected(aSite))
                {
                    if (MessageBox.Show(
                        String.Format(MMUtils.GetString("internet.sitefailed.message"), aSite) + endMessage1,
                        String.Format(MMUtils.GetString("internet.failed.caption"), _docName),
                        MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation)
                        == DialogResult.Cancel)
                    {
                        return false;
                    }
                }

            // Cloud storage.
            if (aProcess != string.Empty && aProcess != MMUtils.GetString("newcloudstoragedlg.processignore.text"))
                while (!CloudStorage.ProcessIsRunnig(aProcess))
                {
                    if (MessageBox.Show(
                        String.Format(MMUtils.GetString("internet.processfailed.message"), aProcess) + endMessage1 + endMessage2,
                        String.Format(MMUtils.GetString("internet.failed.caption"), _docName),
                        MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Exclamation)
                        == DialogResult.Abort)
                    {
                        return false;
                    }
                }
                while (!Internet.IsConnected(MMUtils.GetRegistry("", "GeneralWebsite")))
                {
                    if (MessageBox.Show(
                        String.Format(MMUtils.GetString("internet.sitefailed.message"), aSite) + endMessage1 + endMessage2,
                        String.Format(MMUtils.GetString("internet.failed.caption"), _docName),
                        MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Exclamation)
                        == DialogResult.Abort)
                    {
                        return false;
                    }
                }

            // Network folder.
            if (aStorage == "ND")
                while (!Network.IsAvailable(aPlacePath))
                {
                    if (MessageBox.Show(
                        String.Format(MMUtils.GetString("internet.network.message"), aPlacePath) + endMessage1,
                        String.Format(MMUtils.GetString("internet.failed.caption"), _docName),
                        MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation)
                        == DialogResult.Cancel)
                    {
                        return false;
                    }
                }

            string _mapName = Path.GetFileNameWithoutExtension(publishDoc.FullName);
            if (aSite == "")
            {
                try
                {
                    // Save map to Place.
                    publishDoc.SaveAs(aMapPath);
                    SUtils.AttrMap(publishDoc);

                    // Add .users to map.
                    StreamWriter sw = new StreamWriter(File.Create(aFolderPath + "\\" + _mapName + ".owner"));
                    sw.WriteLine(SUtils.currentUserName);
                    sw.Close();
                    sw = new StreamWriter(File.Create(aFolderPath + "\\" + _mapName + ".users"));
                    sw.WriteLine(SUtils.currentUserName);
                    sw.Close();
                    // Add map info.
                    sw = new StreamWriter(File.Create(aFolderPath + "\\" + _mapName+ ".info"));
                    sw.WriteLine(aGuid);
                    sw.WriteLine(aProcess); // Процесс
                    sw.WriteLine(aSite);    // чтобы проверить Интернет
                    sw.Close();

                    publishDoc.SaveAs(aFolderPath + "\\" + _mapName + "&&&" + SUtils.currentUserName);
                    Directory.CreateDirectory(aFolderPath + "\\" + "Share_" + _mapName);
                }
                catch (Exception _e) // TODO cause!!! read-only, etc... имя файла уже исключено выше
                {
                    MessageBox.Show("Error: " + _e.Message, "PublishMapDlg", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (File.Exists(aMapPath))
                        File.Delete(aMapPath);
                    if (File.Exists(aFolderPath + "\\" + _mapName + ".owner"))
                        File.Delete(aFolderPath + "\\" + _mapName + ".owner");
                    if (File.Exists(aFolderPath + "\\" + _mapName + ".users"))
                        File.Delete(aFolderPath + "\\" + _mapName + ".users");
                    if (File.Exists(aFolderPath + "\\" + _mapName + ".info"))
                        File.Delete(aFolderPath + "\\" + _mapName + ".info");
                    return false;
                }
            }
            else // Save to website!
            {

            }

            //// Publish Map = set attributes to map, topics, relationships and boundaries and process links ////
            Transaction _tr = publishDoc.NewTransaction("");
            _tr.IsUndoable = false;
            _tr.Execute += new ITransactionEvents_ExecuteEventHandler(SUtils.PublishMap);
            _tr.Start();
            ///////////////////////////////////////////////////////////////////////////////////

            publishDoc.Save();

            if (SUtils.MapLinks.Count > 0)
            {
                using (LinkedFilesDlg _dlg = new LinkedFilesDlg(SUtils.MapLinks, publishDoc))
                    _dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd));
                SUtils.MapLinks.Clear();
            }

            MapsDB.AddMapToDB(aPlaceName, aGuid, _docName, aFolderPath,
                SUtils.currentUserName, 0, Convert.ToInt32(DateTime.UtcNow), Convert.ToInt32(DateTime.UtcNow)
            );

            SUtils.ProcessMap(publishDoc);

            // Add to Synergy Explorer
            using (SynergyExplorerDlg dlg = new SynergyExplorerDlg())
                dlg.AddToTable(aFolderPath + "\\" + _mapName);

            // Share map
            using (ShareDlg _dlg = new ShareDlg(MMUtils.ActiveDocument.Name, aFolderPath, aStorage, "map"))
            {
                _dlg.ShowDialog(new WindowWrapper((IntPtr)MMUtils.MindManager.hWnd));
            }
            return true;
        }
    }
}
