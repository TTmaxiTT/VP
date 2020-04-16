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
    public partial class Form2 : Form
    {
        
        public Form2()
        {          
            InitializeComponent();
            if ((DateTime.Now.Minute <= 9) && (DateTime.Now.Hour <= 9))
                label1.Text = "0" + Convert.ToString(DateTime.Now.Hour) + ":" + "0" + Convert.ToString(DateTime.Now.Minute);
            else
            if ((DateTime.Now.Minute <= 9))
                label1.Text = Convert.ToString(DateTime.Now.Hour) + ":" + "0" + Convert.ToString(DateTime.Now.Minute);
            else
            if (DateTime.Now.Hour <= 9)
                label1.Text = "0" + Convert.ToString(DateTime.Now.Hour) + ":" + Convert.ToString(DateTime.Now.Minute);
            else
                label1.Text = Convert.ToString(DateTime.Now.Hour) + ":" + Convert.ToString(DateTime.Now.Minute);           
        }
        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
