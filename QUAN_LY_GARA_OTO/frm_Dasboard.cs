using DevExpress.XtraBars;
using QUAN_LY_GARA_OTO.UI;
using QUAN_LY_GARA_OTO.UI.QuanLyBaoCao;
using QUAN_LY_GARA_OTO.UI.QuanLyBaoTri;
using QUAN_LY_GARA_OTO.UI.QuanLyKho;
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
            if (ucLapPhieuSuaChua == null)
            {
                ucLapPhieuSuaChua = new ucLapPhieuSuaChua();
                ucLapPhieuSuaChua.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(ucLapPhieuSuaChua);
                ucLapPhieuSuaChua.BringToFront();
            }
            else
            {
                ucLapPhieuSuaChua.BringToFront();
            }
        }

        private void aceTraCuuXe_Click(object sender, EventArgs e)
        {
            btxtTieuDe.Caption= aceTraCuuXe.Text;
            if (ucTraCuuXe == null)
            {
                ucTraCuuXe = new ucTraCuuXe();
                ucTraCuuXe.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(ucTraCuuXe);
                ucTraCuuXe.BringToFront();
            }
            else
            {
                ucTraCuuXe.BringToFront();
            }
        }

        private void aceQuanLyVatTuPhuTung_Click(object sender, EventArgs e)
        {
            btxtTieuDe.Caption = aceQuanLyVatTuPhuTung.Text;
            if (ucQuanLyVatTuPhuTung == null)
            {
                ucQuanLyVatTuPhuTung = new ucQuanLyVatTuPhuTung();
                ucQuanLyVatTuPhuTung.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(ucQuanLyVatTuPhuTung);
                ucQuanLyVatTuPhuTung.BringToFront();
            }
            else
            {
                ucQuanLyVatTuPhuTung.BringToFront();
            }
        }

        private void aceQuanLyTienCong_Click(object sender, EventArgs e)
        {
            btxtTieuDe.Caption = aceQuanLyTienCong.Text;
            if (ucQuanLyTienCong == null)
            {
                ucQuanLyTienCong = new ucQuanLyTienCong();
                ucQuanLyTienCong.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(ucQuanLyTienCong);
                ucQuanLyTienCong.BringToFront();
            }
            else
            {
                ucQuanLyTienCong.BringToFront();
            }
        }

        private void aceBaoCaoDoanhSo_Click(object sender, EventArgs e)
        {
            btxtTieuDe.Caption = aceBaoCaoDoanhSo.Text;
            if (ucBaoCaoDoanhSo == null)
            {
                ucBaoCaoDoanhSo = new ucBaoCaoDoanhSo();
                ucBaoCaoDoanhSo.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(ucBaoCaoDoanhSo);
                ucBaoCaoDoanhSo.BringToFront();
            }
            else
            {
                ucBaoCaoDoanhSo.BringToFront();
            }
        }

        private void aceBaoCaoTon_Click(object sender, EventArgs e)
        {
            btxtTieuDe.Caption = aceBaoCaoTon.Text;
            if (ucBaoCaoTon == null)
            {
                ucBaoCaoTon = new ucBaoCaoTon();
                ucBaoCaoTon.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(ucBaoCaoTon);
                ucBaoCaoTon.BringToFront();
            }
            else
            {
                ucBaoCaoTon.BringToFront();
            }
        }

        private void aceTiepNhanBaoTriXe_Click(object sender, EventArgs e)
        {
            btxtTieuDe.Caption = aceTiepNhanBaoTriXe.Text;
            if (ucTiepNhanBaoTriXe == null)
            {
                ucTiepNhanBaoTriXe = new ucTiepNhanBaoTriXe();
                ucTiepNhanBaoTriXe.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(ucTiepNhanBaoTriXe);
                ucTiepNhanBaoTriXe.BringToFront();
            }
            else
            {
                ucTiepNhanBaoTriXe.BringToFront();
            }
        }

        private void aceDashBoard_Click_1(object sender, EventArgs e)
        {
            btxtTieuDe.Caption= aceDashBoard.Text;
            if (ucDashBoard == null)
            {
                ucDashBoard = new ucDashBoard();
                ucDashBoard.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(ucDashBoard);
                ucDashBoard.BringToFront();
            }
            else
            {
                ucDashBoard.BringToFront();
            }
        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {

        }
    }
}
