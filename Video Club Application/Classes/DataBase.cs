using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Video_Club_Application
{
    class DataBase
    {
        public static OdbcConnection connection = new OdbcConnection();
        public static OdbcCommand command;

        public static void Connect(string server, string port, string user, string password)
        {
            try
            {
                if (connection == null) connection = new OdbcConnection();
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.ConnectionString = "Provider=MSDASQL.1" +
                            ";Driver={MySQL ODBC 5.3 UNICODE Driver}" +
                            ";Server=" + server +
                            ";Port=" + port +
                            ";Database=sakila" +
                            ";User=" + user +
                            ";Password=" + password +
                            ";Option=3";
                    connection.Open();
                }
                if (command == null)
                {
                    command = new OdbcCommand();
                    command.Connection = connection;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public static void Disconnect()
        {
            try
            {
                if (connection == null) return;
                if (connection.State == System.Data.ConnectionState.Closed) return;
                connection.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
