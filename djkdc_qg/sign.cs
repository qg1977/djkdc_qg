using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using static djkdc_qg.a_GlobalClass.con_sql;

namespace djkdc_qg
{
    public partial class sign :  Form
    {
        public sign()
        {
            InitializeComponent();
        }

        private void qg_button1_Click(object sender, EventArgs e)
        {
            if (text_user.Text.ToString().Trim().Length<=0 || text_pass.Text.ToString().Trim().Length<=0)
            { MessageBox.Show("用户名或密码不能为空！");return; }

            string sqlstring = "select ID,用户名,密码 from p_passpass where "
                   +" 用户名=ltrim(rtrim('" + text_user.Text.ToString().Trim() + "')) and 密码=ltrim(rtrim('" + text_pass.Text.ToString().Trim() + "'))";
            //MessageBox.Show(sqlstring);
            DataTable dt = return_select(sqlstring);

            if (dt.Rows.Count <= 0) { MessageBox.Show("用户名或密码不正确！");return; }

            begin_class.allczyid = dt.Rows[0]["ID"].ToString();
            begin_class.allczyname = dt.Rows[0]["用户名"].ToString();
         

            MainForm form = new MainForm();
            form.Show();
            this.Hide();
        }

        private void qg_button_quit1_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
            //Application.Exit();
            Close();
        }


        private void sign_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Control)        //Ctrl+F1
            if (e.KeyCode== Keys.Enter)
            {
                qg_button1_Click(this, EventArgs.Empty);
            }
        }
    }
}
