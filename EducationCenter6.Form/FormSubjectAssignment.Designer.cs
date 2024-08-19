using EducationCenter6.Common.Enums;
using EducationCenter6.Common.Objects;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;

namespace EducationCenter6.FormApp
{
    partial class FormSubjectAssignment
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
            components = new System.ComponentModel.Container();
            labelSubjectAssignmentForm = new Label();
            checkedListBoxPeople = new CheckedListBox();
            panel1 = new Panel();
            radioButtonStudent = new RadioButton();
            radioButtonTeacher = new RadioButton();
            comboBoxSubject1 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            comboBoxSubject2 = new ComboBox();
            buttonAssign = new Button();
            buttonPersonForm = new Button();
            dataGridView1 = new DataGridView();
            teacherSubjectDetailBindingSource1 = new BindingSource(components);
            teacherBindingSource = new BindingSource(components);
            teacherSubjectDetailBindingSource = new BindingSource(components);
            teacherSubjectDetailsBindingSource = new BindingSource(components);
            teacherSalaryDetailsBindingSource = new BindingSource(components);
            teacherSubjectDetailsBindingSource1 = new BindingSource(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)teacherSubjectDetailBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)teacherBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)teacherSubjectDetailBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)teacherSubjectDetailsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)teacherSalaryDetailsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)teacherSubjectDetailsBindingSource1).BeginInit();
            SuspendLayout();
            // 
            // labelSubjectAssignmentForm
            // 
            labelSubjectAssignmentForm.AutoSize = true;
            labelSubjectAssignmentForm.Location = new Point(390, 18);
            labelSubjectAssignmentForm.Margin = new Padding(2, 0, 2, 0);
            labelSubjectAssignmentForm.Name = "labelSubjectAssignmentForm";
            labelSubjectAssignmentForm.Size = new Size(132, 20);
            labelSubjectAssignmentForm.TabIndex = 1;
            labelSubjectAssignmentForm.Text = "Assigning Subjects";
            // 
            // checkedListBoxPeople
            // 
            checkedListBoxPeople.FormattingEnabled = true;
            checkedListBoxPeople.Location = new Point(34, 136);
            checkedListBoxPeople.Margin = new Padding(2);
            checkedListBoxPeople.Name = "checkedListBoxPeople";
            checkedListBoxPeople.Size = new Size(531, 114);
            checkedListBoxPeople.TabIndex = 2;
            checkedListBoxPeople.SelectedIndexChanged += checkedListBoxPeople_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(radioButtonStudent);
            panel1.Controls.Add(radioButtonTeacher);
            panel1.Location = new Point(34, 63);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(529, 57);
            panel1.TabIndex = 14;
            // 
            // radioButtonStudent
            // 
            radioButtonStudent.AutoSize = true;
            radioButtonStudent.Location = new Point(195, 14);
            radioButtonStudent.Margin = new Padding(2);
            radioButtonStudent.Name = "radioButtonStudent";
            radioButtonStudent.Size = new Size(81, 24);
            radioButtonStudent.TabIndex = 1;
            radioButtonStudent.Text = "Student";
            radioButtonStudent.UseVisualStyleBackColor = true;
            // 
            // radioButtonTeacher
            // 
            radioButtonTeacher.AutoSize = true;
            radioButtonTeacher.Checked = true;
            radioButtonTeacher.Location = new Point(25, 14);
            radioButtonTeacher.Margin = new Padding(2);
            radioButtonTeacher.Name = "radioButtonTeacher";
            radioButtonTeacher.Size = new Size(81, 24);
            radioButtonTeacher.TabIndex = 0;
            radioButtonTeacher.TabStop = true;
            radioButtonTeacher.Text = "Teacher";
            radioButtonTeacher.UseVisualStyleBackColor = true;
            // 
            // comboBoxSubject1
            // 
            comboBoxSubject1.FormattingEnabled = true;
            comboBoxSubject1.Location = new Point(587, 70);
            comboBoxSubject1.Margin = new Padding(2);
            comboBoxSubject1.Name = "comboBoxSubject1";
            comboBoxSubject1.Size = new Size(150, 28);
            comboBoxSubject1.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(616, 34);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(70, 20);
            label1.TabIndex = 16;
            label1.Text = "Subject 1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(784, 34);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 18;
            label2.Text = "Subject 2";
            // 
            // comboBoxSubject2
            // 
            comboBoxSubject2.FormattingEnabled = true;
            comboBoxSubject2.Location = new Point(755, 70);
            comboBoxSubject2.Margin = new Padding(2);
            comboBoxSubject2.Name = "comboBoxSubject2";
            comboBoxSubject2.Size = new Size(150, 28);
            comboBoxSubject2.TabIndex = 17;
            // 
            // buttonAssign
            // 
            buttonAssign.Location = new Point(587, 136);
            buttonAssign.Margin = new Padding(2);
            buttonAssign.Name = "buttonAssign";
            buttonAssign.Size = new Size(318, 29);
            buttonAssign.TabIndex = 19;
            buttonAssign.Text = "Assign";
            buttonAssign.UseVisualStyleBackColor = true;
            buttonAssign.Click += buttonAssign_Click;
            // 
            // buttonPersonForm
            // 
            buttonPersonForm.Location = new Point(34, 9);
            buttonPersonForm.Margin = new Padding(2);
            buttonPersonForm.Name = "buttonPersonForm";
            buttonPersonForm.Size = new Size(92, 29);
            buttonPersonForm.TabIndex = 20;
            buttonPersonForm.Text = "Person Form";
            buttonPersonForm.UseVisualStyleBackColor = true;
            buttonPersonForm.Click += buttonPersonForm_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(34, 255);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(871, 154);
            dataGridView1.TabIndex = 21;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // teacherSubjectDetailBindingSource1
            // 
            teacherSubjectDetailBindingSource1.DataSource = typeof(Infrastructure.Entities.TeacherSubjectDetail);
            // 
            // teacherBindingSource
            // 
            teacherBindingSource.DataSource = typeof(Infrastructure.Entities.Teacher);
            // 
            // teacherSubjectDetailBindingSource
            // 
            teacherSubjectDetailBindingSource.DataSource = typeof(Infrastructure.Entities.TeacherSubjectDetail);
            // 
            // teacherSubjectDetailsBindingSource
            // 
            teacherSubjectDetailsBindingSource.DataMember = "TeacherSubjectDetails";
            teacherSubjectDetailsBindingSource.DataSource = teacherBindingSource;
            // 
            // teacherSalaryDetailsBindingSource
            // 
            teacherSalaryDetailsBindingSource.DataMember = "TeacherSalaryDetails";
            teacherSalaryDetailsBindingSource.DataSource = teacherBindingSource;
            // 
            // teacherSubjectDetailsBindingSource1
            // 
            teacherSubjectDetailsBindingSource1.DataMember = "TeacherSubjectDetails";
            teacherSubjectDetailsBindingSource1.DataSource = teacherBindingSource;
            // 
            // FormSubjectAssignment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(940, 432);
            Controls.Add(dataGridView1);
            Controls.Add(buttonPersonForm);
            Controls.Add(buttonAssign);
            Controls.Add(label2);
            Controls.Add(comboBoxSubject2);
            Controls.Add(label1);
            Controls.Add(comboBoxSubject1);
            Controls.Add(panel1);
            Controls.Add(checkedListBoxPeople);
            Controls.Add(labelSubjectAssignmentForm);
            Margin = new Padding(2);
            Name = "FormSubjectAssignment";
            Text = "FormSubjectAssignment";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)teacherSubjectDetailBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)teacherBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)teacherSubjectDetailBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)teacherSubjectDetailsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)teacherSalaryDetailsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)teacherSubjectDetailsBindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        /// <summary>
        /// Hàm khởi tạo CheckBoxList kiểu cũ (for reference only)
        /// </summary>
        private void InitializeCheckedBoxList()
        {
            checkedListBoxPeople.Items.Clear();

            if (_role == RoleEnum.Teacher)
            {
                var listPeople = _context.Teachers
                    .Select(t => new BaseObject
                    {
                        Text = t.FullName,
                        Value = t.Id
                    })
                    .ToArray();
                //var listPeople = _context.Teachers.ToArray();
                checkedListBoxPeople.Items.AddRange(listPeople);
                //checkedListBoxPeople.DisplayMember = "FullName";

                //checkedListBoxPeople.
            }
            else if (_role == RoleEnum.Student)
            {
                var listPeople = _context.Students
                    .Select(t => new BaseObject
                    {
                        Text = t.FullName,
                        Value = t.Id
                    })
                    .ToArray();
                checkedListBoxPeople.Items.AddRange(listPeople);

            }
            //=== Không cần xử lý phần Admin
            //else if (_role == RoleEnum.Admin)
            //{
            //    var listPeople = _context.Administrators
            //        .Select(t => new BaseObject
            //        {
            //            Text = t.FullName,
            //            Value = t.Id
            //        })
            //        .ToArray();
            //    checkedListBoxPeople.Items.AddRange(listPeople);

            //}
            checkedListBoxPeople.DisplayMember = "Text";

        }

        //private void InitializeCheckedBoxList_V2()
        private void InitializeCheckedBoxList_V2()
        {
            checkedListBoxPeople.Items.Clear();
            checkedListBoxPeople.DisplayMember = "Text";
            switch (_role)
            {
                case RoleEnum.Teacher:
                    var listTeacher = _context.Teachers
                    .Select(t => new BaseObject
                    {
                        Text = t.FullName,
                        Value = t.Id
                    })
                    .ToArray();
                    checkedListBoxPeople.Items.AddRange(listTeacher);
                    break;
                case RoleEnum.Student:
                    var listStudent = _context.Students
                    .Select(t => new BaseObject
                    {
                        Text = t.FullName,
                        Value = t.Id
                    })
                    .ToArray();
                    checkedListBoxPeople.Items.AddRange(listStudent);
                    break;
                case RoleEnum.Admin:
                    //=== Không làm gì cả (Vì đã xóa rồi) ===//
                    break;
                default:
                    break;
            }
            

        }
        private void OnCheckChanged()
        {
            //=== EventHandler, Arrow Function với Sender và Arguement ===//
            //radioButtonAdmin.CheckedChanged += new System.EventHandler((sender, e) => ShowPeopleByRole(sender, e, RoleEnum.Admin));
            radioButtonTeacher.CheckedChanged += (sender, e) => ShowPeopleByRole(sender, e, RoleEnum.Teacher);
            radioButtonStudent.CheckedChanged += (sender, e) => ShowPeopleByRole(sender, e, RoleEnum.Student);

        }
        #endregion

        private void ShowPeopleByRole(object sender, EventArgs e, RoleEnum role)
        {
            _role = role;
            InitializeCheckedBoxList();
        }
        private Label labelSubjectAssignmentForm;
        private CheckedListBox checkedListBoxPeople;
        private Panel panel1;
        private RadioButton radioButtonStudent;
        private RadioButton radioButtonTeacher;
        private ComboBox comboBoxSubject1;
        private Label label1;
        private Label label2;
        private ComboBox comboBoxSubject2;
        private Button buttonAssign;
        private Button buttonPersonForm;
        private DataGridView dataGridView1;
        private BindingSource teacherSubjectDetailsBindingSource1;
        private BindingSource teacherBindingSource;
        private BindingSource teacherSubjectDetailBindingSource;
        private BindingSource teacherSubjectDetailsBindingSource;
        private BindingSource teacherSalaryDetailsBindingSource;
        private BindingSource teacherSubjectDetailBindingSource1;
    }
}