using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter6.Infrastructure.Entities
{
    public class TeacherSubjectDetail
    {
        public TeacherSubjectDetail()
        {
            IsPreviouslyTaught = false;
        }

        [Key, Column(Order = 0)]
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        [Key, Column(Order = 1)]
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public bool? IsPreviouslyTaught { get; set; }

        public int? Position { get; set; }
    }
}
