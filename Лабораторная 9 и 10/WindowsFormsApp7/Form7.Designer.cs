namespace WindowsFormsApp7
{
    partial class Form7
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.BooksDataSet = new WindowsFormsApp7.BooksDataSet();
            this.writerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.writerTableAdapter = new WindowsFormsApp7.BooksDataSetTableAdapters.writerTableAdapter();
            this.booksDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.writerBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.BooksDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.writerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.booksDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.writerBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.writerBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsApp7.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(569, 371);
            this.reportViewer1.TabIndex = 0;
            // 
            // BooksDataSet
            // 
            this.BooksDataSet.DataSetName = "BooksDataSet";
            this.BooksDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // writerBindingSource
            // 
            this.writerBindingSource.DataMember = "writer";
            this.writerBindingSource.DataSource = this.BooksDataSet;
            // 
            // writerTableAdapter
            // 
            this.writerTableAdapter.ClearBeforeFill = true;
            // 
            // booksDataSetBindingSource
            // 
            this.booksDataSetBindingSource.DataSource = this.BooksDataSet;
            this.booksDataSetBindingSource.Position = 0;
            // 
            // writerBindingSource1
            // 
            this.writerBindingSource1.DataMember = "writer";
            this.writerBindingSource1.DataSource = this.booksDataSetBindingSource;
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 371);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form7";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчет таблицы Авторы";
            this.Load += new System.EventHandler(this.Form7_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BooksDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.writerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.booksDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.writerBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource writerBindingSource;
        private BooksDataSet BooksDataSet;
        private BooksDataSetTableAdapters.writerTableAdapter writerTableAdapter;
        private System.Windows.Forms.BindingSource booksDataSetBindingSource;
        private System.Windows.Forms.BindingSource writerBindingSource1;
    }
}