using DevExpress.XtraCharts;
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

namespace QUAN_LY_GARA_OTO.UI.QuanLyBaoCao
{
    public partial class ucBaoCaoTon : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBaoCaoTon()
        {
            InitializeComponent();
        }

        private void ucBaoCaoTon_Load(object sender, EventArgs e)
        {

            chartControl3.DataSource = GetChartData();
            chartControl3.SeriesTemplate.SeriesDataMember = "Month";
            chartControl3.SeriesTemplate.ArgumentDataMember = "Section";
            chartControl3.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Value" });

            SideBySideStackedBarSeriesView view = new SideBySideStackedBarSeriesView();
            chartControl3.SeriesTemplate.View = view;
            view.BarWidth = 0.6;

            chartControl3.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            chartControl3.SeriesTemplate.Label.TextPattern = "{V}";

        }

        public DataTable GetChartData()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Month", typeof(string));
            table.Columns.Add("Section", typeof(string));
            table.Columns.Add("Value", typeof(int));
            table.Columns.Add("Group", typeof(int));

            table.Rows.Add(new object[] { "Tồn đầu", "Ốc vít", 10, 1 });
            table.Rows.Add(new object[] { "Tồn đầu", "Bộ tản nhiệt động cơ", 20, 1 });
            table.Rows.Add(new object[] { "Tồn đầu", "Ống dẫn khí", 50, 2 });
            table.Rows.Add(new object[] { "Tồn đầu", "Bộ lọc dầu", 40, 1 });
            table.Rows.Add(new object[] { "Tồn đầu", "Dây cáp điện", 70, 3 });
            table.Rows.Add(new object[] { "Tồn đầu", "Đèn pha", 60, 2 });
            table.Rows.Add(new object[] { "Tồn đầu", "Bugi đánh lửa", 35, 1 });
            table.Rows.Add(new object[] { "Tồn đầu", "Lốp xe", 20, 2 });
            table.Rows.Add(new object[] { "Tồn đầu", "Gương chiếu hậu", 10, 1 });
            table.Rows.Add(new object[] { "Tồn đầu", "Hộp số", 5, 2 });
            table.Rows.Add(new object[] { "Tồn đầu", "Má phanh", 80, 1 });
            table.Rows.Add(new object[] { "Tồn đầu", "Vành bánh xe", 25, 3 });

            table.Rows.Add(new object[] { "Phát sinh", "Ốc vít", 20, 1 });
            table.Rows.Add(new object[] { "Phát sinh", "Bộ tản nhiệt động cơ", 30, 2 });
            table.Rows.Add(new object[] { "Phát sinh", "Ống dẫn khí", 40, 3 });
            table.Rows.Add(new object[] { "Phát sinh", "Bộ lọc dầu", 25, 2 });
            table.Rows.Add(new object[] { "Phát sinh", "Dây cáp điện", 35, 1 });
            table.Rows.Add(new object[] { "Phát sinh", "Đèn pha", 20, 3 });
            table.Rows.Add(new object[] { "Phát sinh", "Bugi đánh lửa", 15, 2 });
            table.Rows.Add(new object[] { "Phát sinh", "Lốp xe", 30, 1 });
            table.Rows.Add(new object[] { "Phát sinh", "Gương chiếu hậu", 5, 2 });
            table.Rows.Add(new object[] { "Phát sinh", "Hộp số", 10, 3 });
            table.Rows.Add(new object[] { "Phát sinh", "Má phanh", 20, 2 });
            table.Rows.Add(new object[] { "Phát sinh", "Vành bánh xe", 15, 1 });

            table.Rows.Add(new object[] { "Tồn cuối", "Ốc vít", 15, 2 });
            table.Rows.Add(new object[] { "Tồn cuối", "Bộ tản nhiệt động cơ", 25, 1 });
            table.Rows.Add(new object[] { "Tồn cuối", "Ống dẫn khí", 45, 2 });
            table.Rows.Add(new object[] { "Tồn cuối", "Bộ lọc dầu", 35, 1 });
            table.Rows.Add(new object[] { "Tồn cuối", "Dây cáp điện", 40, 3 });
            table.Rows.Add(new object[] { "Tồn cuối", "Đèn pha", 50, 2 });
            table.Rows.Add(new object[] { "Tồn cuối", "Bugi đánh lửa", 20, 1 });
            table.Rows.Add(new object[] { "Tồn cuối", "Lốp xe", 25, 2 });
            table.Rows.Add(new object[] { "Tồn cuối", "Gương chiếu hậu", 12, 1 });
            table.Rows.Add(new object[] { "Tồn cuối", "Hộp số", 8, 2 });
            table.Rows.Add(new object[] { "Tồn cuối", "Má phanh", 75, 1 });
            table.Rows.Add(new object[] { "Tồn cuối", "Vành bánh xe", 20, 3 });

            return table;
        }

    }
}
