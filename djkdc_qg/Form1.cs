using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using djkdc_qg.a_sqlconn;
using static djkdc_qg.a_GlobalClass.con_sql;
namespace djkdc_qg
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            pagerControl1.OnPageChanged += new EventHandler(OnPageChanged);
            LoadData();
        }
        void OnPageChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            int count;
            int page = pagerControl1.PageIndex;
            int page_size = pagerControl1.PageSize;

            string sqlstring;
            DataTable dt;

            sqlstring = "select * from "
                + "("
                + "select ROW_NUMBER() OVER(ORDER BY ID) 序号"
                + ",0 选择,ID,ISBN号,书名,拼音,单价,convert(char(10),出版日期,120) 出版日期,册数"
                + ",出版社ID,出版社=isnull((select 出版社 from press where ID=b.出版社ID),'')"
                 + ",类别ID,图书类别=isnull((select 图书类别 from types where ID=b.类别ID),'')"
                  + ",convert(decimal(12,2),单价*册数) 金额"
                 + " from booksall b"
                  + ") temp where 序号>" + (page - 1) * page_size + " and 序号<=" + page * page_size;
            dt = return_select(sqlstring);
            qg_grid1.DataSource = dt;


            pagerControl1.DrawControl(35);
 
        }



        //结束
    }
}
