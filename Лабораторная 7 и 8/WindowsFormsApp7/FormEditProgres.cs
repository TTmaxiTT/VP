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
    public partial class FormEditProgres : Form
    {
        public Model1 db = new Model1();
        progress item;
        public FormEditProgres(progress prog)
        {
            InitializeComponent();
            item = prog;
            textBox1.Text = item.estimate.ToString();
            numericUpDown1.Value = item.date_exam.Day;
            numericUpDown2.Value = item.date_exam.Month;
            numericUpDown3.Value = item.date_exam.Year;

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = ((Form1)Owner).db.progress.SingleOrDefault(w => w.code_stud == item.code_stud && w.code_subject == item.code_subject);
            result.estimate = Convert.ToInt32(textBox1.Text);
            result.date_exam = new DateTime((int)numericUpDown3.Value, (int)numericUpDown2.Value, (int)numericUpDown1.Value);
            ((Form1)Owner).progressheet = ((Form1)Owner).db.progress.OrderBy(o => o.code_stud).ToList();
            ((Form1)Owner).db.SaveChanges();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
