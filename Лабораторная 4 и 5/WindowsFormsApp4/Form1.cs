using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        decimal m = 0;
        decimal s = 0;
        int i = 0;
        Form Form2 = new Form2();
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
            label1.Text = "0"+Convert.ToString(m) + ":"+ "0"+Convert.ToString(s);
            timer1.Enabled = false;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            m = numericUpDown1.Value;
            if ((m < 10)&&(s<10))
            label1.Text = "0" + Convert.ToString(m) + ":" + "0" + Convert.ToString(s);
            else
            if ((m<10)&&(s>10))
                label1.Text = "0"+Convert.ToString(m) + ":" + Convert.ToString(s);
            else
            if ((m>10)&&(s<10))
                label1.Text = Convert.ToString(m) + ":" +"0"+ Convert.ToString(s);
            else
                label1.Text = Convert.ToString(m) + ":" + Convert.ToString(s);
            if (label1.Text != null)
                button1.Enabled = true;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            s = numericUpDown2.Value;
            if ((m < 10) && (s < 10))
                label1.Text = "0" + Convert.ToString(m) + ":" + "0" + Convert.ToString(s);
            else
            if ((m < 10) && (s > 10))
                label1.Text = "0" + Convert.ToString(m) + ":" + Convert.ToString(s);
            else
            if ((m > 10) && (s < 10))
                label1.Text = Convert.ToString(m) + ":" + "0" + Convert.ToString(s);
            else
                label1.Text = Convert.ToString(m) + ":" + Convert.ToString(s);
            if (label1.Text != null)
                button1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {          
            if ((s == 0) && (m > 0))
            {
                s = 59;
                m--;
                if ((m < 10) && (s < 10))
                    label1.Text = "0" + Convert.ToString(m) + ":" + "0" + Convert.ToString(s);
                else
               if ((m < 10) && (s > 10))
                    label1.Text = "0" + Convert.ToString(m) + ":" + Convert.ToString(s);
                else
               if ((m > 10) && (s < 10))
                    label1.Text = Convert.ToString(m) + ":" + "0" + Convert.ToString(s);
                else
                    label1.Text = Convert.ToString(m) + ":" + Convert.ToString(s);
                
            }
            else
            {
                if ((m < 10) && (s < 10))
                    label1.Text = "0" + Convert.ToString(m) + ":" + "0" + Convert.ToString(s);
                else
               if ((m < 10) && (s > 10))
                    label1.Text = "0" + Convert.ToString(m) + ":" + Convert.ToString(s);
                else
               if ((m > 10) && (s < 10))
                    label1.Text = Convert.ToString(m) + ":" + "0" + Convert.ToString(s);
                else
                    label1.Text = Convert.ToString(m) + ":" + Convert.ToString(s);
            }
            if ((m == 0) && (s == 0))
            {
                timer1.Enabled = false;
                button1.Text = "Пуск";
                button1.Enabled = false;
                Form2.Show();
            }
            s--;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                groupBox1.Visible = false;
                timer1.Enabled = true;
                button1.Text = "Стоп";
                i++;
            }
            else
            {
                timer1.Enabled = false;
                button1.Text = "Продолжить";
                i = 0;
            }
        }
    }
}
