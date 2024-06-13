using QUAN_LY_GARA_OTO.DataBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUAN_LY_GARA_OTO.Models
{
    internal class VatTuPhuTung
    {
        public int id { get; set; }
        public string spareParts { get; set; }
        public decimal unitPrice { get; set; }
        public string unitType { get; set; }

        public VatTuPhuTung() { }

        public VatTuPhuTung(int id, string spareParts, decimal unitPrice, string unitType)
        {
            this.id = id;
            this.spareParts = spareParts;
            this.unitPrice = unitPrice;
            this.unitType = unitType;
        }

        // Hàm thêm thông tin vật tư phụ tùng
        public bool AddVatTuPhuTung(string spareParts, decimal unitPrice, string unitType)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            SqlConnection _connection = connectionManager.GetConnection();
            if (_connection == null) return false;

            try
            {
                string query = "INSERT INTO tb_VatTuPhuTung ([spareParts], [unitPrice], [unitType]) VALUES (@spareParts, @unitPrice, @unitType)";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@spareParts", spareParts);
                command.Parameters.AddWithValue("@unitPrice", unitPrice);
                command.Parameters.AddWithValue("@unitType", unitType);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm thông tin vật tư phụ tùng: " + ex.Message);
                return false;
            }
            finally
            {
                connectionManager.CloseConnection(_connection);
            }
        }

        // Hàm cập nhật thông tin vật tư phụ tùng
        public bool UpdateVatTuPhuTung(int id, string spareParts, decimal unitPrice, string unitType)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            SqlConnection _connection = connectionManager.GetConnection();
            if (_connection == null) return false;

            try
            {
                string query = "UPDATE tb_VatTuPhuTung SET [spareParts] = @spareParts, [unitPrice] = @unitPrice, [unitType] = @unitType WHERE id = @id";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@spareParts", spareParts);
                command.Parameters.AddWithValue("@unitPrice", unitPrice);
                command.Parameters.AddWithValue("@unitType", unitType);
                command.Parameters.AddWithValue("@id", id);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật thông tin vật tư phụ tùng: " + ex.Message);
                return false;
            }
            finally
            {
                connectionManager.CloseConnection(_connection);
            }
        }

        // Hàm xóa thông tin vật tư phụ tùng
        public bool DeleteVatTuPhuTung(int id)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            SqlConnection _connection = connectionManager.GetConnection();
            if (_connection == null) return false;

            try
            {
                string query = "DELETE FROM tb_VatTuPhuTung WHERE id = @id";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@id", id);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa thông tin vật tư phụ tùng: " + ex.Message);
                return false;
            }
            finally
            {
                connectionManager.CloseConnection(_connection);
            }
        }

    }
}
