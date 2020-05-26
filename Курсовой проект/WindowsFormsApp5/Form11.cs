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
    public partial class Form11 : Form
    {
        public Model1 db = new Model1();
        public List<users> usersh;
        public Form11()
        {
            InitializeComponent();
            usersh = (from user in db.users select user).ToList();
            comboBox1.SelectedIndex = 0;
            textBox7.MaxLength = 11;
            textBox8.MaxLength = 11;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f6 = Application.OpenForms[0];
            f6.Enabled = true;
            this.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            string k = "";
            if (comboBox1.SelectedIndex == 0)
                k = "риэлтор";
            if (comboBox1.SelectedIndex == 1)
                k = "секретарь";
            if (comboBox1.SelectedIndex == 2)
                k = "администратор";
            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == "") || (textBox7.Text == "") || (textBox7.Text.Length != 11) || (textBox9.Text == "") || (textBox10.Text == ""))
                MessageBox.Show("Заполните корректно поля");
            else
            {
                int s = 0;
                try
                {
                    s = (from user in usersh
                         where user.surname == textBox1.Text
                         where user.name == textBox2.Text
                         where user.pathronymic == textBox3.Text
                         where user.phone_number == textBox7.Text
                         where user.login==textBox9.Text
                         where user.password==textBox10.Text
                         select user.id_user).Distinct().First();
                }
                catch
                { }

                if (s == 0)
                {
                    MessageBox.Show("Данный клиент не найден");
                }
                if (s != 0)
                {
                    if (textBox4.Text == "")
                        textBox4.Text = textBox1.Text;
                    if (textBox5.Text == "")
                        textBox5.Text = textBox2.Text;
                    if (textBox6.Text == "")
                        textBox6.Text = textBox3.Text;
                    if (textBox8.Text == "")
                        textBox8.Text = textBox7.Text;
                    if (textBox11.Text == "")
                        textBox11.Text = textBox9.Text;
                    if (textBox12.Text == "")
                        textBox12.Text = textBox10.Text;
                    if (textBox8.Text.Length != 11)
                        MessageBox.Show("Заполните корректно поля");
                    else
                    {
                        var result = db.users.SingleOrDefault(w => w.id_user == s);
                        result.surname = textBox4.Text;
                        result.name = textBox5.Text;
                        result.pathronymic = textBox6.Text;
                        result.phone_number = textBox8.Text;
                        result.login = textBox11.Text;
                        result.password = textBox12.Text;
                        result.role = k;
                        db.SaveChanges();
                        MessageBox.Show("Данные изменены");
                        Form f6 = Application.OpenForms[0];
                        f6.Enabled = true;
                        this.Close();
                    }
                }

            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;

            if ((l < 'A' || l > 'z') && (e.KeyChar != Convert.ToChar(8)) && (!Char.IsDigit(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;

            if ((l < 'A' || l > 'z') && (e.KeyChar != Convert.ToChar(8)) && (!Char.IsDigit(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;

            if ((l < 'A' || l > 'z') && (e.KeyChar != Convert.ToChar(8)) && (!Char.IsDigit(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;

            if ((l < 'A' || l > 'z') && (e.KeyChar != Convert.ToChar(8)) && (!Char.IsDigit(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
    }
}
