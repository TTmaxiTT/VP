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
    public partial class Form13 : Form
    {
        public Model1 db = new Model1();
        public List<realty> realtyh;
        public Form13()
        {
            InitializeComponent();
            realtyh = (from realt in db.realty select realt).ToList();
            textBox4.MaxLength = 11;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
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
            string  k= "";
            if (comboBox1.SelectedIndex == 0)
                k = "Продаётся";
            if (comboBox1.SelectedIndex == 1)
                k= "Продан";
            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") || (textBox4.Text.Length != 11) || (textBox5.Text == ""))
                MessageBox.Show("Заполните корректно все поля");
            else
            {
                try
                {
                    s = (from realt in realtyh
                         where realt.address == textBox1.Text
                         where realt.city == textBox2.Text
                         where realt.priсe == Convert.ToInt32(textBox3.Text)
                         where realt.area == Convert.ToInt32(textBox5.Text)
                         where realt.phone_number==textBox4.Text
                         select realt.id_realty).Distinct().First();
                }
                catch
                { }       
                if (s == 0)
                {
                    realty new_realty = new realty
                    { address = textBox1.Text, city = textBox2.Text, priсe = Convert.ToInt32(textBox3.Text), phone_number = textBox4.Text, area = Convert.ToInt32(textBox5.Text), type = t,status=k };
                    db.realty.Add(new_realty);
                    db.SaveChanges();
                    MessageBox.Show("Недвижимость добавлена");
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
