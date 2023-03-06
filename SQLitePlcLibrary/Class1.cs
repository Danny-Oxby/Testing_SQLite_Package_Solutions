using SQLite;
using System;
using System.Collections.Generic;
using System.IO;

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
            //string dbPath = Path.Combine(Environment.CurrentDirectory, "AllergyData.db");
            return new SQLiteConnection(Path.Combine(Environment.CurrentDirectory, "AllergyData.db"));
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
