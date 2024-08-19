using EducationCenter6.Common.Objects;
using EducationCenter6.Infrastructure;
namespace EducationCenter6.FormApp
{
    internal static class Program
    {
        public static FormTeacher formTeacher = null;
        public static FormSubjectAssignment formSubjectAssignment = null;
        public static FormSalary formSalary = null;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //var context = new EducationCenterDbContext();
            using (var context = new EducationCenterDbContext())
            {
                //Application.Run(new FormTeacher(context));
                formTeacher = new FormTeacher(context);
                Application.Run(formTeacher);
                //Application.Run(new FormSubjectAssignment(context));
            }
        }
    }
}