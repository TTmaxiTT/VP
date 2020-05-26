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
    public partial class Form8 : Form
    {
        public Model1 db = new Model1();
        public List<client> clienth;
        public Form8()
        {
            InitializeComponent();
            clienth = (from clien in db.client select clien).ToList();
            comboBox2.SelectedIndex = 0;
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
            int k = 0;
            if (comboBox2.SelectedIndex == 0)
                k = 0;
            if (comboBox2.SelectedIndex == 1)
                k = 1;
            if (comboBox2.SelectedIndex == 2)
                k = 2;
            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == "") || (textBox7.Text == "") || (textBox7.Text.Length != 11))
                MessageBox.Show("Заполните корректно поля");
            else
            { 
            int s = 0;
                try
                {
                    s = (from clien in clienth
                         where clien.surname == textBox1.Text
                         where clien.name == textBox2.Text
                         where clien.pathronymic == textBox3.Text
                         where clien.phone_number == textBox7.Text
                         select clien.id_client).Distinct().First();
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
                    if (textBox8.Text.Length != 11)
                        MessageBox.Show("Заполните корректно поля");
                    else
                    {
                        var result = db.client.SingleOrDefault(w => w.id_client == s);
                        result.surname = textBox4.Text;
                        result.name = textBox5.Text;
                        result.pathronymic = textBox6.Text;
                        result.phone_number = textBox8.Text;
                        if (k==0)
                        result.status = "новый";
                        if (k == 1)
                            result.status = "обрабатывается";
                        if (k == 2)
                            result.status = "выполнено";
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;

            if ((l < 'А' || l > 'я') && (e.KeyChar != Convert.ToChar(8)))
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;

            if ((l < 'А' || l > 'я') && (e.KeyChar != Convert.ToChar(8)))
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;

            if ((l < 'А' || l > 'я') && (e.KeyChar != Convert.ToChar(8)))
                e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;

            if ((l < 'А' || l > 'я') && (e.KeyChar != Convert.ToChar(8)))
                e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;

            if ((l < 'А' || l > 'я') && (e.KeyChar != Convert.ToChar(8)))
                e.Handled = true;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;

            if ((l < 'А' || l > 'я') && (e.KeyChar != Convert.ToChar(8)))
                e.Handled = true;
        }
    }
}
