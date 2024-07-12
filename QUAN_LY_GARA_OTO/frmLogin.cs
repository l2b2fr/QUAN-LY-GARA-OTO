using DevExpress.XtraReports.UI;
using QUAN_LY_GARA_OTO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUAN_LY_GARA_OTO
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private bool passwordChar = true;


        private void timer1_Tick(object sender, EventArgs e)
        {
            Opacity += .2;
        }
        private void timer2_Tick_1(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Show();
                progressBar1.Value += 10;
                if (progressBar1.Value == 100)
                {
                    this.Hide();
                    frm_Dashboard frm_Dashboard = new frm_Dashboard();
                    frm_Dashboard.Show();
                }
            }
            else
            {
                progressBar1.Hide();
                timer2.Stop();
            }
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            timer1.Start();
            progressBar1.Hide();
            cmbPermission.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Thông báo", "Bạn có muốn thoát không", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            //ReportPrintTool printTool = new ReportPrintTool(new DoanhSo());
            //printTool.ShowPreview();
            //ReportDesignTool designTool = new ReportDesignTool(new ReportDoanhSo());
            //designTool.ShowDesigner();
            Users admin = new Users();
            admin.user = txt_TaiKhoan.Text;
            admin.password = txt_MatKhau.Text;
            admin.permission = cmbPermission.Text;

            if (admin.AdminExists(admin))
            {
                timer2.Start();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mất khẩu không chính sác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMatKhau.Checked == false)
            {
                txt_MatKhau.PasswordChar = '*';
            }
            else
            {
                txt_MatKhau.PasswordChar = '\0';
            }
        }
    }
}
