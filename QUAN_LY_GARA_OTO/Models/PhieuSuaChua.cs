using QUAN_LY_GARA_OTO.DataBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUAN_LY_GARA_OTO.Models
{
    internal class PhieuSuaChua
    {
        public int id { get; set; }
        public int idTiepNhanXeSua { get; set; }
        public int idSoLuongVatTuPhuTung { get; set; }
        public int idCongViec { get; set; }
        public decimal totalCost { get; set; }
        public decimal amountPaid { get; set; }
        public decimal debt { get; set; }
        private SqlConnection _connection;

        public PhieuSuaChua() { }

        public PhieuSuaChua(int id, int idTiepNhanXeSua, int idSoLuongVatTuPhuTung, int idCongViec, decimal totalCost, decimal amountPaid, decimal debt)
        {
            this.id = id;
            this.idTiepNhanXeSua = idTiepNhanXeSua;
            this.idSoLuongVatTuPhuTung = idSoLuongVatTuPhuTung;
            this.idCongViec = idCongViec;
            this.totalCost = totalCost;
            this.amountPaid = amountPaid;
            this.debt = debt;
        }

        // Hàm thêm phiếu sửa chữa mới
        public bool CreatePhieuSuaChua(PhieuSuaChua phieuSuaChua)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            _connection = connectionManager.GetConnection();
            if (_connection == null) return false;

            try
            {
                string query = "INSERT INTO tb_PhieuSuaChua ([idTiepNhanXeSua], [idSoLuongVatTuPhuTung], [idCongViec], [totalCost], [amountPaid], [debt]) VALUES (@idTiepNhanXeSua, @idSoLuongVatTuPhuTung, @idCongViec, @totalCost, @amountPaid, @debt)";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@idTiepNhanXeSua", phieuSuaChua.idTiepNhanXeSua);
                command.Parameters.AddWithValue("@idSoLuongVatTuPhuTung", phieuSuaChua.idSoLuongVatTuPhuTung);
                command.Parameters.AddWithValue("@idCongViec", phieuSuaChua.idCongViec);
                command.Parameters.AddWithValue("@totalCost", phieuSuaChua.totalCost);
                command.Parameters.AddWithValue("@amountPaid", phieuSuaChua.amountPaid);
                command.Parameters.AddWithValue("@debt", phieuSuaChua.debt);
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
        public bool UpdatePhieuSuaChua(PhieuSuaChua phieuSuaChua)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            _connection = connectionManager.GetConnection();
            if (_connection == null) return false;

            try
            {
                string query = "UPDATE tb_PhieuSuaChua SET [idTiepNhanXeSua] = @idTiepNhanXeSua, [idSoLuongVatTuPhuTung] = @idSoLuongVatTuPhuTung, [idCongViec] = @idCongViec, [totalCost] = @totalCost, [amountPaid] = @amountPaid, [debt] = @debt WHERE id = @id";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@idTiepNhanXeSua", phieuSuaChua.idTiepNhanXeSua);
                command.Parameters.AddWithValue("@idSoLuongVatTuPhuTung", phieuSuaChua.idSoLuongVatTuPhuTung);
                command.Parameters.AddWithValue("@idCongViec", phieuSuaChua.idCongViec);
                command.Parameters.AddWithValue("@totalCost", phieuSuaChua.totalCost);
                command.Parameters.AddWithValue("@amountPaid", phieuSuaChua.amountPaid);
                command.Parameters.AddWithValue("@debt", phieuSuaChua.debt);
                command.Parameters.AddWithValue("@id", phieuSuaChua.id);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật phiếu sửa chữa: " + ex.Message);
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
                string query = "DELETE FROM tb_PhieuSuaChua WHERE id = @id";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@id", id);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa phiếu sửa chữa: " + ex.Message);
                return false;
            }
            finally
            {
                connectionManager.CloseConnection(_connection);
            }
        }
    }
}
