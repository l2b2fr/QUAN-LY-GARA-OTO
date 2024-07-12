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
    public partial class ucQuanLyTienCong : DevExpress.XtraEditors.XtraUserControl
    {
        public ucQuanLyTienCong()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            barbtnDieuChinhSoLuongCongViec.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

        private void ucQuanLyTienCong_Load(object sender, EventArgs e)
        {
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnHuyTc.Enabled = false;
            btnLuuTc.Enabled = false;
            loadData();
        }

        private void loadData()
        {
            DataToTable gridControl = new DataToTable();
            gridData.DataSource = gridControl.GetDataTable("SELECT * FROM tb_CongViec");
        }

        private void barbtnDieuChinhSoLuongCongViec_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barbtnDieuChinhSoLuongCongViec.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnHuyTc.Enabled = true;
            btnLuuTc.Enabled = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            barbtnDieuChinhSoLuongCongViec.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnHuyTc.Enabled = true;
            btnLuuTc.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            barbtnDieuChinhSoLuongCongViec.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

        private void btnLuuTc_Click(object sender, EventArgs e)
        {

        }

        private void btnHuyTc_Click(object sender, EventArgs e)
        {
            btnHuyTc.Enabled = false;
            btnLuuTc.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }
    }
}
