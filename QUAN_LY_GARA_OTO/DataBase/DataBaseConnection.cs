using DevExpress.Utils.MVVM.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUAN_LY_GARA_OTO.DataBase
{
    internal class DataBaseConnection
    {
        private string connectionString = "Data Source=DESKTOP-2FF1JBQ;Initial Catalog=QUAN_LY_GARA_OTO;User ID=qlSinhVien;Password=namdz2k4;";
        private SqlConnection connection;

        public SqlConnection GetConnection()
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        public void CloseConnection(SqlConnection connection)
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                Console.WriteLine("Đã đóng kết nối đến cơ sở dữ liệu.");
            }
        }
    }
}
