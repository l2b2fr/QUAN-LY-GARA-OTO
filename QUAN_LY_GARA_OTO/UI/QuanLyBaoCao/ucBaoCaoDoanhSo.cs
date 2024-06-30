using DevExpress.Charts.Model;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Native;
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
    public partial class ucBaoCaoDoanhSo : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBaoCaoDoanhSo()
        {
            InitializeComponent();
        }
        private void ucBaoCaoDoanhSo_Load(object sender, EventArgs e)
        {
            DataSet ds = CreateData();

            Series series1 = new Series("A Pie Series", ViewType.Pie);

            series1.DataSource = ds.Tables["Table"];
            series1.ArgumentDataMember = "Argument";
            series1.ValueDataMembers.AddRange(new string[] { "Value" });

            if (series1.Label is PieSeriesLabel pieSeriesLabel)
            {
                pieSeriesLabel.TextPattern = "{A}: {VP:P0}";
                series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            }

            chartControl1.Series.Add(series1);


            var series = new Series("Doanh số", ViewType.StackedBar);
            series.Points.Add(new SeriesPoint("Tháng 1", 30999) { Color = Color.Red });
            series.Points.Add(new SeriesPoint("Tháng 2", 40999) { Color = Color.Blue });
            series.Points.Add(new SeriesPoint("Tháng 3", 5099) { Color = Color.Green });
            series.Points.Add(new SeriesPoint("Tháng 4", 609999) { Color = Color.Orange });
            series.Points.Add(new SeriesPoint("Tháng 5", 60999) { Color = Color.Purple });
            series.Points.Add(new SeriesPoint("Tháng 6", 6033) { Color = Color.Yellow });
            series.Points.Add(new SeriesPoint("Tháng 7", 60999) { Color = Color.Gray });
            series.Points.Add(new SeriesPoint("Tháng 8", 699990) { Color = Color.Brown });
            series.Points.Add(new SeriesPoint("Tháng 9", 22460) { Color = Color.Pink });
            series.Points.Add(new SeriesPoint("Tháng 10", 11260) { Color = Color.Cyan });
            series.Points.Add(new SeriesPoint("Tháng 11", 611120) { Color = Color.Magenta });
            series.Points.Add(new SeriesPoint("Tháng 12", 601231) { Color = Color.Lime });

            ((BarSeriesView)series.View).ColorEach = true;

            //series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

            ((BarSeriesLabel)series.Label).TextPattern = "{A}: {V:n0} VNĐ";

            series.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.True;
            series.ToolTipPointPattern = "{A}: {V:n0} VNĐ";
            chartControl2.Series.Add(series);


            var chart = new Series("Biểu đồ số lượt sửa của hiệu xe", ViewType.Bar);
            chart.Points.Add(new SeriesPoint("Toyota", 78) { Color = Color.Red });
            chart.Points.Add(new SeriesPoint("Honda", 42) { Color = Color.Blue });
            chart.Points.Add(new SeriesPoint("Hyundai", 233) { Color = Color.Green });
            chart.Points.Add(new SeriesPoint("Kia", 52) { Color = Color.Orange });
            chart.Points.Add(new SeriesPoint("Suzuki", 421) { Color = Color.Purple });
            chart.Points.Add(new SeriesPoint("Mitsubishi", 134) { Color = Color.Yellow });
            chart.Points.Add(new SeriesPoint("Mercedes", 632) { Color = Color.Gray });
            chart.Points.Add(new SeriesPoint("BMW", 22) { Color = Color.Brown });
            chart.Points.Add(new SeriesPoint("Ford", 645) { Color = Color.Pink });
            chart.Points.Add(new SeriesPoint("Mazda", 23) { Color = Color.Cyan });

            ((BarSeriesView)chart.View).ColorEach = true;

            ((BarSeriesLabel)chart.Label).TextPattern = "{A}: {V} Lượt";

            chartControl3.Series.Add(chart);


            
        }

        DataSet CreateData()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable() { TableName = "Table" };
            ds.Tables.Add(dt);
            dt.Columns.Add("Argument");
            dt.Columns.Add("Value", typeof(double));
            dt.Rows.Add("Toyota", 17.0752);
            dt.Rows.Add("Honda", 9.98467);
            dt.Rows.Add("Hyundai", 9.63142);
            dt.Rows.Add("Kia", 9.59696);
            dt.Rows.Add("Suzuki", 8.511965);
            dt.Rows.Add("Mitsubishi", 7.68685);
            dt.Rows.Add("Ford", 3.28759);
            dt.Rows.Add("Mazda", 5);
            dt.Rows.Add("Mercedes", 16);
            dt.Rows.Add("BMW", 5);
            return ds;
        }
    }
}
