namespace WindowsFormsApp7
{
    partial class Form2
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
            System.Windows.Forms.Label surname_writerLabel;
            System.Windows.Forms.Label name_writerLabel;
            System.Windows.Forms.Label patronymic_writerLabel;
            System.Windows.Forms.Label date_birthLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.label1 = new System.Windows.Forms.Label();
            this.booksDataSet = new WindowsFormsApp7.BooksDataSet();
            this.writerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.writerTableAdapter = new WindowsFormsApp7.BooksDataSetTableAdapters.writerTableAdapter();
            this.tableAdapterManager = new WindowsFormsApp7.BooksDataSetTableAdapters.TableAdapterManager();
            this.writerBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.writerBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.surname_writerTextBox = new System.Windows.Forms.TextBox();
            this.name_writerTextBox = new System.Windows.Forms.TextBox();
            this.patronymic_writerTextBox = new System.Windows.Forms.TextBox();
            this.date_birthDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            surname_writerLabel = new System.Windows.Forms.Label();
            name_writerLabel = new System.Windows.Forms.Label();
            patronymic_writerLabel = new System.Windows.Forms.Label();
            date_birthLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.booksDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.writerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.writerBindingNavigator)).BeginInit();
            this.writerBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // surname_writerLabel
            // 
            surname_writerLabel.AutoSize = true;
            surname_writerLabel.Location = new System.Drawing.Point(71, 117);
            surname_writerLabel.Name = "surname_writerLabel";
            surname_writerLabel.Size = new System.Drawing.Size(78, 13);
            surname_writerLabel.TabIndex = 2;
            surname_writerLabel.Text = "surname writer:";
            // 
            // name_writerLabel
            // 
            name_writerLabel.AutoSize = true;
            name_writerLabel.Location = new System.Drawing.Point(85, 157);
            name_writerLabel.Name = "name_writerLabel";
            name_writerLabel.Size = new System.Drawing.Size(64, 13);
            name_writerLabel.TabIndex = 4;
            name_writerLabel.Text = "name writer:";
            // 
            // patronymic_writerLabel
            // 
            patronymic_writerLabel.AutoSize = true;
            patronymic_writerLabel.Location = new System.Drawing.Point(60, 198);
            patronymic_writerLabel.Name = "patronymic_writerLabel";
            patronymic_writerLabel.Size = new System.Drawing.Size(89, 13);
            patronymic_writerLabel.TabIndex = 6;
            patronymic_writerLabel.Text = "patronymic writer:";
            // 
            // date_birthLabel
            // 
            date_birthLabel.AutoSize = true;
            date_birthLabel.Location = new System.Drawing.Point(85, 251);
            date_birthLabel.Name = "date_birthLabel";
            date_birthLabel.Size = new System.Drawing.Size(54, 13);
            date_birthLabel.TabIndex = 8;
            date_birthLabel.Text = "date birth:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(104, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Таблица Авторы";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // booksDataSet
            // 
            this.booksDataSet.DataSetName = "BooksDataSet";
            this.booksDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // writerBindingSource
            // 
            this.writerBindingSource.DataMember = "writer";
            this.writerBindingSource.DataSource = this.booksDataSet;
            // 
            // writerTableAdapter
            // 
            this.writerTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.booksTableAdapter = null;
            this.tableAdapterManager.firmTableAdapter = null;
            this.tableAdapterManager.order_listTableAdapter = null;
            this.tableAdapterManager.publisherTableAdapter = null;
            this.tableAdapterManager.purchaseTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = WindowsFormsApp7.BooksDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.writerTableAdapter = this.writerTableAdapter;
            // 
            // writerBindingNavigator
            // 
            this.writerBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.writerBindingNavigator.BindingSource = this.writerBindingSource;
            this.writerBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.writerBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.writerBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.writerBindingNavigatorSaveItem});
            this.writerBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.writerBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.writerBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.writerBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.writerBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.writerBindingNavigator.Name = "writerBindingNavigator";
            this.writerBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.writerBindingNavigator.Size = new System.Drawing.Size(352, 25);
            this.writerBindingNavigator.TabIndex = 1;
            this.writerBindingNavigator.Text = "bindingNavigator1";
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
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(43, 22);
            this.bindingNavigatorCountItem.Text = "для {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Общее число элементов";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Удалить";
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
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Текущее положение";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Переместить вперед";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Переместить в конец";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // writerBindingNavigatorSaveItem
            // 
            this.writerBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.writerBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("writerBindingNavigatorSaveItem.Image")));
            this.writerBindingNavigatorSaveItem.Name = "writerBindingNavigatorSaveItem";
            this.writerBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.writerBindingNavigatorSaveItem.Text = "Сохранить данные";
            this.writerBindingNavigatorSaveItem.Click += new System.EventHandler(this.writerBindingNavigatorSaveItem_Click);
            // 
            // surname_writerTextBox
            // 
            this.surname_writerTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.writerBindingSource, "surname_writer", true));
            this.surname_writerTextBox.Location = new System.Drawing.Point(155, 114);
            this.surname_writerTextBox.Name = "surname_writerTextBox";
            this.surname_writerTextBox.Size = new System.Drawing.Size(100, 20);
            this.surname_writerTextBox.TabIndex = 3;
            // 
            // name_writerTextBox
            // 
            this.name_writerTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.writerBindingSource, "name_writer", true));
            this.name_writerTextBox.Location = new System.Drawing.Point(155, 154);
            this.name_writerTextBox.Name = "name_writerTextBox";
            this.name_writerTextBox.Size = new System.Drawing.Size(100, 20);
            this.name_writerTextBox.TabIndex = 5;
            // 
            // patronymic_writerTextBox
            // 
            this.patronymic_writerTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.writerBindingSource, "patronymic_writer", true));
            this.patronymic_writerTextBox.Location = new System.Drawing.Point(155, 195);
            this.patronymic_writerTextBox.Name = "patronymic_writerTextBox";
            this.patronymic_writerTextBox.Size = new System.Drawing.Size(100, 20);
            this.patronymic_writerTextBox.TabIndex = 7;
            // 
            // date_birthDateTimePicker
            // 
            this.date_birthDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.writerBindingSource, "date_birth", true));
            this.date_birthDateTimePicker.Location = new System.Drawing.Point(155, 245);
            this.date_birthDateTimePicker.Name = "date_birthDateTimePicker";
            this.date_birthDateTimePicker.Size = new System.Drawing.Size(131, 20);
            this.date_birthDateTimePicker.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(155, 304);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Отчёт";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 368);
            this.Controls.Add(this.button1);
            this.Controls.Add(date_birthLabel);
            this.Controls.Add(this.date_birthDateTimePicker);
            this.Controls.Add(patronymic_writerLabel);
            this.Controls.Add(this.patronymic_writerTextBox);
            this.Controls.Add(name_writerLabel);
            this.Controls.Add(this.name_writerTextBox);
            this.Controls.Add(surname_writerLabel);
            this.Controls.Add(this.surname_writerTextBox);
            this.Controls.Add(this.writerBindingNavigator);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Таблица Авторы";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.booksDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.writerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.writerBindingNavigator)).EndInit();
            this.writerBindingNavigator.ResumeLayout(false);
            this.writerBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private BooksDataSet booksDataSet;
        private System.Windows.Forms.BindingSource writerBindingSource;
        private BooksDataSetTableAdapters.writerTableAdapter writerTableAdapter;
        private BooksDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator writerBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton writerBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox surname_writerTextBox;
        private System.Windows.Forms.TextBox name_writerTextBox;
        private System.Windows.Forms.TextBox patronymic_writerTextBox;
        private System.Windows.Forms.DateTimePicker date_birthDateTimePicker;
        private System.Windows.Forms.Button button1;
    }
}