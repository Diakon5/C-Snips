using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCoreApiContro.Databases
{
   class SQLiteDatabase
   {

      SQLiteDatabase()
      {
         SQLiteConnection sqlite_conn;
         sqlite_conn = CreateConnection();
         CreateTable(sqlite_conn);
      }

      static SQLiteConnection CreateConnection()
      {

         SQLiteConnection sqlite_conn;
         // Create a new database connection:
         sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");
         // Open the connection:
         try
         {
            sqlite_conn.Open();
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.ToString());
         }
         return sqlite_conn;
      }

      static void CreateTable(SQLiteConnection conn)
      {

         SQLiteCommand sqlite_cmd;
         string Createsql = "CREATE TABLE SampleTable (Col1 VARCHAR(20), Col2 INT)";
         string Createsql1 = "CREATE TABLE SampleTable1 (Col1 VARCHAR(20), Col2 INT)";
         sqlite_cmd = conn.CreateCommand();
         sqlite_cmd.CommandText = Createsql;
         sqlite_cmd.ExecuteNonQuery();
         sqlite_cmd.CommandText = Createsql1;
         sqlite_cmd.ExecuteNonQuery();

      }

      static void InsertData(SQLiteConnection conn)
      {
         SQLiteCommand sqlite_cmd;
         sqlite_cmd = conn.CreateCommand();
         sqlite_cmd.CommandText = "INSERT INTO SampleTable (Col1, Col2) VALUES ('Test Text ', 1);";
         sqlite_cmd.ExecuteNonQuery();
      }

      static void ReadData(SQLiteConnection conn)
      {
         SQLiteDataReader sqlite_datareader;
         SQLiteCommand sqlite_cmd;
         sqlite_cmd = conn.CreateCommand();
         sqlite_cmd.CommandText = "SELECT * FROM SampleTable";

         sqlite_datareader = sqlite_cmd.ExecuteReader();
         while (sqlite_datareader.Read())
         {
            string myreader = sqlite_datareader.GetString(0);
            Console.WriteLine(myreader);
         }
         conn.Close();
      }
   }
}