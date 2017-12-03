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
    public partial class first_view : a_qg_trol.qg_form
    {
        public first_view()
        {
            InitializeComponent();
        }

        private void first_view_Load(object sender, EventArgs e)
        {
            qg_label1.Text = "Hi，欢迎您："+begin_class.allczyname.Trim()+"！"
                          +"\n\n 欢迎您使用";
            qg_label2.Text = "图书管理系统";
            qg_label3.Text = "因为您是首次使用本系统，\n\n所以本系统会有很多的提示文字，\n\n如果你已经可以熟练使用本系统，"
                +"\n\n可以通过菜单“系统设置”--“提示设置”来关闭提示"
                 +"\n\n也可直接点击下方勾选框关闭提示文字";

            string sqlstring = "select 值 from z_system where 属性=2";
            DataTable dt = return_select(sqlstring);

            if (dt.Rows[0]["值"].ToString() == "1") { qg_check1.Checked = true; }
            else { qg_check1.Checked = false; }
        }

        private void qg_check1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void qg_check1_MouseClick(object sender, MouseEventArgs e)
        {
            string sqlstring;

            if (qg_check1.Checked)
            {
                sqlstring = "update z_system set 值=1 where 属性 in (1,2)";
                insert_update_delete(sqlstring);

                this.Close();
            }
            else
            {
                sqlstring = "update z_system set 值=0 where 属性 in (1,2)";
                insert_update_delete(sqlstring);
            }
        }
    }
}
