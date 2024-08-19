using EducationCenter6.Common.Enums;
using EducationCenter6.Common.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter6.Infrastructure.Entities
{
    public class Teacher : Person
    {
        public Teacher()
        {
            TeacherSalaryDetails = new List<TeacherSalaryDetail>();
            TeacherSubjectDetails = new List<TeacherSubjectDetail>();
        }

        public virtual List<TeacherSalaryDetail> TeacherSalaryDetails { get; set; }
        public virtual List<TeacherSubjectDetail> TeacherSubjectDetails { get; set; }
    }
}
