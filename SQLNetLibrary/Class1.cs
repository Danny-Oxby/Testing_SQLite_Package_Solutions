using Microsoft.Data.Sqlite;
using SQLitePCL;

namespace SQLNetLibrary
{
    public class Class1
    {
        public static string dbpath = "C:\\Users\\oxbyd\\OneDrive - Sheffield Hallam University\\SQLiteTest\\SQLiteTest\\AllergyData.db";
        public static string CreateDB()
        {
            var db = new SqliteConnection(dbpath);

            return "";
        }

    }
}
