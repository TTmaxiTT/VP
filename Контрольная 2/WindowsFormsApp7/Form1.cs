using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            string t1 = textBox1.Text;
            string t2 = textBox2.Text;
            string t3 = textBox3.Text;
            string t4 = textBox4.Text;
            string t5 = textBox5.Text;
            if (radioButton1.Checked == true)
                i = 1;
            if (radioButton2.Checked == true)
                i = 2;
            if (radioButton3.Checked == true)
                i = 3;
            Form f2 = new Form2(t1,t2,t3,t4,t5,i);
            f2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f4 = new Form4();
            f4.Show();
            this.Hide();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
            pictureBox3.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
        }
    }
}
