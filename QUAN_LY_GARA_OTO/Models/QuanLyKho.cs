using QUAN_LY_GARA_OTO.DataBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUAN_LY_GARA_OTO.Models
{
    internal class QuanLyKho
    {
        public int id { get; set; }
        public int idVatTuPhuTung { get; set; }
        public int beginningInventory { get; set; }
        public int netChange { get; set; }
        public int endingInventory { get; set; }
        public DateTime month { get; set; }
        private SqlConnection _connection;
        public QuanLyKho() { }

        public QuanLyKho(int id, int idVatTuPhuTung, int beginningInventory, int netChange, int endingInventory, DateTime month)
        {
            this.id = id;
            this.idVatTuPhuTung = idVatTuPhuTung;
            this.beginningInventory = beginningInventory;
            this.netChange = netChange;
            this.endingInventory = endingInventory;
            this.month = month;
        }

        // Hàm thêm thông tin vật tư phụ tùng vào kho
        public bool AddVatTuPhuTung(int idVatTuPhuTung, int beginningInventory, int netChange, int endingInventory, DateTime month)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            _connection = connectionManager.GetConnection();
            if (_connection == null) return false;

            try
            {
                string query = "INSERT INTO tb_QuanLyKho ([idVatTuPhuTung], [beginningInventory], [netChange], [endingInventory], [month]) VALUES (@idVatTuPhuTung, @beginningInventory, @netChange, @endingInventory, @month)";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@idVatTuPhuTung", idVatTuPhuTung);
                command.Parameters.AddWithValue("@beginningInventory", beginningInventory);
                command.Parameters.AddWithValue("@netChange", netChange);
                command.Parameters.AddWithValue("@endingInventory", endingInventory);
                command.Parameters.AddWithValue("@month", month);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm thông tin vật tư phụ tùng vào kho: " + ex.Message);
                return false;
            }
            finally
            {
                connectionManager.CloseConnection(_connection);
            }
        }

        // Hàm cập nhật thông tin vật tư phụ tùng trong kho
        public bool UpdateVatTuPhuTung(int id, int beginningInventory, int netChange, int endingInventory, DateTime month)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            _connection = connectionManager.GetConnection();
            if (_connection == null) return false;

            try
            {
                string query = "UPDATE tb_QuanLyKho SET [beginningInventory] = @beginningInventory, [netChange] = @netChange, [endingInventory] = @endingInventory, [month] = @month WHERE id = @id";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@beginningInventory", beginningInventory);
                command.Parameters.AddWithValue("@netChange", netChange);
                command.Parameters.AddWithValue("@endingInventory", endingInventory);
                command.Parameters.AddWithValue("@month", month);
                command.Parameters.AddWithValue("@id", id);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật thông tin vật tư phụ tùng trong kho: " + ex.Message);
                return false;
            }
            finally
            {
                connectionManager.CloseConnection(_connection);
            }
        }

        // Hàm xóa thông tin vật tư phụ tùng khỏi kho
        public bool DeleteVatTuPhuTung(int id)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            _connection = connectionManager.GetConnection();
            if (_connection == null) return false;

            try
            {
                string query = "DELETE FROM tb_QuanLyKho WHERE id = @id";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@id", id);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa thông tin vật tư phụ tùng khỏi kho: " + ex.Message);
                return false;
            }
            finally
            {
                connectionManager.CloseConnection(_connection);
            }
        }
    }
}
