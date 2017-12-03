using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using djkdc_qg.a_sqlconn;
using static djkdc_qg.a_GlobalClass.con_sql;

namespace djkdc_qg.booksql
{
    public partial class booksall_x2 : a_qg_trol.qg_form
    {
        public booksall_x2()
        {
            InitializeComponent();
        }

        private void booksall_x2_Load(object sender, EventArgs e)
        {
            boid();
            chart_auto();
        } 

        private void boid()
        {
            DataTable dt;
            string sqlstring;


            books_hz hz = new books_hz();
            dt = hz.bookshz_all_cbs("");
            //qg_grid1.DataSource = dt;
            //qg_grid1.AutoGenerateColumns = true;




            //DataTable dt_two = dt.DefaultView.ToTable(true, "出版社", "金额"); select distinct

            DataTable dt_two = dt.Clone(); // 克隆dt 的结构，包括所有 dt 架构和约束,并无数据； 
            DataRow[] rows = dt.Select("排序=1"); // 从dt 中查询符合条件的记录； 
            foreach (DataRow row in rows)  // 将查询的结果添加到dt中； 
            {
                dt_two.Rows.Add(row.ItemArray);
            }

            DataColumn dc1 = new DataColumn("金额百分比", Type.GetType("System.Decimal"));
            dc1.DefaultValue = 0;
            dt_two.Columns.Add(dc1);

            decimal sumtemp1 = dt_two.Compute("sum(金额)", "true").ToString().ToDecimal();
            if (sumtemp1 > 0)
            {
                foreach (DataRow row in dt_two.Rows)
                {
                    row["金额百分比"] = Math.Round(row["金额"].ToString().ToDecimal() / sumtemp1, 4);
                }
            }



            chart1.DataSource = dt_two;
            chart1.DataBind();

        }
        private void chart_auto()
        {
            //设置
            chart1.Legends[0].Enabled = false;//不显示右侧的详细图例名称

            //chart1.ChartAreas[0].BackColor = Color.White;//设置背景为白色

            chart1.ChartAreas[0].Area3DStyle.Enable3D = true;//设置3D效果
            chart1.ChartAreas[0].Area3DStyle.PointDepth =chart1.ChartAreas[0].Area3DStyle.PointGapDepth = 50;//设置一下深度，看起来舒服点……
            chart1.ChartAreas[0].Area3DStyle.WallWidth = 0;//设置墙的宽度为0；



            chart1.ChartAreas[0].AxisX.Interval = 1;   //设置X轴坐标的间隔为1
            chart1.ChartAreas[0].AxisX.IntervalOffset = 1;  //设置X轴坐标偏移为1
            chart1.ChartAreas[0].AxisX.LabelStyle.IsStaggered = true;   //设置是否交错显示,比如数据多的时间分成两行来显示
            //X轴上的文字的大小
            chart1.Series[0].Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chart1.Series[0].Label = "#PERCENT";//X轴上显示的数字（比如可以显示X值在合计中的百分比） chart1菜单“series"--"标签"--"label"选择样式


            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "0%";//格式化，为了显示百分号
            chart1.ChartAreas[0].AxisY.Interval = 0.05;//设置刻度间隔为5%
            //chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;//不显示网格线

            //chart1.ChartAreas[0].AxisX.Minimum = 0.5;//设置最小值，为了让第一个柱紧挨坐标轴

            //chart1.Series[0].Label = "#VAL{P}";//设置标签文本 (在设计期通过属性窗口编辑更直观)
            chart1.Series[0].IsValueShownAsLabel = true;//显示标签

            chart1.Series[0].CustomProperties = "DrawingStyle=Cylinder, PointWidth=0.8";//设置为圆柱形 (在设计期通过属性窗口编辑更直观)
            chart1.Series[0].Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;//设置调色板

            //数据
            //chart1.Series[0].Points.AddXY("<10", 0.201);
            //chart1.Series[0].Points.AddXY("10~20", 0.395);
            //chart1.Series[0].Points.AddXY("20~30", 0.173);
            //chart1.Series[0].Points.AddXY("30~40", 0.136);
            //chart1.Series[0].Points.AddXY("40~50", 0.059);
            //chart1.Series[0].Points.AddXY("50~60", 0.015);
            //chart1.Series[0].Points.AddXY(">60", 0.022);


            chart1.Top = 5;
            chart1.Height = Height - 50;
            chart1.Left = 5;
            chart1.Width = Width = 10;
        }
        private void booksall_x2_Resize(object sender, EventArgs e)
        {
            chart1.Left = 0;
            chart1.Width = Width;
            chart1.Height = Height - chart1.Top - 30;

        }


    }
}
