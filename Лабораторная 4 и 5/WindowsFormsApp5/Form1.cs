using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
      
        decimal m = 0;
        decimal c = 0;
        string s = "";
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
            label2.Text = Convert.ToString(DateTime.Now.Hour)+":"+ Convert.ToString(DateTime.Now.Minute);
            timer1.Enabled = true;
            button1.Enabled = false;
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                button1.Enabled = true;
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                textBox1.Enabled = false;
            }
            else
            {
                button1.Enabled = false;
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
                textBox1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((DateTime.Now.Minute <= 9)&&(DateTime.Now.Hour<=9))
                label2.Text ="0"+ Convert.ToString(DateTime.Now.Hour) + ":" +"0"+ Convert.ToString(DateTime.Now.Minute);
            else
            if ((DateTime.Now.Minute <= 9))
                label2.Text = Convert.ToString(DateTime.Now.Hour) + ":" +"0"+ Convert.ToString(DateTime.Now.Minute);
            else
            if (DateTime.Now.Hour <= 9)
                label2.Text = "0" + Convert.ToString(DateTime.Now.Hour) + ":" + Convert.ToString(DateTime.Now.Minute);
            else
                label2.Text = Convert.ToString(DateTime.Now.Hour) + ":" + Convert.ToString(DateTime.Now.Minute);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            c = numericUpDown1.Value;
            m = numericUpDown2.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            c = numericUpDown1.Value;
            m = numericUpDown2.Value;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            s = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c = numericUpDown1.Value;
            m = numericUpDown2.Value;
            timer2.Enabled = true;
            notifyIcon1.Icon = SystemIcons.Error;
            this.Hide();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void показатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void завершитьToolStripMenuItem_Click(object sender, EventArgs e)
        {         
            this.Close();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программу создал Смирнов Максим Леонидович");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if ((m == DateTime.Now.Minute) && (c == DateTime.Now.Hour))
            {
                Form2 f2 = new Form2();
                f2.label2.Text = s;
                f2.Show();
                timer2.Enabled = false;
            }
        }
    }
}
