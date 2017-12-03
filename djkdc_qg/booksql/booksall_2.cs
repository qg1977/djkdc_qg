﻿using System;
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

    public partial class booksall_2 : a_qg_trol.qg_form
    {
        public string bookid = "";
        public string ISBN_all = "";
        public string name_all = "";
        public decimal dj_all = 0;
        public string cbs_all = "";
        public string date_all = "";
        public string type_all="";
        public int sl_all = 0;

        public booksall_2()
        {
            InitializeComponent();
            auto();
            auto_tag();
        }
        public void auto()
        {
            string sqlstring;

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
        private void booksall_2_Load(object sender, EventArgs e)
        {
            ISBN_text.Text = ISBN_all;
            name_text.Text = name_all;
            dj_text.Text = dj_all.ToString();
            pressaaa_text.Text = cbs_all;
            typeaaa_text.Text = type_all;
            sl_text.Text = sl_all.ToString();

            data1_text.Value = Convert.ToDateTime(date_all);
            label_date_ts.LabelText = "(点击日期选择面板标头“" + data1_text.Value.Year.ToString() + "年" + data1_text.Value.Month.ToString() + "月”可直接选择月份，再次点击可选择年份)";

            data1_text.MaxDate = DateTime.Now;
 
        }

        private void auto_tag()
        {
            ISBN_text.Tag = false;
            name_text.Tag = false;
            dj_text.Tag = false;
            pressaaa_text.Tag = false;
            data1_text.Tag = true;//日期有默认日期，可以不选
            typeaaa_text.Tag = false;
            sl_text.Tag = false;

            ISBN_text.Text = "";
            name_text.Text = "";
            dj_text.Value = 0;
            pressaaa_text.Text = "";
            typeaaa_text.Text = "";
            sl_text.Value = 0;

            ISBN_text.Focus();
        }

        #region ISBN验证
        private void ISBN_text_TextChanged(object sender, EventArgs e)
        {
            error_isbn();
        }

        private void ISBN_text_Validating(object sender, CancelEventArgs e)
        {
            error_isbn();
        }
        private void ISBN_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                string errorstring = "";
                bool jytt = true;

                //判断按键是不是要输入的类型。
                if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46 && e.KeyChar != 45)
                {
                    e.Handled = true;
                    jytt = false;
                    errorstring = "ISBN号只能为数字！";
                }

                if (!jytt)
                {
                    label1_ISBN_text.Text = errorstring;
                    label1_ISBN_text.Visible = true;
                }
                else
                {
                    label1_ISBN_text.Visible = false;
                    ISBN_text.Tag = true;
                }
            }
            catch (Exception ex)
            {
                ex.errormess();
            }
        }
        private void error_isbn()
        {
            bool jytt = true;

            string errorstring = "";
            if (ISBN_text.Text.Trim() == "")
            {
                errorstring = "ISBN号不能为空！"; jytt = false; ;
            }
            if (ISBN_text.Text.Trim().Length > 20)
            { errorstring = "ISBN号的长度不能超过20个字符！"; jytt = false; }

            if (!jytt)
            {
                label1_ISBN_text.Text = errorstring;
                label1_ISBN_text.Visible = true;
            }
            else
            {
                label1_ISBN_text.Visible = false;
                ISBN_text.Tag = true;
            }
        }
        #endregion


        #region 书名验证
        private void name_text_TextChanged(object sender, EventArgs e)
        {
            error_name();
        }

        private void name_text_Validating(object sender, CancelEventArgs e)
        {
            error_name();
        }
        private void error_name()
        {
            name_py_text.Text = MyPinYin.GetFirst(name_text.Text.Trim());
            bool jytt = true;

            string errorstring = "";
            if (name_text.Text.Trim() == "")
            {
                errorstring = "书名不能为空！"; jytt = false; ;
            }
            if (name_text.Text.Trim().Length > 30)
            { errorstring = "书名的长度不能超过30个字符！"; jytt = false; }

            if (!jytt)
            {
                label2_name_text.Text = errorstring;
                label2_name_text.Visible = true;
            }
            else
            {
                label2_name_text.Visible = false;
                name_text.Tag = true;
            }
        }
        #endregion


        #region 单价验证
        private void dj_text_ValueChanged(object sender, EventArgs e)
        {
            error_dj();
        }

        private void dj_text_Validating(object sender, CancelEventArgs e)
        {
            error_dj();

            //decimal dVal = dj_text_x.Text.ToDecimal();
            //dj_text.Value = String.Format("{0:N" + Precision + "}", dVal);
        }
        private void error_dj()
        {

            bool jytt = true;

            string errorstring = "";

            if (dj_text.Value <= 0)
            { errorstring = "单价必须大于0元！"; jytt = false; }

            if (dj_text.Value > 100000)
            { errorstring = "单价不能大于十万元！"; jytt = false; }

            if (!jytt)
            {
                label3_dj_text.Text = errorstring;
                label3_dj_text.Visible = true;
            }
            else
            {
                label3_dj_text.Visible = false;
                dj_text.Tag = true;
            }
        }
        #endregion


        #region 出版社验证加初始化
        private void pressaaa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pressaaa.Text.IsNullOrEmpty())
            {
                pressaaa_text.Text = pressaaa.Text;
            }
        }
        private void pressaaa_text_TextChanged(object sender, EventArgs e)
        {
            error_press();
        }
        private void pressaaa_text_Validating(object sender, CancelEventArgs e)
        {
            error_press();
        }
        private void error_press()
        {
            bool jytt = true;

            string errorstring = "";
            if (pressaaa_text.Text.Trim() == "")
            {
                errorstring = "请选择或输入出版社！"; jytt = false; ;
            }
            if (pressaaa_text.Text.Trim().Length > 20)
            { errorstring = "出版社的名称长度不能超过20个字符！"; jytt = false; }

            if (!jytt)
            {
                label4_pressaaa_text.Text = errorstring;
                label4_pressaaa_text.Visible = true;
            }
            else
            {
                label4_pressaaa_text.Visible = false;
                pressaaa_text.Tag = true;
            }
        }
        #endregion

        #region 出版日期验证
        private void data1_text_ValueChanged(object sender, EventArgs e)
        {
            error_date();
        }
        private void data1_text_Validating(object sender, CancelEventArgs e)
        {
            error_date();
        }
        private void error_date()
        {
            bool jytt = true;

            string errorstring = "";
            if (!data1_text.Text.IsDate())
            {
                errorstring = "请输入正确的出版日期！"; jytt = false;
            }
            //if (pressaaa_text.Text.Trim() == "")
            //{
            //    errorstring = "请选择或输入出版社！"; jytt = false; ;
            //}
            //if (pressaaa_text.Text.Trim().Length > 20)
            //{ errorstring = "出版社的名称长度不能超过20个字符！"; jytt = false; }

            if (!jytt)
            {
                label5_data1_text.Text = errorstring;
                label5_data1_text.Visible = true;
            }
            else
            {
                label5_data1_text.Visible = false;
                data1_text.Tag = true;
            }
        }
        #endregion

        #region 图书类型验证加初始化
        private void typeaaa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!typeaaa.Text.IsNullOrEmpty())
            {
                typeaaa_text.Text = typeaaa.Text;
            }
        }
        private void typeaaa_text_TextChanged(object sender, EventArgs e)
        {
            error_type();
        }

        private void typeaaa_text_Validating(object sender, CancelEventArgs e)
        {
            error_type();
        }
        private void error_type()
        {
            bool jytt = true;

            string errorstring = "";
            if (typeaaa_text.Text.Trim() == "")
            {
                errorstring = "请选择或输入图书类型！"; jytt = false; ;
            }
            if (typeaaa_text.Text.Trim().Length > 10)
            { errorstring = "图书类型的名称长度不能超过10个字符！"; jytt = false; }

            if (!jytt)
            {
                label6_typeaaa_text.Text = errorstring;
                label6_typeaaa_text.Visible = true;
            }
            else
            {
                label6_typeaaa_text.Visible = false;
                typeaaa_text.Tag = true;
            }
        }
        #endregion



        #region 册数验证
        private void sl_text_ValueChanged(object sender, EventArgs e)
        {
            error_sl();
        }

        private void sl_text_Validating(object sender, CancelEventArgs e)
        {
            error_sl();
        }
        private void error_sl()
        {

            bool jytt = true;

            string errorstring = "";

            if (sl_text.Value <= 0)
            { errorstring = "图书册数必须大于0本！"; jytt = false; }

            if (sl_text.Value > 100000)
            { errorstring = "图书册数大于十万元！"; jytt = false; }

            if (!jytt)
            {
                label7_sl_text.Text = errorstring;
                label7_sl_text.Visible = true;
            }
            else
            {
                label7_sl_text.Visible = false;
                sl_text.Tag = true;
            }
        }
        #endregion

        #region 总体验证
        private bool ValidateOK()
        {
            //this.qg_button1.Enabled = ((bool)(this.ISBN_text.Tag) && (bool)(this.name_text.Tag) && (bool)(this.dj_text.Tag));

            return (bool)(this.ISBN_text.Tag)
                && (bool)(this.name_text.Tag)
                && (bool)(this.dj_text.Tag)
                 && (bool)(this.pressaaa_text.Tag)
                  && (bool)(this.data1_text.Tag)
                   && (bool)(this.typeaaa_text.Tag)
                   && (bool)(this.sl_text.Tag);
        }
        #endregion


        private void qg_button1_Click(object sender, EventArgs e)
        {
       

            if (!ValidateOK())
            {
                ISBN_text_Validating(ISBN_text, null);
                name_text_Validating(name_text, null);
                dj_text_Validating(dj_text, null);
                data1_text_Validating(data1_text, null);
                pressaaa_text_Validating(pressaaa_text, null);
                typeaaa_text_Validating(typeaaa_text, null);
                sl_text_Validating(sl_text, null);
                return;
            }
            //if (ISBN_text.Text.Trim() == "")
            //{
            //    MessageBox.Show("请输入ISBN号！");
            //    return;
            //}
            //if (name_text.Text.Trim() == "")
            //{
            //    MessageBox.Show("请输入书名！");
            //    return;
            //}
            //if (dj_text.Text.Trim() == "" || !dj_text.Text.IsDecimal() || dj_text.Text.ToDecimal() < 0)
            //{
            //    MessageBox.Show("单价不正常!");
            //    return;
            //}
            //if (pressaaa_text.Text.Trim() == "")
            //{
            //    MessageBox.Show("请输入出版社！");
            //    return;
            //}
            //if (typeaaa_text.Text.Trim() == "")
            //{
            //    MessageBox.Show("请输入图书类别！");
            //    return;
            //}
            //if (sl_text.Text.Trim() == "" || !sl_text.Text.IsInt() || sl_text.Text.ToInt() < 0)
            //{
            //    MessageBox.Show("册数不正常!");
            //    return;
            //}

            string sqlstring = "";
            DataTable dt;

            sqlstring = "select ISBN号,书名 from booksall where ID!=" + bookid + " and ISBN号='" + ISBN_text.Text.Trim() + "'";
            dt = return_select(sqlstring);
            if (dt.Rows.Count > 0)
            {
                string temp1 = "";
                temp1 = temp1 + "\rISBN号：" + dt.Rows[0]["ISBN号"].ToString();
                temp1 = temp1 + "\r书名：" + dt.Rows[0]["书名"].ToString();


                MessageBox.Show("数据库中已经存在以下ISBN号的图书" + temp1 + "\r无法修改！");
                return;
            }




            string pressidtempid = "0";
            string press1temp1 = pressaaa_text.Text.Trim();
            string presspytemp1 = MyPinYin.GetFirst(press1temp1);//
            sqlstring = "select ID from press where 出版社='" + press1temp1.Trim() + "'";
            dt = return_select(sqlstring);
            if (dt.Rows.Count <= 0)
            {
                sqlstring = "insert into press(出版社,拼音) values ('" + press1temp1.Trim() + "','" + presspytemp1 + "')";
                insert_update_delete(sqlstring);
                sqlstring = "select ID from press where 出版社='" + press1temp1.Trim() + "'";
                dt = return_select(sqlstring);
            }
            pressidtempid = dt.Rows[0]["ID"].ToString();

            string typeidtempid = "0";
            string type1temp1 = typeaaa_text.Text.Trim();
            string typepytemp1 = MyPinYin.GetFirst(type1temp1);//
            sqlstring = "select ID from types where 图书类别='" + type1temp1.Trim() + "'";
            dt = return_select(sqlstring);
            if (dt.Rows.Count <= 0)
            {
                sqlstring = "insert into types(图书类别,拼音) values ('" + type1temp1.Trim() + "','" + typepytemp1 + "')";
                insert_update_delete(sqlstring);
                sqlstring = "select ID from types where 图书类别='" + type1temp1.Trim() + "'";
                dt = return_select(sqlstring);
            }
            typeidtempid = dt.Rows[0]["ID"].ToString();


            sqlstring = "select ID from booksall where 出版社ID=" + pressidtempid + " and 书名='" + name_text.Text.Trim() + "'";
        sqlstring = sqlstring + " and ID!=" + bookid;
            dt = return_select(sqlstring);
            if (dt.Rows.Count > 0)
            {
                string temp1 = "";
                temp1 = temp1 + "\rISBN号：" + dt.Rows[0]["ISBN号"].ToString();
                temp1 = temp1 + "\r书名：" + name_text.Text.Trim();
                temp1 = temp1 + "\r出版社：" + pressaaa_text.Text.Trim();

                DialogResult dr = MessageBox.Show("数据库中已经存在以下图书目录？\r" + temp1 + "\r是否确定修改？", "提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }
            }

            string namebytemp1 = MyPinYin.GetFirst(name_text.Text.Trim());
            sqlstring = "update booksall set ISBN号='" + ISBN_text.Text.Trim() + "',书名='" + name_text.Text.Trim() + "',拼音='" + namebytemp1+"'"
                   + ",单价=" + dj_text.Text + ",出版社ID=" + pressidtempid + ",类别ID=" + typeidtempid + ",册数=" + sl_text.Text
                   + ",出版日期=(convert(varchar(10),'" + data1_text.Value.ToShortDateString().ToString() + "',120))"
                    + " where ID=" + bookid;
            insert_update_delete(sqlstring);

            booksall frm1 = (booksall)this.Owner;
            //frm1.auto();
            DataTable owner_dt = frm1.grid_datasource();
            DataRow[] rows = owner_dt.Select("ID=" + bookid);
            rows[0]["ISBN号"] = ISBN_text.Text.Trim();
            rows[0]["书名"] = name_text.Text.Trim();
            rows[0]["单价"] = dj_text.Text.Trim();
            rows[0]["出版社ID"] = pressidtempid;
            rows[0]["类别ID"] = typeidtempid;
            rows[0]["册数"] = sl_text.Text.Trim();
            rows[0]["出版日期"] = data1_text.Value.ToShortDateString().ToString();
            rows[0]["出版社"] = pressaaa_text.Text.Trim();
            rows[0]["图书类别"] = typeaaa_text.Text.Trim();

            Close();
        }


    }
}
