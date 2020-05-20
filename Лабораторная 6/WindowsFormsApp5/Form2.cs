using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp5
{
    public partial class Form2 : Form
    {
        string np = "";
        string s = File.ReadAllText(@"users.txt");
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            np = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("новый пароль принят");
            Form1 f1 = new Form1();
            int i = Convert.ToInt32(label5.Text);
            string[] user = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            user[i] = label2.Text + ";"+np+";"+label4.Text;
            string update = "";
            int j = 0;
            while(j < user.Length)
            {
                update = update + user[j]+" ";
                j++;
            }
            StreamWriter sw = new StreamWriter(@"users.txt");
            sw.WriteLine(Convert.ToString(update));
            sw.Close();
            f1.Show();
            this.Close();          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }
    }
}
