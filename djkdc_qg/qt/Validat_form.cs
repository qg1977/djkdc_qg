using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace djkdc_qg.qt
{
    public partial class Validat_form : Form
    {
        public Validat_form()
        {
            InitializeComponent();

            this.buttonOK.Enabled = false;

            this.textBoxAddress.Tag = false;
            this.textBoxAge.Tag = false;
            this.textBoxName.Tag = false;

            this.textBoxName.Validating += new CancelEventHandler(this.textBoxEmpty_Validating);
            this.textBoxAddress.Validating += new CancelEventHandler(this.textBoxEmpty_Validating);
            this.textBoxName.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textBoxAddress.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textBoxAge.TextChanged += new System.EventHandler(this.textBox_TextChanged);

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            string output;
            output = "Name:" + this.textBoxName.Text + "\r\n";
            output += "Address:" + this.textBoxAddress.Text + "\r\n";
            output += "Occupation:" + (string)(this.checkBoxProgrammer.Checked ? "Programmer" : "Not a  Programmer") + "\r\n";
            output += "Sex:" + (string)(this.radioButtonFemale.Checked ? "Female" : "Male") + "\r\n";
            output += "Age:" + this.textBoxAge.Text + "\r\n";
            this.textBoxOutput.Text = output;
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            string output;
            output = "Name =Your name\r\n";
            output += "Address = Your address\r\n";
            output += "Occupation = Check 'if u r a Programmer'";
            output += "Sex = Your sex\r\n";
            output += "Age = Your age\r\n";
            this.textBoxOutput.Text = output;
        }

        private void textBoxEmpty_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text.Length == 0)
            {
                tb.BackColor = Color.Blue;
                tb.Tag = false;

            }
            else
            {
                tb.Tag = true;
                tb.BackColor = System.Drawing.SystemColors.Window;
            }
            ValidateOK();
        }


        private void textBoxAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void textBox_TextChanged(object sender, System.EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text.Length == 0)
            {
                tb.BackColor = Color.Red;
                tb.Tag = false;

            }
            else
            {
                tb.BackColor = System.Drawing.SystemColors.Window;
                tb.Tag = true;
            }
            ValidateOK();

        }

        private void ValidateOK()
        {
            this.buttonOK.Enabled = ((bool)(this.textBoxAddress.Tag) && (bool)(this.textBoxName.Tag) && (bool)(this.textBoxAge.Tag));
        }

        private void textBoxName_Validating(object sender, CancelEventArgs e)
        {
            MessageBox.Show("aa");
        }





        //结束
    }
}
