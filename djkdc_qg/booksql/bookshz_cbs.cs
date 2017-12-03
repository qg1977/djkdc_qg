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
    public partial class bookshz_cbs : a_qg_trol.qg_form
    {
        public bookshz_cbs()
        {
            InitializeComponent();
            qg_dy1.dy_title = Text;
            try
            {
                books_hz hz = new booksql.books_hz();
                DataTable dt = hz.bookshz_all_cbs("");

                qg_grid_tree1.DataSource = dt;
                qg_grid_tree1.AutoGenerateColumns = true;

                foreach (DataGridViewColumn col in qg_grid_tree1.Columns)
                {
                    if (col.Name == "出版社"
                        || col.Name == "册数"
                        || col.Name == "金额") { }
                    else
                    { col.Visible = false; }

                    if (col.Name == "出版社") {  }
                    //if (col.Name == "册数") { col.Width = 50; }
                    //if (col.Name == "金额") { col.Width = 80;  }

                }

            }
            catch (Exception ex)
            {
                ex.errormess();
            }
        }

        private void auto()
        {
            qg_grid_tree1.Top = 20;
            qg_label_visible1.Top = qg_grid_tree1.Top - 20;

            qg_label_visible2.Text = "如果需要导出或打印表格中的数据，就点“打印预览”，然后选择“纸张大小”或“方向”(或直接不选择默认)，导出时会自动排版";
            qg_label_visible2.Top = qg_dy1.Top - qg_dy1.Height - 10;
            qg_label_visible2.Left = qg_dy1.Top - (qg_label_visible2.Width - qg_dy1.Width) / 2;
        }
        private void bookshz_cbs_Load(object sender, EventArgs e)
        {
            auto();
            qg_label_visible1.Text = "双击出版社名称(比如“北京工业大学”)可显示详细记录，再次双击出版社名称可以收回详细记录！";
        }

        private void bookshz_cbs_Resize(object sender, EventArgs e)
        {
            auto();
        }

        private void bookshz_cbs_Shown(object sender, EventArgs e)
        {
            auto();
        }
    }
}
