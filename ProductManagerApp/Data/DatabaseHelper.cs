﻿using System.Data;
using System.Data.SQLite;

namespace ProductManagerApp.Data
{
    public class DatabaseHelper
    {
        //private static readonly string connStr = @"Data Source=D:\workspace\MyPractice\ProductManagerApp\ProductManagerApp\database.db;Version=3;";
        private static readonly string connStr = @"Data Source=database.db;Version=3;";



        public static DataTable Query(string sql)
        {
            using var conn = new SQLiteConnection(connStr);
            conn.Open();
            using var da = new SQLiteDataAdapter(sql, conn);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static int Execute(string sql, params SQLiteParameter[] parameters)
        {
            using var conn = new SQLiteConnection(connStr);
            conn.Open();
            using var cmd = new SQLiteCommand(sql, conn);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteNonQuery();
        }
    }
}
