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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void booksBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.booksBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.booksDataSet);
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
           
            this.booksTableAdapter.Fill(this.booksDataSet.books);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 a = new Form6();
            a.Show();
        }
    }
}
