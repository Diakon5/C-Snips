﻿using AspCoreApiContro.Models;
using Microsoft.Data.Sqlite;
using System.Security.Cryptography;
namespace AspCoreApiContro
{
    public class SQLiteDatabase
    {
        private SqliteConnection _connection;
        public SQLiteDatabase()
        {
            _connection = new SqliteConnection("Data Source=hello.db");
            _connection.Open();
            SqliteCommand createTables = _connection.CreateCommand();
            createTables.CommandText = "CREATE TABLE IF NOT EXISTS WallMessages (message_id int PRIMARY KEY AUTO_INCREMENT, " +
                                                                            "response_to_id int, " +
                                                                            "posting_date DATETIME NOT NULL, " +
                                                                            "edit_time DATETIME, " +
                                                                            "message_author_id int NOT NULL" +
                                                                            "message_text VARCHAR(1000)) NOT NULL";
            createTables.ExecuteNonQuery();
            createTables.CommandText = "CREATE TABLE IF NOT EXISTS WallUsers (user_id int PRIMARY KEY AUTO_INCREMENT, " +
                                                                            "user_name VARCHAR(100) NOT NULL, " +
                                                                            "creation_date DATETIME NOT NULL, " +
                                                                            "email VARCHAR(100) NOT NULL)";
            createTables.ExecuteNonQuery();
            createTables.CommandText = "CREATE TABLE IF NOT EXISTS UsersPasswords (user_id int PRIMARY KEY, " +
                                                                            "password varchar(100) NOT NULL)";
            createTables.ExecuteNonQuery();
        }

        public SqliteDataReader GetUsers(string? username = null)
        {
            string usernameFilter = "";
            if (username != null)
            {
                usernameFilter = $" WHERE user_name == \"{username}\"";
            }
            SqliteCommand sqliteCommand = _connection.CreateCommand();
            sqliteCommand.CommandText = $"SELECT * FROM WallUsers{username}";
            return sqliteCommand.ExecuteReader();
        }
        public SqliteDataReader GetMessages(int? amount= null)
        {
            string amountFilter = "";
            if (amount != null)
            {
                amountFilter = $" TOP {amount}";
            }
            SqliteCommand sqliteCommand = _connection.CreateCommand();
            sqliteCommand.CommandText = $"SELECT{amountFilter} * FROM WallMessages";
            return sqliteCommand.ExecuteReader();
        }
        public void AddMessage(WallMessage message)
        {
            SqliteCommand sqliteCommand = _connection.CreateCommand();
            sqliteCommand.CommandText = $"INSERT INTO WallMessages (NULL,%responseTo,%postingDate,%editDate,%messageAuthor,%messageText)";
            sqliteCommand.Parameters.AddWithValue("%responseTo",message.RespondingTo?.messageID);
            sqliteCommand.Parameters.AddWithValue("%postingDate", message.PostingDate);
            sqliteCommand.Parameters.AddWithValue("%editDate", message.LastEditDate);
            sqliteCommand.Parameters.AddWithValue("%messageAuthor", message.Author.userID);
            sqliteCommand.Parameters.AddWithValue("%messageText", message.Message);
            sqliteCommand.ExecuteNonQuery();
        }


    }
}
