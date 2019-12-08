using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace Common
{
    public static class DBConnectionString
    {
        private static string connection = string.Empty;
        public static OleDbConnection con;
        public static SqlConnection conn;
        public static string Getconnectionstring(Database DBName)
        {            
            switch (DBName)
            {
                case Database.SQLDBConnection:
                    connection = ConfigurationManager.ConnectionStrings["SQLDBConnection"].ConnectionString;
                    break;
                case Database.AccessDBConnection:
                    connection = ConfigurationManager.ConnectionStrings["AccessDBConnection"].ConnectionString;
                    break;
                default:
                    break;
            }
            return connection;
        }
        public static OleDbConnection OpenConnection(string cs)
        {
            con = new OleDbConnection(cs);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
        public static void CloseConnection(string cs)
        {            
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        public static SqlConnection SqlOpenConnection(string cs)
        {
            conn = new SqlConnection(cs);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }
        public static void SqlCloseConnection(string cs)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
    
    public enum Database
    {
        SQLDBConnection,
        AccessDBConnection,
    }
}
