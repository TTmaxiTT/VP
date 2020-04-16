using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VP
{
    public partial class Form2 : Form
    {
        Form3 f3 = new Form3();
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void comboBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Картинка 1")
                pictureBox1.BackgroundImage = imageList1.Images[0];
            if (comboBox1.Text == "Картинка 2")
                pictureBox1.BackgroundImage = imageList1.Images[1];
            if (comboBox1.Text == "Картинка 3")
                pictureBox1.BackgroundImage = imageList1.Images[2];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = pictureBox1.BackgroundImage;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            f3.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
