using EducationCenter6.Common.Enums;
using EducationCenter6.Common.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter6.Infrastructure.Entities
{
    public class Administrator : Person
    {
        public Administrator()
        {
            AdministratorSalaryDetails = new List<AdministratorSalaryDetail>();
        }
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string Phone { get; set; }
        //public string Email { get; set; }
        //public RoleEnum Role { get; set; }

        public JobTypeEnum JobType { get; set; }
        public int WorkingHours { get; set; }

        public virtual List<AdministratorSalaryDetail> AdministratorSalaryDetails { get; set; }
        
    }
}
