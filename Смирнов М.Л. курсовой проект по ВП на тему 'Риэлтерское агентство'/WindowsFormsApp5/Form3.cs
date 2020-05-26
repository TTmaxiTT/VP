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
    public partial class Form3 : Form
    {
        
        Form f4 = new Form4();
        Form f5 = new Form5();
        Form f6 = new Form6();
        public Model1 db = new Model1();
        public List<users> usersh;
        public Form3()
        {
            InitializeComponent();
            usersh = (from user in db.users select user).ToList();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "";
            try
            {
                s = (from user in usersh
                     where user.login == textBox1.Text
                     where user.password == textBox2.Text
                     select user.role).Distinct().First();
            }
            catch
            {
                if (s == "")
                    MessageBox.Show("Неправильный логин или пароль");
            }
            if (s == "администратор")
            {
                f4.Show();
                this.Close();
                Form f1 = Application.OpenForms[0];
                f1.ShowInTaskbar = false;
                f1.Hide();
            }
            if (s == "риэлтор")
            {
                f5.Show();
                this.Close();
                Form f1 = Application.OpenForms[0];
                f1.ShowInTaskbar = false;
                f1.Hide();
            }
            if (s == "секретарь")
            {
                f6.Show();
                this.Close();
                Form f1 = Application.OpenForms[0];
                f1.ShowInTaskbar = false;
                f1.Hide();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f1 = Application.OpenForms[0];
            f1.Show();
            this.Close();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;

            if ((l < 'A' || l > 'z') && (e.KeyChar != Convert.ToChar(8))&&(!Char.IsDigit(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;

            if ((l < 'A' || l > 'z') && (e.KeyChar != Convert.ToChar(8)) && (!Char.IsDigit(e.KeyChar)))
                e.Handled = true;     
        }
    }
}
