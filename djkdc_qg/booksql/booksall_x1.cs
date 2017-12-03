using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace djkdc_qg.booksql
{
    public partial class booksall_x1 : a_qg_trol.qg_form
    {
        public booksall_x1()
        {
            InitializeComponent();
        }

        private void booksall_x1_Load(object sender, EventArgs e)
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

            chart1.DataSource = dt_two;
            chart1.DataBind();

        }

        private void chart_auto()
        {
            chart1.ChartAreas[0].Area3DStyle.Enable3D = true;//3D效果
            chart1.ChartAreas[0].Area3DStyle.PointDepth = chart1.ChartAreas[0].Area3DStyle.PointGapDepth = 50;//设置一下深度，看起来舒服点……
            chart1.ChartAreas[0].Area3DStyle.WallWidth = 0;//设置墙的宽度为0；
                                                           //chart1.ChartAreas[0].AxisY.LabelStyle.Format = "0%";//格式化，为了显示百分号

            //chart1.ChartAreas[0].AxisY.Interval = 0.05;//设置刻度间隔为5%
            //chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;//不显示网格线
            //chart1.ChartAreas[0].AxisX.Minimum = 0.5;//设置最小值，为了让第一个柱紧挨坐标轴
            //chart1.Series[0].Label = "#VAL{P}";//设置标签文本 (在设计期通过属性窗口编辑更直观)
            //chart1.Series[0].IsValueShownAsLabel = true;//显示标签
            chart1.Series[0].CustomProperties = "DrawingStyle=Cylinder, PointWidth=0.8";//设置为圆柱形 (在设计期通过属性窗口编辑更直观)
            chart1.Series[0].Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;//设置调色板


            chart1.ChartAreas[0].AxisX.Interval = 1;   //设置X轴坐标的间隔为1
            chart1.ChartAreas[0].AxisX.IntervalOffset = 1;  //设置X轴坐标偏移为1
            chart1.ChartAreas[0].AxisX.LabelStyle.IsStaggered = true;   //设置是否交错显示,比如数据多的时间分成两行来显示 
                   
            //X轴上的文字的大小
            chart1.Series[0].Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            //chart1.Series["Series1"].LegendText = "#VALX";

            chart1.Legends.Clear();

            //chart1.Dock = DockStyle.Fill;
            chart1.Top = 5;
            chart1.Height = Height - 50;
            chart1.Left = 5;
            chart1.Width = Width = 10;
        }
        private void booksall_x1_Resize(object sender, EventArgs e)
        {
            chart1.Left = 0;
            chart1.Width = Width;
            chart1.Height = Height - chart1.Top - 50;


        }
    }
}
