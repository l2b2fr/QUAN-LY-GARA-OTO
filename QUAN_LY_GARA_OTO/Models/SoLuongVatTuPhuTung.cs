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
    internal class SoLuongVatTuPhuTung
    {
        public int id { get; set; }
        public int idVatTuPhuTung { get; set; }
        public int quantity { get; set; }
        private SqlConnection _connection;
        public SoLuongVatTuPhuTung() { }

        public SoLuongVatTuPhuTung(int id, int idVatTuPhuTung, int quantity)
        {
            this.id = id;
            this.idVatTuPhuTung = idVatTuPhuTung;
            this.quantity = quantity;
        }

        // Hàm thêm số lượng vật tư phụ tùng mới
        public SoLuongVatTuPhuTung CreateSoLuongVatTuPhuTung(SoLuongVatTuPhuTung soLuong)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            _connection = connectionManager.GetConnection();
            if (_connection == null) return null;
            SoLuongVatTuPhuTung soLuongVatTuPhuTung = new SoLuongVatTuPhuTung();

            try
            {
                string query = "INSERT INTO tb_SoLuongVatTuPhuTung ([idVatTuPhuTung], [quantity]) VALUES (@idVatTuPhuTung, @quantity); SELECT SCOPE_IDENTITY();";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@idVatTuPhuTung", soLuong.idVatTuPhuTung);
                command.Parameters.AddWithValue("@quantity", soLuong.quantity);
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    soLuongVatTuPhuTung.id = Convert.ToInt32(result);
                    //MessageBox.Show(soLuongVatTuPhuTung.id.ToString());
                    return soLuongVatTuPhuTung;
                }
                else
                {
                    MessageBox.Show("Lỗi khi thêm số lượng vật tư","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm số lượng vật tư phụ tùng: " + ex.Message);
                return null;
            }
            finally
            {
                connectionManager.CloseConnection(_connection);
            }
        }

        // Hàm cập nhật thông tin số lượng vật tư phụ tùng
        public bool UpdateSoLuongVatTuPhuTung(SoLuongVatTuPhuTung soLuong)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            _connection = connectionManager.GetConnection();
            if (_connection == null) return false;

            try
            {
                string query = "UPDATE tb_SoLuongVatTuPhuTung SET [idVatTuPhuTung] = @idVatTuPhuTung, [quantity] = @quantity WHERE id = @id";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@idVatTuPhuTung", soLuong.idVatTuPhuTung);
                command.Parameters.AddWithValue("@quantity", soLuong.quantity);
                command.Parameters.AddWithValue("@id", soLuong.id);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật số lượng vật tư phụ tùng: " + ex.Message);
                return false;
            }
            finally
            {
                connectionManager.CloseConnection(_connection);
            }
        }

        // Hàm xóa số lượng vật tư phụ tùng
        public bool DeleteSoLuongVatTuPhuTung(int id)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            _connection = connectionManager.GetConnection();
            if (_connection == null) return false;

            try
            {
                string query = "DELETE FROM tb_SoLuongVatTuPhuTung WHERE id = @id";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@id", id);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa số lượng vật tư phụ tùng: " + ex.Message);
                return false;
            }
            finally
            {
                connectionManager.CloseConnection(_connection);
            }
        }
    }
}
