using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationCenter6.Infrastructure.Entities
{
    public class TeacherSalaryDetail
    {
        [Key, Column(Order = 0)]
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        [Key, Column(Order = 1)]
        public int SalaryId { get; set; }
        public virtual Salary Salary { get; set; }

        public DateTime? StartTime { get; set; }
        public int? Position { get; set; }
    }
}
