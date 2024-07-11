using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUAN_LY_GARA_OTO.UI.QuanLyTaiKhoan
{
    public partial class ucQuanLyTaiKhoan : DevExpress.XtraEditors.XtraUserControl
    {
        public ucQuanLyTaiKhoan()
        {
            InitializeComponent();
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
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
        }

        private void slePhanQuyen_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void ucQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            // Tạo một DataTable
            DataTable table = new DataTable();

            // Thêm các cột vào DataTable
            table.Columns.Add("Mã", typeof(int));
            table.Columns.Add("Phân quyền", typeof(string));

            table.Rows.Add(1, "ADMIN");
            table.Rows.Add(2, "NHÂN VIÊN");

            slePhanQuyen.Properties.DataSource = table;
            slePhanQuyen.Properties.ValueMember = "Mã";
            slePhanQuyen.EditValue = 1;
            slePhanQuyen.Properties.DisplayMember = "Phân quyền";
        }
    }
}
