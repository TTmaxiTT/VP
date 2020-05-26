using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form6 : Form
    {
        public Model1 db = new Model1();
        public List<realty> realtyh;
        public List<client> clienth;
        public List<users> usersh;
        public Form6()
        {
            InitializeComponent();
            realtyh = (from realt in db.realty select realt).ToList();
            clienth = (from clien in db.client select clien).ToList();
            usersh = (from user in db.users select user).ToList();
            var query = (from realt in realtyh
                         orderby realt.id_realty
                         select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
            dataGridView1.DataSource = query;
            dataGridView1.Columns[0].HeaderText = "Номер";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].HeaderText = "Адрес";
            dataGridView1.Columns[1].Width = 380;
            dataGridView1.Columns[2].HeaderText = "Цена, руб";
            dataGridView1.Columns[2].Width = 65;
            dataGridView1.Columns[3].HeaderText = "Площадь, кв. м";
            dataGridView1.Columns[3].Width = 65;
            dataGridView1.Columns[4].HeaderText = "Тип";
            dataGridView1.Columns[4].Width = 80;
            dataGridView1.Columns[5].HeaderText = "Статус";
            dataGridView1.Columns[5].Width = 80;
            dataGridView1.Columns[6].HeaderText = "Телефон";
            dataGridView1.Columns[6].Width = 75;
            dataGridView1.ReadOnly = true;
            comboBox1.SelectedIndex = 6;
            comboBox2.SelectedIndex = 2;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
            var query1 = (from clien in clienth
                          orderby clien.surname
                          select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
            dataGridView2.DataSource = query1;
            dataGridView2.Columns[0].HeaderText = "Номер";
            dataGridView2.Columns[0].Width = 50;
            dataGridView2.Columns[1].HeaderText = "Фамилия";
            dataGridView2.Columns[1].Width = 80;
            dataGridView2.Columns[2].HeaderText = "Имя";
            dataGridView2.Columns[2].Width = 80;
            dataGridView2.Columns[3].HeaderText = "Отчество";
            dataGridView2.Columns[3].Width = 80;
            dataGridView2.Columns[4].HeaderText = "Телефон";
            dataGridView2.Columns[4].Width = 80;
            dataGridView2.Columns[5].HeaderText = "Статус";
            dataGridView2.Columns[5].Width = 80;
            dataGridView2.ReadOnly = true;
            var query2 = (from user in usersh
                          orderby user.surname
                          select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
            dataGridView3.DataSource = query2;
            dataGridView3.Columns[0].HeaderText = "Номер";
            dataGridView3.Columns[0].Width = 50;
            dataGridView3.Columns[1].HeaderText = "Фамилия";
            dataGridView3.Columns[1].Width = 80;
            dataGridView3.Columns[2].HeaderText = "Имя";
            dataGridView3.Columns[2].Width = 80;
            dataGridView3.Columns[3].HeaderText = "Отчество";
            dataGridView3.Columns[3].Width = 80;
            dataGridView3.Columns[4].HeaderText = "Телефон";
            dataGridView3.Columns[4].Width = 80;
            dataGridView3.Columns[5].HeaderText = "Роль";
            dataGridView3.Columns[5].Width = 80;
            dataGridView3.ReadOnly = true;
            textBox12.MaxLength = 11;
            textBox13.MaxLength = 11;
            textBox14.MaxLength = 11;
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox12.Text = "";
            comboBox1.SelectedIndex = 6;
            comboBox2.SelectedIndex = 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int lp = -999;
            int mp = 999999999;
            int la = -999;
            int ma = 999999999;
            if (textBox3.Text != "")
                lp = Convert.ToInt32(textBox3.Text);
            if (textBox4.Text != "")
                mp = Convert.ToInt32(textBox4.Text);
            if (textBox5.Text != "")
                la = Convert.ToInt32(textBox5.Text);
            if (textBox6.Text != "")
                ma = Convert.ToInt32(textBox6.Text);
            if ((comboBox1.SelectedIndex == 6) && (comboBox2.SelectedIndex == 2))
            {
                if ((textBox2.Text == "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
                if ((textBox2.Text != "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.city == textBox2.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
                if ((textBox2.Text == "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.city == textBox2.Text
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
            }
            if ((comboBox1.SelectedIndex == 0) && (comboBox2.SelectedIndex == 2))
            {
                if ((textBox2.Text == "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.type == "Квартира"
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.type == "Квартира"
                                                where realt.area <= ma
                                                where realt.city == textBox2.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
                if ((textBox2.Text == "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.type == "Квартира"
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.type == "Квартира"
                                                where realt.city == textBox2.Text
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

            }
            if ((comboBox1.SelectedIndex == 1) && (comboBox2.SelectedIndex == 2))
            {
                if ((textBox2.Text == "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.type == "Дом"
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.type == "Дом"
                                                where realt.area <= ma
                                                where realt.city == textBox2.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
                if ((textBox2.Text == "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.type == "Дом"
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.type == "Дом"
                                                where realt.city == textBox2.Text
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

            }
            if ((comboBox1.SelectedIndex == 2) && (comboBox2.SelectedIndex == 2))
            {
                if ((textBox2.Text == "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.type == "Дача"
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.type == "Дача"
                                                where realt.area <= ma
                                                where realt.city == textBox2.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
                if ((textBox2.Text == "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.type == "Дача"
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.type == "Дача"
                                                where realt.city == textBox2.Text
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

            }
            if ((comboBox1.SelectedIndex == 3) && (comboBox2.SelectedIndex == 2))
            {
                if ((textBox2.Text == "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.type == "Участок"
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.type == "Участок"
                                                where realt.area <= ma
                                                where realt.city == textBox2.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
                if ((textBox2.Text == "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.type == "Участок"
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.type == "Участок"
                                                where realt.city == textBox2.Text
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
            }
            if ((comboBox1.SelectedIndex == 4) && (comboBox2.SelectedIndex == 2))
            {
                if ((textBox2.Text == "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.type == "Коммерческая"
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.type == "Коммерческая"
                                                where realt.area <= ma
                                                where realt.city == textBox2.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
                if ((textBox2.Text == "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.type == "Коммерческая"
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.type == "Коммерческая"
                                                where realt.city == textBox2.Text
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

            }
            if ((comboBox1.SelectedIndex == 5) && (comboBox2.SelectedIndex == 2))
            {
                if ((textBox2.Text == "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.type == "Гараж"
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.type == "Гараж"
                                                where realt.area <= ma
                                                where realt.city == textBox2.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
                if ((textBox2.Text == "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.type == "Гараж"
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.type == "Гараж"
                                                where realt.city == textBox2.Text
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

            }
            if ((comboBox1.SelectedIndex == 6) && (comboBox2.SelectedIndex == 0))
            {
                if ((textBox2.Text == "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.status == "Продаётся"
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.status == "Продаётся"
                                                where realt.area <= ma
                                                where realt.city == textBox2.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
                if ((textBox2.Text == "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.status == "Продаётся"
                                                where realt.area <= ma
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.status == "Продаётся"
                                                where realt.city == textBox2.Text
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

            }
            if ((comboBox1.SelectedIndex == 0) && (comboBox2.SelectedIndex == 0))
            {
                if ((textBox2.Text == "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.type == "Квартира"
                                                where realt.status == "Продаётся"
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.type == "Квартира"
                                                where realt.area <= ma
                                                where realt.status == "Продаётся"
                                                where realt.city == textBox2.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
                if ((textBox2.Text == "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.status == "Продаётся"
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.type == "Квартира"
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.status == "Продаётся"
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.type == "Квартира"
                                                where realt.city == textBox2.Text
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

            }
            if ((comboBox1.SelectedIndex == 1) && (comboBox2.SelectedIndex == 0))
            {
                if ((textBox2.Text == "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.status == "Продаётся"
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.type == "Дом"
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.status == "Продаётся"
                                                where realt.type == "Дом"
                                                where realt.area <= ma
                                                where realt.city == textBox2.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
                if ((textBox2.Text == "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.status == "Продаётся"
                                                where realt.type == "Дом"
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.status == "Продаётся"
                                                where realt.type == "Дом"
                                                where realt.city == textBox2.Text
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

            }
            if ((comboBox1.SelectedIndex == 2) && (comboBox2.SelectedIndex == 0))
            {
                if ((textBox2.Text == "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.status == "Продаётся"
                                                where realt.area <= ma
                                                where realt.type == "Дача"
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.status == "Продаётся"
                                                where realt.area >= la
                                                where realt.type == "Дача"
                                                where realt.area <= ma
                                                where realt.city == textBox2.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
                if ((textBox2.Text == "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.status == "Продаётся"
                                                where realt.area <= ma
                                                where realt.type == "Дача"
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.status == "Продаётся"
                                                where realt.area <= ma
                                                where realt.type == "Дача"
                                                where realt.city == textBox2.Text
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

            }
            if ((comboBox1.SelectedIndex == 3) && (comboBox2.SelectedIndex == 0))
            {
                if ((textBox2.Text == "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.status == "Продаётся"
                                                where realt.area <= ma
                                                where realt.type == "Участок"
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.status == "Продаётся"
                                                where realt.type == "Участок"
                                                where realt.area <= ma
                                                where realt.city == textBox2.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
                if ((textBox2.Text == "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.status == "Продаётся"
                                                where realt.area <= ma
                                                where realt.type == "Участок"
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.status == "Продаётся"
                                                where realt.area <= ma
                                                where realt.type == "Участок"
                                                where realt.city == textBox2.Text
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

            }
            if ((comboBox1.SelectedIndex == 4) && (comboBox2.SelectedIndex == 0))
            {
                if ((textBox2.Text == "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.status == "Продаётся"
                                                where realt.type == "Коммерческая"
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.status == "Продаётся"
                                                where realt.type == "Коммерческая"
                                                where realt.area <= ma
                                                where realt.city == textBox2.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
                if ((textBox2.Text == "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.status == "Продаётся"
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.type == "Коммерческая"
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.status == "Продаётся"
                                                where realt.type == "Коммерческая"
                                                where realt.city == textBox2.Text
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

            }
            if ((comboBox1.SelectedIndex == 5) && (comboBox2.SelectedIndex == 0))
            {
                if ((textBox2.Text == "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.status == "Продаётся"
                                                where realt.type == "Гараж"
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.status == "Продаётся"
                                                where realt.type == "Гараж"
                                                where realt.area <= ma
                                                where realt.city == textBox2.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
                if ((textBox2.Text == "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.status == "Продаётся"
                                                where realt.area <= ma
                                                where realt.type == "Гараж"
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.status == "Продаётся"
                                                where realt.type == "Гараж"
                                                where realt.city == textBox2.Text
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

            }
            if ((comboBox1.SelectedIndex == 6) && (comboBox2.SelectedIndex == 1))
            {
                if ((textBox2.Text == "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.status == "Продан"
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.status == "Продан"
                                                where realt.area <= ma
                                                where realt.city == textBox2.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
                if ((textBox2.Text == "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.status == "Продан"
                                                where realt.area <= ma
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.status == "Продан"
                                                where realt.city == textBox2.Text
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

            }
            if ((comboBox1.SelectedIndex == 0) && (comboBox2.SelectedIndex == 1))
            {
                if ((textBox2.Text == "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.type == "Квартира"
                                                where realt.status == "Продан"
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.type == "Квартира"
                                                where realt.area <= ma
                                                where realt.status == "Продан"
                                                where realt.city == textBox2.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
                if ((textBox2.Text == "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.status == "Продан"
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.type == "Квартира"
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.status == "Продан"
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.type == "Квартира"
                                                where realt.city == textBox2.Text
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

            }
            if ((comboBox1.SelectedIndex == 1) && (comboBox2.SelectedIndex == 1))
            {
                if ((textBox2.Text == "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.status == "Продан"
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.type == "Дом"
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.status == "Продан"
                                                where realt.type == "Дом"
                                                where realt.area <= ma
                                                where realt.city == textBox2.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
                if ((textBox2.Text == "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.status == "Продан"
                                                where realt.type == "Дом"
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.status == "Продан"
                                                where realt.type == "Дом"
                                                where realt.city == textBox2.Text
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

            }
            if ((comboBox1.SelectedIndex == 2) && (comboBox2.SelectedIndex == 1))
            {
                if ((textBox2.Text == "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.status == "Продан"
                                                where realt.area <= ma
                                                where realt.type == "Дача"
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.status == "Продан"
                                                where realt.area >= la
                                                where realt.type == "Дача"
                                                where realt.area <= ma
                                                where realt.city == textBox2.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
                if ((textBox2.Text == "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.status == "Продан"
                                                where realt.area <= ma
                                                where realt.type == "Дача"
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.status == "Продан"
                                                where realt.area <= ma
                                                where realt.type == "Дача"
                                                where realt.city == textBox2.Text
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

            }
            if ((comboBox1.SelectedIndex == 3) && (comboBox2.SelectedIndex == 1))
            {
                if ((textBox2.Text == "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.status == "Продан"
                                                where realt.area <= ma
                                                where realt.type == "Участок"
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.status == "Продан"
                                                where realt.type == "Участок"
                                                where realt.area <= ma
                                                where realt.city == textBox2.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
                if ((textBox2.Text == "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.status == "Продан"
                                                where realt.area <= ma
                                                where realt.type == "Участок"
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();


                if ((textBox2.Text != "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.status == "Продан"
                                                where realt.area <= ma
                                                where realt.type == "Участок"
                                                where realt.city == textBox2.Text
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

            }
            if ((comboBox1.SelectedIndex == 4) && (comboBox2.SelectedIndex == 1))
            {
                if ((textBox2.Text == "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.status == "Продан"
                                                where realt.type == "Коммерческая"
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.status == "Продан"
                                                where realt.type == "Коммерческая"
                                                where realt.area <= ma
                                                where realt.city == textBox2.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
                if ((textBox2.Text == "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.status == "Продан"
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.type == "Коммерческая"
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.status == "Продан"
                                                where realt.type == "Коммерческая"
                                                where realt.city == textBox2.Text
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

            }
            if ((comboBox1.SelectedIndex == 5) && (comboBox2.SelectedIndex == 1))
            {
                if ((textBox2.Text == "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.status == "Продан"
                                                where realt.type == "Гараж"
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.status == "Продан"
                                                where realt.type == "Гараж"
                                                where realt.area <= ma
                                                where realt.city == textBox2.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
                if ((textBox2.Text == "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.status == "Продан"
                                                where realt.area <= ma
                                                where realt.type == "Гараж"
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.status == "Продан"
                                                where realt.type == "Гараж"
                                                where realt.city == textBox2.Text
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

            }

        }
    
        private void button3_Click(object sender, EventArgs e)
        {
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox13.Text = "";
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0; 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if((comboBox4.SelectedIndex==0)&&(comboBox5.SelectedIndex==0))
            {
                if((textBox8.Text=="")&&(textBox9.Text=="")&&(textBox10.Text=="")&&(textBox13.Text==""))
                dataGridView2.DataSource = (from clien in clienth
                                            orderby clien.surname                                                                            
                                            select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();             
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.surname == textBox8.Text
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.name == textBox9.Text
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.pathronymic == textBox10.Text
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.phone_number == textBox13.Text
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();        
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.surname == textBox8.Text
                                                where clien.name == textBox9.Text
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.surname == textBox8.Text
                                                where clien.pathronymic == textBox10.Text
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.surname == textBox8.Text
                                                where clien.phone_number == textBox13.Text
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.surname == textBox8.Text
                                                where clien.name == textBox9.Text
                                                where clien.pathronymic==textBox10.Text
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.surname == textBox8.Text
                                                where clien.name == textBox9.Text
                                                where clien.phone_number== textBox13.Text
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.surname == textBox8.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.phone_number== textBox13.Text
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname                                             
                                                where clien.name == textBox9.Text
                                                where clien.pathronymic==textBox10.Text
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.name == textBox9.Text
                                                where clien.phone_number == textBox13.Text
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.name == textBox9.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.phone_number== textBox13.Text
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.pathronymic == textBox10.Text
                                                where clien.phone_number== textBox13.Text
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.surname == textBox8.Text
                                                where clien.name == textBox9.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.phone_number == textBox13.Text
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();

            }
            if ((comboBox4.SelectedIndex == 1) && (comboBox5.SelectedIndex == 0))
            {
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.status=="новый"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.surname == textBox8.Text
                                                where clien.status == "новый"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.name == textBox9.Text
                                                where clien.status == "новый"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.pathronymic == textBox10.Text
                                                where clien.status == "новый"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "новый"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.surname == textBox8.Text
                                                where clien.name == textBox9.Text
                                                where clien.status == "новый"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.surname == textBox8.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.status == "новый"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.surname == textBox8.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "новый"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.surname == textBox8.Text
                                                where clien.name == textBox9.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.status == "новый"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.surname == textBox8.Text
                                                where clien.name == textBox9.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "новый"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.surname == textBox8.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "новый"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.name == textBox9.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.status == "новый"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.name == textBox9.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "новый"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.name == textBox9.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "новый"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.pathronymic == textBox10.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "новый"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.surname == textBox8.Text
                                                where clien.name == textBox9.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "новый"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
            }
            if ((comboBox4.SelectedIndex == 2) && (comboBox5.SelectedIndex == 0))
            {
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.status == "обрабатывается"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.surname == textBox8.Text
                                                where clien.status == "обрабатывается"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.name == textBox9.Text
                                                where clien.status == "обрабатывается"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.pathronymic == textBox10.Text
                                                where clien.status == "обрабатывается"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "обрабатывается"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.surname == textBox8.Text
                                                where clien.name == textBox9.Text
                                                where clien.status == "обрабатывается"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.surname == textBox8.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.status == "обрабатывается"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.surname == textBox8.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "обрабатывается"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.surname == textBox8.Text
                                                where clien.name == textBox9.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.status == "обрабатывается"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.surname == textBox8.Text
                                                where clien.name == textBox9.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "обрабатывается"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.surname == textBox8.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "обрабатывается"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.name == textBox9.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.status == "обрабатывается"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.name == textBox9.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "обрабатывается"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.name == textBox9.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "обрабатывается"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.pathronymic == textBox10.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "обрабатывается"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.surname == textBox8.Text
                                                where clien.name == textBox9.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "обрабатывается"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
            }
            if ((comboBox4.SelectedIndex == 3) && (comboBox5.SelectedIndex == 0))
            {
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.status == "выполнено"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.surname == textBox8.Text
                                                where clien.status == "выполнено"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.name == textBox9.Text
                                                where clien.status == "выполнено"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.pathronymic == textBox10.Text
                                                where clien.status == "выполнено"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "выполнено"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.surname == textBox8.Text
                                                where clien.name == textBox9.Text
                                                where clien.status == "выполнено"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.surname == textBox8.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.status == "выполнено"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.surname == textBox8.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "выполнено"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.surname == textBox8.Text
                                                where clien.name == textBox9.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.status == "выполнено"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.surname == textBox8.Text
                                                where clien.name == textBox9.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "выполнено"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.surname == textBox8.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "выполнено"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.name == textBox9.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.status == "выполнено"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.name == textBox9.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "выполнено"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.name == textBox9.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "выполнено"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.pathronymic == textBox10.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "выполнено"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.surname == textBox8.Text
                                                where clien.name == textBox9.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "выполнено"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
            }
            if ((comboBox4.SelectedIndex == 0) && (comboBox5.SelectedIndex == 1))
            {
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.surname == textBox8.Text
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.name == textBox9.Text
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.pathronymic == textBox10.Text
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.phone_number == textBox13.Text
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.surname == textBox8.Text
                                                where clien.name == textBox9.Text
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.surname == textBox8.Text
                                                where clien.pathronymic == textBox10.Text
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.surname == textBox8.Text
                                                where clien.phone_number == textBox13.Text
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.surname == textBox8.Text
                                                where clien.name == textBox9.Text
                                                where clien.pathronymic == textBox10.Text
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.surname == textBox8.Text
                                                where clien.name == textBox9.Text
                                                where clien.phone_number == textBox13.Text
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.surname == textBox8.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.phone_number == textBox13.Text
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.name == textBox9.Text
                                                where clien.pathronymic == textBox10.Text
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.name == textBox9.Text
                                                where clien.phone_number == textBox13.Text
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.name == textBox9.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.phone_number == textBox13.Text
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.pathronymic == textBox10.Text
                                                where clien.phone_number == textBox13.Text
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.surname == textBox8.Text
                                                where clien.name == textBox9.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.phone_number == textBox13.Text
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
            }
            if ((comboBox4.SelectedIndex == 1) && (comboBox5.SelectedIndex == 1))
            {
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.status == "новый"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.surname == textBox8.Text
                                                where clien.status == "новый"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.name == textBox9.Text
                                                where clien.status == "новый"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.pathronymic == textBox10.Text
                                                where clien.status == "новый"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "новый"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.surname == textBox8.Text
                                                where clien.name == textBox9.Text
                                                where clien.status == "новый"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.surname == textBox8.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.status == "новый"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.surname == textBox8.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "новый"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.surname == textBox8.Text
                                                where clien.name == textBox9.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.status == "новый"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.surname == textBox8.Text
                                                where clien.name == textBox9.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "новый"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.surname == textBox8.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "новый"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.name == textBox9.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.status == "новый"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.name == textBox9.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "новый"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.name == textBox9.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "новый"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.pathronymic == textBox10.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "новый"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.surname == textBox8.Text
                                                where clien.name == textBox9.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "новый"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
            }
            if ((comboBox4.SelectedIndex == 2) && (comboBox5.SelectedIndex == 1))
            {
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.status == "обрабатывается"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.surname == textBox8.Text
                                                where clien.status == "обрабатывается"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.name == textBox9.Text
                                                where clien.status == "обрабатывается"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.pathronymic == textBox10.Text
                                                where clien.status == "обрабатывается"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "обрабатывается"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.surname == textBox8.Text
                                                where clien.name == textBox9.Text
                                                where clien.status == "обрабатывается"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.surname == textBox8.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.status == "обрабатывается"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.surname == textBox8.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "обрабатывается"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.surname == textBox8.Text
                                                where clien.name == textBox9.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.status == "обрабатывается"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.surname == textBox8.Text
                                                where clien.name == textBox9.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "обрабатывается"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.surname == textBox8.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "обрабатывается"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.name == textBox9.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.status == "обрабатывается"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.name == textBox9.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "обрабатывается"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.name == textBox9.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "обрабатывается"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.pathronymic == textBox10.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "обрабатывается"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.surname == textBox8.Text
                                                where clien.name == textBox9.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "обрабатывается"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
            }
            if ((comboBox4.SelectedIndex == 3) && (comboBox5.SelectedIndex == 1))
            {
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.status == "выполнено"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.surname == textBox8.Text
                                                where clien.status == "выполнено"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.name == textBox9.Text
                                                where clien.status == "выполнено"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.pathronymic == textBox10.Text
                                                where clien.status == "выполнено"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "выполнено"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.surname == textBox8.Text
                                                where clien.name == textBox9.Text
                                                where clien.status == "выполнено"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.surname == textBox8.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.status == "выполнено"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.surname == textBox8.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "выполнено"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.surname == textBox8.Text
                                                where clien.name == textBox9.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.status == "выполнено"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.surname == textBox8.Text
                                                where clien.name == textBox9.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "выполнено"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.surname == textBox8.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "выполнено"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.name == textBox9.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.status == "выполнено"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.name == textBox9.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "выполнено"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.name == textBox9.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "выполнено"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.pathronymic == textBox10.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "выполнено"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname descending
                                                where clien.surname == textBox8.Text
                                                where clien.name == textBox9.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.phone_number == textBox13.Text
                                                where clien.status == "выполнено"
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox7.Text = "";
            textBox11.Text = "";
            textBox14.Text = "";         
            comboBox3.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if ((comboBox3.SelectedIndex==0)&&(comboBox6.SelectedIndex==0))
            {
                if ((textBox1.Text == "") && (textBox7.Text == "") && (textBox11.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.name == textBox7.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.pathronymic == textBox11.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.phone_number == textBox14.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.pathronymic == textBox11.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.phone_number == textBox14.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.phone_number == textBox14.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.name == textBox7.Text
                                                where user.phone_number == textBox14.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
            }
            if ((comboBox3.SelectedIndex == 1) && (comboBox6.SelectedIndex == 0))
            {
                if ((textBox1.Text == "") && (textBox7.Text == "") && (textBox11.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.role=="риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.name == textBox7.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.phone_number == textBox14.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.name == textBox7.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
            }
            if ((comboBox3.SelectedIndex == 2) && (comboBox6.SelectedIndex == 0))
            {
                if ((textBox1.Text == "") && (textBox7.Text == "") && (textBox11.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.name == textBox7.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.phone_number == textBox14.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.name == textBox7.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
            }
            if ((comboBox3.SelectedIndex == 3) && (comboBox6.SelectedIndex == 0))
            {
                if ((textBox1.Text == "") && (textBox7.Text == "") && (textBox11.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.name == textBox7.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.phone_number == textBox14.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.name == textBox7.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
            }
            if ((comboBox3.SelectedIndex == 0) && (comboBox6.SelectedIndex == 1))
            {
                if ((textBox1.Text == "") && (textBox7.Text == "") && (textBox11.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.name == textBox7.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.pathronymic == textBox11.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.phone_number == textBox14.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.pathronymic == textBox11.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.phone_number == textBox14.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.phone_number == textBox14.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.name == textBox7.Text
                                                where user.phone_number == textBox14.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
            }
            if ((comboBox3.SelectedIndex == 1) && (comboBox6.SelectedIndex == 1))
            {
                if ((textBox1.Text == "") && (textBox7.Text == "") && (textBox11.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.name == textBox7.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.phone_number == textBox14.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.name == textBox7.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
            }
            if ((comboBox3.SelectedIndex == 2) && (comboBox6.SelectedIndex == 1))
            {
                if ((textBox1.Text == "") && (textBox7.Text == "") && (textBox11.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.name == textBox7.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.phone_number == textBox14.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.name == textBox7.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
            }
            if ((comboBox3.SelectedIndex == 3) && (comboBox6.SelectedIndex == 1))
            {
                if ((textBox1.Text == "") && (textBox7.Text == "") && (textBox11.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.name == textBox7.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.phone_number == textBox14.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.name == textBox7.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form f7 = new Form7();
            f7.Show();
            this.Enabled = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form f8 = new Form8();
            f8.Show();
            this.Enabled = false;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            usersh = (from user in db.users select user).ToList();
            var query2 = (from user in usersh
                          orderby user.surname
                          select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role }).ToList();
            dataGridView3.DataSource = query2;
            dataGridView3.ReadOnly = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;

            if ((l < 'а' || l > 'я') && (e.KeyChar != Convert.ToChar(8)))
                e.Handled = true;
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;

            if ((l < 'а' || l > 'я') && (e.KeyChar != Convert.ToChar(8)))
                e.Handled = true;
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;

            if ((l < 'а' || l > 'я') && (e.KeyChar != Convert.ToChar(8)))
                e.Handled = true;
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;

            if ((l < 'а' || l > 'я') && (e.KeyChar != Convert.ToChar(8)))
                e.Handled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;

            if ((l < 'а' || l > 'я') && (e.KeyChar != Convert.ToChar(8)))
                e.Handled = true;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;

            if ((l < 'а' || l > 'я') && (e.KeyChar != Convert.ToChar(8)))
                e.Handled = true;
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;

            if ((l < 'а' || l > 'я') && (e.KeyChar != Convert.ToChar(8)))
                e.Handled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 1)
                textBox2.Text = textBox2.Text.ToUpper();
            textBox2.Select(textBox2.Text.Length, 0);
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text.Length == 1)
                textBox8.Text = textBox8.Text.ToUpper();
            textBox8.Select(textBox8.Text.Length, 0);
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (textBox9.Text.Length == 1)
                textBox9.Text = textBox9.Text.ToUpper();
            textBox9.Select(textBox9.Text.Length, 0);
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (textBox10.Text.Length == 1)
                textBox10.Text = textBox10.Text.ToUpper();
            textBox10.Select(textBox10.Text.Length, 0);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 1)
                textBox1.Text = textBox1.Text.ToUpper();
            textBox1.Select(textBox1.Text.Length, 0);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text.Length == 1)
                textBox7.Text = textBox7.Text.ToUpper();
            textBox7.Select(textBox7.Text.Length, 0);
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (textBox11.Text.Length == 1)
                textBox11.Text = textBox11.Text.ToUpper();
            textBox11.Select(textBox11.Text.Length, 0);
        }
    }
    }
