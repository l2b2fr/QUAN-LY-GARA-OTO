using QUAN_LY_GARA_OTO.DataBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUAN_LY_GARA_OTO.Models
{
    internal class TiepNhanXeSua
    {
        public int id { get; set; }
        public int idPhuongTien { get; set; }
        public DateTime dayReception { get; set; }
        private SqlConnection _connection;

        public TiepNhanXeSua() { }
        public TiepNhanXeSua(int id, int idPhuongTien, DateTime dayReception)
        {
            this.id = id;
            this.idPhuongTien = idPhuongTien;
            this.dayReception = dayReception;
        }

        // Hàm thêm tiếp nhận xe sửa mới
        public bool CreateTiepNhanXeSua(TiepNhanXeSua tiepNhan)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            SqlConnection _connection = connectionManager.GetConnection();
            if (_connection == null) return false;

            try
            {
                string query = "INSERT INTO tb_TiepNhanXeSua ([idPhuongTien], [dayReception]) VALUES (@idPhuongTien, @dayReception)";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@idPhuongTien", tiepNhan.idPhuongTien);
                command.Parameters.AddWithValue("@dayReception", tiepNhan.dayReception);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm tiếp nhận xe sửa: " + ex.Message);
                return false;
            }
            finally
            {
                connectionManager.CloseConnection(_connection);
            }
        }

        // Hàm cập nhật thông tin tiếp nhận xe sửa
        public bool UpdateTiepNhanXeSua(TiepNhanXeSua tiepNhan)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            SqlConnection _connection = connectionManager.GetConnection();
            if (_connection == null) return false;

            try
            {
                string query = "UPDATE tb_TiepNhanXeSua SET [idPhuongTien] = @idPhuongTien, [dayReception] = @dayReception WHERE id = @id";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@idPhuongTien", tiepNhan.idPhuongTien);
                command.Parameters.AddWithValue("@dayReception", tiepNhan.dayReception);
                command.Parameters.AddWithValue("@id", tiepNhan.id);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật tiếp nhận xe sửa: " + ex.Message);
                return false;
            }
            finally
            {
                connectionManager.CloseConnection(_connection);
            }
        }

        // Hàm xóa tiếp nhận xe sửa
        public bool DeleteTiepNhanXeSua(int id)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            SqlConnection _connection = connectionManager.GetConnection();
            if (_connection == null) return false;

            try
            {
                string query = "DELETE FROM tb_TiepNhanXeSua WHERE id = @id";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@id", id);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa tiếp nhận xe sửa: " + ex.Message);
                return false;
            }
            finally
            {
                connectionManager.CloseConnection(_connection);
            }
        }
    }
}
