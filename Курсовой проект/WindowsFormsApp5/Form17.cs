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
    public partial class Form17 : Form
    {
        public Model1 db = new Model1();
        public List<deal> dealh;
        public Form17()
        {
            InitializeComponent();
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
            if ((textBox1.Text == ""))
                MessageBox.Show("Заполните поле");
            else
            {
                try
                {
                    s = (from dea in dealh
                         where dea.id_deal == Convert.ToInt32(textBox1.Text)
                         select dea.id_deal).Distinct().First();
                }
                catch
                { }
                if (s == 0)
                {
                    MessageBox.Show("Данный договор не найден");
                }
                if (s != 0)
                {
                    List<deal> query = (from us in db.deal
                                          select us).ToList();
                    deal item = query.First(n => n.id_deal == s);
                    db.deal.Remove(item);
                    db.SaveChanges();
                    MessageBox.Show("Договор удален");
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
