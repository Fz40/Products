using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace MVC.App_Code.Connect
{
    public class DataAccess
    {


        // protected string Conn = "Data Source=SSO\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True";
        //protected string Conn = "Data Surce=PTK580080095-NB\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True";
        protected SqlConnection databaseConnection;

        

        private void ConnectDB (string Conn)
        {
            if (databaseConnection == null)
                databaseConnection = new SqlConnection(Conn);
                
            if (databaseConnection.State != ConnectionState.Open)
            {
                databaseConnection.Open();
            }
        }

        public SqlDataReader ExecuteReader(string Connect ,string sqlCommand)
        {
            ConnectDB(Connect);
            var cmd = new SqlCommand(sqlCommand,databaseConnection);
            var dataexec = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return dataexec ;
        }

        public int ExecuteNonQuery (string Connect ,string sqlcommand)
        {
            ConnectDB(Connect);
            var rowAffect = 0;
            var cmd = new SqlCommand(sqlcommand,databaseConnection);
            rowAffect = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            cmd.Connection.Dispose();
            cmd.Dispose();

            return rowAffect;
        }
    }
}