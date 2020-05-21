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
    public partial class Form3 : Form
    {
        public Form3(string t1, string t2, string t3, string t4, int i,int l,int pp)
        {
            InitializeComponent();
            label1.Text = t1;
            label2.Text = t2;
            label3.Text = t3;
            label4.Text = t4;
            label6.Text = t4;
            if (pp == 1)
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
               
            }
            if (pp == 2)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
                pictureBox3.Visible = false;
             
            }
            if (pp == 3)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = true;
            
            }
            if(i == 1)
            {
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
            }
            if (i == 2)
            {
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
            }
            if (i == 3)
            {
                label1.ForeColor = Color.Red;
                label2.ForeColor = Color.Red;
            }
            if (i == 4)
            {
                label1.ForeColor = Color.Blue;
                label2.ForeColor = Color.Blue;
            }
            if (l == 1)
            {
                label2.Font = new System.Drawing.Font(FontFamily.Families[5], this.Height / 2);
                
            }
            if (l == 2)
            {
                label2.Font = new System.Drawing.Font(FontFamily.Families[10], this.Height / 2);

            }
            if (l == 3)
            {
                label2.Font = new System.Drawing.Font(FontFamily.Families[15], this.Height / 2);

            }
            if (l == 4)
            {
                label2.Font = new System.Drawing.Font(FontFamily.Families[20], this.Height / 2);

            }
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
