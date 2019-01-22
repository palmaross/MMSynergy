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
            m_db.ExecuteNonQuery("CREATE TABLE USERS(NAME text, EMAIL text, LOGIN text, PASSWORD text," +
                                 "reserved1 text, reserved2 text, reserved3 integer, reserved4 integer);");
            m_db.ExecuteNonQuery("END");
        }
    }

    internal class SharedItemsDB : DatabaseWrapper
    {
        public override string GetDatabaseName()
        {
            return MMUtils.m_SynergyAppDataPath + "shared.db";
        }

        public override void CreateDatabase()
        {
            base.CreateDatabase();
            m_db.ExecuteNonQuery("BEGIN EXCLUSIVE");
            m_db.ExecuteNonQuery("CREATE TABLE SHARED(" +
                "PLACE text, " + // Name of Place
                "PATH text, " +  // Path to shared folder
                "OWNER text, " + // Name of account owner = name of account
                "EMAIL text, " + // Email of account owner
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
            m_db.ExecuteNonQuery("CREATE TABLE MAPS(" +
                "PLACE text, " +                // Place name
                "MAPGUID text primary key, " +  // map Synergy guid
                "MAPNAME text," +               // map file name
                "FOLDERPATH text, " +                 // path to map folder
                "AUTHOR text," +                // map creator
                "VERSION integer, " +           // map version (if any)
                "CREATED integer, " +           // date created
                "MODIFIED integer, " +          // date modified
                "reserved1 text, reserved2 text, reserved3 integer, reserved4 integer);");
            m_db.ExecuteNonQuery("END");
        }

        /// <summary>
        /// Add map to MapsDB
        /// </summary>
        public static void AddMapToDB(string aPlace, string aGuid, string aMapName, string aPath, 
                                      string aAuthor, int aVersion, int aCreated, int aModified)
        {
            using (MapsDB _db = new MapsDB())
            {
                _db.ExecuteNonQuery("INSERT INTO MAPS VALUES(" +
                "`" + aPlace + "`," +
                "`" + aGuid + "`," +
                "`" + aMapName + "`," +
                "`" + aPath + "`," +
                "`" + aAuthor + "`," +
                "`" + aVersion + "`," +
                "`" + aCreated.ToString() + "`," +
                "`" + aModified.ToString() + "`, ``, ``, 0, 0)");
            }
        }
    }

    internal class PlacesDB : DatabaseWrapper
    {
        public override string GetDatabaseName()
        {
            return MMUtils.m_SynergyAppDataPath + "places.db";
        }

        public override void CreateDatabase()
        {
            base.CreateDatabase();
            m_db.ExecuteNonQuery("BEGIN EXCLUSIVE");
            m_db.ExecuteNonQuery("CREATE TABLE PLACES(" +
                "PLACENAME text, " + // Place name
                "STORAGE text, " +   // Storage name - ND, synergysite, usersite or cloudstorage name
                "PLACEPATH text, " + // Path to place for cloud and disk, for site - 
                "PROCESS text, " +   // Process for cloud storage
                "SITE text, " +        // Site URL in case of synergysite or usersite
                "reserved1 text, reserved2 text, reserved3 integer, reserved4 integer);");
            m_db.ExecuteNonQuery("END");
        }
    }
}
