using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form4 : Form
    {
        public Model1 db = new Model1();
        public List<post> posth;
        public Form4()
        {
            InitializeComponent();
            posth = (from pos in db.post select pos).ToList();
            var query = (from pos in posth 
                             select new { pos.recipient }).ToList();
            dataGridView1.DataSource = query;
            dataGridView1.Columns[0].HeaderText = "Адрес";
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Form f1 = new Form1();
            f1.Show();
            this.Close();
        }
    }
}
