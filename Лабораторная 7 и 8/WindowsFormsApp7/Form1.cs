﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NPOI.XSSF.UserModel;

namespace WindowsFormsApp7
{

    public partial class Form1 : Form
    {
        public Model1 db = new Model1();
        public List<students> studentsheet;
        public List<progress> progressheet;
        public Form1()
        {
            InitializeComponent();
            studentsheet = (from stud in db.students select stud).ToList();
            progressheet = (from prog in db.progress select prog).ToList();
            var query = (from stud in studentsheet
                         join g in db.groups on stud.code_group equals g.code_group
                         orderby stud.code_stud
                         select new { stud.code_stud, stud.surname, stud.name, g.name_group, stud.code_group }).ToList();
            var query2 = (from prog in db.progress
                          join s in db.students on prog.code_stud equals s.code_stud
                          join sub in db.subjects on prog.code_subject equals sub.code_subject
                          join l in db.lectors on prog.code_lector equals l.code_lector
                          orderby prog.code_stud
                          select new { s.surname, s.name, sub.name_subject, l.name_lector, prog.date_exam, prog.estimate }).ToList();
            if (radioButton1.Checked)
                dataGridView1.DataSource = query;
            else
                dataGridView1.DataSource = query2;
            dataGridView1.ReadOnly = true;
            if (dataGridView1.RowCount == 0) label1.Visible = true;
            else label1.Visible = false;
            dataGridView1.Columns[0].HeaderText = "Фамилия";
            dataGridView1.Columns[1].HeaderText = "Имя";
            dataGridView1.Columns[2].HeaderText = "Предмет";
            dataGridView1.Columns[3].HeaderText = "Преподаватель";
            dataGridView1.Columns[4].HeaderText = "Дата";
            dataGridView1.Columns[5].HeaderText = "Оценка";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                var query = (from stud in db.students
                             join g in db.groups on stud.code_group equals g.code_group
                             orderby stud.code_stud
                             select new { stud.code_stud, stud.surname, stud.name, g.name_group, stud.code_group }).ToList();
                if (textBox1.Text != "")
                {
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            dataGridView1.DataSource = query.Where(p => p.code_stud.ToString() == textBox1.Text.ToString()).ToList(); break;
                        case 1:
                            dataGridView1.DataSource = query.Where(p => p.surname.ToString() == textBox1.Text.ToString()).ToList(); break;
                        case 2:
                            dataGridView1.DataSource = query.Where(p => p.name.ToString() == textBox1.Text.ToString()).ToList(); break;
                        case 3:
                            dataGridView1.DataSource = query.Where(p => p.name_group.ToString() == textBox1.Text.ToString()).ToList(); break;
                    }
                }
                else dataGridView1.DataSource = query;
                dataGridView1.Update();
                if (dataGridView1.RowCount == 0) label1.Visible = true;
                else label1.Visible = false;
            }
            else if (radioButton2.Checked)
            {
                var query = (from prog in db.progress
                             join s in db.students on prog.code_stud equals s.code_stud
                             join sub in db.subjects on prog.code_subject equals sub.code_subject
                             join l in db.lectors on prog.code_lector equals l.code_lector
                             orderby prog.code_stud
                             select new { s.surname, s.name, sub.name_subject, l.name_lector, prog.date_exam, prog.estimate }).ToList();
                if (textBox2.Text != "")
                {
                    switch (comboBox2.SelectedIndex)
                    {
                        case 0:
                            dataGridView1.DataSource = query.Where(p => p.surname.ToString() == textBox2.Text).ToList(); break;
                        case 1:
                            dataGridView1.DataSource = query.Where(p => p.name.ToString() == textBox2.Text).ToList(); break;
                        case 2:
                            dataGridView1.DataSource = query.Where(p => p.name_subject.ToString() == textBox2.Text).ToList(); break;
                        case 3:
                            dataGridView1.DataSource = query.Where(p => p.name_lector.ToString() == textBox2.Text).ToList(); break;
                        case 4:
                            dataGridView1.DataSource = query.Where(p => p.date_exam.ToString() == textBox2.Text).ToList(); break;
                        case 5:
                            dataGridView1.DataSource = query.Where(p => p.estimate.ToString() == textBox2.Text).ToList(); break;
                    }
                }
                else dataGridView1.DataSource = query;
                dataGridView1.Update();
                if (dataGridView1.RowCount == 0) label1.Visible = true;
                else label1.Visible = false;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (Application.OpenForms.Count == 1)
                {
                    FormAddStudent addSt = new FormAddStudent();
                    addSt.Owner = this;
                    addSt.Show();
                }
                else Application.OpenForms[0].Focus();
            }
            else if (radioButton2.Checked)
            {
                if (Application.OpenForms.Count == 1)
                {
                    FormAddEstimate addPr = new FormAddEstimate();
                    addPr.Owner = this;
                    addPr.Show();
                }
                else Application.OpenForms[0].Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                List<students> query = (from stud in db.students
                                        select stud).ToList();
                if (dataGridView1.SelectedCells.Count == 1)
                {
                    if (Application.OpenForms.Count == 1)
                    {
                        students item = query.First(w => w.code_stud.ToString() == dataGridView1.SelectedCells[0].OwningRow.Cells[0].Value.ToString());

                        FormEditStudent edtSt = new FormEditStudent(item);
                        edtSt.Owner = this;
                        edtSt.Show();
                    }
                    else Application.OpenForms[0].Focus();
                }
            }
            else if (radioButton2.Checked)
            {
                List<progress> query = (from prog in db.progress
                                        join stud in db.students on prog.code_stud equals stud.code_stud
                                        join sub in db.subjects on prog.code_subject equals sub.code_subject
                                        select prog).ToList();
                if (dataGridView1.SelectedCells.Count == 1)
                {
                    if (Application.OpenForms.Count == 1)
                    {
                        progress item = query.First(w => w.students.surname.ToString() == dataGridView1.SelectedCells[0].OwningRow.Cells[0].Value.ToString() && w.subjects.name_subject.ToString() == dataGridView1.SelectedCells[0].OwningRow.Cells[2].Value.ToString());

                        FormEditProgres edtPr = new FormEditProgres(item);
                        edtPr.Owner = this;
                        edtPr.Show();

                    }
                    else Application.OpenForms[0].Focus();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var query = (from stud in db.students
                         join g in db.groups on stud.code_group equals g.code_group
                         orderby stud.code_stud
                         select new { stud.code_stud, stud.surname, stud.name, g.name_group}).ToList();
            dataGridView1.DataSource = query;
            dataGridView1.Columns[0].HeaderText = "Номер студента";
            dataGridView1.Columns[1].HeaderText = "Фамилия";
            dataGridView1.Columns[2].HeaderText = "Имя";
            dataGridView1.Columns[3].HeaderText = "Номер группы";
        } 

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            var query = (from stud in db.students
                         join g in db.groups on stud.code_group equals g.code_group
                         orderby stud.code_stud
                         select new { stud.code_stud, stud.surname, stud.name, g.name_group}).ToList();
            dataGridView1.DataSource = query;
            dataGridView1.Columns[0].HeaderText = "Номер студента";
            dataGridView1.Columns[1].HeaderText = "Фамилия";
            dataGridView1.Columns[2].HeaderText = "Имя";
            dataGridView1.Columns[3].HeaderText = "Номер группы";
            textBox1.Visible = true;
            comboBox1.Visible = true;
            textBox2.Visible = false;
            comboBox2.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            var query = (from prog in db.progress
                         join s in db.students on prog.code_stud equals s.code_stud
                         join sub in db.subjects on prog.code_subject equals sub.code_subject
                         join l in db.lectors on prog.code_lector equals l.code_lector
                         orderby prog.code_stud
                         select new { s.surname, s.name, sub.name_subject,l.name_lector, prog.date_exam, prog.estimate }).ToList();
            dataGridView1.DataSource = query;
            dataGridView1.Columns[0].HeaderText = "Фамилия";
            dataGridView1.Columns[1].HeaderText = "Имя";
            dataGridView1.Columns[2].HeaderText = "Предмет";
            dataGridView1.Columns[3].HeaderText = "Преподаватель";
            dataGridView1.Columns[4].HeaderText = "Дата";
            dataGridView1.Columns[5].HeaderText = "Оценка";
            textBox1.Visible = false;
            comboBox1.Visible = false;
            textBox2.Visible = true;
            comboBox2.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                dialog.DefaultExt = ".xls";
                dialog.Filter = "Таблицы Excel (*.xls)|*.xls|Все файлы (*.*)|*.*";
                dialog.FilterIndex = 1;
                dialog.FileName = "Отчет";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var file = new FileStream(dialog.FileName, FileMode.Create, FileAccess.ReadWrite);
                    var query = (from stud in db.students
                                 join g in db.groups on stud.code_group equals g.code_group
                                 orderby stud.code_stud
                                 select new { stud.code_stud, stud.surname, stud.name, g.name_group }).ToList();
                    var template = new MemoryStream(Convert.ToInt32(Properties.Resources.template));
                    var workbook = new XSSFWorkbook(template);
                    var sheet1 = workbook.GetSheet("Лист1");

                    int row = 8;
                    foreach (var item in query.OrderBy(o => o.code_stud))
                    {
                        var rowInsert = sheet1.CreateRow(row);
                        rowInsert.CreateCell(2).SetCellValue(item.code_stud);
                        rowInsert.CreateCell(3).SetCellValue(item.surname);
                        rowInsert.CreateCell(4).SetCellValue(item.name);
                        rowInsert.CreateCell(5).SetCellValue(item.name_group);
                        row++;

                    }
                    workbook.Write(file);
                }
            }
            else if (radioButton2.Checked)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                dialog.DefaultExt = ".xls";
                dialog.Filter = "Таблицы Excel (*.xls)|*.xls|Все файлы (*.*)|*.*";
                dialog.FilterIndex = 1;
                dialog.FileName = "Отчет";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var file = new FileStream(dialog.FileName, FileMode.Create, FileAccess.ReadWrite);
                    var query = (from prog in db.progress
                                 join s in db.students on prog.code_stud equals s.code_stud
                                 join sub in db.subjects on prog.code_subject equals sub.code_subject
                                 join l in db.lectors on prog.code_lector equals l.code_lector
                                 orderby prog.code_stud
                                 select new { s.surname, s.name, sub.name_subject, prog.date_exam, prog.estimate, l.name_lector }).ToList();
                    var template = new MemoryStream(Convert.ToInt32(Properties.Resources.template2));
                    var workbook = new XSSFWorkbook(template);
                    var sheet1 = workbook.GetSheet("Лист1");

                    int row = 3;
                    foreach (var item in query.OrderBy(o => o.date_exam))
                    {
                        var rowInsert = sheet1.CreateRow(row);
                        rowInsert.CreateCell(0).SetCellValue(item.surname);
                        rowInsert.CreateCell(1).SetCellValue(item.name);
                        rowInsert.CreateCell(2).SetCellValue(item.name_subject);
                        rowInsert.CreateCell(3).SetCellValue(item.date_exam);
                        rowInsert.CreateCell(4).SetCellValue((double)item.estimate);
                        rowInsert.CreateCell(5).SetCellValue(item.name_lector);
                        row++;

                    }
                    workbook.Write(file);
                }
            }
        }
    }
}
