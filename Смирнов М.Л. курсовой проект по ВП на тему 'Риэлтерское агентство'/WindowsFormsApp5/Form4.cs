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
    public partial class Form4 : Form
    {
        public Model1 db = new Model1();
        public List<realty> realtyh;
        public List<client> clienth;
        public List<users> usersh;
        public List<deal> dealh;
        public Form4()
        {
            InitializeComponent();
            realtyh = (from realt in db.realty select realt).ToList();
            clienth = (from clien in db.client select clien).ToList();
            usersh = (from user in db.users select user).ToList();
            dealh = (from dea in db.deal select dea).ToList();
            var query = (from realt in realtyh
                         orderby realt.id_realty
                         select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
            dataGridView1.DataSource = query;
            dataGridView1.Columns[0].HeaderText = "Номер";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].HeaderText = "Адрес";
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].HeaderText = "Город";
            dataGridView1.Columns[2].Width = 70;
            dataGridView1.Columns[3].HeaderText = "Цена, руб";
            dataGridView1.Columns[3].Width = 50;
            dataGridView1.Columns[4].HeaderText = "Площадь,   кв. м";
            dataGridView1.Columns[4].Width = 70;
            dataGridView1.Columns[5].HeaderText = "Тип";
            dataGridView1.Columns[5].Width = 70;
            dataGridView1.Columns[6].HeaderText = "Статус";
            dataGridView1.Columns[6].Width = 70;
            dataGridView1.Columns[7].HeaderText = "Телефон";
            dataGridView1.Columns[7].Width = 80;
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
                          select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
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
            dataGridView3.Columns[5].Width = 90;
            dataGridView3.Columns[6].HeaderText = "Логин";
            dataGridView3.Columns[6].Width = 80;
            dataGridView3.Columns[7].HeaderText = "Пароль";
            dataGridView3.Columns[7].Width = 80;
            dataGridView3.ReadOnly = true;
            textBox12.MaxLength = 11;
            textBox13.MaxLength = 11;
            textBox14.MaxLength = 11;
            var query3 = (from dea in dealh
                          join g in db.client on dea.id_client equals g.id_client
                          join g2 in db.realty on dea.id_realty equals g2.id_realty
                          orderby dea.id_deal
                          select new { dea.id_deal, dea.id_client, g.surname, dea.id_user, dea.id_realty, g2.address, g2.priсe, g2.area, g2.type, dea.date_deal, dea.transaction }).ToList();
            dataGridView4.DataSource = query3;
            dataGridView4.Columns[0].HeaderText = "Номер договора";
            dataGridView4.Columns[0].Width =60;
            dataGridView4.Columns[1].HeaderText = "Номер клиента";
            dataGridView4.Columns[1].Width = 50;
            dataGridView4.Columns[2].HeaderText = "Фамилия клиента";
            dataGridView4.Columns[2].Width = 80;
            dataGridView4.Columns[3].HeaderText = "Номер риэлтора";
            dataGridView4.Columns[3].Width = 50;
            dataGridView4.Columns[4].HeaderText = "Номер недвиж.";
            dataGridView4.Columns[4].Width = 50;
            dataGridView4.Columns[5].HeaderText = "Адрес";
            dataGridView4.Columns[5].Width = 200;
            dataGridView4.Columns[6].HeaderText = "Цена, руб.";
            dataGridView4.Columns[6].Width = 50;
            dataGridView4.Columns[7].HeaderText = "Площадь, кв. м";
            dataGridView4.Columns[7].Width = 70;
            dataGridView4.Columns[8].HeaderText = "Тип";
            dataGridView4.Columns[8].Width = 70;
            dataGridView4.Columns[9].HeaderText = "Дата";
            dataGridView4.Columns[9].Width = 70;
            dataGridView4.Columns[10].HeaderText = "Стоимость, руб.";
            dataGridView4.Columns[10].Width = 70;
            dataGridView4.ReadOnly = true;
            dateTimePicker1.Enabled = false;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
                if ((textBox2.Text != "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.city == textBox2.Text
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
                if ((textBox2.Text == "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.city == textBox2.Text
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.type == "Квартира"
                                                where realt.area <= ma
                                                where realt.city == textBox2.Text
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
                if ((textBox2.Text == "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.type == "Квартира"
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.type == "Дом"
                                                where realt.area <= ma
                                                where realt.city == textBox2.Text
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
                if ((textBox2.Text == "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.type == "Дом"
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.type == "Дача"
                                                where realt.area <= ma
                                                where realt.city == textBox2.Text
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
                if ((textBox2.Text == "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.type == "Дача"
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.type == "Участок"
                                                where realt.area <= ma
                                                where realt.city == textBox2.Text
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
                if ((textBox2.Text == "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.type == "Участок"
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.type == "Коммерческая"
                                                where realt.area <= ma
                                                where realt.city == textBox2.Text
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
                if ((textBox2.Text == "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.type == "Коммерческая"
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.type == "Гараж"
                                                where realt.area <= ma
                                                where realt.city == textBox2.Text
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
                if ((textBox2.Text == "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.area <= ma
                                                where realt.type == "Гараж"
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.status == "Продаётся"
                                                where realt.area <= ma
                                                where realt.city == textBox2.Text
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
                if ((textBox2.Text == "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.status == "Продаётся"
                                                where realt.area <= ma
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

                if ((textBox2.Text != "") && (textBox12.Text == ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.status == "Продан"
                                                where realt.area <= ma
                                                where realt.city == textBox2.Text
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
                if ((textBox2.Text == "") && (textBox12.Text != ""))
                    dataGridView1.DataSource = (from realt in realtyh
                                                orderby realt.priсe
                                                where realt.priсe >= lp
                                                where realt.priсe <= mp
                                                where realt.area >= la
                                                where realt.status == "Продан"
                                                where realt.area <= ma
                                                where realt.phone_number == textBox12.Text
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();


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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
                                                select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();

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
            if ((comboBox4.SelectedIndex == 0) && (comboBox5.SelectedIndex == 0))
            {
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox13.Text == ""))
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
                                                where clien.pathronymic == textBox10.Text
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.surname == textBox8.Text
                                                where clien.name == textBox9.Text
                                                where clien.phone_number == textBox13.Text
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.surname == textBox8.Text
                                                where clien.pathronymic == textBox10.Text
                                                where clien.phone_number == textBox13.Text
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox13.Text == ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.name == textBox9.Text
                                                where clien.pathronymic == textBox10.Text
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
                                                where clien.phone_number == textBox13.Text
                                                select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox13.Text != ""))
                    dataGridView2.DataSource = (from clien in clienth
                                                orderby clien.surname
                                                where clien.pathronymic == textBox10.Text
                                                where clien.phone_number == textBox13.Text
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
                                                where clien.status == "новый"
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
            if ((comboBox3.SelectedIndex == 0) && (comboBox6.SelectedIndex == 0))
            {
                if ((textBox1.Text == "") && (textBox7.Text == "") && (textBox11.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.name == textBox7.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.pathronymic == textBox11.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.phone_number == textBox14.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.pathronymic == textBox11.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.phone_number == textBox14.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.phone_number == textBox14.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.name == textBox7.Text
                                                where user.phone_number == textBox14.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
            }
            if ((comboBox3.SelectedIndex == 1) && (comboBox6.SelectedIndex == 0))
            {
                if ((textBox1.Text == "") && (textBox7.Text == "") && (textBox11.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.name == textBox7.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.phone_number == textBox14.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.name == textBox7.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
            }
            if ((comboBox3.SelectedIndex == 2) && (comboBox6.SelectedIndex == 0))
            {
                if ((textBox1.Text == "") && (textBox7.Text == "") && (textBox11.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.name == textBox7.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.phone_number == textBox14.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.name == textBox7.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
            }
            if ((comboBox3.SelectedIndex == 3) && (comboBox6.SelectedIndex == 0))
            {
                if ((textBox1.Text == "") && (textBox7.Text == "") && (textBox11.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.name == textBox7.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.phone_number == textBox14.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.name == textBox7.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
            }
            if ((comboBox3.SelectedIndex == 0) && (comboBox6.SelectedIndex == 1))
            {
                if ((textBox1.Text == "") && (textBox7.Text == "") && (textBox11.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.name == textBox7.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.pathronymic == textBox11.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.phone_number == textBox14.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.pathronymic == textBox11.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.phone_number == textBox14.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.phone_number == textBox14.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.name == textBox7.Text
                                                where user.phone_number == textBox14.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
            }
            if ((comboBox3.SelectedIndex == 1) && (comboBox6.SelectedIndex == 1))
            {
                if ((textBox1.Text == "") && (textBox7.Text == "") && (textBox11.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.name == textBox7.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.phone_number == textBox14.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.name == textBox7.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "риэлтор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
            }
            if ((comboBox3.SelectedIndex == 2) && (comboBox6.SelectedIndex == 1))
            {
                if ((textBox1.Text == "") && (textBox7.Text == "") && (textBox11.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.name == textBox7.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.phone_number == textBox14.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.name == textBox7.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "секретарь"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
            }
            if ((comboBox3.SelectedIndex == 3) && (comboBox6.SelectedIndex == 1))
            {
                if ((textBox1.Text == "") && (textBox7.Text == "") && (textBox11.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.name == textBox7.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.phone_number == textBox14.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text == ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text == "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.name == textBox7.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text == "") && (textBox9.Text == "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
                if ((textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox14.Text != ""))
                    dataGridView3.DataSource = (from user in usersh
                                                orderby user.surname descending
                                                where user.surname == textBox1.Text
                                                where user.name == textBox7.Text
                                                where user.pathronymic == textBox11.Text
                                                where user.phone_number == textBox14.Text
                                                where user.role == "администратор"
                                                select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role, user.login, user.password }).ToList();
            }
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form f9 = new Form9();
            f9.Show();
            this.Enabled = false;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            clienth = (from clien in db.client select clien).ToList();
            var query1 = (from clien in clienth
                          orderby clien.surname
                          select new { clien.id_client, clien.surname, clien.name, clien.pathronymic, clien.phone_number, clien.status }).ToList();
            dataGridView2.ReadOnly = true;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            usersh = (from user in db.users select user).ToList();
            var query2 = (from user in usersh
                          orderby user.surname
                          select new { user.id_user, user.surname, user.name, user.pathronymic, user.phone_number, user.role,user.login,user.password }).ToList();
            dataGridView3.DataSource = query2;
            dataGridView3.ReadOnly = true;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            realtyh = (from realt in db.realty select realt).ToList();
            var query = (from realt in realtyh
                         orderby realt.id_realty
                         select new { realt.id_realty, realt.address, realt.city, realt.priсe, realt.area, realt.type, realt.status, realt.phone_number }).ToList();
            dataGridView1.DataSource = query;
            dataGridView1.ReadOnly = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Form f11 = new Form11();
            f11.Show();
            this.Enabled = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form f12 = new Form12();
            f12.Show();
            this.Enabled = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form f10 = new Form10();
            f10.Show();
            this.Enabled = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form f13 = new Form13();
            f13.Show();
            this.Enabled = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form f14 = new Form14();
            f14.Show();
            this.Enabled = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form f15 = new Form15();
            f15.Show();
            this.Enabled = false;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            dealh = (from dea in db.deal select dea).ToList();
            var query3 = (from dea in dealh
                          join g in db.client on dea.id_client equals g.id_client
                          join g2 in db.realty on dea.id_realty equals g2.id_realty
                          orderby dea.id_deal
                          select new { dea.id_deal, dea.id_client, g.surname, dea.id_user, dea.id_realty, g2.address, g2.priсe, g2.area, g2.type, dea.date_deal, dea.transaction }).ToList();
            dataGridView4.DataSource = query3;
            dataGridView4.ReadOnly = true;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Enabled == true)
            {
                System.DateTime s = dateTimePicker1.Value;
                if((textBox15.Text=="")&& (textBox16.Text == "")&& (textBox17.Text == "")&& (textBox18.Text == ""))
                    dataGridView4.DataSource = (from dea in dealh
                                            join g in db.client on dea.id_client equals g.id_client
                                            join g2 in db.realty on dea.id_realty equals g2.id_realty
                                            orderby dea.id_deal
                                            where dea.date_deal == s
                                            select new { dea.id_deal, dea.id_client, g.surname, dea.id_user, dea.id_realty, g2.address, g2.priсe, g2.area, g2.type, dea.date_deal, dea.transaction }).ToList();
                if ((textBox15.Text != "") && (textBox16.Text == "") && (textBox17.Text == "") && (textBox18.Text == ""))
                    dataGridView4.DataSource = (from dea in dealh
                                                join g in db.client on dea.id_client equals g.id_client
                                                join g2 in db.realty on dea.id_realty equals g2.id_realty
                                                orderby dea.id_deal
                                                where dea.date_deal == s
                                                where dea.id_deal==Convert.ToInt32(textBox15.Text)
                                                select new { dea.id_deal, dea.id_client, g.surname, dea.id_user, dea.id_realty, g2.address, g2.priсe, g2.area, g2.type, dea.date_deal, dea.transaction }).ToList();
                if ((textBox15.Text == "") && (textBox16.Text != "") && (textBox17.Text == "") && (textBox18.Text == ""))
                    dataGridView4.DataSource = (from dea in dealh
                                                join g in db.client on dea.id_client equals g.id_client
                                                join g2 in db.realty on dea.id_realty equals g2.id_realty
                                                orderby dea.id_deal
                                                where dea.date_deal == s
                                                where g.surname == textBox16.Text
                                                select new { dea.id_deal, dea.id_client, g.surname, dea.id_user, dea.id_realty, g2.address, g2.priсe, g2.area, g2.type, dea.date_deal, dea.transaction }).ToList();
                if ((textBox15.Text == "") && (textBox16.Text == "") && (textBox17.Text != "") && (textBox18.Text == ""))
                    dataGridView4.DataSource = (from dea in dealh
                                                join g in db.client on dea.id_client equals g.id_client
                                                join g2 in db.realty on dea.id_realty equals g2.id_realty
                                                orderby dea.id_deal
                                                where dea.date_deal == s
                                                where dea.id_user == Convert.ToInt32(textBox17.Text)
                                                select new { dea.id_deal, dea.id_client, g.surname, dea.id_user, dea.id_realty, g2.address, g2.priсe, g2.area, g2.type, dea.date_deal, dea.transaction }).ToList();
                if ((textBox15.Text == "") && (textBox16.Text == "") && (textBox17.Text == "") && (textBox18.Text != ""))
                    dataGridView4.DataSource = (from dea in dealh
                                                join g in db.client on dea.id_client equals g.id_client
                                                join g2 in db.realty on dea.id_realty equals g2.id_realty
                                                orderby dea.id_deal
                                                where dea.date_deal == s
                                                where dea.id_realty == Convert.ToInt32(textBox18.Text)
                                                select new { dea.id_deal, dea.id_client, g.surname, dea.id_user, dea.id_realty, g2.address, g2.priсe, g2.area, g2.type, dea.date_deal, dea.transaction }).ToList();
                if ((textBox15.Text != "") && (textBox16.Text != "") && (textBox17.Text == "") && (textBox18.Text == ""))
                    dataGridView4.DataSource = (from dea in dealh
                                                join g in db.client on dea.id_client equals g.id_client
                                                join g2 in db.realty on dea.id_realty equals g2.id_realty
                                                orderby dea.id_deal
                                                where dea.date_deal == s
                                                where dea.id_deal == Convert.ToInt32(textBox15.Text)
                                                where g.surname== textBox16.Text
                                                select new { dea.id_deal, dea.id_client, g.surname, dea.id_user, dea.id_realty, g2.address, g2.priсe, g2.area, g2.type, dea.date_deal, dea.transaction }).ToList();
                if ((textBox15.Text != "") && (textBox16.Text == "") && (textBox17.Text != "") && (textBox18.Text == ""))
                    dataGridView4.DataSource = (from dea in dealh
                                                join g in db.client on dea.id_client equals g.id_client
                                                join g2 in db.realty on dea.id_realty equals g2.id_realty
                                                orderby dea.id_deal
                                                where dea.date_deal == s
                                                where dea.id_deal == Convert.ToInt32(textBox15.Text)
                                                where dea.id_user == Convert.ToInt32(textBox17.Text)
                                                select new { dea.id_deal, dea.id_client, g.surname, dea.id_user, dea.id_realty, g2.address, g2.priсe, g2.area, g2.type, dea.date_deal, dea.transaction }).ToList();
                if ((textBox15.Text != "") && (textBox16.Text == "") && (textBox17.Text == "") && (textBox18.Text != ""))
                    dataGridView4.DataSource = (from dea in dealh
                                                join g in db.client on dea.id_client equals g.id_client
                                                join g2 in db.realty on dea.id_realty equals g2.id_realty
                                                orderby dea.id_deal
                                                where dea.date_deal == s
                                                where dea.id_deal == Convert.ToInt32(textBox15.Text)
                                                where dea.id_realty == Convert.ToInt32(textBox18.Text)
                                                select new { dea.id_deal, dea.id_client, g.surname, dea.id_user, dea.id_realty, g2.address, g2.priсe, g2.area, g2.type, dea.date_deal, dea.transaction }).ToList();
                if ((textBox15.Text != "") && (textBox16.Text != "") && (textBox17.Text != "") && (textBox18.Text == ""))
                    dataGridView4.DataSource = (from dea in dealh
                                                join g in db.client on dea.id_client equals g.id_client
                                                join g2 in db.realty on dea.id_realty equals g2.id_realty
                                                orderby dea.id_deal
                                                where dea.date_deal == s
                                                where dea.id_deal == Convert.ToInt32(textBox15.Text)
                                                where g.surname == textBox16.Text
                                                where dea.id_user == Convert.ToInt32(textBox17.Text)
                                                select new { dea.id_deal, dea.id_client, g.surname, dea.id_user, dea.id_realty, g2.address, g2.priсe, g2.area, g2.type, dea.date_deal, dea.transaction }).ToList();
                if ((textBox15.Text != "") && (textBox16.Text == "") && (textBox17.Text != "") && (textBox18.Text != ""))
                    dataGridView4.DataSource = (from dea in dealh
                                                join g in db.client on dea.id_client equals g.id_client
                                                join g2 in db.realty on dea.id_realty equals g2.id_realty
                                                orderby dea.id_deal
                                                where dea.date_deal == s
                                                where dea.id_deal == Convert.ToInt32(textBox15.Text)
                                                where dea.id_user == Convert.ToInt32(textBox17.Text)
                                                where dea.id_realty == Convert.ToInt32(textBox18.Text)
                                                select new { dea.id_deal, dea.id_client, g.surname, dea.id_user, dea.id_realty, g2.address, g2.priсe, g2.area, g2.type, dea.date_deal, dea.transaction }).ToList();
                if ((textBox15.Text == "") && (textBox16.Text != "") && (textBox17.Text != "") && (textBox18.Text != ""))
                    dataGridView4.DataSource = (from dea in dealh
                                                join g in db.client on dea.id_client equals g.id_client
                                                join g2 in db.realty on dea.id_realty equals g2.id_realty
                                                orderby dea.id_deal
                                                where dea.date_deal == s
                                                where g.surname == textBox16.Text
                                                where dea.id_user == Convert.ToInt32(textBox17.Text)
                                                where dea.id_realty == Convert.ToInt32(textBox18.Text)
                                                select new { dea.id_deal, dea.id_client, g.surname, dea.id_user, dea.id_realty, g2.address, g2.priсe, g2.area, g2.type, dea.date_deal, dea.transaction }).ToList();
                if ((textBox15.Text != "") && (textBox16.Text != "") && (textBox17.Text != "") && (textBox18.Text != ""))
                    dataGridView4.DataSource = (from dea in dealh
                                                join g in db.client on dea.id_client equals g.id_client
                                                join g2 in db.realty on dea.id_realty equals g2.id_realty
                                                orderby dea.id_deal
                                                where dea.date_deal == s
                                                where dea.id_deal == Convert.ToInt32(textBox15.Text)
                                                where g.surname == textBox16.Text
                                                where dea.id_user == Convert.ToInt32(textBox17.Text)
                                                where dea.id_realty == Convert.ToInt32(textBox18.Text)
                                                select new { dea.id_deal, dea.id_client, g.surname, dea.id_user, dea.id_realty, g2.address, g2.priсe, g2.area, g2.type, dea.date_deal, dea.transaction }).ToList();
                if ((textBox15.Text == "") && (textBox16.Text != "") && (textBox17.Text != "") && (textBox18.Text == ""))
                    dataGridView4.DataSource = (from dea in dealh
                                                join g in db.client on dea.id_client equals g.id_client
                                                join g2 in db.realty on dea.id_realty equals g2.id_realty
                                                orderby dea.id_deal
                                                where dea.date_deal == s
                                                where g.surname == textBox16.Text
                                                where dea.id_user == Convert.ToInt32(textBox17.Text) 
                                                select new { dea.id_deal, dea.id_client, g.surname, dea.id_user, dea.id_realty, g2.address, g2.priсe, g2.area, g2.type, dea.date_deal, dea.transaction }).ToList();
                if ((textBox15.Text == "") && (textBox16.Text != "") && (textBox17.Text == "") && (textBox18.Text != ""))
                    dataGridView4.DataSource = (from dea in dealh
                                                join g in db.client on dea.id_client equals g.id_client
                                                join g2 in db.realty on dea.id_realty equals g2.id_realty
                                                orderby dea.id_deal
                                                where dea.date_deal == s
                                                where g.surname == textBox16.Text
                                                where dea.id_realty == Convert.ToInt32(textBox18.Text)
                                                select new { dea.id_deal, dea.id_client, g.surname, dea.id_user, dea.id_realty, g2.address, g2.priсe, g2.area, g2.type, dea.date_deal, dea.transaction }).ToList();
                if ((textBox15.Text == "") && (textBox16.Text == "") && (textBox17.Text != "") && (textBox18.Text != ""))
                    dataGridView4.DataSource = (from dea in dealh
                                                join g in db.client on dea.id_client equals g.id_client
                                                join g2 in db.realty on dea.id_realty equals g2.id_realty
                                                orderby dea.id_deal
                                                where dea.date_deal == s
                                                where dea.id_user == Convert.ToInt32(textBox17.Text)
                                                where dea.id_realty == Convert.ToInt32(textBox18.Text)
                                                select new { dea.id_deal, dea.id_client, g.surname, dea.id_user, dea.id_realty, g2.address, g2.priсe, g2.area, g2.type, dea.date_deal, dea.transaction }).ToList();


            }
            if (dateTimePicker1.Enabled == false)
            {
                if ((textBox15.Text == "") && (textBox16.Text == "") && (textBox17.Text == "") && (textBox18.Text == ""))
                    dataGridView4.DataSource = (from dea in dealh
                                                join g in db.client on dea.id_client equals g.id_client
                                                join g2 in db.realty on dea.id_realty equals g2.id_realty
                                                orderby dea.id_deal
                                                
                                                select new { dea.id_deal, dea.id_client, g.surname, dea.id_user, dea.id_realty, g2.address, g2.priсe, g2.area, g2.type, dea.date_deal, dea.transaction }).ToList();
                if ((textBox15.Text != "") && (textBox16.Text == "") && (textBox17.Text == "") && (textBox18.Text == ""))
                    dataGridView4.DataSource = (from dea in dealh
                                                join g in db.client on dea.id_client equals g.id_client
                                                join g2 in db.realty on dea.id_realty equals g2.id_realty
                                                orderby dea.id_deal
                                             
                                                where dea.id_deal == Convert.ToInt32(textBox15.Text)
                                                select new { dea.id_deal, dea.id_client, g.surname, dea.id_user, dea.id_realty, g2.address, g2.priсe, g2.area, g2.type, dea.date_deal, dea.transaction }).ToList();
                if ((textBox15.Text == "") && (textBox16.Text != "") && (textBox17.Text == "") && (textBox18.Text == ""))
                    dataGridView4.DataSource = (from dea in dealh
                                                join g in db.client on dea.id_client equals g.id_client
                                                join g2 in db.realty on dea.id_realty equals g2.id_realty
                                                orderby dea.id_deal
                                              
                                                where g.surname == textBox16.Text
                                                select new { dea.id_deal, dea.id_client, g.surname, dea.id_user, dea.id_realty, g2.address, g2.priсe, g2.area, g2.type, dea.date_deal, dea.transaction }).ToList();
                if ((textBox15.Text == "") && (textBox16.Text == "") && (textBox17.Text != "") && (textBox18.Text == ""))
                    dataGridView4.DataSource = (from dea in dealh
                                                join g in db.client on dea.id_client equals g.id_client
                                                join g2 in db.realty on dea.id_realty equals g2.id_realty
                                                orderby dea.id_deal
                                               
                                                where dea.id_user == Convert.ToInt32(textBox17.Text)
                                                select new { dea.id_deal, dea.id_client, g.surname, dea.id_user, dea.id_realty, g2.address, g2.priсe, g2.area, g2.type, dea.date_deal, dea.transaction }).ToList();
                if ((textBox15.Text == "") && (textBox16.Text == "") && (textBox17.Text == "") && (textBox18.Text != ""))
                    dataGridView4.DataSource = (from dea in dealh
                                                join g in db.client on dea.id_client equals g.id_client
                                                join g2 in db.realty on dea.id_realty equals g2.id_realty
                                                orderby dea.id_deal
                                            
                                                where dea.id_realty == Convert.ToInt32(textBox18.Text)
                                                select new { dea.id_deal, dea.id_client, g.surname, dea.id_user, dea.id_realty, g2.address, g2.priсe, g2.area, g2.type, dea.date_deal, dea.transaction }).ToList();
                if ((textBox15.Text != "") && (textBox16.Text != "") && (textBox17.Text == "") && (textBox18.Text == ""))
                    dataGridView4.DataSource = (from dea in dealh
                                                join g in db.client on dea.id_client equals g.id_client
                                                join g2 in db.realty on dea.id_realty equals g2.id_realty
                                                orderby dea.id_deal
                                            
                                                where dea.id_deal == Convert.ToInt32(textBox15.Text)
                                                where g.surname == textBox16.Text
                                                select new { dea.id_deal, dea.id_client, g.surname, dea.id_user, dea.id_realty, g2.address, g2.priсe, g2.area, g2.type, dea.date_deal, dea.transaction }).ToList();
                if ((textBox15.Text != "") && (textBox16.Text == "") && (textBox17.Text != "") && (textBox18.Text == ""))
                    dataGridView4.DataSource = (from dea in dealh
                                                join g in db.client on dea.id_client equals g.id_client
                                                join g2 in db.realty on dea.id_realty equals g2.id_realty
                                                orderby dea.id_deal
                                              
                                                where dea.id_deal == Convert.ToInt32(textBox15.Text)
                                                where dea.id_user == Convert.ToInt32(textBox17.Text)
                                                select new { dea.id_deal, dea.id_client, g.surname, dea.id_user, dea.id_realty, g2.address, g2.priсe, g2.area, g2.type, dea.date_deal, dea.transaction }).ToList();
                if ((textBox15.Text != "") && (textBox16.Text == "") && (textBox17.Text == "") && (textBox18.Text != ""))
                    dataGridView4.DataSource = (from dea in dealh
                                                join g in db.client on dea.id_client equals g.id_client
                                                join g2 in db.realty on dea.id_realty equals g2.id_realty
                                                orderby dea.id_deal
                                         
                                                where dea.id_deal == Convert.ToInt32(textBox15.Text)
                                                where dea.id_realty == Convert.ToInt32(textBox18.Text)
                                                select new { dea.id_deal, dea.id_client, g.surname, dea.id_user, dea.id_realty, g2.address, g2.priсe, g2.area, g2.type, dea.date_deal, dea.transaction }).ToList();
                if ((textBox15.Text != "") && (textBox16.Text != "") && (textBox17.Text != "") && (textBox18.Text == ""))
                    dataGridView4.DataSource = (from dea in dealh
                                                join g in db.client on dea.id_client equals g.id_client
                                                join g2 in db.realty on dea.id_realty equals g2.id_realty
                                                orderby dea.id_deal
                                            
                                                where dea.id_deal == Convert.ToInt32(textBox15.Text)
                                                where g.surname == textBox16.Text
                                                where dea.id_user == Convert.ToInt32(textBox17.Text)
                                                select new { dea.id_deal, dea.id_client, g.surname, dea.id_user, dea.id_realty, g2.address, g2.priсe, g2.area, g2.type, dea.date_deal, dea.transaction }).ToList();
                if ((textBox15.Text != "") && (textBox16.Text == "") && (textBox17.Text != "") && (textBox18.Text != ""))
                    dataGridView4.DataSource = (from dea in dealh
                                                join g in db.client on dea.id_client equals g.id_client
                                                join g2 in db.realty on dea.id_realty equals g2.id_realty
                                                orderby dea.id_deal
                                               
                                                where dea.id_deal == Convert.ToInt32(textBox15.Text)
                                                where dea.id_user == Convert.ToInt32(textBox17.Text)
                                                where dea.id_realty == Convert.ToInt32(textBox18.Text)
                                                select new { dea.id_deal, dea.id_client, g.surname, dea.id_user, dea.id_realty, g2.address, g2.priсe, g2.area, g2.type, dea.date_deal, dea.transaction }).ToList();
                if ((textBox15.Text == "") && (textBox16.Text != "") && (textBox17.Text != "") && (textBox18.Text != ""))
                    dataGridView4.DataSource = (from dea in dealh
                                                join g in db.client on dea.id_client equals g.id_client
                                                join g2 in db.realty on dea.id_realty equals g2.id_realty
                                                orderby dea.id_deal
                                             
                                                where g.surname == textBox16.Text
                                                where dea.id_user == Convert.ToInt32(textBox17.Text)
                                                where dea.id_realty == Convert.ToInt32(textBox18.Text)
                                                select new { dea.id_deal, dea.id_client, g.surname, dea.id_user, dea.id_realty, g2.address, g2.priсe, g2.area, g2.type, dea.date_deal, dea.transaction }).ToList();
                if ((textBox15.Text != "") && (textBox16.Text != "") && (textBox17.Text != "") && (textBox18.Text != ""))
                    dataGridView4.DataSource = (from dea in dealh
                                                join g in db.client on dea.id_client equals g.id_client
                                                join g2 in db.realty on dea.id_realty equals g2.id_realty
                                                orderby dea.id_deal
                                            
                                                where dea.id_deal == Convert.ToInt32(textBox15.Text)
                                                where g.surname == textBox16.Text
                                                where dea.id_user == Convert.ToInt32(textBox17.Text)
                                                where dea.id_realty == Convert.ToInt32(textBox18.Text)
                                                select new { dea.id_deal, dea.id_client, g.surname, dea.id_user, dea.id_realty, g2.address, g2.priсe, g2.area, g2.type, dea.date_deal, dea.transaction }).ToList();
                if ((textBox15.Text == "") && (textBox16.Text != "") && (textBox17.Text != "") && (textBox18.Text == ""))
                    dataGridView4.DataSource = (from dea in dealh
                                                join g in db.client on dea.id_client equals g.id_client
                                                join g2 in db.realty on dea.id_realty equals g2.id_realty
                                                orderby dea.id_deal
                                             
                                                where g.surname == textBox16.Text
                                                where dea.id_user == Convert.ToInt32(textBox17.Text)
                                                select new { dea.id_deal, dea.id_client, g.surname, dea.id_user, dea.id_realty, g2.address, g2.priсe, g2.area, g2.type, dea.date_deal, dea.transaction }).ToList();
                if ((textBox15.Text == "") && (textBox16.Text != "") && (textBox17.Text == "") && (textBox18.Text != ""))
                    dataGridView4.DataSource = (from dea in dealh
                                                join g in db.client on dea.id_client equals g.id_client
                                                join g2 in db.realty on dea.id_realty equals g2.id_realty
                                                orderby dea.id_deal
                                           
                                                where g.surname == textBox16.Text
                                                where dea.id_realty == Convert.ToInt32(textBox18.Text)
                                                select new { dea.id_deal, dea.id_client, g.surname, dea.id_user, dea.id_realty, g2.address, g2.priсe, g2.area, g2.type, dea.date_deal, dea.transaction }).ToList();
                if ((textBox15.Text == "") && (textBox16.Text == "") && (textBox17.Text != "") && (textBox18.Text != ""))
                    dataGridView4.DataSource = (from dea in dealh
                                                join g in db.client on dea.id_client equals g.id_client
                                                join g2 in db.realty on dea.id_realty equals g2.id_realty
                                                orderby dea.id_deal
                                              
                                                where dea.id_user == Convert.ToInt32(textBox17.Text)
                                                where dea.id_realty == Convert.ToInt32(textBox18.Text)
                                                select new { dea.id_deal, dea.id_client, g.surname, dea.id_user, dea.id_realty, g2.address, g2.priсe, g2.area, g2.type, dea.date_deal, dea.transaction }).ToList();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = false;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Form f16 = new Form16();
            f16.Show();
            this.Enabled = false;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Form f17 = new Form17();
            f17.Show();
            this.Enabled = false;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Form f18 = new Form18();
            f18.Show();
            this.Enabled = false;
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

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (textBox11.Text.Length == 1)
                textBox11.Text = textBox11.Text.ToUpper();
            textBox11.Select(textBox11.Text.Length, 0);
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;

            if ((l < 'а' || l > 'я') && (e.KeyChar != Convert.ToChar(8)))
                e.Handled = true;
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;

            if ((l < 'а' || l > 'я') && (e.KeyChar != Convert.ToChar(8)))
                e.Handled = true;
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            if (textBox16.Text.Length == 1)
                textBox16.Text = textBox16.Text.ToUpper();
            textBox16.Select(textBox16.Text.Length, 0);
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
    }
}
