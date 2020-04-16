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
    public partial class Form1 : Form
    {
        Form2 f2 = new Form2();     
        string log ="";
        string pas = "";
        public Form1()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            log = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            pas = textBox2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = File.ReadAllText(@"C:\Users\maxi0\source\repos\ВП 6\users.txt");
            string[] user = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int i = 0;
            while (i < user.Length)
            {
                if ((log + ";" + pas + ";Администратор") == (user[i]))
                {
                    string[] par = user[i].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    f2.Text = par[2];                   
                    f2.label2.Text = par[0];
                    f2.label3.Text = par[1];
                    f2.label4.Text = par[2];
                    f2.label5.Text = Convert.ToString(i);
                    f2.Show();
                    i = 9999;
                    this.Hide();
                }
                else
                if ((log + ";" + pas + ";Пользователь") == (user[i]))
                {
                    string[] par = user[i].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    f2.Text = par[2];
                    f2.label2.Text = par[0];
                    f2.label3.Text = par[1];
                    f2.label4.Text = par[2];
                    f2.label5.Text = Convert.ToString(i);
                    f2.Show();
                    i = 9999;
                    this.Hide();
                }
                i++;
            }
            if (i!=10000)
                MessageBox.Show("неверный логин или пароль");
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }   
    }
}
