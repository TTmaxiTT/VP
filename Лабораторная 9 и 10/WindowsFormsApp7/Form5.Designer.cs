namespace WindowsFormsApp7
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            System.Windows.Forms.Label quantity_order_listLabel;
            System.Windows.Forms.Label price_order_listLabel;
            System.Windows.Forms.Label id_bookLabel;
            System.Windows.Forms.Label id_publisherLabel;
            this.label1 = new System.Windows.Forms.Label();
            this.booksDataSet = new WindowsFormsApp7.BooksDataSet();
            this.order_listBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.order_listTableAdapter = new WindowsFormsApp7.BooksDataSetTableAdapters.order_listTableAdapter();
            this.tableAdapterManager = new WindowsFormsApp7.BooksDataSetTableAdapters.TableAdapterManager();
            this.order_listBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.order_listBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.quantity_order_listTextBox = new System.Windows.Forms.TextBox();
            this.price_order_listTextBox = new System.Windows.Forms.TextBox();
            this.id_bookTextBox = new System.Windows.Forms.TextBox();
            this.id_publisherTextBox = new System.Windows.Forms.TextBox();
            quantity_order_listLabel = new System.Windows.Forms.Label();
            price_order_listLabel = new System.Windows.Forms.Label();
            id_bookLabel = new System.Windows.Forms.Label();
            id_publisherLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.booksDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.order_listBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.order_listBindingNavigator)).BeginInit();
            this.order_listBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(119, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Таблица Заказы ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // booksDataSet
            // 
            this.booksDataSet.DataSetName = "BooksDataSet";
            this.booksDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // order_listBindingSource
            // 
            this.order_listBindingSource.DataMember = "order_list";
            this.order_listBindingSource.DataSource = this.booksDataSet;
            // 
            // order_listTableAdapter
            // 
            this.order_listTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.booksTableAdapter = null;
            this.tableAdapterManager.firmTableAdapter = null;
            this.tableAdapterManager.order_listTableAdapter = this.order_listTableAdapter;
            this.tableAdapterManager.publisherTableAdapter = null;
            this.tableAdapterManager.purchaseTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = WindowsFormsApp7.BooksDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.writerTableAdapter = null;
            // 
            // order_listBindingNavigator
            // 
            this.order_listBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.order_listBindingNavigator.BindingSource = this.order_listBindingSource;
            this.order_listBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.order_listBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.order_listBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.order_listBindingNavigatorSaveItem});
            this.order_listBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.order_listBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.order_listBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.order_listBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.order_listBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.order_listBindingNavigator.Name = "order_listBindingNavigator";
            this.order_listBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.order_listBindingNavigator.Size = new System.Drawing.Size(396, 25);
            this.order_listBindingNavigator.TabIndex = 1;
            this.order_listBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Переместить в начало";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Переместить назад";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Положение";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Текущее положение";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(43, 15);
            this.bindingNavigatorCountItem.Text = "для {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Общее число элементов";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 6);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveNextItem.Text = "Переместить вперед";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveLastItem.Text = "Переместить в конец";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 6);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Добавить";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorDeleteItem.Text = "Удалить";
            // 
            // order_listBindingNavigatorSaveItem
            // 
            this.order_listBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.order_listBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("order_listBindingNavigatorSaveItem.Image")));
            this.order_listBindingNavigatorSaveItem.Name = "order_listBindingNavigatorSaveItem";
            this.order_listBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 23);
            this.order_listBindingNavigatorSaveItem.Text = "Сохранить данные";
            this.order_listBindingNavigatorSaveItem.Click += new System.EventHandler(this.order_listBindingNavigatorSaveItem_Click);
            // 
            // quantity_order_listLabel
            // 
            quantity_order_listLabel.AutoSize = true;
            quantity_order_listLabel.Location = new System.Drawing.Point(101, 112);
            quantity_order_listLabel.Name = "quantity_order_listLabel";
            quantity_order_listLabel.Size = new System.Drawing.Size(89, 13);
            quantity_order_listLabel.TabIndex = 2;
            quantity_order_listLabel.Text = "quantity order list:";
            // 
            // quantity_order_listTextBox
            // 
            this.quantity_order_listTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.order_listBindingSource, "quantity_order_list", true));
            this.quantity_order_listTextBox.Location = new System.Drawing.Point(196, 109);
            this.quantity_order_listTextBox.Name = "quantity_order_listTextBox";
            this.quantity_order_listTextBox.Size = new System.Drawing.Size(100, 20);
            this.quantity_order_listTextBox.TabIndex = 3;
            // 
            // price_order_listLabel
            // 
            price_order_listLabel.AutoSize = true;
            price_order_listLabel.Location = new System.Drawing.Point(115, 157);
            price_order_listLabel.Name = "price_order_listLabel";
            price_order_listLabel.Size = new System.Drawing.Size(75, 13);
            price_order_listLabel.TabIndex = 4;
            price_order_listLabel.Text = "price order list:";
            // 
            // price_order_listTextBox
            // 
            this.price_order_listTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.order_listBindingSource, "price_order_list", true));
            this.price_order_listTextBox.Location = new System.Drawing.Point(196, 154);
            this.price_order_listTextBox.Name = "price_order_listTextBox";
            this.price_order_listTextBox.Size = new System.Drawing.Size(100, 20);
            this.price_order_listTextBox.TabIndex = 5;
            // 
            // id_bookLabel
            // 
            id_bookLabel.AutoSize = true;
            id_bookLabel.Location = new System.Drawing.Point(145, 200);
            id_bookLabel.Name = "id_bookLabel";
            id_bookLabel.Size = new System.Drawing.Size(45, 13);
            id_bookLabel.TabIndex = 6;
            id_bookLabel.Text = "id book:";
            // 
            // id_bookTextBox
            // 
            this.id_bookTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.order_listBindingSource, "id_book", true));
            this.id_bookTextBox.Location = new System.Drawing.Point(196, 197);
            this.id_bookTextBox.Name = "id_bookTextBox";
            this.id_bookTextBox.Size = new System.Drawing.Size(100, 20);
            this.id_bookTextBox.TabIndex = 7;
            // 
            // id_publisherLabel
            // 
            id_publisherLabel.AutoSize = true;
            id_publisherLabel.Location = new System.Drawing.Point(127, 248);
            id_publisherLabel.Name = "id_publisherLabel";
            id_publisherLabel.Size = new System.Drawing.Size(63, 13);
            id_publisherLabel.TabIndex = 8;
            id_publisherLabel.Text = "id publisher:";
            // 
            // id_publisherTextBox
            // 
            this.id_publisherTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.order_listBindingSource, "id_publisher", true));
            this.id_publisherTextBox.Location = new System.Drawing.Point(196, 245);
            this.id_publisherTextBox.Name = "id_publisherTextBox";
            this.id_publisherTextBox.Size = new System.Drawing.Size(100, 20);
            this.id_publisherTextBox.TabIndex = 9;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 296);
            this.Controls.Add(id_publisherLabel);
            this.Controls.Add(this.id_publisherTextBox);
            this.Controls.Add(id_bookLabel);
            this.Controls.Add(this.id_bookTextBox);
            this.Controls.Add(price_order_listLabel);
            this.Controls.Add(this.price_order_listTextBox);
            this.Controls.Add(quantity_order_listLabel);
            this.Controls.Add(this.quantity_order_listTextBox);
            this.Controls.Add(this.order_listBindingNavigator);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Таблица Заказы";
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.booksDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.order_listBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.order_listBindingNavigator)).EndInit();
            this.order_listBindingNavigator.ResumeLayout(false);
            this.order_listBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private BooksDataSet booksDataSet;
        private System.Windows.Forms.BindingSource order_listBindingSource;
        private BooksDataSetTableAdapters.order_listTableAdapter order_listTableAdapter;
        private BooksDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator order_listBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton order_listBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox quantity_order_listTextBox;
        private System.Windows.Forms.TextBox price_order_listTextBox;
        private System.Windows.Forms.TextBox id_bookTextBox;
        private System.Windows.Forms.TextBox id_publisherTextBox;
    }
}