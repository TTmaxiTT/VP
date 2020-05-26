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
    public partial class Form16 : Form
    {
        public Model1 db = new Model1();
        public List<deal> dealh;
        public List<realty> realtyh;
        public List<client> clienth;
        public List<users> usersh;
        public Form16()
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
            
            int s = 0;
            int s1 = 0;
            int s2 = 0;
            int s3 = 0;
            System.DateTime t = dateTimePicker1.Value;
            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == "") || (textBox5.Text == ""))
                MessageBox.Show("Заполните корректно все поля");
            else
            {
                try
                {
                    s = (from dea in dealh
                         where dea.id_client == Convert.ToInt32(textBox1.Text)
                         where dea.id_user == Convert.ToInt32(textBox2.Text)
                         where dea.id_realty == Convert.ToInt32(textBox3.Text)
                         where dea.transaction == Convert.ToInt32(textBox5.Text)
                         where dea.date_deal==t
                         select dea.id_deal).Distinct().First();
                }
                catch
                { }
                try
                {
                    s1 = (from clien in clienth
                          where clien.id_client == Convert.ToInt32(textBox1.Text)
                          select clien.id_client).Distinct().First();
                    s2 = (from user in usersh  
                          where user.id_user == Convert.ToInt32(textBox2.Text)
                          select user.id_user).Distinct().First();
                    s3 = (from realt in realtyh
                          where realt.id_realty == Convert.ToInt32(textBox3.Text)
                          select realt.id_realty).Distinct().First();
                }
                catch
                { }   
                if ((s1 == 0) || (s2 == 0) || (s3 == 0))
                { 
                    MessageBox.Show("Таких данных не существует");
                }
                else
                {
                    if (s == 0)
                    {
                        deal new_deal = new deal
                        { id_client = Convert.ToInt32(textBox1.Text), id_user = Convert.ToInt32(textBox2.Text), id_realty = Convert.ToInt32(textBox3.Text), date_deal = t, transaction = Convert.ToInt32(textBox5.Text) };
                        db.deal.Add(new_deal);
                        db.SaveChanges();
                        MessageBox.Show("Договор добавлен");
                        Form f6 = Application.OpenForms[0];
                        f6.Enabled = true;
                        this.Close();
                    }
                    if (s != 0)
                    {
                        MessageBox.Show("Договор с такими данными уже существует");
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

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
