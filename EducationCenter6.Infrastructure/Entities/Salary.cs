using EducationCenter6.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter6.Infrastructure.Entities
{
    /// <summary>
    /// Quản lý bậc lương
    /// </summary>
    public class Salary
    {
        public Salary()
        {
            TeacherSalaryDetails = new List<TeacherSalaryDetail>();
            AdministratorSalaryDetails = new List<AdministratorSalaryDetail>();
        }
        public int Id { get; set; }

        [Description("Bậc lương")]
        public int Level { get; set; }

        [Description("Hệ số lương")]
        public float Coefficient { get; set; }

        [Description("Lương cơ bản")]
        public double UnitSalary { get; set; }

        public JobTypeEnum Type { get; set; }

        public int Position { get; set; }

        public List<TeacherSalaryDetail> TeacherSalaryDetails { get; set; }
        public virtual List<AdministratorSalaryDetail> AdministratorSalaryDetails { get; set; }
    }
}
