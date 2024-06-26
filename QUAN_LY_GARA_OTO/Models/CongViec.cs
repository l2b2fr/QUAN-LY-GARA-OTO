using QUAN_LY_GARA_OTO.DataBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUAN_LY_GARA_OTO.Models
{
    internal class CongViec
    {
        public int id { get; set; }
        public string content { get; set; }
        public decimal laborCost { get; set; }
        private SqlConnection _connection;
        public CongViec() { }

        public CongViec(int id, string content, decimal laborCost)
        {
            this.id = id;
            this.content = content;
            this.laborCost = laborCost;
        }
        // Hàm thêm công việc mới
        public bool CreateCongViec(string content, decimal laborCost)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            _connection = connectionManager.GetConnection();
            if (_connection == null) return false;

            try
            {
                string query = "INSERT INTO tb_CongViec ([content], [laborCost]) VALUES  (N'@content', N'@laborCost')";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@content", content);
                command.Parameters.AddWithValue("@laborCost", laborCost);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm công việc: " + ex.Message);
                return false;
            }
            finally
            {
                connectionManager.CloseConnection(_connection);
            }
        }

        // Hàm cập nhật thông tin công việc
        public bool UpdateCongViec(int id, string content, decimal laborCost)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            _connection = connectionManager.GetConnection();
            if (_connection == null) return false;

            try
            {
                string query = "UPDATE tb_CongViec SET [content] = N'@content', [laborCost] = N'@laborCost' WHERE id = @id";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@content", content);
                command.Parameters.AddWithValue("@laborCost", laborCost);
                command.Parameters.AddWithValue("@id", id);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật công việc: " + ex.Message);
                return false;
            }
            finally
            {
                connectionManager.CloseConnection(_connection);
            }
        }

        // Hàm xóa công việc
        public bool DeleteCongViec(int id)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            _connection = connectionManager.GetConnection();
            if (_connection == null) return false;

            try
            {
                string query = "DELETE FROM tb_CongViec WHERE id = @id";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@id", id);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa công việc: " + ex.Message);
                return false;
            }
            finally
            {
                connectionManager.CloseConnection(_connection);
            }
        }
    }
}