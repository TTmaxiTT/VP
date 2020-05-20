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
        public Form4()
        {
            InitializeComponent();
        }

        private void publisherBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {


                this.Validate();
                this.publisherBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.booksDataSet);
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
            this.publisherTableAdapter.Fill(this.booksDataSet.publisher);

        }
    }
}
