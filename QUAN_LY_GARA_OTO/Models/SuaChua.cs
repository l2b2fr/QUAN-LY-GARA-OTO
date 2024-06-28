using DevExpress.Xpo.DB.Helpers;
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
    internal class SuaChua
    {
        public int id { get; set; }
        public int idTiepNhanXeSua { get; set; }
        public int idSoLuongVatTuPhuTung { get; set; }
        public int idCongViec { get; set; }
        public decimal intoMoney { get; set; }

        private SqlConnection _connection;

        public SuaChua() { }

        public SuaChua(int id, int idTiepNhanXeSua, int idSoLuongVatTuPhuTung, int idCongViec, decimal intoMoney)
        {
            this.id = id;
            this.idTiepNhanXeSua = idTiepNhanXeSua;
            this.idSoLuongVatTuPhuTung = idSoLuongVatTuPhuTung;
            this.idCongViec = idCongViec;
            this.intoMoney = intoMoney;
        }

        // Hàm thêm phiếu sửa chữa mới
        public bool CreatePhieuSuaChua(SuaChua phieuSuaChua)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            _connection = connectionManager.GetConnection();
            if (_connection == null) return false;

            try
            {
                string query = "INSERT INTO tb_SuaChua ([idTiepNhanXeSua], [idSoLuongVatTuPhuTung], [idCongViec], [intoMoney]) VALUES (@idTiepNhanXeSua, @idSoLuongVatTuPhuTung, @idCongViec, @intoMoney)";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@idTiepNhanXeSua", phieuSuaChua.idTiepNhanXeSua);
                command.Parameters.AddWithValue("@idSoLuongVatTuPhuTung", phieuSuaChua.idSoLuongVatTuPhuTung);
                command.Parameters.AddWithValue("@idCongViec", phieuSuaChua.idCongViec);
                command.Parameters.AddWithValue("@intoMoney", phieuSuaChua.intoMoney);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm phiếu sửa chữa: " + ex.Message);
                return false;
            }
            finally
            {
                connectionManager.CloseConnection(_connection);
            }
        }

        // Hàm cập nhật thông tin phiếu sửa chữa
        public bool UpdatePhieuSuaChua(SuaChua phieuSuaChua)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            _connection = connectionManager.GetConnection();
            if (_connection == null)
            {
                MessageBox.Show("Lỗi khi cập nhật phiếu sửa chữa 1 ");
                return false;
            };

            try
            {
                string query = "UPDATE tb_SuaChua SET [idTiepNhanXeSua] = @idTiepNhanXeSua, [idSoLuongVatTuPhuTung] = @idSoLuongVatTuPhuTung, [idCongViec] = @idCongViec, [intoMoney] = @intoMoney WHERE id = @id";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@idTiepNhanXeSua", phieuSuaChua.idTiepNhanXeSua);
                command.Parameters.AddWithValue("@idSoLuongVatTuPhuTung", phieuSuaChua.idSoLuongVatTuPhuTung);
                command.Parameters.AddWithValue("@idCongViec", phieuSuaChua.idCongViec);
                command.Parameters.AddWithValue("@intoMoney", phieuSuaChua.intoMoney);
                command.Parameters.AddWithValue("@id", phieuSuaChua.id);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật phiếu sửa chữa: " + ex.Message);
                MessageBox.Show("Lỗi khi cập nhật phiếu sửa chữa: " + ex.Message);
                return false;
            }
            finally
            {
                connectionManager.CloseConnection(_connection);
            }
        }

        // Hàm xóa phiếu sửa chữa
        public bool DeletePhieuSuaChua(int id)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            _connection = connectionManager.GetConnection();
            if (_connection == null) return false;

            try
            {
                string query = "DELETE FROM tb_SuaChua WHERE id = @id";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@id", id);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa phiếu sửa chữa: " + ex.Message);
                MessageBox.Show("Lỗi khi xóa phiếu sửa chữa: " + ex.Message);
                return false;
            }
            finally
            {
                connectionManager.CloseConnection(_connection);
            }
        }

        public decimal GetSumIntoMoney(int id)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            _connection = connectionManager.GetConnection();
            if (_connection == null) return 0;
            

            try
            {
                string query = "SELECT SUM(intoMoney) FROM tb_SuaChua WHERE idTiepNhanXeSua = @id";
                decimal totalIntoMoney = 0;
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@id", id);
                object result = command.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    totalIntoMoney = Convert.ToDecimal(result);
                }
                return totalIntoMoney;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa phiếu sửa chữa: " + ex.Message);
                MessageBox.Show("Lỗi khi xóa phiếu sửa chữa: " + ex.Message);
                return 0;
            }
            finally
            {
                connectionManager.CloseConnection(_connection);
            }
        }
    }
}