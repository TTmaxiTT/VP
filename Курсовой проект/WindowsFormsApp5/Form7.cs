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
    public partial class Form7 : Form
    {
        public Model1 db = new Model1();
        public List<client> clienth;
        public Form7()
        {
            InitializeComponent();
            clienth = (from clien in db.client select clien).ToList();
            textBox4.MaxLength = 11;
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
            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") || (textBox4.Text.Length != 11))
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
                MessageBox.Show("Клиент добавлен");
                Form f6 = Application.OpenForms[0];
                f6.Enabled = true;
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
    }
}
