using System;

namespace SynManager
{
    internal class UsersDB : DatabaseWrapper
    {
        public void KillDatabase()
        {
            try
            {
                System.IO.File.Delete(GetDatabaseName());
            }
            catch { }
        }

        public override string GetDatabaseName()
        {
            return MMUtils.m_SynergyAppDataPath + "users.db";
        }

        public override void CreateDatabase()
        {
            base.CreateDatabase();
            m_db.ExecuteNonQuery("BEGIN EXCLUSIVE");
            m_db.ExecuteNonQuery("CREATE TABLE USERS(NAME text, EMAIL text, LOGIN text, PASS text, ROLE text," +
                                 "reserved1 text, reserved2 text, reserved3 integer, reserved4 integer);");
            m_db.ExecuteNonQuery("END");
        }
    }

    internal class MapsDB : DatabaseWrapper
    {
        public override string GetDatabaseName()
        {
            return MMUtils.m_SynergyAppDataPath + "maps.db";
        }

        public override void CreateDatabase()
        {
            base.CreateDatabase();
            m_db.ExecuteNonQuery("BEGIN EXCLUSIVE");
            m_db.ExecuteNonQuery("CREATE TABLE MAPS(PROJECTNAME text, MAPGUID text, MAPNAME text," +
                                 "PATHTOPLACE text, LOCALPATH text, AUTHOR text," +
                                 "VERSION integer, CREATED integer, MODIFIED integer" +
                                 "reserved1 text, reserved2 text, reserved3 integer, reserved4 integer);");
            m_db.ExecuteNonQuery("END");
        }

        /// <summary>
        /// Add map to MapsDB
        /// </summary>
        /// <param name="aProject">Project name</param>
        /// <param name="aGuid">Map Synergy guid</param>
        /// <param name="aMapName">Map file name</param>
        /// <param name="aPathToPlace">Path to map folder in Place - with backslash!</param>
        /// <param name="aLocalPath">Path to map in Local Storage</param>
        /// <param name="aAuthor">map creator</param>
        /// <param name="aCreated">data map created</param>
        /// <param name="aModified">data map aModified</param>
        /// <param name="aVersion">map version (if any)</param>
        public static void AddMapToDB(string aProject, string aGuid, string aMapName,
                                      string aPathToPlace, string aLocalPath, string aAuthor,
                                      int aVersion, int aCreated, int aModified)
        {
            using (MapsDB _db = new MapsDB())
            {
                _db.ExecuteNonQuery("INSERT INTO MAPS VALUES(" +
                "`" + aProject + "`," +
                "`" + aGuid + "`," +
                "`" + aMapName + "`," +
                "`" + aPathToPlace + "`," +
                "`" + aLocalPath + "`," +
                "`" + aAuthor + "`," +
                "`" + aCreated.ToString() + "`," +
                "`" + aModified.ToString() + "`," +
                "`" + aVersion.ToString() + "`, ``, ``, 0, 0)");
            }
        }
    }

    internal class StoragesDB : DatabaseWrapper
    {
        public override string GetDatabaseName()
        {
            return MMUtils.m_SynergyAppDataPath + "storages.db";
        }

        public override void CreateDatabase()
        {
            base.CreateDatabase();
            m_db.ExecuteNonQuery("BEGIN EXCLUSIVE");
            m_db.ExecuteNonQuery("CREATE TABLE STORAGES(STORAGENAME text, PROCESS text, SITE text, TYPE text," + 
                                 "reserved1 text, reserved2 text, reserved3 integer, reserved4 integer);");

            AddStorageToDB(MMUtils.GetString("storage1.text"), "OneDrive", "https://onedrive.live.com", "cloud");
            AddStorageToDB(MMUtils.GetString("storage2.text"), "googledrivesync", "https://drive.google.com", "cloud");
            AddStorageToDB(MMUtils.GetString("storage3.text"), "Dropbox", "https://www.dropbox.com", "cloud");
            AddStorageToDB(MMUtils.GetString("storage4.text"), "box", "https://www.box.com", "cloud"); // TODO site
            
            m_db.ExecuteNonQuery("END");
        }

        protected void AddStorageToDB(string aStorage, string aProcess, string aSite, string aType)
        {
            m_db.ExecuteNonQuery("insert into STORAGES values(" +
                "`" + aStorage + "`," +
                "`" + aProcess + "`," +
                "`" + aSite + "`," +
                "`" + aType + "`, ``, ``, 0, 0)");
        }
    }

    internal class PlacesDB : DatabaseWrapper
    {
        public override string GetDatabaseName()
        {
            return MMUtils.m_SynergyAppDataPath + "places.db";
        }

        /// <summary>
        /// STORAGE - 
        /// </summary>
        public override void CreateDatabase()
        {
            base.CreateDatabase();
            m_db.ExecuteNonQuery("BEGIN EXCLUSIVE");
            m_db.ExecuteNonQuery("CREATE TABLE PLACES(PLACENAME text, TYPE text, PLACEPATH text," +
                "PROCESS text, SITE text," +
                "reserved1 text, reserved2 text, reserved3 integer, reserved4 integer);");

            m_db.ExecuteNonQuery("END");
        }

        /// <summary>
        /// Add Place to DB
        /// </summary>
        /// <param name="aName">Place name</param>
        /// <param name="aType">Place type: cloud, ND, site</param>
        /// <param name="aPath">Path to place for cloud and disk, for site - </param>
        /// <param name="aProcess">Process for cloud storage</param>
        /// <param name="aSite">Site URL for given place</param>
        public void AddPlaceToDB(string aName, string aType, string aPath, string aProcess, string aSite)
        {
            m_db.ExecuteNonQuery("INSERT INTO PLACES VALUES(" +
                    "`" + aName + "`," +
                    "`" + aType + "`," +
                    "`" + aPath + "`," +
                    "`" + aProcess + "`," +
                    "`" + aSite + "`, ``, ``, 0, 0)");
        }
    }

    internal class ProjectsDB : DatabaseWrapper
    {
        public override string GetDatabaseName()
        {
            return MMUtils.m_SynergyAppDataPath + "projects.db";
        }

        public override void CreateDatabase()
        {
            base.CreateDatabase();
            m_db.ExecuteNonQuery("BEGIN EXCLUSIVE");
            m_db.ExecuteNonQuery("CREATE TABLE PROJECTS(STORAGE text, PLACENAME text, PROJECTNAME text, PROJECTPATH text, LOCALPATH text," +
                                 "reserved1 text, reserved2 text, reserved3 integer, reserved4 integer);");
            m_db.ExecuteNonQuery("END");
        }

        public static void AddProjectToDB(string aStorage, string aPlaceName, string aProjectName, string aPathToProject, string aLocalPath)
        {
            using (ProjectsDB _db = new ProjectsDB())
            {
                _db.ExecuteNonQuery("INSERT INTO PROJECTS VALUES(" +
                "`" + aStorage + "`," +
                "`" + aPlaceName + "`," +
                "`" + aProjectName + "`," +
                "`" + aPathToProject + "`," +
                "`" + aLocalPath + "`, ``, ``, 0, 0)");
            }
        }
    }
}
