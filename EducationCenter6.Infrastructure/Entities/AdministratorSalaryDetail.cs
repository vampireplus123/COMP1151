using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter6.Infrastructure.Entities
{
    public class AdministratorSalaryDetail
    {
        [Key, Column(Order = 0)]
        public int AdministratorId { get; set; }
        public virtual Administrator Administrator { get; set; }

        [Key, Column(Order = 1)]
        public int SalaryId { get; set; }
        public virtual Salary Salary { get; set; }

        public DateTime? StartTime { get; set; }
        public int? Position { get; set; }
    }
}
