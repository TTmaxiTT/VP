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
    public partial class Form1 : Form
    {     
        public Model1 db = new Model1();
        public List<realty> realtyh;
        public Form1()
        {
            InitializeComponent();
            realtyh = (from realt in db.realty select realt).ToList();
            var query = (from realt in realtyh
                         where realt.status == "Продаётся"
                         orderby realt.priсe
                         select new {realt.address, realt.priсe, realt.area, realt.type, realt.phone_number}).ToList();          
            dataGridView1.DataSource = query;
            dataGridView1.Columns[0].HeaderText = "Адрес";
            dataGridView1.Columns[0].Width = 400;        
            dataGridView1.Columns[1].HeaderText = "Цена, руб";
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].HeaderText = "Площадь,   кв. м";
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].HeaderText = "Тип";
            dataGridView1.Columns[3].Width = 128;
            dataGridView1.Columns[4].HeaderText = "Телефон";
            dataGridView1.Columns[4].Width = 140;
            dataGridView1.ReadOnly = true;
            comboBox1.SelectedIndex = 6;
            comboBox2.SelectedIndex = 0;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {        
            Form f3 = new Form3();
            f3.Show ();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {          
            int la = -99;
            int ma = 999999999;
            int lp = -99;
            int mp = 999999999;
            if (textBox5.Text != "")
                la = Convert.ToInt32(textBox5.Text);
            if (textBox4.Text != "")
                ma = Convert.ToInt32(textBox4.Text);
            if (textBox1.Text != "")
                lp = Convert.ToInt32(textBox1.Text);
            if (textBox2.Text != "")
                mp = Convert.ToInt32(textBox2.Text);         
            
            if((comboBox1.SelectedIndex==6)&&(comboBox2.SelectedIndex==0))
            {
                if (textBox3.Text == "")
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.status == "Продаётся"
                                                where realt.priсe > lp
                                                where realt.priсe < mp
                                                where realt.area > la
                                                where realt.area <ma
                                                select new {realt.address,realt.priсe,realt.area,realt.type,realt.phone_number }).ToList();
                if (textBox3.Text != "")
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.status == "Продаётся"
                                                where realt.priсe > lp
                                                where realt.priсe < mp
                                                where realt.area > la
                                                where realt.area < ma
                                                where realt.city == textBox3.Text
                                                select new { realt.address, realt.priсe, realt.area, realt.type, realt.phone_number }).ToList();
            }
            if ((comboBox1.SelectedIndex == 0) && (comboBox2.SelectedIndex == 0))
            {
                if (textBox3.Text == "")
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.status == "Продаётся"
                                                where realt.priсe > lp
                                                where realt.priсe < mp
                                                where realt.area > la
                                                where realt.area < ma
                                                where realt.type=="Квартира"
                                                select new { realt.address, realt.priсe, realt.area, realt.type, realt.phone_number }).ToList();
                if (textBox3.Text != "")
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.status == "Продаётся"
                                                where realt.priсe > lp
                                                where realt.priсe < mp
                                                where realt.area > la
                                                where realt.area < ma
                                                where realt.type == "Квартира"
                                                where realt.city == textBox3.Text
                                                select new { realt.address, realt.priсe, realt.area, realt.type, realt.phone_number }).ToList();
            }
            if ((comboBox1.SelectedIndex == 1) && (comboBox2.SelectedIndex == 0))
            {
                if (textBox3.Text == "")
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.status == "Продаётся"
                                                where realt.priсe > lp
                                                where realt.priсe < mp
                                                where realt.area > la
                                                where realt.area < ma
                                                where realt.type == "Дом"
                                                select new { realt.address, realt.priсe, realt.area, realt.type, realt.phone_number }).ToList();
                if (textBox3.Text != "")
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.status == "Продаётся"
                                                where realt.priсe > lp
                                                where realt.priсe < mp
                                                where realt.area > la
                                                where realt.area < ma
                                                where realt.type == "Дом"
                                                where realt.city == textBox3.Text
                                                select new { realt.address, realt.priсe, realt.area, realt.type, realt.phone_number }).ToList();
            }
            if ((comboBox1.SelectedIndex == 2) && (comboBox2.SelectedIndex == 0))
            {
                if (textBox3.Text == "")
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.status == "Продаётся"
                                                where realt.priсe > lp
                                                where realt.priсe < mp
                                                where realt.area > la
                                                where realt.area < ma
                                                where realt.type == "Дача"
                                                select new { realt.address, realt.priсe, realt.area, realt.type, realt.phone_number }).ToList();
                if (textBox3.Text != "")
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.status == "Продаётся"
                                                where realt.priсe > lp
                                                where realt.priсe < mp
                                                where realt.area > la
                                                where realt.area < ma
                                                where realt.type == "Дача"
                                                where realt.city == textBox3.Text
                                                select new { realt.address, realt.priсe, realt.area, realt.type, realt.phone_number }).ToList();
            }
            if ((comboBox1.SelectedIndex == 3) && (comboBox2.SelectedIndex == 0))
            {
                if (textBox3.Text == "")
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.status == "Продаётся"
                                                where realt.priсe > lp
                                                where realt.priсe < mp
                                                where realt.area > la
                                                where realt.area < ma
                                                where realt.type == "Участок"
                                                select new { realt.address, realt.priсe, realt.area, realt.type, realt.phone_number }).ToList();
                if (textBox3.Text != "")
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.status == "Продаётся"
                                                where realt.priсe > lp
                                                where realt.priсe < mp
                                                where realt.area > la
                                                where realt.area < ma
                                                where realt.type == "Участок"
                                                where realt.city == textBox3.Text
                                                select new { realt.address, realt.priсe, realt.area, realt.type, realt.phone_number }).ToList();
            }
            if ((comboBox1.SelectedIndex == 4) && (comboBox2.SelectedIndex == 0))
            {
                if (textBox3.Text == "")
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.status == "Продаётся"
                                                where realt.priсe > lp
                                                where realt.priсe < mp
                                                where realt.area > la
                                                where realt.area < ma
                                                where realt.type == "Коммерческая"
                                                select new { realt.address, realt.priсe, realt.area, realt.type, realt.phone_number }).ToList();
                if (textBox3.Text != "")
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.status == "Продаётся"
                                                where realt.priсe > lp
                                                where realt.priсe < mp
                                                where realt.area > la
                                                where realt.area < ma
                                                where realt.type == "Коммерческая"
                                                where realt.city == textBox3.Text
                                                select new { realt.address, realt.priсe, realt.area, realt.type, realt.phone_number }).ToList();
            }
            if ((comboBox1.SelectedIndex == 5) && (comboBox2.SelectedIndex == 0))
            {
                if (textBox3.Text == "")
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.status == "Продаётся"
                                                where realt.priсe > lp
                                                where realt.priсe < mp
                                                where realt.area > la
                                                where realt.area < ma
                                                where realt.type == "Гараж"
                                                select new { realt.address, realt.priсe, realt.area, realt.type, realt.phone_number }).ToList();
                if (textBox3.Text != "")
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.status == "Продаётся"
                                                where realt.priсe > lp
                                                where realt.priсe < mp
                                                where realt.area > la
                                                where realt.area < ma
                                                where realt.type == "Гараж"
                                                where realt.city == textBox3.Text
                                                select new { realt.address, realt.priсe, realt.area, realt.type, realt.phone_number }).ToList();
            }
            if ((comboBox1.SelectedIndex == 6) && (comboBox2.SelectedIndex == 1))
            {
                if (textBox3.Text == "")
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe descending
                                                where realt.status == "Продаётся"
                                                where realt.priсe > lp
                                                where realt.priсe < mp
                                                where realt.area > la
                                                where realt.area < ma
                                                select new { realt.address, realt.priсe, realt.area, realt.type, realt.phone_number }).ToList();
                if (textBox3.Text != "")
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe descending
                                                where realt.status == "Продаётся"
                                                where realt.priсe > lp
                                                where realt.priсe < mp
                                                where realt.area > la
                                                where realt.area < ma
                                                where realt.city == textBox3.Text
                                                select new { realt.address, realt.priсe, realt.area, realt.type, realt.phone_number }).ToList();
            }
            if ((comboBox1.SelectedIndex == 0) && (comboBox2.SelectedIndex == 1))
            {
                if (textBox3.Text == "")
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe descending
                                                where realt.status == "Продаётся"
                                                where realt.priсe > lp
                                                where realt.priсe < mp
                                                where realt.area > la
                                                where realt.area < ma
                                                where realt.type == "Квартира"
                                                select new { realt.address, realt.priсe, realt.area, realt.type, realt.phone_number }).ToList();
                if (textBox3.Text != "")
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe descending
                                                where realt.status == "Продаётся"
                                                where realt.priсe > lp
                                                where realt.priсe < mp
                                                where realt.area > la
                                                where realt.area < ma
                                                where realt.type == "Квартира"
                                                where realt.city == textBox3.Text
                                                select new { realt.address, realt.priсe, realt.area, realt.type, realt.phone_number }).ToList();
            }
            if ((comboBox1.SelectedIndex == 1) && (comboBox2.SelectedIndex == 1))
            {
                if (textBox3.Text == "")
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe descending
                                                where realt.status == "Продаётся"
                                                where realt.priсe > lp
                                                where realt.priсe < mp
                                                where realt.area > la
                                                where realt.area < ma
                                                where realt.type == "Дом"
                                                select new { realt.address, realt.priсe, realt.area, realt.type, realt.phone_number }).ToList();
                if (textBox3.Text != "")
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe descending
                                                where realt.status == "Продаётся"
                                                where realt.priсe > lp
                                                where realt.priсe < mp
                                                where realt.area > la
                                                where realt.area < ma
                                                where realt.type == "Дом"
                                                where realt.city == textBox3.Text
                                                select new { realt.address, realt.priсe, realt.area, realt.type, realt.phone_number }).ToList();
            }
            if ((comboBox1.SelectedIndex == 2) && (comboBox2.SelectedIndex == 1))
            {
                if (textBox3.Text == "")
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe descending
                                                where realt.status == "Продаётся"
                                                where realt.priсe > lp
                                                where realt.priсe < mp
                                                where realt.area > la
                                                where realt.area < ma
                                                where realt.type == "Дача"
                                                select new { realt.address, realt.priсe, realt.area, realt.type, realt.phone_number }).ToList();
                if (textBox3.Text != "")
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe descending
                                                where realt.status == "Продаётся"
                                                where realt.priсe > lp
                                                where realt.priсe < mp
                                                where realt.area > la
                                                where realt.area < ma
                                                where realt.type == "Дача"
                                                where realt.city == textBox3.Text
                                                select new { realt.address, realt.priсe, realt.area, realt.type, realt.phone_number }).ToList();
            }
            if ((comboBox1.SelectedIndex == 3) && (comboBox2.SelectedIndex == 1))
            {
                if (textBox3.Text == "")
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe descending
                                                where realt.status == "Продаётся"
                                                where realt.priсe > lp
                                                where realt.priсe < mp
                                                where realt.area > la
                                                where realt.area < ma
                                                where realt.type == "Участок"
                                                select new { realt.address, realt.priсe, realt.area, realt.type, realt.phone_number }).ToList();
                if (textBox3.Text != "")
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe descending
                                                where realt.status == "Продаётся"
                                                where realt.priсe > lp
                                                where realt.priсe < mp
                                                where realt.area > la
                                                where realt.area < ma
                                                where realt.type == "Участок"
                                                where realt.city == textBox3.Text
                                                select new { realt.address, realt.priсe, realt.area, realt.type, realt.phone_number }).ToList();
            }
            if ((comboBox1.SelectedIndex == 4) && (comboBox2.SelectedIndex == 1))
            {
                if (textBox3.Text == "")
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe descending
                                                where realt.status == "Продаётся"
                                                where realt.priсe > lp
                                                where realt.priсe < mp
                                                where realt.area > la
                                                where realt.area < ma
                                                where realt.type == "Коммерческая"
                                                select new { realt.address, realt.priсe, realt.area, realt.type, realt.phone_number }).ToList();
                if (textBox3.Text != "")
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe descending
                                                where realt.status == "Продаётся"
                                                where realt.priсe > lp
                                                where realt.priсe < mp
                                                where realt.area > la
                                                where realt.area < ma
                                                where realt.type == "Коммерческая"
                                                where realt.city == textBox3.Text
                                                select new { realt.address, realt.priсe, realt.area, realt.type, realt.phone_number }).ToList();
            }
            if ((comboBox1.SelectedIndex == 5) && (comboBox2.SelectedIndex == 1))
            {
                if (textBox3.Text == "")
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe descending
                                                where realt.status == "Продаётся"
                                                where realt.priсe > lp
                                                where realt.priсe < mp
                                                where realt.area > la
                                                where realt.area < ma
                                                where realt.type == "Гараж"
                                                select new { realt.address, realt.priсe, realt.area, realt.type, realt.phone_number }).ToList();
                if (textBox3.Text != "")
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe descending
                                                where realt.status == "Продаётся"
                                                where realt.priсe > lp
                                                where realt.priсe < mp
                                                where realt.area > la
                                                where realt.area < ma
                                                where realt.type == "Гараж"
                                                where realt.city == textBox3.Text
                                                select new { realt.address, realt.priсe, realt.area, realt.type, realt.phone_number }).ToList();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            textBox4.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.SelectedIndex = 6;
            comboBox2.SelectedIndex = 0;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

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
            char l = e.KeyChar;
            
                if ((l < 'А' || l > 'я')&& (e.KeyChar != Convert.ToChar(8)))
                    e.Handled = true;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
