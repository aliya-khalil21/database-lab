using System;
using System.Data.SqlClient;

namespace CRUD_Operations
{
    class Configuration
    {
        private string ConnectionStr = @"Data Source=(local);Initial Catalog=Lab2_Home;Integrated Security=True";
        private SqlConnection con;
        private static Configuration _instance;

        public static Configuration getInstance()
        {
            if (_instance == null)
                _instance = new Configuration();
            return _instance;
        }

        private Configuration()
        {
            con = new SqlConnection(ConnectionStr);
        }

        public SqlConnection getConnection()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public void CloseConnection()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
