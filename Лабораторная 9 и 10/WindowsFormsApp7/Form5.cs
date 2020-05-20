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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void order_listBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {


                this.Validate();
                this.order_listBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.booksDataSet);
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
           
            this.order_listTableAdapter.Fill(this.booksDataSet.order_list);

        }
    }
}
