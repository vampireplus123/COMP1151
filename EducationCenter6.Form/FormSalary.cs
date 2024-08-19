using EducationCenter6.Common.Enums;
using EducationCenter6.Infrastructure;
using EducationCenter6.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace EducationCenter6.FormApp
{
    public partial class FormSalary : Form
    {
        private readonly EducationCenterDbContext _context;
        private int idSalary;
        private Salary _salary = null;
        private RoleEnum _role;

        public FormSalary(EducationCenterDbContext context)
        {
            _context = context;
            _role = RoleEnum.Teacher; // Default role
            InitializeComponent();
            InitializeComboBox();
            InitializeDataGridView();
            OnCheckChanged();
            InitializeEditButtonColumn();
            InitializeDeleteButtonColumn();
        }

        private void InitializeComboBox()
        {
            comboBoxJobType.DataSource = Enum.GetValues(typeof(JobTypeEnum));
            comboBoxJobType.SelectedIndex = 0; // Default selection
        }

        private void InitializeDataGridView()
        {
            //ConfigureDataGridViewColumns();
            UpdateDataGridView(); // Initial population
        }

        /*private void ConfigureDataGridViewColumns()
        {
            // Clear existing columns
            dataGridView1.Columns.Clear();

            // Add FullName column
            var fullNameColumn = new DataGridViewTextBoxColumn
            {
                Name = "FullName",
                HeaderText = "Full Name",
                DataPropertyName = "FullName",
                ReadOnly = true
            };
            dataGridView1.Columns.Add(fullNameColumn);

            // Add Level column
            var levelColumn = new DataGridViewTextBoxColumn
            {
                Name = "Level",
                HeaderText = "Level",
                DataPropertyName = "Level",
                ReadOnly = true
            };
            dataGridView1.Columns.Add(levelColumn);

            // Add Coefficient column
            var coefficientColumn = new DataGridViewTextBoxColumn
            {
                Name = "Coefficient",
                HeaderText = "Coefficient",
                DataPropertyName = "Coefficient",
                ReadOnly = true
            };
            dataGridView1.Columns.Add(coefficientColumn);

            // Add UnitSalary column
            var unitSalaryColumn = new DataGridViewTextBoxColumn
            {
                Name = "UnitSalary",
                HeaderText = "Unit Salary",
                DataPropertyName = "UnitSalary",
                ReadOnly = true
            };
            dataGridView1.Columns.Add(unitSalaryColumn);

            // Add Position column
            var positionColumn = new DataGridViewTextBoxColumn
            {
                Name = "Position",
                HeaderText = "Position",
                DataPropertyName = "Position",
                ReadOnly = true
            };
            dataGridView1.Columns.Add(positionColumn);

            // Add JobType column
            var jobTypeColumn = new DataGridViewTextBoxColumn
            {
                Name = "JobType",
                HeaderText = "Job Type",
                DataPropertyName = "JobType",
                ReadOnly = true
            };
            dataGridView1.Columns.Add(jobTypeColumn);

            // Initialize the Edit button column
            InitializeEditButtonColumn();

            InitializeDeleteButtonColumn();
        }*/

        private void UpdateDataGridView()
        {
            if (_role == RoleEnum.Teacher)
            {
                var teacherData = _context.TeacherSalaryDetails
                    .Include(tsd => tsd.Teacher)
                    .Include(tsd => tsd.Salary)
                    .Select(tsd => new
                    {
                        Id = tsd.Salary.Id,
                        FullName = tsd.Teacher.FullName,
                        Level = tsd.Salary.Level,
                        Coefficient = tsd.Salary.Coefficient,
                        UnitSalary = tsd.Salary.UnitSalary,
                        Position = tsd.Position,
                        JobType = tsd.Salary.Type.ToString()
                    })
                    .ToList();
                dataGridView1.DataSource = teacherData;
            }
            else if (_role == RoleEnum.Admin)
            {
                var adminData = _context.AdministratorSalaryDetails
                    .Include(asd => asd.Administrator)
                    .Include(asd => asd.Salary)
                    .Select(asd => new
                    {
                        FullName = asd.Administrator.FullName,
                        Level = asd.Salary.Level,
                        Coefficient = asd.Salary.Coefficient,
                        UnitSalary = asd.Salary.UnitSalary,
                        Position = asd.Position,
                        JobType = asd.Salary.Type.ToString(),
                        Edit = "Edit",
                        Delete = "Delete",
                    })
                    .ToList();
                dataGridView1.DataSource = adminData;
            }
        }

        private void buttonSalarySubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var level = int.Parse(textBoxSalaryLevel.Text.Trim());
                var coefficient = float.Parse(textBoxCoefficient.Text.Trim());
                var unitSalary = double.Parse(textBoxUnitSalary.Text.Trim());
                var jobType = (JobTypeEnum)comboBoxJobType.SelectedItem;
                var selectedEmployeeId = (int)comboBoxEmployee.SelectedValue;

                var salary = new Salary
                {
                    Level = level,
                    Coefficient = coefficient,
                    UnitSalary = unitSalary,
                    Type = jobType,
                };

                _context.Salaries.Add(salary);
                _context.SaveChanges();

                if (radioButtonTeacher.Checked)
                {
                    SaveTeacherSalaryDatabase(salary.Id, selectedEmployeeId);
                }
                else if (radioButtonAdmin.Checked)
                {
                    SaveAdminSalaryDatabase(salary.Id, selectedEmployeeId);
                }

                MessageBox.Show("Salary added successfully");
                ResetForm();
                UpdateDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


        private void buttonSalaryUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (_salary != null)
                {
                    _salary.Level = int.Parse(textBoxSalaryLevel.Text.Trim());
                    _salary.Coefficient = float.Parse(textBoxCoefficient.Text.Trim());
                    _salary.UnitSalary = double.Parse(textBoxUnitSalary.Text.Trim());
                    _salary.Type = (JobTypeEnum)comboBoxJobType.SelectedItem;

                    _context.Salaries.Update(_salary);
                    _context.SaveChanges();

                    MessageBox.Show("Salary updated successfully");
                    ResetForm();
                    UpdateDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void SaveTeacherSalaryDatabase(int salaryId, int teacherId)
        {
            var teacherSalaryDetail = new TeacherSalaryDetail
            {
                TeacherId = teacherId,
                SalaryId = salaryId,
                StartTime = DateTime.Now,
                Position = _context.Teachers.Find(teacherId)?.Position
            };
            _context.TeacherSalaryDetails.Add(teacherSalaryDetail);
            _context.SaveChanges();
        }

        private void SaveAdminSalaryDatabase(int salaryId, int adminId)
        {
            var adminSalaryDetail = new AdministratorSalaryDetail
            {
                AdministratorId = adminId,
                SalaryId = salaryId,
                StartTime = DateTime.Now,
                Position = _context.Administrators.Find(adminId)?.Position
            };
            _context.AdministratorSalaryDetails.Add(adminSalaryDetail);
            _context.SaveChanges();
        }


        private void ResetForm()
        {
            textBoxSalaryLevel.Clear();
            textBoxCoefficient.Clear();
            textBoxUnitSalary.Clear();
            comboBoxJobType.SelectedIndex = 0;
            radioButtonTeacher.Checked = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Ensure the click is not on a header or out of bounds
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Get the clicked row and the column name
                    var clickedColumn = dataGridView1.Columns[e.ColumnIndex];
                    var clickedRow = dataGridView1.Rows[e.RowIndex];

                    // Check if Edit button was clicked
                    if (clickedColumn.HeaderText == "Edit" && clickedColumn is DataGridViewButtonColumn)
                    {
                        // Assuming ID column is the first column, you can adjust the index accordingly
                        var id = Convert.ToInt32(clickedRow.Cells["ID"].Value); // Replace "ID" with your actual ID column name

                        _salary = _context.Salaries.Find(id);

                        if (_salary != null)
                        {
                            textBoxSalaryLevel.Text = _salary.Level.ToString();
                            textBoxCoefficient.Text = _salary.Coefficient.ToString();
                            textBoxUnitSalary.Text = _salary.UnitSalary.ToString();
                            comboBoxJobType.SelectedItem = _salary.Type;

                            buttonSalarySubmit.Click -= buttonSalarySubmit_Click;
                            buttonSalarySubmit.Click += buttonSalaryUpdate_Click;
                        }
                    }
                    // Check if Delete button was clicked
                    else if (clickedColumn.HeaderText == "Delete" && clickedColumn is DataGridViewButtonColumn)
                    {
                        var id = Convert.ToInt32(clickedRow.Cells["ID"].Value); // Replace "ID" with your actual ID column name
                        var salaryToDelete = _context.Salaries.Find(id);

                        if (salaryToDelete != null)
                        {
                            _context.Salaries.Remove(salaryToDelete);
                            _context.SaveChanges();
                            MessageBox.Show("Salary record deleted successfully");
                            UpdateDataGridView();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


        private void OnCheckChanged()
        {
            radioButtonTeacher.CheckedChanged += (sender, e) =>
            {
                ShowDataByRole(sender, e, RoleEnum.Teacher);
                UpdateEmployeeComboBox(RoleEnum.Teacher); // Update ComboBox for Teachers
            };

            radioButtonAdmin.CheckedChanged += (sender, e) =>
            {
                ShowDataByRole(sender, e, RoleEnum.Admin);
                UpdateEmployeeComboBox(RoleEnum.Admin); // Update ComboBox for Admins
            };
        }


        private void ShowDataByRole(object sender, EventArgs e, RoleEnum role)
        {
            labelForm.Text = role.ToString() + " Salary Form";
            _role = role;
            //ConfigureDataGridViewColumns();
            UpdateDataGridView();
            UpdateEmployeeComboBox(role);
        }

        private void FormSalary_Load(object sender, EventArgs e)
        {
            // Initialize the JobType ComboBox with enum values
            comboBoxJobType.DataSource = Enum.GetValues(typeof(JobTypeEnum));

            // Set default role to Teacher and update data
            radioButtonTeacher.Checked = true;
            ShowDataByRole(radioButtonTeacher, EventArgs.Empty, RoleEnum.Teacher);

            // Populate ComboBox with Teachers initially
            UpdateEmployeeComboBox(RoleEnum.Teacher);
        }


        private void InitializeDataGridViewByRole(RoleEnum role)
        {
            dataGridView1.RowHeadersVisible = false;
            //dataGridView1.Columns[0].Visible = false; // Hide the ID column or any other unwanted column

            using (var context = new EducationCenterDbContext())
            {
                if (role == RoleEnum.Teacher)
                {
                    var teacherSalaryDetails = context.TeacherSalaryDetails
                        .Include(tsd => tsd.Teacher) // Assuming you want to include related teacher data
                        .Include(tsd => tsd.Salary)   // Assuming you want to include related salary data
                        .ToList();
                    dataGridView1.DataSource = teacherSalaryDetails;
                }
                else if (role == RoleEnum.Admin)
                {
                    var adminSalaryDetails = context.AdministratorSalaryDetails
                        .Include(asd => asd.Administrator) // Assuming you want to include related administrator data
                        .Include(asd => asd.Salary)        // Assuming you want to include related salary data
                        .ToList();
                    dataGridView1.DataSource = adminSalaryDetails;
                }
            }

            // Remove previous event handler and add a new one for cell clicks if needed
            dataGridView1.CellClick -= dataGridView1_CellClick;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void UpdateEmployeeComboBox(RoleEnum role)
        {

            comboBoxEmployee.DataSource = null; // Clear existing DataSource

            try
            {
                if (role == RoleEnum.Teacher)
                {
                    var teachers = _context.Teachers.ToList();
                    if (teachers.Any())
                    {
                        comboBoxEmployee.DataSource = teachers;
                        comboBoxEmployee.DisplayMember = "FullName"; // Adjust this property name
                        comboBoxEmployee.ValueMember = "Id"; // Adjust this property name
                    }
                    else
                    {
                        MessageBox.Show("No teachers found.");
                    }
                }
                else if (role == RoleEnum.Admin)
                {
                    var admins = _context.Administrators.ToList();
                    if (admins.Any())
                    {
                        comboBoxEmployee.DataSource = admins;
                        comboBoxEmployee.DisplayMember = "FullName"; // Adjust this property name
                        comboBoxEmployee.ValueMember = "Id"; // Adjust this property name
                    }
                    else
                    {
                        MessageBox.Show("No administrators found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error populating employee combo box: {ex.Message}");
            }
        }

        private void InitializeEditButtonColumn()
        {
            // Create a list to hold columns to be removed
            var columnsToRemove = new List<DataGridViewColumn>();

            // Iterate over the existing columns and add columns to remove list
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.HeaderText == "Edit")
                {
                    columnsToRemove.Add(column);
                }
            }

            // Remove the columns after enumeration
            foreach (var column in columnsToRemove)
            {
                dataGridView1.Columns.Remove(column);
            }

            // Add the new Edit button column
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn
            {
                Name = "Edit",
                HeaderText = "Edit",
                Text = "Edit",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Add(editButtonColumn);
        }

        private void InitializeDeleteButtonColumn()
        {
            // Create a list to hold columns to be removed
            var columnsToRemove = new List<DataGridViewColumn>();

            // Iterate over the existing columns and add columns to remove list
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.HeaderText == "Delete")
                {
                    columnsToRemove.Add(column);
                }
            }

            // Remove the columns after enumeration
            foreach (var column in columnsToRemove)
            {
                dataGridView1.Columns.Remove(column);
            }

            // Add the new Edit button column
            DataGridViewButtonColumn DeleteButtonColumn = new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Add(DeleteButtonColumn);
        }


        private void buttonPersonForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (Program.formTeacher == null)
            {
                Program.formTeacher = new FormTeacher(_context);
            }

            Program.formTeacher.Location = this.Location;
            Program.formTeacher.StartPosition = FormStartPosition.Manual;
            Program.formTeacher.FormClosing += delegate
            {
                this.Show();
            };
            Program.formTeacher.Show();
        }
    }
}