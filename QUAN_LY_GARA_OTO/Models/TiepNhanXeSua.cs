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
    internal class TiepNhanXeSua
    {
        public int id { get; set; }
        public int idPhuongTien { get; set; }
        public DateTime dayReception { get; set; }
        public decimal totalCost { get; set; }
        public decimal amountPaid { get; set; }
        public decimal debt { get; set; }

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
                string query = "INSERT INTO tb_TiepNhanXeSua ([idPhuongTien], [dayReception], [totalCost], [amountPaid], [debt]) VALUES (@idPhuongTien, @dayReception, @totalCost, @amountPaid, @debt)";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@idPhuongTien", tiepNhan.idPhuongTien);
                command.Parameters.AddWithValue("@dayReception", tiepNhan.dayReception);
                command.Parameters.AddWithValue("@totalCost", tiepNhan.totalCost);
                command.Parameters.AddWithValue("@amountPaid", tiepNhan.amountPaid);
                command.Parameters.AddWithValue("@debt", tiepNhan.debt);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                string query = "UPDATE tb_TiepNhanXeSua SET [idPhuongTien] = @idPhuongTien, [dayReception] = @dayReception, [totalCost] = @totalCost, [amountPaid] = @amountPaid, [debt] = @debt WHERE [id] = @id";

                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@idPhuongTien", tiepNhan.idPhuongTien);
                    command.Parameters.AddWithValue("@dayReception", tiepNhan.dayReception);
                    command.Parameters.AddWithValue("@totalCost", tiepNhan.totalCost);
                    command.Parameters.AddWithValue("@amountPaid", tiepNhan.amountPaid);
                    command.Parameters.AddWithValue("@debt", tiepNhan.debt);
                    command.Parameters.AddWithValue("@id", tiepNhan.id);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật tiếp nhận xe sửa: " + ex.Message);
                MessageBox.Show(ex.Message);
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

        public TiepNhanXeSua getAllInfo(int id)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            SqlConnection _connection = connectionManager.GetConnection();
            if (_connection == null) return null;

            TiepNhanXeSua tiepNhan = null;
            try
            {
                string query = "SELECT * FROM tb_TiepNhanXeSua WHERE id = @id";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    tiepNhan = new TiepNhanXeSua
                    {
                        id = reader.GetInt32(reader.GetOrdinal("id")),
                        idPhuongTien = reader.GetInt32(reader.GetOrdinal("idPhuongTien")),
                        dayReception = reader.GetDateTime(reader.GetOrdinal("dayReception")),
                        totalCost = reader.GetDecimal(reader.GetOrdinal("totalCost")),
                        amountPaid = reader.GetDecimal(reader.GetOrdinal("amountPaid")),
                        debt = reader.GetDecimal(reader.GetOrdinal("debt"))
                    };
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connectionManager.CloseConnection(_connection);
            }

            return tiepNhan;
        }

        public TiepNhanXeSua getAllInfoTiepNhan(int idPhuongTien, string dateTime)
        {
            DataBaseConnection connectionManager = new DataBaseConnection();
            SqlConnection _connection = connectionManager.GetConnection();
            if (_connection == null)
            {
                return null;
            };

            TiepNhanXeSua tiepNhan = null;
            try
            {
                string query = "SELECT * FROM tb_TiepNhanXeSua WHERE idPhuongTien = @idPhuongTien AND dayReception = '" + dateTime + "'";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@idPhuongTien", idPhuongTien);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    tiepNhan = new TiepNhanXeSua
                    {
                        id = reader.GetInt32(reader.GetOrdinal("id")),
                        idPhuongTien = reader.GetInt32(reader.GetOrdinal("idPhuongTien")),
                        dayReception = reader.GetDateTime(reader.GetOrdinal("dayReception")),
                        totalCost = reader.GetDecimal(reader.GetOrdinal("totalCost")),
                        amountPaid = reader.GetDecimal(reader.GetOrdinal("amountPaid")),
                        debt = reader.GetDecimal(reader.GetOrdinal("debt"))
                    };
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connectionManager.CloseConnection(_connection);
            }

            return tiepNhan;
        }

    }
}
