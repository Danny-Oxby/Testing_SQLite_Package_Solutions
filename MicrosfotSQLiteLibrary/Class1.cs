using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace MicrosfotSQLiteLibrary
{
    public class Class1
    {
        public static string CreateDB()
        {
            SQLiteConnection sqlite_conn;
            sqlite_conn = CreateConnection();
            InsertData(sqlite_conn);
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


        static void InsertData(SQLiteConnection conn)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO User (Password2) VALUES('abcdef'); ";
           sqlite_cmd.ExecuteNonQuery();

        }

        static string ReadData(SQLiteConnection conn)
        {
            string myreader = "";
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM User";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            if (sqlite_datareader.Read())
            {
                myreader = sqlite_datareader.GetString(0);
            }
            conn.Close();
            return myreader;
        }
    }
}
