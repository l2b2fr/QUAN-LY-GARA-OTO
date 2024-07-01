using DevExpress.XtraBars;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QUAN_LY_GARA_OTO.UI;
using QUAN_LY_GARA_OTO.UI.QuanLyBaoCao;
using QUAN_LY_GARA_OTO.UI.QuanLyBaoTri;
using QUAN_LY_GARA_OTO.UI.QuanLyKho;
using QUAN_LY_GARA_OTO.UI.QuanLyTaiKhoan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QUAN_LY_GARA_OTO
{
    public partial class frm_Dashboard : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public frm_Dashboard()
        {
            InitializeComponent();
        }
        private ucDashBoard ucDashBoard;
        private ucLapPhieuSuaChua ucLapPhieuSuaChua;
        private ucTiepNhanBaoTriXe ucTiepNhanBaoTriXe;
        private ucTraCuuXe ucTraCuuXe;
        private ucQuanLyVatTuPhuTung ucQuanLyVatTuPhuTung;
        private ucQuanLyTienCong ucQuanLyTienCong;
        private ucBaoCaoDoanhSo ucBaoCaoDoanhSo;
        private ucBaoCaoTon ucBaoCaoTon;
        private ucQuanLyTaiKhoan ucQuanLyTaiKhoan;

        private void timer1_Tick(object sender, EventArgs e)
        {
            Opacity += .2;
        }

        private void frm_Dasboard_Load(object sender, EventArgs e)
        {
            timer1.Start();
            ucDashBoard = new ucDashBoard();
            ucDashBoard.Dock = DockStyle.Fill;
            mainContainer.Controls.Add(ucDashBoard);
            ucDashBoard.BringToFront();
        }

        private void frm_Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void aceLapPhieuSuaChua_Click(object sender, EventArgs e)
        {
            btxtTieuDe.Caption = aceLapPhieuSuaChua.Text;
            ucLapPhieuSuaChua = new ucLapPhieuSuaChua();
            ucLapPhieuSuaChua.Dock = DockStyle.Fill;
            mainContainer.Controls.Add(ucLapPhieuSuaChua);
            ucLapPhieuSuaChua.BringToFront();
        }

        private void aceTraCuuXe_Click(object sender, EventArgs e)
        {
            btxtTieuDe.Caption = aceTraCuuXe.Text;
            ucTraCuuXe = new ucTraCuuXe();
            ucTraCuuXe.Dock = DockStyle.Fill;
            mainContainer.Controls.Add(ucTraCuuXe);
            ucTraCuuXe.BringToFront();
        }

        private void aceQuanLyVatTuPhuTung_Click(object sender, EventArgs e)
        {
            btxtTieuDe.Caption = aceQuanLyVatTuPhuTung.Text;
            ucQuanLyVatTuPhuTung = new ucQuanLyVatTuPhuTung();
            ucQuanLyVatTuPhuTung.Dock = DockStyle.Fill;
            mainContainer.Controls.Add(ucQuanLyVatTuPhuTung);
            ucQuanLyVatTuPhuTung.BringToFront();
        }

        private void aceQuanLyTienCong_Click(object sender, EventArgs e)
        {
            btxtTieuDe.Caption = aceQuanLyTienCong.Text;
            ucQuanLyTienCong = new ucQuanLyTienCong();
            ucQuanLyTienCong.Dock = DockStyle.Fill;
            mainContainer.Controls.Add(ucQuanLyTienCong);
            ucQuanLyTienCong.BringToFront();
        }

        private void aceBaoCaoDoanhSo_Click(object sender, EventArgs e)
        {
            btxtTieuDe.Caption = aceBaoCaoDoanhSo.Text;
            ucBaoCaoDoanhSo = new ucBaoCaoDoanhSo();
            ucBaoCaoDoanhSo.Dock = DockStyle.Fill;
            mainContainer.Controls.Add(ucBaoCaoDoanhSo);
            ucBaoCaoDoanhSo.BringToFront();
        }

        private void aceBaoCaoTon_Click(object sender, EventArgs e)
        {
            btxtTieuDe.Caption = aceBaoCaoTon.Text;
            ucBaoCaoTon = new ucBaoCaoTon();
            ucBaoCaoTon.Dock = DockStyle.Fill;
            mainContainer.Controls.Add(ucBaoCaoTon);
            ucBaoCaoTon.BringToFront();
        }

        private void aceTiepNhanBaoTriXe_Click(object sender, EventArgs e)
        {
            btxtTieuDe.Caption = aceTiepNhanBaoTriXe.Text;
            ucTiepNhanBaoTriXe = new ucTiepNhanBaoTriXe();
            ucTiepNhanBaoTriXe.Dock = DockStyle.Fill;
            mainContainer.Controls.Add(ucTiepNhanBaoTriXe);
            ucTiepNhanBaoTriXe.BringToFront();
        }

        private void aceDashBoard_Click_1(object sender, EventArgs e)
        {
            btxtTieuDe.Caption = aceDashBoard.Text;
            ucDashBoard = new ucDashBoard();
            ucDashBoard.Dock = DockStyle.Fill;
            mainContainer.Controls.Add(ucDashBoard);
            ucDashBoard.BringToFront();
        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement25_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đây là phiên bản v1.0\nNhà phát triển:\nLê Minh Nam 0123456789\nĐỗ Thị Thơm 0123456789\nPhạm Thúy Quỳnh 0123456789", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void accordionControlElement24_Click(object sender, EventArgs e)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = ("https://www.facebook.com/profile.php?id=100056086951279");
            driver.Navigate();
        }

        private void accordionControlElement22_Click(object sender, EventArgs e)
        {
            btxtTieuDe.Caption = "Quản lý tài khoản";
            ucQuanLyTaiKhoan = new ucQuanLyTaiKhoan();
            ucQuanLyTaiKhoan.Dock = DockStyle.Fill;
            mainContainer.Controls.Add(ucQuanLyTaiKhoan);
            ucQuanLyTaiKhoan.BringToFront();
        }
    }
}
