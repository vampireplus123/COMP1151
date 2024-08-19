namespace EducationCenter6.FormApp
{
    partial class FormSalary
    {
        private System.ComponentModel.IContainer components = null;

        // UI controls declared at the class level
        private Label labelSalaryLevel;
        private TextBox textBoxSalaryLevel;
        private TextBox textBoxCoefficient;
        private Label labelCoefficient;
        private TextBox textBoxUnitSalary;
        private Label labelUnitxSalary;
        private Button buttonSalarySubmit;
        private DataGridView dataGridView1;
        private Label labelJobType;
        private ComboBox comboBoxJobType;
        private RadioButton radioButtonTeacher;
        private RadioButton radioButtonAdmin;
        private ComboBox comboBoxEmployee;
        private Label labelEmployee;
        private Label labelForm;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            labelSalaryLevel = new Label();
            textBoxSalaryLevel = new TextBox();
            textBoxCoefficient = new TextBox();
            labelCoefficient = new Label();
            textBoxUnitSalary = new TextBox();
            labelUnitxSalary = new Label();
            buttonSalarySubmit = new Button();
            dataGridView1 = new DataGridView();
            labelJobType = new Label();
            comboBoxJobType = new ComboBox();
            radioButtonTeacher = new RadioButton();
            radioButtonAdmin = new RadioButton();
            comboBoxEmployee = new ComboBox();
            labelEmployee = new Label();
            labelForm = new Label();
            buttonPersonForm = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // labelSalaryLevel
            // 
            labelSalaryLevel.AutoSize = true;
            labelSalaryLevel.Location = new Point(35, 72);
            labelSalaryLevel.Name = "labelSalaryLevel";
            labelSalaryLevel.Size = new Size(87, 20);
            labelSalaryLevel.TabIndex = 0;
            labelSalaryLevel.Text = "Salary Level";
            // 
            // textBoxSalaryLevel
            // 
            textBoxSalaryLevel.Location = new Point(128, 69);
            textBoxSalaryLevel.Name = "textBoxSalaryLevel";
            textBoxSalaryLevel.Size = new Size(229, 27);
            textBoxSalaryLevel.TabIndex = 1;
            // 
            // textBoxCoefficient
            // 
            textBoxCoefficient.Location = new Point(128, 125);
            textBoxCoefficient.Name = "textBoxCoefficient";
            textBoxCoefficient.Size = new Size(229, 27);
            textBoxCoefficient.TabIndex = 3;
            // 
            // labelCoefficient
            // 
            labelCoefficient.AutoSize = true;
            labelCoefficient.Location = new Point(35, 128);
            labelCoefficient.Name = "labelCoefficient";
            labelCoefficient.Size = new Size(81, 20);
            labelCoefficient.TabIndex = 2;
            labelCoefficient.Text = "Coefficient";
            // 
            // textBoxUnitSalary
            // 
            textBoxUnitSalary.Location = new Point(128, 184);
            textBoxUnitSalary.Name = "textBoxUnitSalary";
            textBoxUnitSalary.Size = new Size(229, 27);
            textBoxUnitSalary.TabIndex = 5;
            // 
            // labelUnitxSalary
            // 
            labelUnitxSalary.AutoSize = true;
            labelUnitxSalary.Location = new Point(35, 187);
            labelUnitxSalary.Name = "labelUnitxSalary";
            labelUnitxSalary.Size = new Size(80, 20);
            labelUnitxSalary.TabIndex = 4;
            labelUnitxSalary.Text = "Unit Salary";
            // 
            // buttonSalarySubmit
            // 
            buttonSalarySubmit.Location = new Point(396, 277);
            buttonSalarySubmit.Name = "buttonSalarySubmit";
            buttonSalarySubmit.Size = new Size(843, 48);
            buttonSalarySubmit.TabIndex = 6;
            buttonSalarySubmit.Text = "Submit";
            buttonSalarySubmit.UseVisualStyleBackColor = true;
            buttonSalarySubmit.Click += buttonSalarySubmit_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(396, 69);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(843, 197);
            dataGridView1.TabIndex = 7;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // labelJobType
            // 
            labelJobType.AutoSize = true;
            labelJobType.Location = new Point(35, 305);
            labelJobType.Name = "labelJobType";
            labelJobType.Size = new Size(67, 20);
            labelJobType.TabIndex = 8;
            labelJobType.Text = "Job Type";
            // 
            // comboBoxJobType
            // 
            comboBoxJobType.FormattingEnabled = true;
            comboBoxJobType.Location = new Point(128, 302);
            comboBoxJobType.Name = "comboBoxJobType";
            comboBoxJobType.Size = new Size(229, 28);
            comboBoxJobType.TabIndex = 9;
            // 
            // radioButtonTeacher
            // 
            radioButtonTeacher.AutoSize = true;
            radioButtonTeacher.Location = new Point(35, 362);
            radioButtonTeacher.Name = "radioButtonTeacher";
            radioButtonTeacher.Size = new Size(81, 24);
            radioButtonTeacher.TabIndex = 10;
            radioButtonTeacher.TabStop = true;
            radioButtonTeacher.Text = "Teacher";
            radioButtonTeacher.UseVisualStyleBackColor = true;
            // 
            // radioButtonAdmin
            // 
            radioButtonAdmin.AutoSize = true;
            radioButtonAdmin.Location = new Point(183, 362);
            radioButtonAdmin.Name = "radioButtonAdmin";
            radioButtonAdmin.Size = new Size(74, 24);
            radioButtonAdmin.TabIndex = 11;
            radioButtonAdmin.TabStop = true;
            radioButtonAdmin.Text = "Admin";
            radioButtonAdmin.UseVisualStyleBackColor = true;
            // 
            // comboBoxEmployee
            // 
            comboBoxEmployee.FormattingEnabled = true;
            comboBoxEmployee.Location = new Point(128, 243);
            comboBoxEmployee.Name = "comboBoxEmployee";
            comboBoxEmployee.Size = new Size(229, 28);
            comboBoxEmployee.TabIndex = 13;
            // 
            // labelEmployee
            // 
            labelEmployee.AutoSize = true;
            labelEmployee.Location = new Point(35, 246);
            labelEmployee.Name = "labelEmployee";
            labelEmployee.Size = new Size(75, 20);
            labelEmployee.TabIndex = 12;
            labelEmployee.Text = "Employee";
            // 
            // labelForm
            // 
            labelForm.AutoSize = true;
            labelForm.Location = new Point(85, 32);
            labelForm.Name = "labelForm";
            labelForm.Size = new Size(0, 20);
            labelForm.TabIndex = 14;
            // 
            // buttonPersonForm
            // 
            buttonPersonForm.Location = new Point(35, 410);
            buttonPersonForm.Margin = new Padding(2);
            buttonPersonForm.Name = "buttonPersonForm";
            buttonPersonForm.Size = new Size(92, 29);
            buttonPersonForm.TabIndex = 21;
            buttonPersonForm.Text = "Person Form";
            buttonPersonForm.UseVisualStyleBackColor = true;
            buttonPersonForm.Click += buttonPersonForm_Click;
            // 
            // FormSalary
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1352, 450);
            Controls.Add(buttonPersonForm);
            Controls.Add(labelForm);
            Controls.Add(comboBoxEmployee);
            Controls.Add(labelEmployee);
            Controls.Add(radioButtonAdmin);
            Controls.Add(radioButtonTeacher);
            Controls.Add(comboBoxJobType);
            Controls.Add(labelJobType);
            Controls.Add(dataGridView1);
            Controls.Add(buttonSalarySubmit);
            Controls.Add(textBoxUnitSalary);
            Controls.Add(labelUnitxSalary);
            Controls.Add(textBoxCoefficient);
            Controls.Add(labelCoefficient);
            Controls.Add(textBoxSalaryLevel);
            Controls.Add(labelSalaryLevel);
            Name = "FormSalary";
            Text = "FormSalary";
            Load += FormSalary_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button buttonPerson;
        private Button buttonPersonForm;
    }
}
