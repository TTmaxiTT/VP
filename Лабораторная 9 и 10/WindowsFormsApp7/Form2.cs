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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void writerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.writerBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.booksDataSet);
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {          
            this.writerTableAdapter.Fill(this.booksDataSet.writer);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 a = new Form7();
            a.Show();
        }
    }
}
