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
using System.Drawing.Printing;
using System.IO;

namespace djkdc_qg.booksql
{
    public partial class bookshz_type :a_qg_trol.qg_form
    {

        public bookshz_type()
        {
            InitializeComponent();



            try
            {
                books_hz hz = new booksql.books_hz();
                DataTable dt = hz.bookshz_all_type("");

                qg_grid_tree1.DataSource = dt;
                qg_grid_tree1.AutoGenerateColumns = true;

                foreach (DataGridViewColumn col in qg_grid_tree1.Columns)
                {
                    if (col.Name == "图书类别"
                        || col.Name == "ISBN号"
                        || col.Name == "书名"
                        || col.Name == "册数"
                        || col.Name == "金额") { }
                    else
                    { col.Visible = false; }

                    if (col.Name == "图书类别") { }
                    //if (col.Name == "册数") { col.Width = 50; }
                    //if (col.Name == "金额") { col.Width = 80;  }

                }

            }
            catch (Exception ex)
            {
                ex.errormess();
            }
        }




 //结束
    }
}
