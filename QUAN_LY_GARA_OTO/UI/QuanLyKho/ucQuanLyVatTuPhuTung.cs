using DevExpress.XtraEditors;
using QUAN_LY_GARA_OTO.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUAN_LY_GARA_OTO.UI.QuanLyKho
{
    public partial class ucQuanLyVatTuPhuTung : DevExpress.XtraEditors.XtraUserControl
    {
        public ucQuanLyVatTuPhuTung()
        {
            InitializeComponent();
        }
        private void ucQuanLyVatTuPhuTung_Load(object sender, EventArgs e)
        {
            txtTenVatTu.Focus();
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            loadData();
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barbtnDieuChinhSoLuongVatTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            txtDonGia.Text = "";
            txtLoaiDonVi.Text = "";
            txtPhatSinh.Text = "";
            txtTenVatTu.Text = "";
            txtTonCuoi.Text = "";
            txtTonDau.Text = "";
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

        }

        private void loadData()
        {
            DataToTable dataToTable = new DataToTable();
            gridData.DataSource = dataToTable.GetDataTable("SELECT \r\n    vtp.[id], \r\n    vtp.[spareParts], \r\n    vtp.[unitPrice], \r\n    vtp.[unitType],\r\n    qlk.[beginningInventory], \r\n    qlk.[netChange], \r\n    qlk.[endingInventory],\r\n    qlk.[month]\r\nFROM \r\n    [tb_VatTuPhuTung] vtp\r\nINNER JOIN \r\n    [tb_QuanLyKho] qlk\r\nON \r\n    vtp.[id] = qlk.[idVatTuPhuTung];");
        }
    }
}
