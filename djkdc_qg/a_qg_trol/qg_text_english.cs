using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace djkdc_qg.a_qg_trol
{
    //只能输入英语、数字、字符，不能输入 中文符号，
    //用于输入手机号，邮箱等特殊处
    public partial class qg_text_english : TextBox
    {
        public qg_text_english()
        {
            InitializeComponent();
            this.SuspendLayout();
            //BackColor = System.Drawing.Color.FromArgb(255, 255, 170);//背景色为浅黄色
            //Font = new Font(this.Font, FontStyle.Bold);//加粗

            Tag = true;

            this.ResumeLayout(false);
        }

        private void qg_text_english_Enter(object sender, EventArgs e)
        {
            ImeMode = ImeMode.Disable;//获得焦点时,设置为英文
            BackColor = Color.LightCyan; //当textBox1获得焦点时，背景色变为LightCyan（淡蓝绿色）

        }

        private void qg_text_english_Leave(object sender, EventArgs e)
        {
            ImeMode = ImeMode.NoControl;//
            BackColor = Color.White; //当textBox1失去焦点时，背景色恢复为White(白色)
        }
    }
}
