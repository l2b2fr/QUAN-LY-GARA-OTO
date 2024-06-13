using QUAN_LY_GARA_OTO.DataBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUAN_LY_GARA_OTO.Models
{
    internal class Users
    {
        public int id { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public string permission { get; set; }
        private static SqlConnection _connection;

        public Users() { }

        public Users(int id, string user, string password, string permission)
        {
            this.id = id;
            this.user = user;
            this.password = password;
            this.permission = permission;
        }

        public bool AdminExists(Users admin)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            SqlConnection _connection = connectionManager.GetConnection();
            if (_connection == null) return false;

            try
            {
                string query = "SELECT COUNT(*) FROM tb_Users WHERE [user] = @user AND [password] = @password AND [permission] = @permission";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@user", admin.user);
                command.Parameters.AddWithValue("@password", admin.password);
                command.Parameters.AddWithValue("@permission", admin.permission);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connectionManager.CloseConnection(_connection);
            }
        }

        public bool CreateAdmin(Users admin)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            _connection = connectionManager.GetConnection();
            if (_connection == null) return false;

            try
            {
                string query = "INSERT INTO tb_Users ([user], [password]) VALUES (@user, @password, @permission)";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@user", admin.user);
                command.Parameters.AddWithValue("@password", admin.password);
                command.Parameters.AddWithValue("@permission", admin.permission);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm admin: " + ex.Message);
                return false;
            }
            finally
            {
                connectionManager.CloseConnection(_connection);
            }
        }

        public bool UpdateAdmin(Users admin)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            _connection = connectionManager.GetConnection();
            if (_connection == null) return false;

            try
            {
                string query = "UPDATE tb_Users SET [user] = @user, [password] = @password, [permission] = @permission WHERE id = @id";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@user", admin.user);
                command.Parameters.AddWithValue("@password", admin.password);
                command.Parameters.AddWithValue("@permission", admin.permission);
                command.Parameters.AddWithValue("@id", admin.id);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật admin: " + ex.Message);
                return false;
            }
            finally
            {
                connectionManager.CloseConnection(_connection);
            }
        }

        public bool DeleteAdmin(int id)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            _connection = connectionManager.GetConnection();
            if (_connection == null) return false;

            try
            {
                string query = "DELETE FROM tb_Users WHERE id = @id";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@id", id);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa admin: " + ex.Message);
                return false;
            }
            finally
            {
                connectionManager.CloseConnection(_connection);
            }
        }
    }
}
