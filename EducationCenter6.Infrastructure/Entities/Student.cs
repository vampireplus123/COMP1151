using EducationCenter6.Common.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter6.Infrastructure.Entities
{
    public class Student : Person
    {
        public Student()
        {
            //this.Id = 1;
            StudentSubjectDetails = new List<StudentSubjectDetail>();
        }
        public virtual List<StudentSubjectDetail> StudentSubjectDetails { get; set; }
    }
}
