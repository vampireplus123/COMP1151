using EducationCenter6.Common.Enums;
using EducationCenter6.Infrastructure;
using EducationCenter6.Infrastructure.Entities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Data;
using EducationCenter6.Common.Objects;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;

namespace EducationCenter6.FormApp
{
    public partial class FormTeacher : Form
    {
        private readonly EducationCenterDbContext _context;
        private int idPerson;
        private Teacher _teacher = null;
        private Student _student = null;
        private Administrator _admin = null;
        private RoleEnum _role;

        public FormTeacher(EducationCenterDbContext context)
        {
            _context = context;

            _role = RoleEnum.Teacher;
            InitializeComponent();
            InitializeComboBox();
            InitializeDataGridViewByRole(_role);
            OnCheckChanged();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        //private async Task<bool> buttonSubmit_Click(object sender, EventArgs e)
        {
            var isOK = false;
            try
            {
                var fullName = textBoxFullName.Text?.Trim();
                //if(fullName != null || fullName == "")
                if (string.IsNullOrEmpty(fullName))
                {
                    MessageBox.Show("Nhớ nhập dùm dữ liệu nha");
                    return;
                }
                var dateOfBirth = datePickerDateOfBirth.Value;
                var phone = textBoxPhone.Text?.Trim();
                var email = textBoxEmail.Text?.Trim();

                //var role = (RoleEnum)comboBoxRole.SelectedValue;
                //!!!=== Phải lấy role từ RadioButton chứ không phải ComboBox ===!!!//
                //var role = RoleEnum.Student;
                //if (radioButtonAdmin.Checked)
                //{
                //    role = RoleEnum.Admin;
                //}
                //else if (radioButtonTeacher.Checked)
                //{
                //    role = RoleEnum.Teacher;
                //}
                _role = radioButtonAdmin.Checked
                                ? RoleEnum.Admin : (radioButtonTeacher.Checked
                                        ? RoleEnum.Teacher : RoleEnum.Student);
                switch (_role)
                {
                    case RoleEnum.Admin:
                        SaveAdministratorDatabase(fullName, dateOfBirth, phone, email, _role);
                        break;
                    case RoleEnum.Teacher:
                        SaveTeacherDatabase(fullName, dateOfBirth, phone, email, _role);
                        break;
                    case RoleEnum.Student:
                        SaveStudentDatabase(fullName, dateOfBirth, phone, email, _role);

                        break;
                    default:
                        break;
                }

                MessageBox.Show("Thành công");
                //=== Clear Form ===//
                ResetForm();
                InitializeDataGridViewByRole(_role);
            }
            catch (Exception ex)
            {

            }
            //return isOK;
        }


        private void buttonSubmit_ClickUpdate(object sender, EventArgs e)
        //private async Task<bool> buttonSubmit_Click(object sender, EventArgs e)
        {
            var isOK = false;
            try
            {
                var fullName = textBoxFullName.Text?.Trim();
                var dateOfBirth = datePickerDateOfBirth.Value;
                var phone = textBoxPhone.Text?.Trim();
                var email = textBoxEmail.Text?.Trim();

                _role = radioButtonAdmin.Checked
                                ? RoleEnum.Admin : (radioButtonTeacher.Checked
                                        ? RoleEnum.Teacher : RoleEnum.Student);
                switch (_role)
                {
                    case RoleEnum.Admin:
                        UpdateAdministratorDatabase(fullName, dateOfBirth, phone, email, _role);
                        break;
                    case RoleEnum.Teacher:
                        UpdateTeacherDatabase(fullName, dateOfBirth, phone, email, _role);
                        break;
                    case RoleEnum.Student:
                        UpdateStudentDatabase(fullName, dateOfBirth, phone, email, _role);
                        break;
                    default:
                        break;
                }

                MessageBox.Show("Thành công");
                //=== Clear Form ===//
                ResetForm();
                //=== Reload DataGridView ===//
                InitializeDataGridViewByRole(_role);

            }
            catch (Exception ex)
            {

            }
            //return isOK;
        }

        private bool ResetForm()
        {
            bool isOK = false;
            textBoxFullName.Text = "";
            datePickerDateOfBirth.Value = DateTime.Now;
            textBoxEmail.Text = "";
            textBoxPhone.Text = "";
            comboBoxRole.SelectedItem = _role;
            isOK = true;
            buttonSubmit.Click -= buttonSubmit_Click;
            buttonSubmit.Click -= buttonSubmit_ClickUpdate;
            buttonSubmit.Click += buttonSubmit_Click;

            return isOK;
        }

        private void showDataAdmin(object sender, EventArgs e)
        {
            labelForm.Text = "Admin Form";
            //comboBoxRole.SelectedValue = RoleEnum.Admin;
            comboBoxRole.SelectedItem = RoleEnum.Admin;
            _role = RoleEnum.Admin;
            //=== Set Data cho Data Grid View ===//
            //var role = 
            InitializeDataGridViewByRole(RoleEnum.Admin);
        }

        private void showDataTeacher(object sender, EventArgs e)
        {
            labelForm.Text = "Teacher Form";
            comboBoxRole.SelectedItem = RoleEnum.Teacher;
            _role = RoleEnum.Teacher;

            InitializeDataGridViewByRole(RoleEnum.Teacher);
        }

        private void showDataStudent(object sender, EventArgs e)
        {
            labelForm.Text = "Student Form";
            comboBoxRole.SelectedItem = RoleEnum.Student;
            _role = RoleEnum.Student;

            InitializeDataGridViewByRole(RoleEnum.Student);
        }

        /// <summary>
        /// Hàm dùng chung cho cả 3 hàm ShowData cho Admin, Teacher và Student ở trên.
        /// Lưu ý: trừu tượng hóa các thành phần giống nhau và thêm thành phần phụ thuộc role vào tham số
        /// </summary>
        /// <param name="sender">Mặc định của EventHandler</param>
        /// <param name="e">Mặc định của EventHandler</param>
        /// <param name="role">Vai trò của mình truyền</param>
        private void ShowDataByRole(object sender, EventArgs e, RoleEnum role)
        {
            labelForm.Text = role.ToString() + " Form";
            comboBoxRole.SelectedItem = role;
            _role = role;
            InitializeDataGridViewByRole(role);
        }

        private bool SaveTeacherDatabase(string fullName, DateTime dateOfBirth,
            string phone, string email, RoleEnum role)
        {
            var isOK = false;
            //var context = new EducationCenterDbContext();
            //=== Khởi tạo và hủy bỏ biến context sau khi kết thúc khối hàm (IDisposable) ===//
            using (var context = new EducationCenterDbContext())
            {
                var count = context.Teachers.Count();
                var newTeacher = new Teacher
                {
                    FullName = fullName,
                    DateOfBirth = dateOfBirth,
                    Phone = phone,
                    Email = email,
                    //Role = RoleEnum.Teacher,
                    Role = role,
                    Position = count + 1,
                };
                newTeacher.Name = newTeacher.GetNameFromFullName(fullName);
                newTeacher.Age = newTeacher.GetAge(dateOfBirth);

                context.Teachers.Add(newTeacher);
                context.SaveChanges();
                //await context.SaveChangesAsync();
                isOK = true;
            }
            return isOK;
        }

        private bool UpdateTeacherDatabase(string fullName, DateTime dateOfBirth,
            string phone, string email, RoleEnum role)
        {
            var isOK = false;
            var teacher = _context.Teachers
                .Where(t => t.Id == idPerson)
                .SingleOrDefault();
            if (teacher != null)
            {
                teacher.FullName = fullName;
                teacher.DateOfBirth = dateOfBirth;
                teacher.Phone = phone;
                teacher.Email = email;
                //!!!=== Không được cập nhật Role vì đổi Table ===!!!//
                _context.SaveChanges();
                isOK = true;
            }
            return isOK;
        }

        private bool SaveStudentDatabase(string fullName, DateTime dateOfBirth,
            string phone, string email, RoleEnum role)
        {
            var isOK = false;
            var count = _context.Students.Count();
            var newStudent = new Student
            {
                FullName = fullName,
                DateOfBirth = dateOfBirth,
                Phone = phone,
                Email = email,
                //Role = RoleEnum.Teacher,
                Role = role,
                Position = count + 1,
            };
            newStudent.Name = newStudent.GetNameFromFullName(fullName);
            newStudent.Age = newStudent.GetAge(dateOfBirth);

            _context.Students.Add(newStudent);
            _context.SaveChanges();
            //await context.SaveChangesAsync();
            isOK = true;
            return isOK;
        }

        private bool UpdateStudentDatabase(string fullName, DateTime dateOfBirth,
            string phone, string email, RoleEnum role)
        {
            var isOK = false;
            var student = _context.Students
                .Where(t => t.Id == idPerson)
                .SingleOrDefault();
            if (student != null)
            {
                student.FullName = fullName;
                student.DateOfBirth = dateOfBirth;
                student.Phone = phone;
                student.Email = email;
                //!!!=== Không được cập nhật Role vì đổi Table ===!!!//
                _context.SaveChanges();
                isOK = true;
            }
            return isOK;
        }
        private bool SaveAdministratorDatabase(string fullName, DateTime dateOfBirth,
            string phone, string email, RoleEnum role)
        {
            var isOK = false;
            //var context = new EducationCenterDbContext();

            var count = _context.Administrators.Count();
            var newAdmin = new Administrator
            {
                FullName = fullName,
                DateOfBirth = dateOfBirth,
                Phone = phone,
                Email = email,
                //Role = RoleEnum.Teacher,
                Role = role,
                Position = count + 1,
            };
            newAdmin.Name = newAdmin.GetNameFromFullName(fullName);
            newAdmin.Age = newAdmin.GetAge(dateOfBirth);

            _context.Administrators.Add(newAdmin);
            _context.SaveChanges();
            //await context.SaveChangesAsync();
            isOK = true;
            return isOK;
        }

        private bool UpdateAdministratorDatabase(string fullName, DateTime dateOfBirth,
            string phone, string email, RoleEnum role)
        {
            var isOK = false;
            var admin = _context.Administrators
                .Where(t => t.Id == idPerson)
                .SingleOrDefault();
            if (admin != null)
            {
                admin.FullName = fullName;
                if (admin.DateOfBirth != dateOfBirth)
                {
                    admin.DateOfBirth = dateOfBirth;
                    admin.Age = admin.GetAge(dateOfBirth);
                }
                admin.Phone = phone;
                admin.Email = email;
                //!!!=== Không được cập nhật Role vì đổi Table ===!!!//
                _context.SaveChanges();
                isOK = true;
            }
            return isOK;
        }

        private void gridViewEditButton_CellClick(Object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;

                // Ensure the click is on a valid button cell
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    // Step 1: Grab the Id of the clicked row
                    var rowIndex = e.RowIndex;
                    int columnId = 0;
                    var columnValue = dataGridViewList[columnId, rowIndex].Value;
                    int id = (int)columnValue;
                    idPerson = id;

                    // Step 2: Determine whether "Edit" or "Delete" button was clicked
                    var clickedButtonValue = senderGrid[e.ColumnIndex, e.RowIndex].Value.ToString();

                    if (clickedButtonValue == "Edit")
                    {
                        // Handle "Edit" logic
                        switch (_role)
                        {
                            case RoleEnum.Admin:
                                _admin = _context.Administrators.SingleOrDefault(t => t.Id == idPerson);
                                if (_admin != null)
                                {
                                    textBoxFullName.Text = _admin.FullName;
                                    datePickerDateOfBirth.Value = _admin.DateOfBirth;
                                    comboBoxRole.SelectedItem = _admin.Role;
                                    textBoxEmail.Text = _admin.Email;
                                    textBoxPhone.Text = _admin.Phone;
                                }
                                break;

                            case RoleEnum.Teacher:
                                _teacher = _context.Teachers.SingleOrDefault(t => t.Id == idPerson);
                                if (_teacher != null)
                                {
                                    textBoxFullName.Text = _teacher.FullName;
                                    datePickerDateOfBirth.Value = _teacher.DateOfBirth;
                                    textBoxEmail.Text = _teacher.Email;
                                    textBoxPhone.Text = _teacher.Phone;
                                    comboBoxRole.SelectedItem = _teacher.Role;
                                }
                                break;

                            case RoleEnum.Student:
                                _student = _context.Students.SingleOrDefault(t => t.Id == idPerson);
                                if (_student != null)
                                {
                                    textBoxFullName.Text = _student.FullName;
                                    datePickerDateOfBirth.Value = _student.DateOfBirth;
                                    comboBoxRole.SelectedItem = _student.Role;
                                    textBoxEmail.Text = _student.Email;
                                    textBoxPhone.Text = _student.Phone;
                                }
                                break;

                            default:
                                break;
                        }

                        // Step 3: Set event for Submit Button to handle Update
                        buttonSubmit.Click -= buttonSubmit_Click;
                        buttonSubmit.Click -= buttonSubmit_ClickUpdate;
                        buttonSubmit.Click += buttonSubmit_ClickUpdate;
                    }
                    else if (clickedButtonValue == "Delete")
                    {
                        // Handle "Delete" logic
                        switch (_role)
                        {
                            case RoleEnum.Admin:
                                _admin = _context.Administrators.SingleOrDefault(t => t.Id == idPerson);
                                if (_admin != null)
                                {
                                    _context.Administrators.Remove(_admin);
                                }
                                break;

                            case RoleEnum.Teacher:
                                _teacher = _context.Teachers.SingleOrDefault(t => t.Id == idPerson);
                                if (_teacher != null)
                                {
                                    _context.Teachers.Remove(_teacher);
                                }
                                break;

                            case RoleEnum.Student:
                                _student = _context.Students.SingleOrDefault(t => t.Id == idPerson);
                                if (_student != null)
                                {
                                    _context.Students.Remove(_student);
                                }
                                break;

                            default:
                                break;
                        }

                        _context.SaveChanges();
                        MessageBox.Show("Row deleted successfully");

                        // Refresh DataGridView after deletion
                        InitializeDataGridViewByRole(_role);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log error and show a message to the user)
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void buttonSubjectDetails_Click(object sender, EventArgs e)
        {
            //=== Con trỏ THIS là Form hiện tại (FormTeacher) ==//
            this.Hide();
            if (Program.formSubjectAssignment == null)
            {
                Program.formSubjectAssignment = new FormSubjectAssignment(_context);
            }

            Program.formSubjectAssignment.Location = this.Location;
            Program.formSubjectAssignment.StartPosition = FormStartPosition.Manual;
            Program.formSubjectAssignment.FormClosing += delegate
            {
                //=== Nếu Form SubjectAssignment đóng thì cho FormTeacher hiện ===//
                this.Show();
            };
            Program.formSubjectAssignment.Show();

        }

        private void buttonSalaryDetails_Click(object sender, EventArgs e)
        {
            // Hide the current FormSalary
            this.Hide();

            // Check if the FormSalaryDetails instance is already created
            if (Program.formSalary == null)
            {
                Program.formSalary = new FormSalary(_context);
            }

            // Set the position of the new form to the same location as the current form
            Program.formSalary.Location = this.Location;
            Program.formSalary.StartPosition = FormStartPosition.Manual;

            // Show FormSalaryDetails and handle its FormClosing event
            Program.formSalary.FormClosing += (s, args) =>
            {
                // Show the current FormSalary when FormSalaryDetails is closed
                this.Show();
            };

            Program.formSalary.Show();
        }


        private void InitializeDataGridViewByRole(RoleEnum role)
        {
            dataGridViewList.RowHeadersVisible = false;
            //dataGridViewList.Columns["Id"].Visible = false;
            dataGridViewList.Columns[0].Visible = false;
            using (var context = new EducationCenterDbContext())
            {
                if (role == RoleEnum.Teacher)
                {
                    //=== Truy vấn có điều kiện (Ngữ cảnh này không cần Where vẫn đúng) ===//
                    var teacherList = context.Teachers
                        .Where(x => x.Role == role)
                        .ToList();
                    dataGridViewList.DataSource = teacherList;
                }
                else if (role == RoleEnum.Student)
                {
                    var studentList = context.Students.ToList();
                    dataGridViewList.DataSource = studentList;
                }
                else if (role == RoleEnum.Admin)
                {
                    var adminList = context.Administrators.ToList();
                    dataGridViewList.DataSource = adminList;
                }
            }
            dataGridViewList.CellClick -= gridViewEditButton_CellClick;
            dataGridViewList.CellClick += gridViewEditButton_CellClick;
        }

        private void InitializeComboBox()
        {
            comboBoxRole.DataSource = Enum.GetValues(typeof(RoleEnum));
        }

        private void OnCheckChanged()
        {
            //radioButtonAdmin.CheckedChanged += showDataAdmin;
            //radioButtonTeacher.CheckedChanged += showDataTeacher;
            //radioButtonStudent.CheckedChanged += showDataStudent;

            //=== EventHandler, Arrow Function với Sender và Arguement ===//
            radioButtonAdmin.CheckedChanged += new System.EventHandler((sender, e) => ShowDataByRole(sender, e, RoleEnum.Admin));
            radioButtonTeacher.CheckedChanged += (sender, e) => ShowDataByRole(sender, e, RoleEnum.Teacher);
            radioButtonStudent.CheckedChanged += (sender, e) => ShowDataByRole(sender, e, RoleEnum.Student);

        }

        private void InitializeDataGridView()
        {
            dataGridViewList.RowHeadersVisible = false;
            //dataGridViewList.Columns["Id"].Visible = false;
            dataGridViewList.Columns[0].Visible = false;
            using (var context = new EducationCenterDbContext())
            {
                var teacherList = context.Teachers.ToList();
                dataGridViewList.DataSource = teacherList;
            }
        }

        private void FormTeacher_Load(object sender, EventArgs e)
        {

        }
    }
}
