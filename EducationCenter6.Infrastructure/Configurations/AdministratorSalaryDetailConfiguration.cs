using EducationCenter6.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter6.Infrastructure.Configurations
{
    //=== Fluent API ===//
    public class AdministratorSalaryDetailConfiguration
        : IEntityTypeConfiguration<AdministratorSalaryDetail>
    {
        public void Configure(EntityTypeBuilder<AdministratorSalaryDetail> builder)
        {
            
        }
    }
}
