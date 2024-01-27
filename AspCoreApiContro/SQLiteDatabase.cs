using System.Data.SQLite;

namespace AspCoreApiContro
{
    public class SQLiteDatabase
    {
        private SQLiteConnection _connection;
        public SQLiteDatabase()
        {
            _connection = new SQLiteConnection("Data Source=hello.db");
            _connection.Open();
            SQLiteCommand createTables = _connection.CreateCommand();
            createTables.CommandText = "CREATE TABLE IF NOT EXISTS WallMessages (message_id int PRIMARY KEY AUTO_INCREMENT, " +
                                                                            "response_to_id int, " +
                                                                            "posting_date DATETIME NOT NULL, " +
                                                                            "edit_time DATETIME, " +
                                                                            "message_author_id int NOT NULL" +
                                                                            "message_text VARCHAR(1000)) NOT NULL";
            createTables.ExecuteNonQuery();
            createTables.CommandText = "CREATE TABLE IF NOT EXISTS WallMessages (user_id int PRIMARY KEY AUTO_INCREMENT, " +
                                                                            "user_name VARCHAR(100) NOT NULL, " +
                                                                            "creation_date DATETIME NOT NULL, " +
                                                                            "email VARCHAR(100) NOT NULL)";
        }

    }
}
