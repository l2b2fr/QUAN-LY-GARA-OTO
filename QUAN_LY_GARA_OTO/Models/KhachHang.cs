using DevExpress.Data.Helpers;
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
    internal class KhachHang
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        private SqlConnection _connection;

        public KhachHang() { }

        public KhachHang(int id, string name, string phone, string email, string address)
        {
            this.id = id;
            this.name = name;
            this.phone = phone;
            this.email = email;
            this.address = address;
        }
        public KhachHang SelectKhanhHangSDT(String sdt)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            SqlConnection _connection = connectionManager.GetConnection();
            KhachHang khachHang = new KhachHang();
            if (_connection == null) return null;

            try
            {
                string query = "SELECT * FROM tb_KhachHang WHERE [phone] = @sdt";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@sdt", sdt);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    khachHang.id = reader.GetInt32(reader.GetOrdinal("id"));
                    khachHang.name = reader.GetString(reader.GetOrdinal("name"));
                    khachHang.phone = reader.GetString(reader.GetOrdinal("phone"));
                    khachHang.email = reader.GetString(reader.GetOrdinal("email"));
                    khachHang.address = reader.GetString(reader.GetOrdinal("address"));
                }
                return khachHang;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                connectionManager.CloseConnection(_connection);
            }
        }

        // Hàm thêm khách hàng mới
        public bool CreateKhachHang(KhachHang khachHang)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            _connection = connectionManager.GetConnection();
            if (_connection == null) return false;

            try
            {
                string query = "INSERT INTO tb_KhachHang ([name], [phone], [email], [address]) VALUES (@name, @phone, @email, @address)";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@name", khachHang.name);
                command.Parameters.AddWithValue("@phone", khachHang.phone);
                command.Parameters.AddWithValue("@address", khachHang.address);
                command.Parameters.AddWithValue("@email", khachHang.email);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm khách hàng: " + ex.Message);
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connectionManager.CloseConnection(_connection);
            }
        }

        // Hàm cập nhật thông tin khách hàng
        public bool UpdateKhachHang(KhachHang khachHang)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            _connection = connectionManager.GetConnection();
            if (_connection == null) return false;

            try
            {
                string query = "UPDATE tb_KhachHang SET [name] = @name, [phone] = @phone, [address] = @address, [email] = @email WHERE id = @id";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@name", khachHang.name);
                command.Parameters.AddWithValue("@phone", khachHang.phone);
                command.Parameters.AddWithValue("@address", khachHang.address);
                command.Parameters.AddWithValue("@email", khachHang.email);
                command.Parameters.AddWithValue("@id", khachHang.id);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật khách hàng: " + ex.Message);
                return false;
            }
            finally
            {
                connectionManager.CloseConnection(_connection);
            }
        }

        // Hàm xóa khách hàng
        public bool DeleteKhachHang(int id)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            _connection = connectionManager.GetConnection();
            if (_connection == null) return false;

            try
            {
                string query = "DELETE FROM tb_KhachHang WHERE id = @id";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@id", id);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa khách hàng: " + ex.Message);
                return false;
            }
            finally
            {
                connectionManager.CloseConnection(_connection);
            }
        }
    }
}
