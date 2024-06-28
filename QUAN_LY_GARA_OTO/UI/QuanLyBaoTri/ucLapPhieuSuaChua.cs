using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid.Native;
using QUAN_LY_GARA_OTO.DataBase;
using QUAN_LY_GARA_OTO.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUAN_LY_GARA_OTO.UI.QuanLyBaoTri
{
    public partial class ucLapPhieuSuaChua : DevExpress.XtraEditors.XtraUserControl
    {
        private String typeLuu;
        private PhuongTien phuongTien;
        private int idVatTuPhuTung;
        private int idTienCong;
        private int idSoLuongVatTuPhuTung;
        private int idTiepNhanXeSua;
        public ucLapPhieuSuaChua()
        {
            InitializeComponent();
        }

        private void ucLapPhieuSuaChua_Load(object sender, EventArgs e)
        {
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnIn.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnThanhToan.Enabled = false;
            gridView1.GroupPanelText = "Lê Minh Nam";
            nudSoLuong.Enabled = false;
            txtDonGia.Enabled = false;
            txtTienCong.Enabled = false;
            txtThanhTien.Enabled = false;
            lueCongViec.Enabled = false;
            lueVatTuPhuTung.Enabled = false;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            lueVatTuPhuTung.SelectedText = "";
            txtDonGia.Text = "";
            txtTienCong.Text = "";
            nudSoLuong.Value = 0;
            txtThanhTien.Text = "";
            typeLuu = "Thêm";
            lueVatTuPhuTung.Enabled = true;
            nudSoLuong.Enabled = true;
            txtDonGia.Enabled = true;
            lueCongViec.Enabled = true;
            txtTienCong.Enabled = true;
            txtThanhTien.Enabled = true;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            typeLuu = "Sửa";
            lueVatTuPhuTung.Enabled = true;
            nudSoLuong.Enabled = true;
            txtDonGia.Enabled = true;
            lueCongViec.Enabled = true;
            txtTienCong.Enabled = true;
            txtThanhTien.Enabled = true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    SuaChua suaChua = new SuaChua();
                    suaChua.id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString());
                    if (suaChua.DeletePhieuSuaChua(suaChua.id))
                    {
                        MessageBox.Show("Xóa thành công");
                        loadData(phuongTien);
                        loadVatTuPhuTung();
                        loadTienCong();
                        afterUpdateAndCreateAnDelete();
                        btnIn.Enabled = true;
                        btnThem.Enabled = true;
                        btnSua.Enabled = true;
                        btnXoa.Enabled = true;
                        btnThanhToan.Enabled = true;
                        nudSoLuong.Enabled = false;
                        txtDonGia.Enabled = false;
                        txtTienCong.Enabled = false;
                        txtThanhTien.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi xóa");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gặp lỗi" + ex.Message);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            nudSoLuong.Enabled = false;
            txtDonGia.Enabled = false;
            txtTienCong.Enabled = false;
            txtThanhTien.Enabled = false;
            lueVatTuPhuTung.Enabled = false;
            lueCongViec.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtBienSoXe.Text == "")
            {
                MessageBox.Show("Vui nhập biển số xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                phuongTien = new PhuongTien();
                phuongTien = phuongTien.SelectPhuongTienBienSo(txtBienSoXe.Text);
                if (phuongTien.id != 0)
                {
                    loadData(phuongTien);
                    loadVatTuPhuTung();
                    loadTienCong();
                    btnIn.Enabled = true;
                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnThanhToan.Enabled = true;
                    nudSoLuong.Enabled = false;
                    txtDonGia.Enabled = false;
                    txtTienCong.Enabled = false;
                    txtThanhTien.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy biển số xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (typeLuu == "Thêm")
            {
                if (checkValues())
                {
                    SoLuongVatTuPhuTung soLuongVatTuPhuTung = new SoLuongVatTuPhuTung();
                    soLuongVatTuPhuTung.idVatTuPhuTung = idVatTuPhuTung;
                    soLuongVatTuPhuTung.quantity = Convert.ToInt32(nudSoLuong.Value);
                    soLuongVatTuPhuTung = soLuongVatTuPhuTung.CreateSoLuongVatTuPhuTung(soLuongVatTuPhuTung);
                    if (soLuongVatTuPhuTung != null)
                    {
                        decimal tong = 0;
                        try
                        {
                            decimal soLuong = nudSoLuong.Value;
                            decimal vatTuPhuTung = 0;
                            decimal congViec = 0;

                            // Kiểm tra và chuyển đổi lueVatTuPhuTung.EditValue
                            if (lueVatTuPhuTung.EditValue != null && decimal.TryParse(lueVatTuPhuTung.EditValue.ToString(), out vatTuPhuTung))
                            {
                                vatTuPhuTung = Convert.ToDecimal(lueVatTuPhuTung.EditValue);
                            }
                            else
                            {
                                // Xử lý khi giá trị không hợp lệ
                                MessageBox.Show("Vui lòng nhập thêm vật tư và phụ tùng!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            // Kiểm tra và chuyển đổi lueCongViec.EditValue
                            if (lueCongViec.EditValue != null && decimal.TryParse(lueCongViec.EditValue.ToString(), out congViec))
                            {
                                congViec = Convert.ToDecimal(lueCongViec.EditValue);
                            }
                            else
                            {
                                // Xử lý khi giá trị không hợp lệ
                                MessageBox.Show("Vui lòng nhập thêm công việc!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            tong = (soLuong * vatTuPhuTung) + congViec;
                        }
                        catch (FormatException ex)
                        {
                            // Xử lý lỗi khi giá trị không đúng định dạng
                            MessageBox.Show("Có lỗi xảy ra khi chuyển đổi dữ liệu. Vui lòng kiểm tra lại giá trị nhập vào.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception ex)
                        {
                            // Xử lý các lỗi khác
                            MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        txtThanhTien.Text = string.Format("{0:0,0 vnđ}", tong);
                        SuaChua suaChua = new SuaChua();
                        suaChua.idTiepNhanXeSua = idTiepNhanXeSua;
                        suaChua.idSoLuongVatTuPhuTung = soLuongVatTuPhuTung.id;
                        suaChua.idCongViec = idTienCong;
                        suaChua.intoMoney = tong;
                        if (suaChua.CreatePhieuSuaChua(suaChua))
                        {
                            MessageBox.Show("Tạo thành công");
                            loadData(phuongTien);
                            loadVatTuPhuTung();
                            loadTienCong();
                            afterUpdateAndCreateAnDelete();
                            updateTotalCost(idTiepNhanXeSua);
                        }
                        else
                        {
                            MessageBox.Show("Ngày " + dtNgaySuaChua.Text + " chưa được tiếp nhận cho phương tiện này");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lỗi 1");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (typeLuu == "Sửa")
            {
                if (checkValues())
                {
                    decimal tong = 0;
                    try
                    {
                        decimal soLuong = nudSoLuong.Value;
                        decimal vatTuPhuTung = 0;
                        decimal congViec = 0;

                        // Kiểm tra và chuyển đổi lueVatTuPhuTung.EditValue
                        if (lueVatTuPhuTung.EditValue != null && decimal.TryParse(lueVatTuPhuTung.EditValue.ToString(), out vatTuPhuTung))
                        {
                            vatTuPhuTung = Convert.ToDecimal(lueVatTuPhuTung.EditValue);
                        }
                        else
                        {
                            // Xử lý khi giá trị không hợp lệ
                            MessageBox.Show("Vui lòng nhập thêm vật tư và phụ tùng!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        // Kiểm tra và chuyển đổi lueCongViec.EditValue
                        if (lueCongViec.EditValue != null && decimal.TryParse(lueCongViec.EditValue.ToString(), out congViec))
                        {
                            congViec = Convert.ToDecimal(lueCongViec.EditValue);
                        }
                        else
                        {
                            // Xử lý khi giá trị không hợp lệ
                            MessageBox.Show("Vui lòng nhập thêm công việc!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        tong = (soLuong * vatTuPhuTung) + congViec;
                    }
                    catch (FormatException ex)
                    {
                        // Xử lý lỗi khi giá trị không đúng định dạng
                        MessageBox.Show("Có lỗi xảy ra khi chuyển đổi dữ liệu. Vui lòng kiểm tra lại giá trị nhập vào.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        // Xử lý các lỗi khác
                        MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    SoLuongVatTuPhuTung soLuongVatTuPhuTung = new SoLuongVatTuPhuTung();
                    soLuongVatTuPhuTung.id = idSoLuongVatTuPhuTung;
                    soLuongVatTuPhuTung.idVatTuPhuTung = idVatTuPhuTung;
                    soLuongVatTuPhuTung.quantity = Convert.ToInt32(nudSoLuong.Value);
                    soLuongVatTuPhuTung.UpdateSoLuongVatTuPhuTung(soLuongVatTuPhuTung);

                    txtThanhTien.Text = string.Format("{0:0,0 vnđ}", tong);
                    SuaChua suaChua = new SuaChua();
                    suaChua.id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString());
                    suaChua.idTiepNhanXeSua = idTiepNhanXeSua;
                    suaChua.idSoLuongVatTuPhuTung = idSoLuongVatTuPhuTung;
                    suaChua.idCongViec = idTienCong;
                    suaChua.intoMoney = tong;
                    if (suaChua.UpdatePhieuSuaChua(suaChua))
                    {
                        MessageBox.Show("Cập nhật thành công");
                        loadData(phuongTien);
                        loadVatTuPhuTung();
                        loadTienCong();
                        afterUpdateAndCreateAnDelete();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi cập nhật");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void loadData(PhuongTien phuongTien)
        {
            DataToTable gridControl = new DataToTable();
            string ngaySuaChua = DateTime.Parse(dtNgaySuaChua.Text).ToString("yyyy-MM-dd");

            string query = "SELECT psc.id, vtp.spareParts, slvpt.id as idSoluong, slvpt.quantity, vtp.unitPrice, cv.laborCost, cv.content, psc.intoMoney, tnxs.dayReception " +
                           "FROM tb_TiepNhanXeSua tnxs " +
                           "JOIN tb_SuaChua psc ON tnxs.id = psc.idTiepNhanXeSua " +
                           "JOIN tb_SoLuongVatTuPhuTung slvpt ON psc.idSoLuongVatTuPhuTung = slvpt.id " +
                           "JOIN tb_VatTuPhuTung vtp ON slvpt.idVatTuPhuTung = vtp.id " +
                           "JOIN tb_CongViec cv ON psc.idCongViec = cv.id " +
                           "WHERE tnxs.idPhuongTien = " + phuongTien.id + " " +
                           "AND tnxs.dayReception = '" + ngaySuaChua + "' " +
                           "ORDER BY tnxs.dayReception";

            gridData.DataSource = gridControl.GetDataTable(query);

            TiepNhanXeSua tiepNhanXeSua = new TiepNhanXeSua();
            tiepNhanXeSua = tiepNhanXeSua.getAllInfoTiepNhan(phuongTien.id, ngaySuaChua);
            if (tiepNhanXeSua != null)
            {
                loadTienNo();
                idTiepNhanXeSua = tiepNhanXeSua.id;
            }
        }

        private void loadVatTuPhuTung()
        {
            DataToTable gridControl = new DataToTable();
            this.lueVatTuPhuTung.Properties.DataSource = gridControl.GetDataTable("SELECT * FROM tb_VatTuPhuTung");
            this.lueVatTuPhuTung.Properties.DisplayMember = "spareParts";
            this.lueVatTuPhuTung.Properties.ValueMember = "unitPrice";
        }

        private void loadTienCong()
        {
            DataToTable gridControl = new DataToTable();
            this.lueCongViec.Properties.DataSource = gridControl.GetDataTable("SELECT * FROM tb_CongViec");
            this.lueCongViec.Properties.DisplayMember = "content";
            this.lueCongViec.Properties.ValueMember = "laborCost";
        }

        private void lueTienCong_EditValueChanged(object sender, EventArgs e)
        {
            var values = lueCongViec.EditValue;
            txtTienCong.Text = string.Format("{0:0,0 vnđ}", values);
            var values2 = lueCongViec.Properties.View.GetFocusedRowCellValue("id");
            idTienCong = Convert.ToInt32(values2);
            decimal tong = 0;
            try
            {
                decimal soLuong = nudSoLuong.Value;
                decimal vatTuPhuTung = 0;
                decimal congViec = 0;

                // Kiểm tra và chuyển đổi lueVatTuPhuTung.EditValue
                if (lueVatTuPhuTung.EditValue != null && decimal.TryParse(lueVatTuPhuTung.EditValue.ToString(), out vatTuPhuTung))
                {
                    vatTuPhuTung = Convert.ToDecimal(lueVatTuPhuTung.EditValue);
                }
                else
                {
                    // Xử lý khi giá trị không hợp lệ
                    MessageBox.Show("Vui lòng nhập thêm vật tư và phụ tùng!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Kiểm tra và chuyển đổi lueCongViec.EditValue
                if (lueCongViec.EditValue != null && decimal.TryParse(lueCongViec.EditValue.ToString(), out congViec))
                {
                    congViec = Convert.ToDecimal(lueCongViec.EditValue);
                }
                else
                {
                    // Xử lý khi giá trị không hợp lệ
                    MessageBox.Show("Vui lòng nhập thêm công việc!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                tong = (soLuong * vatTuPhuTung) + congViec;
            }
            catch (FormatException ex)
            {
                // Xử lý lỗi khi giá trị không đúng định dạng
                MessageBox.Show("Có lỗi xảy ra khi chuyển đổi dữ liệu. Vui lòng kiểm tra lại giá trị nhập vào.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi khác
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtThanhTien.Text = string.Format("{0:0,0 vnđ}", tong);
        }

        private void lueVatTuPhuTung_EditValueChanged(object sender, EventArgs e)
        {
            var values = lueVatTuPhuTung.EditValue;
            txtDonGia.Text = string.Format("{0:0,0 vnđ}", values);
            var values2 = lueVatTuPhuTung.Properties.View.GetFocusedRowCellValue("id");
            idVatTuPhuTung = Convert.ToInt32(values2);
            decimal tong = 0;
            try
            {
                decimal soLuong = nudSoLuong.Value;
                decimal vatTuPhuTung = 0;
                decimal congViec = 0;

                // Kiểm tra và chuyển đổi lueVatTuPhuTung.EditValue
                if (lueVatTuPhuTung.EditValue != null && decimal.TryParse(lueVatTuPhuTung.EditValue.ToString(), out vatTuPhuTung))
                {
                    vatTuPhuTung = Convert.ToDecimal(lueVatTuPhuTung.EditValue);
                }
                else
                {
                    // Xử lý khi giá trị không hợp lệ
                    MessageBox.Show("Vui lòng nhập thêm vật tư và phụ tùng!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Kiểm tra và chuyển đổi lueCongViec.EditValue
                if (lueCongViec.EditValue != null && decimal.TryParse(lueCongViec.EditValue.ToString(), out congViec))
                {
                    congViec = Convert.ToDecimal(lueCongViec.EditValue);
                }
                else
                {
                    // Xử lý khi giá trị không hợp lệ
                    MessageBox.Show("Vui lòng nhập thêm công việc!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                tong = (soLuong * vatTuPhuTung) + congViec;
            }
            catch (FormatException ex)
            {
                // Xử lý lỗi khi giá trị không đúng định dạng
                MessageBox.Show("Có lỗi xảy ra khi chuyển đổi dữ liệu. Vui lòng kiểm tra lại giá trị nhập vào.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi khác
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtThanhTien.Text = string.Format("{0:0,0 vnđ}", tong);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (txtThanhToan.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tiền", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                TiepNhanXeSua tiepNhanXeSua = new TiepNhanXeSua();
                string ngaySuaChua = DateTime.Parse(dtNgaySuaChua.Text).ToString("yyyy-MM-dd");
                tiepNhanXeSua = tiepNhanXeSua.getAllInfoTiepNhan(phuongTien.id, ngaySuaChua);
                tiepNhanXeSua.amountPaid = Convert.ToDecimal(txtThanhToan.Text);
                tiepNhanXeSua.UpdateTiepNhanXeSua(tiepNhanXeSua);
                loadData(phuongTien);
                loadTienNo();
            }
        }

        private bool checkValues()
        {
            if (nudSoLuong.Text == "" || txtDonGia.Text == "" || txtTienCong.Text == "" || txtThanhTien.Text == "" || lueCongViec.Text == "" || lueVatTuPhuTung.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void nudSoLuong_ValueChanged(object sender, EventArgs e)
        {
            decimal tong = 0;
            try
            {
                decimal soLuong = nudSoLuong.Value;
                decimal vatTuPhuTung = 0;
                decimal congViec = 0;

                // Kiểm tra và chuyển đổi lueVatTuPhuTung.EditValue
                if (lueVatTuPhuTung.EditValue != null && decimal.TryParse(lueVatTuPhuTung.EditValue.ToString(), out vatTuPhuTung))
                {
                    vatTuPhuTung = Convert.ToDecimal(lueVatTuPhuTung.EditValue);
                }
                else
                {

                    return;
                }

                // Kiểm tra và chuyển đổi lueCongViec.EditValue
                if (lueCongViec.EditValue != null && decimal.TryParse(lueCongViec.EditValue.ToString(), out congViec))
                {
                    congViec = Convert.ToDecimal(lueCongViec.EditValue);
                }
                else
                {

                    return;
                }

                tong = (soLuong * vatTuPhuTung) + congViec;
            }
            catch (FormatException ex)
            {
                // Xử lý lỗi khi giá trị không đúng định dạng
                MessageBox.Show("Có lỗi xảy ra khi chuyển đổi dữ liệu. Vui lòng kiểm tra lại giá trị nhập vào.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi khác
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtThanhTien.Text = string.Format("{0:0,0 vnđ}", tong);
        }
        private void afterUpdateAndCreateAnDelete()
        {
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnIn.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThanhToan.Enabled = true;
        }

        private void dtNgaySuaChua_ValueChanged(object sender, EventArgs e)
        {
            if (phuongTien != null)
            {
                loadData(phuongTien);
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            lueVatTuPhuTung.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "content").ToString();
            nudSoLuong.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "quantity").ToString();
            txtDonGia.Text = string.Format("{0:0,0 vnđ}", Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "unitPrice")));
            lueCongViec.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "spareParts").ToString();
            txtTienCong.Text = string.Format("{0:0,0 vnđ}", Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "laborCost")));
            txtThanhTien.Text = string.Format("{0:0,0 vnđ}", Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "intoMoney")));
            idSoLuongVatTuPhuTung = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "idSoluong"));
        }

        private void updateTotalCost(int id)
        {
            SuaChua suaChua = new SuaChua();
            TiepNhanXeSua tiepNhanXeSua = new TiepNhanXeSua();
            string ngaySuaChua = DateTime.Parse(dtNgaySuaChua.Text).ToString("yyyy-MM-dd");
            tiepNhanXeSua = tiepNhanXeSua.getAllInfoTiepNhan(phuongTien.id, ngaySuaChua);
            tiepNhanXeSua.totalCost = suaChua.GetSumIntoMoney(id);
            tiepNhanXeSua.UpdateTiepNhanXeSua(tiepNhanXeSua);
            loadData(phuongTien);
        }

        private void loadTienNo()
        {
            TiepNhanXeSua tiepNhanXeSua = new TiepNhanXeSua();
            string ngaySuaChua = DateTime.Parse(dtNgaySuaChua.Text).ToString("yyyy-MM-dd");
            tiepNhanXeSua = tiepNhanXeSua.getAllInfoTiepNhan(phuongTien.id, ngaySuaChua);
            tiepNhanXeSua.debt = (tiepNhanXeSua.totalCost - tiepNhanXeSua.amountPaid);
            tiepNhanXeSua.UpdateTiepNhanXeSua(tiepNhanXeSua);
            tiepNhanXeSua = tiepNhanXeSua.getAllInfoTiepNhan(phuongTien.id, ngaySuaChua);
            txtTienNo.Text = string.Format("{0:0,0 vnđ}", tiepNhanXeSua.debt);
        }
    }
}
