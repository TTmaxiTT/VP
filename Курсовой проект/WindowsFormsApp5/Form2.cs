using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form2 : Form
    {
        public Model1 db = new Model1();
        public List<client> clienth;
        public Form2()
        {
            InitializeComponent();
            clienth = (from clien in db.client select clien).ToList();
            textBox4.MaxLength = 11;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f1 = Application.OpenForms[0];
            f1.Show();
            this.Close();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {         
            int s = 0;
            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == "")||(textBox4.Text.Length!=11))
                MessageBox.Show("Заполните корректно все поля");
            else
            {
                try
                {
                    s = (from clien in clienth
                         where clien.surname == textBox1.Text
                         where clien.name == textBox2.Text
                         where clien.pathronymic == textBox3.Text
                         where clien.phone_number == textBox4.Text
                         select clien.id_client).Distinct().First();
                }
                catch
                { }
                if (s == 0)
                {
                    client new_client = new client
                    { surname = textBox1.Text, name = textBox2.Text, pathronymic = textBox3.Text, phone_number = textBox4.Text, status = "новый" };
                    db.client.Add(new_client);
                    db.SaveChanges();
                }
                if (s != 0)
                {
                    var result = db.client.SingleOrDefault(w => w.id_client == s);
                    result.status = "новый";
                    db.SaveChanges();
                }
                MessageBox.Show("Ваша заявка принята. С вами свяжутся в ближайшее время.");
                Form f1 = Application.OpenForms[0];
                f1.Show();
                this.Close();
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

        private void textBox4_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
    }
}
