using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter6.Infrastructure.Entities
{
    public class StudentSubjectDetail
    {
        [Key, Column(Order = 0)]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        [Key, Column(Order = 1)]
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }


        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public bool? IsPreviouslyStudied { get; set; }

        public int? Position { get; set; }
    }
}
