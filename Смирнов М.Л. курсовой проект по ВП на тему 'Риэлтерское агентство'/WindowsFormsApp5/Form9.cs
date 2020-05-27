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
    public partial class Form9 : Form
    {
        public Model1 db = new Model1();
        public List<client> clienth;
        public Form9()
        {
            InitializeComponent();
            clienth = (from clien in db.client select clien).ToList();
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
            if ((textBox1.Text == ""))
                MessageBox.Show("Заполните поле");
            else
            {
                try
                {
                    s = (from clien in clienth
                         where clien.id_client == Convert.ToInt32(textBox1.Text)
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
                    List<client> query = (from us in db.client
                                          select us).ToList();
                    client item = query.First(n => n.id_client == s);
                    db.client.Remove(item);
                    db.SaveChanges();
                    MessageBox.Show("Клиент удалён");
                    Form f6 = Application.OpenForms[0];
                    f6.Enabled = true;
                    this.Close();
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
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;

            if ((l < 'А' || l > 'я') && (e.KeyChar != Convert.ToChar(8)))
                e.Handled = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;

            if ((l < 'А' || l > 'я') && (e.KeyChar != Convert.ToChar(8)))
                e.Handled = true;
        }
    }
}
