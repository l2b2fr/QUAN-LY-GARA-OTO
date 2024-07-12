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

namespace QUAN_LY_GARA_OTO.UI.QuanLyTaiKhoan
{
    public partial class ucQuanLyTaiKhoan : DevExpress.XtraEditors.XtraUserControl
    {
        private static string typeLuu;
        private static Users users;
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
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            typeLuu = "Thêm";
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            typeLuu = "Sửa";
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (users.DeleteAdmin(users.id))
            {
                MessageBox.Show("Xóa thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Vui lòng chọn User muốn xóa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (typeLuu == "Thêm")
            {
                if (txtTaiKhoan.Text == "" || txtMatKhau.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    users = new Users();
                    users.user = txtTaiKhoan.Text;
                    users.password = txtMatKhau.Text;
                    users.permission = slePhanQuyen.Text;
                    if (users.CreateAdmin(users))
                    {
                        MessageBox.Show("Tạo thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData();
                    }
                    else
                    {
                        MessageBox.Show("Tạo thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (txtTaiKhoan.Text == "" || txtMatKhau.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    users.user = txtTaiKhoan.Text;
                    users.password = txtMatKhau.Text;
                    users.permission = slePhanQuyen.Text;
                    if (users.UpdateAdmin(users))
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
            loadData();
        }

        private void loadData()
        {
            DataToTable gridControl = new DataToTable();
            gridControl1.DataSource = gridControl.GetDataTable("SELECT * FROM tb_Users");
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            users = new Users();
            users.id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id"));
            txtTaiKhoan.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "user").ToString();
            txtMatKhau.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "password").ToString();

            string phanQuyen = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "permission").ToString();
            if (phanQuyen == "ADMIN")
            {
                slePhanQuyen.EditValue = 1;
            }
            else
            {
                slePhanQuyen.EditValue = 2;
            }
        }
    }
}
