using QUAN_LY_GARA_OTO.DataBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUAN_LY_GARA_OTO.Models
{
    internal class PhuongTien
    {
        public int id { get; set; }
        public int idKhachHang { get; set; }
        public string carBrand { get; set; }
        public string carNumberPlates { get; set; }
        private SqlConnection _connection;

        public PhuongTien() { }

        public PhuongTien(int id, int idKhachHang, string carBrand, string carNumberPlates)
        {
            this.id = id;
            this.idKhachHang = idKhachHang;
            this.carBrand = carBrand;
            this.carNumberPlates = carNumberPlates;
        }

        // Hàm thêm phương tiện mới
        public bool CreatePhuongTien(PhuongTien phuongTien)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            _connection = connectionManager.GetConnection();
            if (_connection == null) return false;

            try
            {
                string query = "INSERT INTO tb_PhuongTien ([idKhachHang], [carBrand], [carNumberPlates]) VALUES (@idKhachHang, @carBrand, @carNumberPlates)";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@idKhachHang", phuongTien.idKhachHang);
                command.Parameters.AddWithValue("@carBrand", phuongTien.carBrand);
                command.Parameters.AddWithValue("@carNumberPlates", phuongTien.carNumberPlates);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm phương tiện: " + ex.Message);
                return false;
            }
            finally
            {
                connectionManager.CloseConnection(_connection);
            }
        }

        // Hàm cập nhật thông tin phương tiện
        public bool UpdatePhuongTien(PhuongTien phuongTien)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            _connection = connectionManager.GetConnection();
            if (_connection == null) return false;

            try
            {
                string query = "UPDATE tb_PhuongTien SET [idKhachHang] = @idKhachHang, [carBrand] = @carBrand, [carNumberPlates] = @carNumberPlates WHERE id = @id";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@idKhachHang", phuongTien.idKhachHang);
                command.Parameters.AddWithValue("@carBrand", phuongTien.carBrand);
                command.Parameters.AddWithValue("@carNumberPlates", phuongTien.carNumberPlates);
                command.Parameters.AddWithValue("@id", phuongTien.id);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật phương tiện: " + ex.Message);
                return false;
            }
            finally
            {
                connectionManager.CloseConnection(_connection);
            }
        }

        // Hàm xóa phương tiện
        public bool DeletePhuongTien(int id)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            _connection = connectionManager.GetConnection();
            if (_connection == null) return false;

            try
            {
                string query = "DELETE FROM tb_PhuongTien WHERE id = @id";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@id", id);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa phương tiện: " + ex.Message);
                return false;
            }
            finally
            {
                connectionManager.CloseConnection(_connection);
            }
        }
    }
}
