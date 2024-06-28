using DevExpress.CodeParser;
using DevExpress.XtraEditors;
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
    public partial class ucTraCuuXe : DevExpress.XtraEditors.XtraUserControl
    {
        private PhuongTien phuongTien;
        public ucTraCuuXe()
        {
            InitializeComponent();
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
                    loadDataPhuongTien(phuongTien);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy biển số xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void loadData()
        {
            DataToTable gridControl = new DataToTable();
            string query = "SELECT k.id, k.name, p.carBrand, p.carNumberPlates, t.debt FROM tb_TiepNhanXeSua t JOIN tb_PhuongTien p ON t.idPhuongTien = p.id JOIN tb_KhachHang k ON p.idKhachHang = k.id WHERE t.debt IS NOT NULL;";
            gridData.DataSource = gridControl.GetDataTable(query);
        }

        private void loadDataPhuongTien(PhuongTien phuongTien)
        {
            DataToTable gridControl = new DataToTable();
            string query = "SELECT k.id, k.name, p.carBrand, p.carNumberPlates, t.debt FROM tb_TiepNhanXeSua t JOIN tb_PhuongTien p ON t.idPhuongTien = p.id JOIN tb_KhachHang k ON p.idKhachHang = k.id WHERE t.debt IS NOT NULL AND t.idPhuongTien = " + phuongTien.id + ";";
            gridData.DataSource = gridControl.GetDataTable(query);
        }

        private void ucTraCuuXe_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            txtChuXe.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "name").ToString();
            txtHieuXe.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "carBrand").ToString();
            txtBienSo.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "carNumberPlates").ToString();
            txtTienNo.Text = string.Format("{0:0,0 vnđ}", Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "debt")));
        }
    }
}
