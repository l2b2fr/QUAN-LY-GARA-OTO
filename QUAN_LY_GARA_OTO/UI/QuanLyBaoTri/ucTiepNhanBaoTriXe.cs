using DevExpress.Utils;
using DevExpress.XtraCharts.Design;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Filtering.Templates;
using QUAN_LY_GARA_OTO.DataBase;
using QUAN_LY_GARA_OTO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUAN_LY_GARA_OTO.UI.QuanLyBaoTri
{
    public partial class ucTiepNhanBaoTriXe : DevExpress.XtraEditors.XtraUserControl
    {
        private String typeLuu;
        private int idTiepNhanBaoTri;

        public ucTiepNhanBaoTriXe()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (checkValues() && typeLuu == "Them")
            {
                try
                {
                    KhachHang khachHang = new KhachHang();
                    khachHang.name = txtTenChuXe.Text;
                    khachHang.phone = txtSDT.Text;
                    khachHang.address = txtDiaChi.Text;
                    khachHang.email = "";

                    if (khachHang.CreateKhachHang(khachHang))
                    {
                        khachHang = khachHang.SelectKhanhHangSDT(khachHang.phone);
                        PhuongTien phuongTien = new PhuongTien();
                        phuongTien.idKhachHang = khachHang.id;
                        phuongTien.carNumberPlates = txtBienSo.Text;
                        phuongTien.carBrand = cmbHieuXe.Text;
                        try
                        {
                            if (phuongTien.CreatePhuongTien(phuongTien))
                            {
                                phuongTien = phuongTien.SelectPhuongTienKhachHang(phuongTien.idKhachHang);
                                TiepNhanXeSua tiepNhanXeSua = new TiepNhanXeSua();
                                tiepNhanXeSua.idPhuongTien = phuongTien.id;
                                tiepNhanXeSua.dayReception = dtNgayTiepNhan.DateTime;
                                tiepNhanXeSua.totalCost = 0;
                                tiepNhanXeSua.amountPaid = 0;
                                tiepNhanXeSua.debt = 0;
                                if (tiepNhanXeSua.CreateTiepNhanXeSua(tiepNhanXeSua))
                                {
                                    MessageBox.Show("Tạo thành công");
                                    LoadData();
                                }
                                else {

                                    MessageBox.Show("lỗi kk");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lỗi");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (checkValues() && typeLuu == "Sua")
            {
                try
                {
                    KhachHang khachHang = new KhachHang();
                    String id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString();
                    khachHang.id = Int32.Parse(id);
                    khachHang.name = txtTenChuXe.Text;
                    khachHang.phone = txtSDT.Text;
                    khachHang.address = txtDiaChi.Text;
                    khachHang.email = "";

                    if (khachHang.UpdateKhachHang(khachHang))
                    {
                        PhuongTien phuongTien = new PhuongTien();
                        phuongTien.idKhachHang = khachHang.id;
                        phuongTien.carNumberPlates = txtBienSo.Text;
                        phuongTien.carBrand = cmbHieuXe.Text;
                        try
                        {
                            if (phuongTien.UpdatePhuongTien(phuongTien))
                            {
                                phuongTien = phuongTien.SelectPhuongTienKhachHang(phuongTien.idKhachHang);
                                TiepNhanXeSua tiepNhanXeSua = new TiepNhanXeSua();
                                tiepNhanXeSua = tiepNhanXeSua.getAllInfo(idTiepNhanBaoTri);
                                tiepNhanXeSua.dayReception = dtNgayTiepNhan.DateTime;
                                if (tiepNhanXeSua.UpdateTiepNhanXeSua(tiepNhanXeSua))
                                {
                                    MessageBox.Show("Sửa thành công");
                                    LoadData();
                                }
                                else
                                {
                                    MessageBox.Show("Lỗi");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Lỗi");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            txtTenChuXe.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtBienSo.Text = "";
            dtNgayTiepNhan.DateTime = DateTime.Now;
            typeLuu = "Them";
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;

            txtTenChuXe.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtBienSo.Text = "";
            typeLuu = "Sua";
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KhachHang khachHang = new KhachHang();
            String id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString();
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (khachHang.DeleteKhachHang(Int32.Parse(id)))
                    MessageBox.Show("Xóa thành công");
                LoadData();
            }
        }

        private void barbtnDieuChinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void ucTiepNhanBaoTriXe_Load(object sender, EventArgs e)
        {
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            LoadData();
            loadHangXe();
            dtNgayTiepNhan.Properties.DisplayFormat.FormatType = FormatType.DateTime;
            dtNgayTiepNhan.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
        }

        private void LoadData()
        {
            DataToTable gridControl = new DataToTable();
            gridData.DataSource = gridControl.GetDataTable("SELECT tb_KhachHang.id, name, address, phone, carBrand, carNumberPlates,tb_TiepNhanXeSua.id as idTiepNhan, dayReception FROM tb_KhachHang,tb_PhuongTien,tb_TiepNhanXeSua WHERE tb_KhachHang.id = tb_PhuongTien.idKhachHang AND tb_PhuongTien.id = tb_TiepNhanXeSua.idPhuongTien");
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            txtTenChuXe.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "name").ToString();
            txtDiaChi.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "address").ToString();
            txtSDT.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "phone").ToString();
            txtBienSo.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "carNumberPlates").ToString();
            cmbHieuXe.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "carBrand").ToString();
            DateTime ngayTiepNhan = DateTime.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dayReception").ToString());
            dtNgayTiepNhan.EditValue = ngayTiepNhan;

            idTiepNhanBaoTri = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "idTiepNhan"));
        }

        private bool checkValues()
        {
            if (txtTenChuXe.Text == "" ||
            txtDiaChi.Text == "" ||
            txtSDT.Text == "" ||
            txtBienSo.Text == "" ||
            cmbHieuXe.Text == "" ||
            dtNgayTiepNhan.Text == "")
            {
                MessageBox.Show("Vui lòng điển đầy đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void loadHangXe()
        {
            ComboEdit comboBoxEdit = new ComboEdit();
            List<string> list = new List<string>();
            list = comboBoxEdit.GetDataString("SELECT * FROM tb_CarBrand");
            cmbHieuXe.Properties.Items.AddRange(list);
        }
    }
}
