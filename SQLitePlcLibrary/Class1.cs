using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace SQLitePlcLibrary
{
    [Table("User")] // matches the name of the DB table
    public class User
    {
        [PrimaryKey, AutoIncrement] // assigned to the property directly below
        public int User_Id { get; set; }
        public string Password { get; set; }
    }
    public class Class1
    {
        public static string CreateDB()
        {
            SQLiteConnection db = CreateConnection();
            //AddToDb(new User { Password = "123" });
            //RemoveFromDb(new User { Password = "123" });
            return SearchDB(db);
        }

        private static SQLiteConnection CreateConnection()
        {
            //string assemblyFile = (
            //    new System.Uri(Assembly.GetExecutingAssembly().CodeBase)
            //).AbsolutePath; //"C:/Users/oxbyd/OneDrive%20-%20Sheffield%20Hallam%20University/SQLiteTest/SQLiteTest/bin/Debug/net6.0/SQLitePlcLibrary.dll"
            //var buildDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //string dbPath = Path.Combine(Environment.CurrentDirectory, "AllergyData.db"); // this is looking at the SQLiteTest bin not the library
            string dbPath = Path.Combine("C:\\Users\\oxbyd\\OneDrive - Sheffield Hallam University\\SQLiteTest\\SQLitePlcLibrary\\bin\\Debug\\netstandard2.0", "AllergyData.db");
            return new SQLiteConnection(dbPath);
        }

        private static string SearchDB(SQLiteConnection db)
        {
            TableQuery<User> stockList = db.Table<User>();
            //List<User> users = stockList.ToList(); //convert from query to generic list

            string passwords = "";
            foreach (var item in stockList)
            {
                passwords += item.Password;
            }

            return passwords;
        }

        private static string AddToDb(User user)
        {
            SQLiteConnection db = CreateConnection();
            db.Insert(user);
            return SearchDB(db);
        }

        private static string RemoveFromDb(User user)
        {
            SQLiteConnection db = CreateConnection();
            //db.Delete(user); //delete using ID
            db.Execute($"DELETE FROM User where Password = {user.Password} ;");
            return SearchDB(db);
        }
    }
}
