using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUAN_LY_GARA_OTO.DataBase
{
    internal class ComboEdit
    {
        private SqlConnection _connection;
        public ComboEdit() { }

        public List<string> GetDataDate(string sql)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            _connection = connectionManager.GetConnection();
            if (_connection == null) return null;

            try
            {
                SqlCommand sqlCommand = new SqlCommand(sql, _connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                List<string> list = new List<string>();
                while (reader.Read())
                {
                    DateTime date = reader.GetDateTime(0);
                    list.Add(date.ToString("dd-MM-yyyy"));
                }
                reader.Close();
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                connectionManager.CloseConnection(_connection);
            }
        }

        public List<string> GetDataString(string sql)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            _connection = connectionManager.GetConnection();
            if (_connection == null) return null;

            try
            {
                SqlCommand sqlCommand = new SqlCommand(sql, _connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                List<string> list = new List<string>();
                while (reader.Read())
                {
                    list.Add(reader.GetString(1));
                }
                reader.Close();
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                connectionManager.CloseConnection(_connection);
            }
        }
    }
}
