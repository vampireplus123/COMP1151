using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter6.Infrastructure.Entities
{
    public class Subject
    {
        public Subject()
        {
            TeacherSubjectDetails = new List<TeacherSubjectDetail>();
            StudentSubjectDetails = new List<StudentSubjectDetail>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        [Description("Mô tả môn học")]
        public string Description { get; set; }

        [Description("Mã môn học")]
        public string Code { get; set; }
        public int Position { get; set; }

        public virtual List<TeacherSubjectDetail> TeacherSubjectDetails { get; set; }
        public virtual List<StudentSubjectDetail> StudentSubjectDetails { get; set; }

    }
}
