using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form2 : Form
    {
        public Model1 db = new Model1();
        public List<post> posth;
        int p = 0;
        public Form2(string t1, string t2, string t3, string t4,int i)
        {
            InitializeComponent();
            label1.Text = t1;
            label2.Text = t4;
            label3.Text = t2;
            label4.Text = t3;
            if (i == 1)
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                p = i;
            }
            if (i == 2)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
                pictureBox3.Visible = false;
                p = i;
            }
            if (i == 3)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = true;
                p = i;
            }
            posth = (from pos in db.post select pos).ToList();           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Blue;
            label2.ForeColor = Color.Blue;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f1 = new Form1();
            f1.Show();
            this.Close();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            post new_post = new post
            { name = label1.Text, donor = label3.Text, recipient = label4.Text, congratulation = label2.Text, picture = p };
            db.post.Add(new_post);
            db.SaveChanges();
            }
            catch
                {
                int i = 0;
                int l = 0;
                int pp = p;
                string t1 = label1.Text;
                string t2 = label2.Text;
                string t3 = label3.Text;
                string t4 = label4.Text;
                if (radioButton1.Checked == true)
                    i = 1;
                if (radioButton2.Checked == true)
                    i = 2;
                if (radioButton3.Checked == true)
                    i = 3;
                if (radioButton4.Checked == true)
                    i = 4;
                if (radioButton5.Checked == true)
                    l = 1;
                if (radioButton6.Checked == true)
                    l = 2;
                if (radioButton7.Checked == true)
                    l = 3;
                if (radioButton8.Checked == true)
                    l = 4;
                Form f3 = new Form3(t1, t2, t3, t4, i, l, pp);
                f3.Show();
                this.Close();
            }
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Red;
            label2.ForeColor = Color.Red;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            label2.Font = new System.Drawing.Font(FontFamily.Families[5], this.Height / 10);
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            label2.Font = new System.Drawing.Font(FontFamily.Families[10], this.Height / 10);
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            label2.Font = new System.Drawing.Font(FontFamily.Families[15], this.Height / 10);
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            label2.Font = new System.Drawing.Font(FontFamily.Families[20], this.Height / 10);
        }
    }
}
