using EducationCenter6.Common.Enums;
using EducationCenter6.Infrastructure;

namespace EducationCenter6.FormApp
{
    partial class FormTeacher
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            labelForm = new Label();
            labelFullName = new Label();
            textBoxFullName = new TextBox();
            label1 = new Label();
            datePickerDateOfBirth = new DateTimePicker();
            labelPhone = new Label();
            textBoxPhone = new TextBox();
            textBoxEmail = new TextBox();
            labelEmail = new Label();
            buttonSubmit = new Button();
            labelRole = new Label();
            comboBoxRole = new ComboBox();
            dataGridViewList = new DataGridView();
            teacherBindingSource = new BindingSource(components);
            panel1 = new Panel();
            radioButtonAdmin = new RadioButton();
            radioButtonStudent = new RadioButton();
            radioButtonTeacher = new RadioButton();
            buttonSubjectDetails = new Button();
            buttonSalaryDetails = new Button();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fullNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            phoneDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dateOfBirthDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            roleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            positionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ageDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ColumnEdit = new DataGridViewButtonColumn();
            Delete = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridViewList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)teacherBindingSource).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // labelForm
            // 
            labelForm.AutoSize = true;
            labelForm.Location = new Point(183, 21);
            labelForm.Margin = new Padding(2, 0, 2, 0);
            labelForm.Name = "labelForm";
            labelForm.Size = new Size(98, 20);
            labelForm.TabIndex = 0;
            labelForm.Text = "Teacher Form";
            // 
            // labelFullName
            // 
            labelFullName.AutoSize = true;
            labelFullName.Location = new Point(28, 69);
            labelFullName.Margin = new Padding(2, 0, 2, 0);
            labelFullName.Name = "labelFullName";
            labelFullName.Size = new Size(76, 20);
            labelFullName.TabIndex = 1;
            labelFullName.Text = "Full Name";
            // 
            // textBoxFullName
            // 
            textBoxFullName.Location = new Point(183, 69);
            textBoxFullName.Margin = new Padding(2);
            textBoxFullName.Name = "textBoxFullName";
            textBoxFullName.Size = new Size(326, 27);
            textBoxFullName.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 118);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(94, 20);
            label1.TabIndex = 3;
            label1.Text = "Date of Birth";
            // 
            // datePickerDateOfBirth
            // 
            datePickerDateOfBirth.Location = new Point(183, 118);
            datePickerDateOfBirth.Margin = new Padding(2);
            datePickerDateOfBirth.Name = "datePickerDateOfBirth";
            datePickerDateOfBirth.Size = new Size(326, 27);
            datePickerDateOfBirth.TabIndex = 4;
            // 
            // labelPhone
            // 
            labelPhone.AutoSize = true;
            labelPhone.Location = new Point(34, 166);
            labelPhone.Margin = new Padding(2, 0, 2, 0);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(50, 20);
            labelPhone.TabIndex = 5;
            labelPhone.Text = "Phone";
            // 
            // textBoxPhone
            // 
            textBoxPhone.Location = new Point(183, 166);
            textBoxPhone.Margin = new Padding(2);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(326, 27);
            textBoxPhone.TabIndex = 6;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(183, 215);
            textBoxEmail.Margin = new Padding(2);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(326, 27);
            textBoxEmail.TabIndex = 8;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(34, 215);
            labelEmail.Margin = new Padding(2, 0, 2, 0);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(46, 20);
            labelEmail.TabIndex = 7;
            labelEmail.Text = "Email";
            // 
            // buttonSubmit
            // 
            buttonSubmit.Location = new Point(281, 352);
            buttonSubmit.Margin = new Padding(2);
            buttonSubmit.Name = "buttonSubmit";
            buttonSubmit.Size = new Size(92, 29);
            buttonSubmit.TabIndex = 9;
            buttonSubmit.Text = "Submit";
            buttonSubmit.UseVisualStyleBackColor = true;
            buttonSubmit.Click += buttonSubmit_Click;
            // 
            // labelRole
            // 
            labelRole.AutoSize = true;
            labelRole.Location = new Point(34, 268);
            labelRole.Margin = new Padding(2, 0, 2, 0);
            labelRole.Name = "labelRole";
            labelRole.Size = new Size(39, 20);
            labelRole.TabIndex = 10;
            labelRole.Text = "Role";
            // 
            // comboBoxRole
            // 
            comboBoxRole.FormattingEnabled = true;
            comboBoxRole.Location = new Point(183, 262);
            comboBoxRole.Margin = new Padding(2);
            comboBoxRole.Name = "comboBoxRole";
            comboBoxRole.Size = new Size(326, 28);
            comboBoxRole.TabIndex = 11;
            // 
            // dataGridViewList
            // 
            dataGridViewList.AutoGenerateColumns = false;
            dataGridViewList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewList.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, fullNameDataGridViewTextBoxColumn, phoneDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, dateOfBirthDataGridViewTextBoxColumn, roleDataGridViewTextBoxColumn, positionDataGridViewTextBoxColumn, ageDataGridViewTextBoxColumn, ColumnEdit, Delete });
            dataGridViewList.DataSource = teacherBindingSource;
            dataGridViewList.Location = new Point(543, 74);
            dataGridViewList.Margin = new Padding(2);
            dataGridViewList.Name = "dataGridViewList";
            dataGridViewList.RowHeadersWidth = 82;
            dataGridViewList.Size = new Size(529, 378);
            dataGridViewList.TabIndex = 12;
            // 
            // teacherBindingSource
            // 
            teacherBindingSource.DataSource = typeof(Infrastructure.Entities.Teacher);
            // 
            // panel1
            // 
            panel1.Controls.Add(radioButtonAdmin);
            panel1.Controls.Add(radioButtonStudent);
            panel1.Controls.Add(radioButtonTeacher);
            panel1.Location = new Point(543, 13);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(529, 57);
            panel1.TabIndex = 13;
            // 
            // radioButtonAdmin
            // 
            radioButtonAdmin.AutoSize = true;
            radioButtonAdmin.Location = new Point(369, 14);
            radioButtonAdmin.Margin = new Padding(2);
            radioButtonAdmin.Name = "radioButtonAdmin";
            radioButtonAdmin.Size = new Size(74, 24);
            radioButtonAdmin.TabIndex = 2;
            radioButtonAdmin.Text = "Admin";
            radioButtonAdmin.UseVisualStyleBackColor = true;
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
            // buttonSubjectDetails
            // 
            buttonSubjectDetails.Location = new Point(11, 423);
            buttonSubjectDetails.Margin = new Padding(2);
            buttonSubjectDetails.Name = "buttonSubjectDetails";
            buttonSubjectDetails.Size = new Size(92, 29);
            buttonSubjectDetails.TabIndex = 14;
            buttonSubjectDetails.Text = "Subject Details";
            buttonSubjectDetails.UseVisualStyleBackColor = true;
            buttonSubjectDetails.Click += buttonSubjectDetails_Click;
            // 
            // buttonSalaryDetails
            // 
            buttonSalaryDetails.Location = new Point(118, 423);
            buttonSalaryDetails.Name = "buttonSalaryDetails";
            buttonSalaryDetails.Size = new Size(94, 29);
            buttonSalaryDetails.TabIndex = 15;
            buttonSalaryDetails.Text = "Salary";
            buttonSalaryDetails.UseVisualStyleBackColor = true;
            buttonSalaryDetails.Click += buttonSalaryDetails_Click;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.MinimumWidth = 10;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.Width = 200;
            // 
            // fullNameDataGridViewTextBoxColumn
            // 
            fullNameDataGridViewTextBoxColumn.DataPropertyName = "FullName";
            fullNameDataGridViewTextBoxColumn.HeaderText = "FullName";
            fullNameDataGridViewTextBoxColumn.MinimumWidth = 10;
            fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
            fullNameDataGridViewTextBoxColumn.Width = 200;
            // 
            // phoneDataGridViewTextBoxColumn
            // 
            phoneDataGridViewTextBoxColumn.DataPropertyName = "Phone";
            phoneDataGridViewTextBoxColumn.HeaderText = "Phone";
            phoneDataGridViewTextBoxColumn.MinimumWidth = 10;
            phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
            phoneDataGridViewTextBoxColumn.Width = 200;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.HeaderText = "Email";
            emailDataGridViewTextBoxColumn.MinimumWidth = 10;
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            emailDataGridViewTextBoxColumn.Width = 200;
            // 
            // dateOfBirthDataGridViewTextBoxColumn
            // 
            dateOfBirthDataGridViewTextBoxColumn.DataPropertyName = "DateOfBirth";
            dateOfBirthDataGridViewTextBoxColumn.HeaderText = "DateOfBirth";
            dateOfBirthDataGridViewTextBoxColumn.MinimumWidth = 10;
            dateOfBirthDataGridViewTextBoxColumn.Name = "dateOfBirthDataGridViewTextBoxColumn";
            dateOfBirthDataGridViewTextBoxColumn.Width = 200;
            // 
            // roleDataGridViewTextBoxColumn
            // 
            roleDataGridViewTextBoxColumn.DataPropertyName = "Role";
            roleDataGridViewTextBoxColumn.HeaderText = "Role";
            roleDataGridViewTextBoxColumn.MinimumWidth = 10;
            roleDataGridViewTextBoxColumn.Name = "roleDataGridViewTextBoxColumn";
            roleDataGridViewTextBoxColumn.Width = 200;
            // 
            // positionDataGridViewTextBoxColumn
            // 
            positionDataGridViewTextBoxColumn.DataPropertyName = "Position";
            positionDataGridViewTextBoxColumn.HeaderText = "Position";
            positionDataGridViewTextBoxColumn.MinimumWidth = 10;
            positionDataGridViewTextBoxColumn.Name = "positionDataGridViewTextBoxColumn";
            positionDataGridViewTextBoxColumn.Width = 200;
            // 
            // ageDataGridViewTextBoxColumn
            // 
            ageDataGridViewTextBoxColumn.DataPropertyName = "Age";
            ageDataGridViewTextBoxColumn.HeaderText = "Age";
            ageDataGridViewTextBoxColumn.MinimumWidth = 10;
            ageDataGridViewTextBoxColumn.Name = "ageDataGridViewTextBoxColumn";
            ageDataGridViewTextBoxColumn.Width = 200;
            // 
            // ColumnEdit
            // 
            ColumnEdit.HeaderText = "Edit";
            ColumnEdit.MinimumWidth = 10;
            ColumnEdit.Name = "ColumnEdit";
            ColumnEdit.Text = "Edit";
            ColumnEdit.UseColumnTextForButtonValue = true;
            ColumnEdit.Width = 200;
            // 
            // Delete
            // 
            Delete.HeaderText = "Delete";
            Delete.MinimumWidth = 6;
            Delete.Name = "Delete";
            Delete.Resizable = DataGridViewTriState.True;
            Delete.SortMode = DataGridViewColumnSortMode.Automatic;
            Delete.Text = "Delete";
            Delete.UseColumnTextForButtonValue = true;
            Delete.Width = 125;
            // 
            // FormTeacher
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1080, 459);
            Controls.Add(buttonSalaryDetails);
            Controls.Add(buttonSubjectDetails);
            Controls.Add(panel1);
            Controls.Add(dataGridViewList);
            Controls.Add(comboBoxRole);
            Controls.Add(labelRole);
            Controls.Add(buttonSubmit);
            Controls.Add(textBoxEmail);
            Controls.Add(labelEmail);
            Controls.Add(textBoxPhone);
            Controls.Add(labelPhone);
            Controls.Add(datePickerDateOfBirth);
            Controls.Add(label1);
            Controls.Add(textBoxFullName);
            Controls.Add(labelFullName);
            Controls.Add(labelForm);
            Margin = new Padding(2);
            Name = "FormTeacher";
            Text = "Form1";
            Load += FormTeacher_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewList).EndInit();
            ((System.ComponentModel.ISupportInitialize)teacherBindingSource).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }






        #endregion

        private Label labelForm;
        private Label labelFullName;
        private TextBox textBoxFullName;
        private Label label1;
        private DateTimePicker datePickerDateOfBirth;
        private Label labelPhone;
        private TextBox textBoxPhone;
        private TextBox textBoxEmail;
        private Label labelEmail;
        private Button buttonSubmit;
        private Label labelRole;
        private ComboBox comboBoxRole;
        private DataGridView dataGridViewList;
        private BindingSource teacherBindingSource;
        private Panel panel1;
        private RadioButton radioButtonAdmin;
        private RadioButton radioButtonStudent;
        private RadioButton radioButtonTeacher;
        private Button buttonSubjectDetails;
        private Button buttonSalaryDetails;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dateOfBirthDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn roleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn positionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ageDataGridViewTextBoxColumn;
        private DataGridViewButtonColumn ColumnEdit;
        private DataGridViewButtonColumn Delete;
    }
}
