using System;
using System.Drawing;
using System.Windows.Forms;
using djkdc_qg.a_sqlconn;

namespace djkdc_qg.a_qg_trol
{
    public partial class qg_numericUpDown : NumericUpDown
    {
        public qg_numericUpDown()
        {
            InitializeComponent();
            this.SuspendLayout();
            BackColor = System.Drawing.Color.FromArgb(255, 255, 170);//背景色为浅黄色
            Font = new Font(this.Font, FontStyle.Bold);//加粗

            Tag = true;

            this.ResumeLayout(false);
        }

        private void qg_numericUpDown_Enter(object sender, EventArgs e)
        {
            ImeMode = ImeMode.Disable;//获得焦点时,设置为英文
            BackColor = Color.LightCyan; //当textBox1获得焦点时，背景色变为LightCyan（淡蓝绿色）
            this.Select(0, this.Value.ToString().Length);
            //MessageBox.Show("a");
        }

        private void qg_numericUpDown_Leave(object sender, EventArgs e)
        {
            ImeMode = ImeMode.NoControl;//
            BackColor = Color.White; //当textBox1失去焦点时，背景色恢复为White(白色)
        }

        private void qg_numericUpDown_MouseUp(object sender, MouseEventArgs e)
        {
            this.Select(0, this.Value.ToString().Length);

            //如果鼠标左键操作并且标记存在，则执行全选             
            //if (e.Button == MouseButtons.Left && (bool)Tag == true)
            //{
            //    this.Select(0, this.Value.ToString().Length);
            //}
        }

        private void qg_numericUpDown_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                NumericUpDown num1 = (NumericUpDown)sender;
                //输入为小数点时，只能输入一次且只能输入一次
                if (e.KeyChar == 46 && (num1.Text.IndexOf(".") >= 0))
                {
                    e.Handled = true;
                    //this.Select(0, ((NumericUpDown)sender).ToString().Length);
                    num1.Select(num1.Text.IndexOf(".") + 1, num1.ToString().Length);
                }
                //else
                //{
                    //MessageBox.Show(num1.Text.Trim().Length.ToString() + "-----------" + num1.Text.Trim().IndexOf(".").ToString());
                    //if ((num1.Text.Trim().Length - num1.Text.Trim().IndexOf(".")) > num1.DecimalPlaces+1)
                    //{
                    //    MessageBox.Show("狗不");
                    //    //e.Handled = true;
                    //    //num1.Text = num1.Text.Trim().Substring(0, num1.Text.Trim().IndexOf(".") + num1.DecimalPlaces + 1);
                    //    e.Handled = true;
                    //}
                //}
            }
            catch (Exception ex)
            {
                ex.errormess();
            }
        }
    }
}
