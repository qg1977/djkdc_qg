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

namespace djkdc_qg.systemall
{
    public partial class pass_update : a_qg_trol.qg_form
    {
        public pass_update()
        {
            InitializeComponent();
            auto();
        }

        private void auto()
        {
            text_old_pass.Tag = false;
            text_new_name.Tag = false;
            text_new_pass.Tag = false;
            text_new_pass_2.Tag = false;

            text_old_name.Text = begin_class.allczyname.Trim();
            text_new_name.Text = begin_class.allczyname.Trim(); ;

            text_old_pass.Text = "";

            text_new_pass.Text = "";
            text_new_pass_2.Text = "";

            text_old_pass.Focus();

            string sqlstring = "select 密码 from p_passpass where ID=" + begin_class.allczyid;
            DataTable dt = return_select(sqlstring);
            if (dt.Rows.Count<=0)
            { MessageBox.Show("当前登录信息不正常，请退出后重新登录系统！");return; }
        }


        #region 当前密码验证
        private void text_old_pass_Validating(object sender, CancelEventArgs e)
        {
            error_old_pass();
        }
        private void text_old_pass_TextChanged(object sender, EventArgs e)
        {
            error_old_pass();
        }
        private void error_old_pass()
        {
            bool jytt = true;

            string errorstring = "";
            //if (text_old_pass.Text.Trim() == "")
            //{
            //    errorstring = "当前密码不能为空！"; jytt = false; ;
            //}
            if (!qg_Validator.IsPassJytt(text_old_pass.Text.Trim()))
            { errorstring = "密码格式为6-20个数字或英文字母！"; jytt = false; }

            if (!jytt)
            {
                text_old_pass_label.Text = errorstring;
                text_old_pass_label.Visible = true;
            }
            else
            {
                text_old_pass_label.Visible = false;
                text_old_pass.Tag = true;
            }
        }


        #endregion

        #region 新的用户名验证
        private void text_new_name_TextChanged(object sender, EventArgs e)
        {
            error_new_name();
        }
        private void text_new_name_Validating(object sender, CancelEventArgs e)
        {
            error_new_name();
        }
        private void error_new_name()
        {
            bool jytt = true;

            string errorstring = "";
            //if (text_old_pass.Text.Trim() == "")
            //{
            //    errorstring = "当前密码不能为空！"; jytt = false; ;
            //}
            if (!qg_Validator.IsPassJytt(text_new_name.Text.Trim()))
            { errorstring = "用户名格式为6-20个数字或英文字母！"; jytt = false; }

            if (!jytt)
            {
                text_new_name_label.Text = errorstring;
                text_new_name_label.Visible = true;
            }
            else
            {
                text_new_name_label.Visible = false;
                text_new_name.Tag = true;
            }
        }
        #endregion

        #region 新输入密码验证
        private void text_new_pass_TextChanged(object sender, EventArgs e)
        {
            error_new_pass();
        }
        private void text_new_pass_Validating(object sender, CancelEventArgs e)
        {
            error_new_pass();
        }
        private void error_new_pass()
        {
            bool jytt = true;

            string errorstring = "";
            //if (text_old_pass.Text.Trim() == "")
            //{
            //    errorstring = "当前密码不能为空！"; jytt = false; ;
            //}
            if (!qg_Validator.IsPassJytt(text_new_pass.Text.Trim()))
            { errorstring = "密码格式为6-20个数字或英文字母！"; jytt = false; }

            if (!jytt)
            {
                text_new_pass_label.Text = errorstring;
                text_new_pass_label.Visible = true;
            }
            else
            {
                text_new_pass_label.Visible = false;
                text_new_pass.Tag = true;
            }
        }
        #endregion

        #region 重新输入密码框验证
        private void text_new_pass_2_Validating(object sender, CancelEventArgs e)
        {
            error_new_pass_2();
        }
        //private void text_new_pass_2_TextChanged(object sender, EventArgs e)
        //{
        //    error_new_pass_2();
        //}
        private void error_new_pass_2()
        {
            bool jytt = true;

            string errorstring = "";
            //if (text_old_pass.Text.Trim() == "")
            //{
            //    errorstring = "当前密码不能为空！"; jytt = false; ;
            //}
            //if (qg_Validator.IsPassJytt(text_new_pass_2.Text.Trim()))
            //{ errorstring = "密码格式为6-20个数字或英文字母！"; jytt = false; }
            if (text_new_pass.Text.Trim()!=text_new_pass_2.Text.Trim())
            { errorstring = "两次密码输入不一致，请重新输入！";jytt = false; }

            if (!jytt)
            {
                text_new_pass_2_label.Text = errorstring;
                text_new_pass_2_label.Visible = true;
            }
            else
            {
                text_new_pass_2_label.Visible = false;
                text_new_pass_2.Tag = true;
            }
        }
        #endregion

        #region 总体验证
        private bool ValidateOK()
        {
            //this.qg_button1.Enabled = ((bool)(this.ISBN_text.Tag) && (bool)(this.name_text.Tag) && (bool)(this.dj_text.Tag));

            return (bool)(this.text_old_pass.Tag)
                && (bool)(this.text_new_name.Tag)
                && (bool)(this.text_new_pass.Tag)
                 && (bool)(this.text_new_pass_2.Tag);
        }
        #endregion

        private void qg_button1_Click(object sender, EventArgs e)
        {

            if (!ValidateOK())
            {
                text_old_pass_Validating(text_old_pass, null);
                text_new_name_Validating(text_new_name, null);
                text_new_pass_Validating(text_new_pass, null);
                text_new_pass_2_Validating(text_new_pass_2, null);

                return;
            }


            string sqlstring = "select 密码 from p_passpass where ID=" + begin_class.allczyid;
            DataTable dt = return_select(sqlstring);
            if (dt.Rows.Count <= 0)
            { MessageBox.Show("当前登录信息不正常，请退出后重新登录系统！"); return; }

            if (text_old_pass.Text.Trim()!=dt.Rows[0]["密码"].ToString().Trim())
            { MessageBox.Show("当前密码输入不正确，请重新输入！");return; }

            DialogResult dr = MessageBox.Show("是否确定修改用户名及密码？", "提示", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            sqlstring = "update p_passpass set 用户名='" + text_new_name.Text.Trim() + "',密码='" + text_new_pass.Text.Trim() + "' where ID=" + begin_class.allczyid;
            insert_update_delete(sqlstring);

            begin_class.allczyname = text_new_name.Text.Trim();
          
            MessageBox.Show("用户名及密码修改完毕！");
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //使用红色虚线绘制边框  
            Pen pen1 = new Pen(Color.Red, 1);
            pen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            pen1.DashPattern = new float[] { 4f, 2f };
            e.Graphics.DrawRectangle(pen1, 0, 0, this.panel1.Width - 1, this.panel1.Height - 1);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            //使用红色虚线绘制边框  
            Pen pen1 = new Pen(Color.Red, 1);
            pen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            pen1.DashPattern = new float[] { 4f, 2f };
            e.Graphics.DrawRectangle(pen1, 0, 0, this.panel2.Width - 1, this.panel2.Height - 1);
        }


        //结束
    }
}
