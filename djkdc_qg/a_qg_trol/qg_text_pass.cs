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
    public partial class qg_text_pass : TextBox
    {
        public qg_text_pass()
        {
            InitializeComponent();
        }

        private void qg_text_pass_Enter(object sender, EventArgs e)
        {
            ImeMode = ImeMode.Disable;//获得焦点时,设置为英文
            BackColor = Color.LightCyan; //当textBox1获得焦点时，背景色变为LightCyan（淡蓝绿色）
        }

        private void qg_text_pass_Leave(object sender, EventArgs e)
        {
            ImeMode = ImeMode.NoControl;//
            BackColor = Color.White; //当textBox1失去焦点时，背景色恢复为White(白色)
        }
    }
}
