using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace ClassLibrary1
{
    public class Class1
    {
        public static string CreateDB() // this Nuget package dosn't work is android, since it dosn't include a .dll to .os converter
        {
            SQLiteConnection sqlite_conn = CreateConnection();
            //CreateTable(sqlite_conn);
            //InsertData(sqlite_conn);
            return ReadData(sqlite_conn);
        }

        static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=AllergyData.db; Version = 3; New = True; Compress = True; ");
            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {

            }
            return sqlite_conn;
        }

        static void CreateTable(SQLiteConnection conn)
        {
            SQLiteCommand sqlite_cmd;
            string Createsql = "CREATE TABLE User (User_ID INTEGER NOT NULL UNIQUE,Password TEXT NOT NULL,PRIMARY KEY(User_ID AUTOINCREMENT));";
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();

        }

        static void InsertData(SQLiteConnection conn)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO User (Password) VALUES('abc'); ";
            sqlite_cmd.ExecuteNonQuery();
        }

        static string ReadData(SQLiteConnection conn)
        {
            string values = "";
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT Password FROM User";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                values = sqlite_datareader.GetString(0);
            }
            conn.Close();

            return values;
        }
    }
}
