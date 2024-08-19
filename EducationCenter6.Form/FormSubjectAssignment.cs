using EducationCenter6.Common.Enums;
using EducationCenter6.Common.Objects;
using EducationCenter6.Infrastructure;
using EducationCenter6.Infrastructure.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace EducationCenter6.FormApp
{
    public partial class FormSubjectAssignment : Form
    {
        private readonly EducationCenterDbContext _context;
        private RoleEnum _role = RoleEnum.Teacher;

        public FormSubjectAssignment(EducationCenterDbContext context)
        {
            _context = context;
            InitializeComponent();
            InitializeCheckedBoxList_V2();
            OnCheckChanged();
            InitializeSubjects();


            // Wire up the Load and Activated events
            this.Load += FormSubjectAssignment_Load;
            this.Activated += FormSubjectAssignment_Activated;

            // Wire up role selection event handlers
            radioButtonStudent.CheckedChanged += radioButtonStudent_CheckedChanged;
            radioButtonTeacher.CheckedChanged += radioButtonTeacher_CheckedChanged;
        }

        private void FormSubjectAssignment_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            LoadDataBasedOnRole(); // Load data based on the selected role
            InitializeDeleteButtonColumn();
        }

        private void FormSubjectAssignment_Activated(object sender, EventArgs e)
        {
            LoadDataBasedOnRole(); // Refresh data based on the selected role
            InitializeCheckedBoxList_V2(); // Refresh the checked list box
        }

        private void buttonAssign_Click(object sender, EventArgs e)
        {
            try
            {
                var listSelectedItems = checkedListBoxPeople.CheckedItems;
                if (listSelectedItems != null && listSelectedItems.Count > 0)
                {
                    var subject1 = comboBoxSubject1.SelectedValue as BaseObject;
                    var subject2 = comboBoxSubject2.SelectedValue as BaseObject;

                    // Check if Subject1 and Subject2 are the same
                    if (subject1 != null && subject2 != null && subject1.Value == subject2.Value)
                    {
                        MessageBox.Show("Subject 1 and Subject 2 cannot be the same. Please select different subjects.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    foreach (var itemChecked in listSelectedItems)
                    {
                        if (itemChecked == null) continue;

                        var person = itemChecked as BaseObject;
                        if (person == null) continue;

                        var idPerson = person.Value;
                        var idSubject1 = subject1?.Value ?? 0; // Use null-coalescing operator to default to 0
                        var idSubject2 = subject2?.Value ?? 0; // Use null-coalescing operator to default to 0

                        switch (_role)
                        {
                            case RoleEnum.Teacher:
                                if (idSubject2 == 0)
                                {
                                    MessageBox.Show("Please select a valid Subject 2.", "Invalid Subject", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                CreateTeacherSubjectDetails(idPerson, idSubject1, idSubject2);
                                break;
                            case RoleEnum.Student:
                                if (idSubject2 == 0)
                                {
                                    MessageBox.Show("Please select a valid Subject 2.", "Invalid Subject", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                CreateStudentSubjectDetails(idPerson, idSubject1, idSubject2);
                                break;
                        }
                    }

                    _context.SaveChanges();

                    // Refresh DataGridView and CheckedListBox
                    LoadDataBasedOnRole(); // Use the role-based data load method
                    InitializeCheckedBoxList_V2();

                    // Show success message
                    MessageBox.Show("Subjects assigned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CreateTeacherSubjectDetails(int idTeacher, int idSubject1, int idSubject2)
        {
            bool isOK = false;
            try
            {
                var teacherSubject1 = _context.TeacherSubjectDetails
                    .Where(tsd => tsd.TeacherId == idTeacher && tsd.SubjectId == idSubject1)
                    .SingleOrDefault();

                if (teacherSubject1 == null)
                {
                    var newTeacherSubject = new TeacherSubjectDetail
                    {
                        TeacherId = idTeacher,
                        SubjectId = idSubject1,
                        Position = 1,
                    };
                    _context.TeacherSubjectDetails.Add(newTeacherSubject);
                }

                var teacherSubject2 = _context.TeacherSubjectDetails
                    .Where(tsd => tsd.TeacherId.Equals(idTeacher) && tsd.SubjectId.Equals(idSubject2))
                    .SingleOrDefault();

                if (teacherSubject2 == null)
                {
                    var newTeacherSubject2 = new TeacherSubjectDetail
                    {
                        TeacherId = idTeacher,
                        SubjectId = idSubject2,
                        Position = 2,
                    };
                    _context.TeacherSubjectDetails.Add(newTeacherSubject2);
                }
                isOK = true;
            }
            catch
            {
                // Handle exceptions if needed
            }

            return isOK;
        }

        private bool CreateStudentSubjectDetails(int idStudent, int idSubject1, int idSubject2)
        {
            bool isOK = false;
            try
            {
                var studentSubject1 = _context.StudentSubjectDetails
                    .Where(ssd => ssd.StudentId.Equals(idStudent) && ssd.SubjectId == idSubject1)
                    .SingleOrDefault();

                if (studentSubject1 == null)
                {
                    var newStudentSubject = new StudentSubjectDetail
                    {
                        StudentId = idStudent,
                        SubjectId = idSubject1,
                        Position = 1,
                    };
                    _context.StudentSubjectDetails.Add(newStudentSubject);
                }

                var studentSubject2 = _context.StudentSubjectDetails
                    .Where(ssd => ssd.StudentId == idStudent && ssd.SubjectId == idSubject2)
                    .SingleOrDefault();

                if (studentSubject2 == null)
                {
                    var newStudentSubject2 = new StudentSubjectDetail
                    {
                        StudentId = idStudent,
                        SubjectId = idSubject2,
                        Position = 2,
                    };
                    _context.StudentSubjectDetails.Add(newStudentSubject2);
                }
                isOK = true;
            }
            catch
            {
                // Handle exceptions if needed
            }

            return isOK;
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

        private bool InitializeSubjects()
        {
            bool isOK = false;
            var listSubject = _context.Subjects
                .Select(s => new BaseObject
                {
                    Value = s.Id,
                    Text = s.Position + ". " + s.Name,
                })
                .ToList();
            comboBoxSubject1.DataSource = listSubject;
            comboBoxSubject1.DisplayMember = "Text";

            comboBoxSubject2.BindingContext = new BindingContext();
            var listSubject2 = listSubject;
            comboBoxSubject2.DataSource = listSubject2;
            comboBoxSubject2.DisplayMember = "Text";

            isOK = true;
            return isOK;
        }

        private void ConfigureDataGridView()
        {
            dataGridView1.Columns.Clear();

            if (_role == RoleEnum.Student)
            {
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Student Name",
                    DataPropertyName = "StudentName",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Subject 1",
                    DataPropertyName = "Subject1",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Subject 2",
                    DataPropertyName = "Subject2",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });
            }
            else if (_role == RoleEnum.Teacher)
            {
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Teacher Name",
                    DataPropertyName = "TeacherName",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Subject 1",
                    DataPropertyName = "Subject1",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Subject 2",
                    DataPropertyName = "Subject2",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });
            }
        }

        private void LoadTeacherSubjectData()
        {
            var teacherSubjectList = _context.Teachers
                .Select(teacher => new
                {
                    ID = teacher.Id,
                    TeacherName = teacher.Name,
                    Subject1 = _context.TeacherSubjectDetails
                        .Where(tsd => tsd.TeacherId == teacher.Id && tsd.Position == 1)
                        .Select(tsd => _context.Subjects.FirstOrDefault(s => s.Id == tsd.SubjectId).Name)
                        .FirstOrDefault() ?? "N/A",
                    Subject2 = _context.TeacherSubjectDetails
                        .Where(tsd => tsd.TeacherId == teacher.Id && tsd.Position == 2)
                        .Select(tsd => _context.Subjects.FirstOrDefault(s => s.Id == tsd.SubjectId).Name)
                        .FirstOrDefault() ?? "N/A"
                })
                .ToList();

            dataGridView1.DataSource = null; // Clear existing data
            dataGridView1.DataSource = teacherSubjectList;
        }

        private void LoadStudentSubjectData()
        {
            var studentSubjectList = _context.Students
                .Select(student => new
                {
                    ID = student.Id,
                    StudentName = student.Name,
                    Subject1 = _context.StudentSubjectDetails
                        .Where(ssd => ssd.StudentId == student.Id && ssd.Position == 1)
                        .Select(ssd => _context.Subjects.FirstOrDefault(s => s.Id == ssd.SubjectId).Name)
                        .FirstOrDefault() ?? "N/A",
                    Subject2 = _context.StudentSubjectDetails
                        .Where(ssd => ssd.StudentId == student.Id && ssd.Position == 2)
                        .Select(ssd => _context.Subjects.FirstOrDefault(s => s.Id == ssd.SubjectId).Name)
                        .FirstOrDefault() ?? "N/A"
                })
                .ToList();

            dataGridView1.DataSource = null; // Clear existing data
            dataGridView1.DataSource = studentSubjectList;
        }

        private void checkedListBoxPeople_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Optional: Handle any specific logic when selection changes
        }


        private void radioButtonStudent_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonStudent.Checked)
            {
                _role = RoleEnum.Student;
                LoadStudentSubjectData();
            }
        }

        private void radioButtonTeacher_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTeacher.Checked)
            {
                _role = RoleEnum.Teacher;
                LoadTeacherSubjectData();
            }
        }
        private void LoadDataBasedOnRole()
        {
            if (radioButtonStudent.Checked)
            {
                LoadStudentSubjectData();
            }
            else if (radioButtonTeacher.Checked)
            {
                LoadTeacherSubjectData();
            }
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

                    // Check if Delete button was clicked
                    if (clickedColumn.HeaderText == "Delete" && clickedColumn is DataGridViewButtonColumn)
                    {
                        var id = Convert.ToInt32(clickedRow.Cells["ID"].Value); // Replace "ID" with your actual ID column name

                        if (_role == RoleEnum.Student)
                        {
                            var subjectsToDelete = _context.StudentSubjectDetails.Where(t => t.StudentId == id).ToList();

                            if (subjectsToDelete != null && subjectsToDelete.Count > 0)
                            {
                                _context.StudentSubjectDetails.RemoveRange(subjectsToDelete);
                                _context.SaveChanges();
                                MessageBox.Show("Student's subject records deleted successfully");
                                LoadDataBasedOnRole();
                            }
                        }
                        else if (_role == RoleEnum.Teacher)
                        {
                            var subjectsToDelete = _context.TeacherSubjectDetails.Where(t => t.TeacherId == id).ToList();

                            if (subjectsToDelete != null && subjectsToDelete.Count > 0)
                            {
                                _context.TeacherSubjectDetails.RemoveRange(subjectsToDelete);
                                _context.SaveChanges();
                                MessageBox.Show("Teacher's subject records deleted successfully");
                                LoadDataBasedOnRole();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


    }

}