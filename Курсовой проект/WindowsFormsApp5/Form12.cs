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
    public partial class Form12 : Form
    {
        public Model1 db = new Model1();
        public List<users> usersh;
        public Form12()
        {
            InitializeComponent();
            usersh = (from user in db.users select user).ToList();  
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
                    s = (from user in usersh
                         where user.id_user == Convert.ToInt32(textBox1.Text)
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
                    List<users> query = (from us in db.users
                                          select us).ToList();
                    users item = query.First(n => n.id_user == s);
                    db.users.Remove(item);
                    db.SaveChanges();
                    MessageBox.Show("Пользователь удалён");
                    Form f6 = Application.OpenForms[0];
                    f6.Enabled = true;
                    this.Close();
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
    }
}
