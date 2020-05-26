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
    public partial class Form10 : Form
    {
        public Model1 db = new Model1();
        public List<users> usersh;
        public Form10()
        {
            InitializeComponent();
            usersh = (from user in db.users select user).ToList();
            textBox4.MaxLength = 11;
            comboBox3.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f6 = Application.OpenForms[0];
            f6.Enabled = true;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int s = 0;
            string k = "";
            if (comboBox3.SelectedIndex == 0)
                k = "риэлтор";
            if (comboBox3.SelectedIndex == 1)
                k = "секретарь";
            if (comboBox3.SelectedIndex == 2)
                k = "администратор";
            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") || (textBox4.Text.Length != 11)||(textBox5.Text=="")||(textBox7.Text==""))
                MessageBox.Show("Заполните корректно все поля");
            else
            {
                try
                {
                    s = (from user in usersh
                         where user.surname == textBox1.Text
                         where user.name == textBox2.Text
                         where user.pathronymic == textBox3.Text
                         select user.id_user).Distinct().First();
                }
                catch
                { }
                try
                {
                    s = (from user in usersh
                         where user.login == textBox5.Text
                         select user.id_user).Distinct().First();
                }
                catch
                { }
                try
                {
                    s = (from user in usersh
                         where user.password == textBox7.Text
                         select user.id_user).Distinct().First();
                }
                catch
                { }
                try
                {
                    s = (from user in usersh
                         where user.phone_number == textBox4.Text
                         select user.id_user).Distinct().First();
                }
                catch
                { }
                if (s == 0)
                {
                    users new_user = new users
                    { surname = textBox1.Text, name = textBox2.Text, pathronymic = textBox3.Text, phone_number = textBox4.Text, login = textBox5.Text,password=textBox7.Text,role=k };
                    db.users.Add(new_user);
                    db.SaveChanges();
                    MessageBox.Show("Пользователь добавлен");    
                    Form f6 = Application.OpenForms[0];
                    f6.Enabled = true;
                    this.Close();
                }
                if (s != 0)
                {
                    MessageBox.Show("Пользователь с такими данными уже существует");
                }
                
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;

            if ((l < 'а' || l > 'я') && (e.KeyChar != Convert.ToChar(8)))
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;

            if ((l < 'а' || l > 'я') && (e.KeyChar != Convert.ToChar(8)))
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;

            if ((l < 'а' || l > 'я') && (e.KeyChar != Convert.ToChar(8)))
                e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;

            if ((l < 'A' || l > 'z') && (e.KeyChar != Convert.ToChar(8)) && (!Char.IsDigit(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;

            if ((l < 'A' || l > 'z') && (e.KeyChar != Convert.ToChar(8)) && (!Char.IsDigit(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 1)
                textBox1.Text = textBox1.Text.ToUpper();
            textBox1.Select(textBox1.Text.Length, 0);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 1)
                textBox2.Text = textBox2.Text.ToUpper();
            textBox2.Select(textBox2.Text.Length, 0);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length == 1)
                textBox3.Text = textBox3.Text.ToUpper();
            textBox3.Select(textBox3.Text.Length, 0);
        }
    }
}
