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
    public partial class Form14 : Form
    {
        public Model1 db = new Model1();
        public List<realty> realtyh;
        public Form14()
        {
            InitializeComponent();
            realtyh = (from realt in db.realty select realt).ToList();  
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
                    s = (from realt in realtyh
                         where realt.id_realty == Convert.ToInt32(textBox1.Text)
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
                    List<realty> query = (from us in db.realty
                                          select us).ToList();
                    realty item = query.First(n => n.id_realty== s);
                    db.realty.Remove(item);
                    db.SaveChanges();
                    MessageBox.Show("Недвижимость удалена");
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
