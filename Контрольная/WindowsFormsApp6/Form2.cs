using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp6
{
    public partial class Form2 : Form
    {
        public Model1 db = new Model1();
        public List<s_students> studentsheet;
        public Form2()
        {
            InitializeComponent();
            studentsheet = (from stud in db.s_students select stud).ToList();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var query = (from s_stud in studentsheet
                         join g in db.s_in_group on s_stud.id_group equals g.id_group
                         orderby s_stud.id
                         select new { s_stud.id, s_stud.surname, s_stud.name, s_stud.middlename, s_stud.id_group, g.group_num }).ToList();
            dataGridView1.DataSource = query;
            dataGridView1.Columns[0].HeaderText = "Номер зачетной";
            dataGridView1.Columns[1].HeaderText = "Фамилия";
            dataGridView1.Columns[2].HeaderText = "Имя";
            dataGridView1.Columns[3].HeaderText = "Отчество";
            dataGridView1.Columns[4].HeaderText = "Номер курса";
            dataGridView1.Columns[5].HeaderText = "Номер группы";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var query = (from s_stud in studentsheet
                         join g in db.s_in_group on s_stud.id_group equals g.id_group
                         orderby s_stud.id
                         select new { s_stud.id, s_stud.surname, s_stud.name, s_stud.middlename, s_stud.id_group, g.group_num }).ToList();

        }
    }
}
