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
    public partial class Form15 : Form
    {
        public Model1 db = new Model1();
        public List<realty> realtyh;
        public Form15()
        {
            InitializeComponent();
            realtyh = (from realt in db.realty select realt).ToList();
            comboBox2.SelectedIndex = 0;
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

        private void button8_Click(object sender, EventArgs e)
        {
            string k = "";
            if (comboBox2.SelectedIndex == 0)
                k = "Продаётся";
            if (comboBox2.SelectedIndex == 1)
                k = "Продан";
            string t = "";
            if (comboBox1.SelectedIndex == 0)
                t = "Квартира";
            if (comboBox1.SelectedIndex == 1)
                t = "Дом";
            if (comboBox1.SelectedIndex == 2)
                t = "Дача";
            if (comboBox1.SelectedIndex == 3)
                t = "Участок";
            if (comboBox1.SelectedIndex == 4)
                t = "Коммерческая";
            if (comboBox1.SelectedIndex == 5)
                t = "Гараж";
            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == "") || (textBox7.Text == "") || (textBox7.Text.Length != 11)||(textBox9.Text==""))
                MessageBox.Show("Заполните корректно поля");
            else
            {
                int s = 0;
                try
                {
                    s = (from realt in realtyh
                         where realt.address == textBox1.Text
                         where realt.city == textBox2.Text
                         where realt.priсe == Convert.ToInt32(textBox3.Text)
                         where realt.phone_number == textBox7.Text
                         where realt.area == Convert.ToInt32(textBox9.Text)
                         select realt.id_realty).Distinct().First();
                }
                catch
                { }

                if (s == 0)
                {
                    MessageBox.Show("Данная недвижимость не найдена");
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
                    if (textBox10.Text == "")
                        textBox10.Text = textBox9.Text;
                    if (textBox8.Text.Length != 11)
                        MessageBox.Show("Заполните корректно поля");
                    else
                    {
                        var result = db.realty.SingleOrDefault(w => w.id_realty == s);
                        result.address = textBox4.Text;
                        result.city = textBox5.Text;
                        result.priсe = Convert.ToInt32(textBox6.Text);
                        result.phone_number = textBox8.Text;
                        result.area = Convert.ToInt32(textBox10.Text);
                        result.type = t;
                        result.status = k;
                        db.SaveChanges();
                        MessageBox.Show("Данные изменены");
                        Form f6 = Application.OpenForms[0];
                        f6.Enabled = true;
                        this.Close();
                    }
                }

            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;

            if ((l < 'а' || l > 'я') && (e.KeyChar != Convert.ToChar(8)))
                e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;

            if ((l < 'а' || l > 'я') && (e.KeyChar != Convert.ToChar(8)))
                e.Handled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 1)
                textBox2.Text = textBox2.Text.ToUpper();
            textBox2.Select(textBox2.Text.Length, 0);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text.Length == 1)
                textBox5.Text = textBox5.Text.ToUpper();
            textBox5.Select(textBox5.Text.Length, 0);
        }
    }
}
