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
    public partial class Form18 : Form
    {
        public Model1 db = new Model1();
        public List<deal> dealh;
        public List<realty> realtyh;
        public List<client> clienth;
        public List<users> usersh;
        public Form18()
        {
            InitializeComponent();
            realtyh = (from realt in db.realty select realt).ToList();
            clienth = (from clien in db.client select clien).ToList();
            usersh = (from user in db.users select user).ToList();
            dealh = (from dea in db.deal select dea).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f6 = Application.OpenForms[0];
            f6.Enabled = true;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int s1 = 0;
            int s2 = 0;
            int s3 = 0;
            System.DateTime t = dateTimePicker1.Value;
            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == "") || (textBox7.Text == ""))
                MessageBox.Show("Заполните поля");
            else
            {
                int s = 0;
                try
                {
                    s = (from dea in dealh
                         where dea.id_client == Convert.ToInt32(textBox1.Text)
                         where dea.id_user == Convert.ToInt32(textBox2.Text)
                         where dea.id_realty == Convert.ToInt32(textBox3.Text)
                         where dea.date_deal == t
                         where dea.transaction == Convert.ToInt32(textBox7.Text)
                         select dea.id_deal).Distinct().First();
                }
                catch
                { }
                try
                {
                    s1 = (from clien in clienth
                          where clien.id_client == Convert.ToInt32(textBox4.Text)
                          select clien.id_client).Distinct().First();
                    s2 = (from user in usersh
                          where user.id_user == Convert.ToInt32(textBox5.Text)
                          select user.id_user).Distinct().First();
                    s3 = (from realt in realtyh
                          where realt.id_realty == Convert.ToInt32(textBox6.Text)
                          select realt.id_realty).Distinct().First();
                }
                catch
                { }
                if (s == 0)
                {
                    MessageBox.Show("Данный договор не найден");
                }               
                if (s != 0)
                {
                    if ((s1 == 0) || (s2 == 0) || (s3 == 0))
                    {
                        MessageBox.Show("Таких данных не существует");
                    }
                    else
                    {
                        if (textBox4.Text == "")
                            textBox4.Text = textBox1.Text;
                        if (textBox5.Text == "")
                            textBox5.Text = textBox2.Text;
                        if (textBox6.Text == "")
                            textBox6.Text = textBox3.Text;
                        if (textBox8.Text == "")
                            textBox8.Text = textBox7.Text;
                        var dea = db.deal.SingleOrDefault(w => w.id_deal == s);
                            dea.id_client = Convert.ToInt32(textBox4.Text);
                            dea.id_user = Convert.ToInt32(textBox5.Text);
                            dea.id_realty = Convert.ToInt32(textBox6.Text);
                            dea.date_deal = dateTimePicker2.Value;
                            dea.transaction = Convert.ToInt32(textBox8.Text);
                            db.SaveChanges();
                            MessageBox.Show("Данные изменены");
                            Form f6 = Application.OpenForms[0];
                            f6.Enabled = true;
                            this.Close();
                      
                    }
                }
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

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}