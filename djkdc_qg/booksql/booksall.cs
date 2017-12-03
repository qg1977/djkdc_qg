using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using djkdc_qg.a_sqlconn;
using static djkdc_qg.a_GlobalClass.con_sql;

namespace djkdc_qg.booksql
{
    public partial class booksall : a_qg_trol.qg_form
    {
        private string tj_sqlstring_all="";//附加的查询语句，比如需要加条件查询
        public booksall()
        {
            InitializeComponent();
            auto();

            //qg_tip_visible1.set_text("我就是想看看你会不会自适应长度！");
        }

        private void booksall_Load(object sender, EventArgs e)
        {
            auto_size();

            pagerControl1.OnPageChanged += new EventHandler(pagerControl1_OnPageChanged);
            biod();
        }

        void pagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            biod();
        }


        private DataTable biod()
        {
 
            DataTable dt = null;
            try
            {
                //WaitFormService.Show();
                //WaitFormService.SetText("正在查询图书信息,请稍候……");
                string sqlstring = "";


                

                int page = pagerControl1.PageIndex;
                int page_size = pagerControl1.PageSize;

                sqlstring = "select * from "
                    + "(";
                sqlstring = sqlstring+ "select ROW_NUMBER() OVER(ORDER BY ID) 序号"
                    + ",0 选择,ID,ISBN号,书名,拼音,单价,convert(char(10),出版日期,120) 出版日期,册数"
                    + ",出版社ID,出版社=isnull((select 出版社 from press where ID=b.出版社ID),'')"
                     + ",类别ID,图书类别=isnull((select 图书类别 from types where ID=b.类别ID),'')"
                      + ",convert(decimal(12,2),单价*册数) 金额"
                     + " from booksall b where ID is not null";
                sqlstring = sqlstring + tj_sqlstring_all;//附加查询条件 
                sqlstring=sqlstring +") temp where 序号>"+(page-1)*page_size+" and 序号<="+page*page_size;

                dt = return_select(sqlstring);
                grid_booksall.DataSource = dt;

                //WaitFormService.Close();

                //qg_pager1.DrawControl(dt.Rows.Count);
                sqlstring = "select count(1) un from booksall where ID is not null";
                sqlstring = sqlstring + tj_sqlstring_all;//附加查询条件 

                DataTable  dt_count = return_select(sqlstring);
                int count;
                count = dt_count.Rows[0]["un"].ToString().ToInt();
                pagerControl1.DrawControl(count);
               
              
            }
            catch (Exception ex)
            {
                ex.errormess();
            }
            return dt;
        }

        #region 控件布局
        private void auto_size()
        {
            if (qg_tip_visible1.Visible == false)
            {
                panel1.Height = panel1.Height - qg_tip_visible1.Height - 10;
                grid_booksall.Height = grid_booksall.Height + 50;
            }
            panel1.Top = grid_booksall.Top ;

            grid_booksall.Top = panel1.Top + panel1.Height + 30;
            if (qg_tip_visible1.Visible == false)
            {
               
            }


            qg_label1.Top = 2;// + grid_booksall.Height + 10;
            //grid_booksall.Top = qg_label1.Top + 30;
            pressaaa.Top = qg_label1.Top;
            qg_label2.Top = qg_label1.Top;
            typeaaa.Top = pressaaa.Top;
            qg_label3.Top = qg_label1.Top;
            bookaaa.Top = pressaaa.Top;          
            qg_label5.Top = qg_label1.Top;
            bookaaa_like.Top = pressaaa.Top;

            qg_button_small1.Top = pressaaa.Top;
            qg_button_small1.Left = bookaaa_like.Left + bookaaa_like.Width + 30;
            qg_button_small2.Top = pressaaa.Top;
            qg_button_small2.Left = qg_button_small1.Left + qg_button_small1.Width + 30;

            qg_tip_visible1.Left = qg_label1.Left+5;
            qg_tip_visible1.Top = qg_label1.Top + qg_label1.Height + 10;

            qg_tip_visible2.Left = qg_label3.Left + 5;
            qg_tip_visible2.Top = qg_tip_visible1.Top;

            qg_tip_visible3.Left = qg_label5.Left + 5;
            qg_tip_visible3.Top = qg_tip_visible1.Top;

            qg_tip_visible4.Top = qg_button3.Top+qg_button3.Height;
            qg_tip_visible4.Left = qg_button3.Left - (qg_tip_visible4.Width- qg_button3.Width) / 2;

            qg_tip_visible5.Top = qg_dy1.Top + qg_dy1.Height;
            qg_tip_visible5.Left = qg_dy1.Left - (qg_tip_visible5.Width - qg_dy1.Width) / 2;

            //分页控件布局
            grid_booksall.Height = grid_booksall.Height - pagerControl1.Height - 20;
            pagerControl1.Left = grid_booksall.Left+grid_booksall.Width-pagerControl1.Width-30;
            pagerControl1.Top = grid_booksall.Top + grid_booksall.Height + 10;
        }
        #endregion

        #region 出版社和图书类型加载数据
        public void auto()
        {
            try
            {
                string sqlstring = "";


                DataTable dt = biod();
                //grid_booksall.DataSource = dt;

                DataTable dt_bookaaa = dt.Copy();
                bookaaa.DataSource = dt_bookaaa;
                bookaaa.DisplayMember = "书名";
                bookaaa.ValueMember = "ID";
                if (dt_bookaaa != null && dt_bookaaa.Rows.Count > 0)
                {
                    bookaaa.SelectedIndex = 0;
                }


                sqlstring = "select ID,出版社,拼音 from press";
                DataTable dt_pressaaa = return_select(sqlstring);
                pressaaa.DataSource = dt_pressaaa;
                pressaaa.DisplayMember = "出版社";
                pressaaa.ValueMember = "ID";
                pressaaa.SelectedIndex = 0;


                sqlstring = "select ID,图书类别,拼音 from types";
                DataTable dt_typeaaa = return_select(sqlstring);
                typeaaa.DataSource = dt_typeaaa;
                typeaaa.DisplayMember = "图书类别";
                typeaaa.ValueMember = "ID";
                typeaaa.SelectedIndex = 0;



            }
            catch (Exception ex)
            {
                ex.errormess();
            }
        }
        #endregion


        #region 将grid的table传递到增加或修改表单中
        public DataTable grid_datasource()
        {
            return (DataTable)grid_booksall.DataSource;
        }
        #endregion

        #region 增加记录后高亮显示新增加的记录
        public void grid_add(DataRow row)
        {
            DataTable dt =(DataTable) grid_booksall.DataSource;

            dt.Rows.Add(row);

            //增加记录后，将光标跳转至新增加的行
            grid_booksall.Rows[grid_booksall.Rows.Count - 2].Selected = true;//选中
            grid_booksall.FirstDisplayedScrollingRowIndex = grid_booksall.Rows.Count - 2; //指定某行为第一个显示的行
            //增加记录后，将光标跳转至新增加的行

            //增加记录后，需要将翻页控件 的总记录数加1
            pagerControl1.DrawControl(pagerControl1.RecordCount+1);
        }
        

        private void qg_button1_Click(object sender, EventArgs e)
        {
            booksall_1 b1 = new booksall_1();
            b1.Owner = this;
            b1.ShowDialog();

            //DialogResult result = b1.ShowDialog();
            //if (result == DialogResult.Cancel)
            //{
            //    this.gridControl1.DataSource = b1.CreateTable();
            //}
            //booksall_1 child = new booksall_1();
            //child.MdiParent = this;
            //child.Show();
        }
        #endregion

        public void grid_update()
        {

        }
        private void qg_button2_Click(object sender, EventArgs e)
        {
            int hh_index = grid_booksall.CurrentCell.RowIndex;

            string bookid = grid_booksall.CurrentRow.Cells["ID"].Value.ToString();//
            string ISBN_all = grid_booksall.CurrentRow.Cells["ISBN号"].Value.ToString();//
            string name_all = grid_booksall.CurrentRow.Cells["书名"].Value.ToString();
            decimal djtemp1 = grid_booksall.CurrentRow.Cells["单价"].Value.ToString().ToDecimal();
            string cbstemp1 = grid_booksall.CurrentRow.Cells["出版社"].Value.ToString();
            string datetemp1 = grid_booksall.CurrentRow.Cells["出版日期"].Value.ToString();
            string typetemp1 = grid_booksall.CurrentRow.Cells["图书类别"].Value.ToString();
            int sltemp1 = grid_booksall.CurrentRow.Cells["册数"].Value.ToString().ToInt();

            booksall_2 b2 = new booksall_2();
            b2.bookid = bookid;
            b2.ISBN_all = ISBN_all;
            b2.name_all = name_all;
            b2.dj_all = djtemp1;
            b2.cbs_all = cbstemp1;
            b2.date_all = datetemp1;
            b2.type_all = typetemp1;
            b2.sl_all = sltemp1;
            b2.Owner = this;
            b2.ShowDialog();


        }

        private void qg_button3_Click(object sender, EventArgs e)
        {
            DataRow[] row = ((DataTable)grid_booksall.DataSource).Select("选择=1");
            if (row.Count() <= 0){ MessageBox.Show("请将准备删除的记录打勾！"); return; }

            string temp1 = "";
            foreach (DataRow r in row)
            { temp1 = temp1 + "\rISBN号：" + r["ISBN号"].ToString().Trim() + "   " + "书名：" + r["书名"].ToString().Trim() + "   " + "出版社：" + r["出版社"].ToString().Trim(); }

            DialogResult dr = MessageBox.Show("是否确定删除以下"+row.Count().ToString()+"条记录？"+temp1, "提示", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            string sqlstring;
            foreach (DataRow r in row)
            {
                sqlstring = "delete from booksall where ID=" + r["ID"].ToString();
                insert_update_delete(sqlstring);

                r.Delete();
            }
            ((DataTable)grid_booksall.DataSource).AcceptChanges();

            //删除记录后，需要将翻页控件 的总记录数减去删除的记录数
            pagerControl1.DrawControl(pagerControl1.RecordCount -row.Count());
        }



        private void qg_button_small1_Click(object sender, EventArgs e)
        {
            if (pressaaa.Text.IsNullOrEmpty() && typeaaa.Text.IsNullOrEmpty() && bookaaa.Text.IsNullOrEmpty() && bookaaa_like.Text.IsNullOrEmpty())
            {
                MessageBox.Show("请至少选择一种查询条件！");
                return;
            }

            DataTable dt = biod();
            grid_booksall.DataSource = dt;

            string pressID = "";
            string typeID = "";
            string bookID = "";
            string booknameliketemp1 = "";
            if (!pressaaa.Text.IsNullOrEmpty())
                {pressID = pressaaa.SelectedValue.ToString().Trim(); }

            if (!typeaaa.Text.IsNullOrEmpty())
            { typeID = typeaaa.SelectedValue.ToString().Trim(); }

            if (!bookaaa.Text.IsNullOrEmpty())
            { bookID = bookaaa.SelectedValue.ToString().Trim(); }
            
            if (!bookaaa_like.Text.IsNullOrEmpty())
            { booknameliketemp1 = bookaaa_like.Text.Trim(); }

            string sqltemp = "";
            if (pressID!=""){ sqltemp = sqltemp + " and 出版社ID=" + pressID + ""; }
            if (typeID != "") { sqltemp = sqltemp + " and 类别ID=" + typeID + ""; }
            if (bookID != "") { sqltemp = sqltemp + " and ID=" + bookID + ""; }
            if (booknameliketemp1 != "") { sqltemp = sqltemp + " and 书名 like '%" + booknameliketemp1 + "%'"; }

            pagerControl1.PageIndex = 1;
            tj_sqlstring_all = sqltemp;
            biod();


            //DataTable dt_sql_temp = ((DataTable)grid_booksall.DataSource).Copy();
            //DataRow[] rows = dt_sql_temp.Select("书名<>''"+sqltemp.Trim());// ID='" + bookID + "' and 月份='" + dtName.Rows[i][4] + "'");

            //DataTable dt_sql= ((DataTable)grid_booksall.DataSource).Clone();
            //foreach (DataRow row in rows)
            //{
            //    dt_sql.Rows.Add(row.ItemArray);
            //}
            //if (dt_sql.Rows.Count <= 0)
            //{
            //    MessageBox.Show("没有查到符合条件的记录！");
            //    return;
            //}
            //grid_booksall.DataSource = dt_sql;

        }

        private void qg_button_small2_Click(object sender, EventArgs e)
        {
            pressaaa.Text = "";
            typeaaa.Text = "";
            //bookaaa.Text = "";
            bookaaa_like.Text = "";

            tj_sqlstring_all = "";//复位查询条件 

            DataTable dt = biod();
            grid_booksall.DataSource = dt;
        }

  

        private void booksall_Resize(object sender, EventArgs e)
        {
            auto_size();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //Pen pen = new Pen(Color.Black, 1);
            //pen.DashStyle = DashStyle.Dash;
            //e.Graphics.DrawRectangle(pen, panel1.DisplayRectangle);
            //使用红色虚线绘制边框  
            Pen pen1 = new Pen(Color.Red, 1);
            pen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            pen1.DashPattern = new float[] { 4f, 2f };
            e.Graphics.DrawRectangle(pen1, 0, 0, this.panel1.Width - 1, this.panel1.Height - 1);
        }



        //结束
    }
}
