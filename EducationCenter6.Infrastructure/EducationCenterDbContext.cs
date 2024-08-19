using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationCenter6.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace EducationCenter6.Infrastructure
{
    public class EducationCenterDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // See https://github.com/aspnet/EntityFramework/issues/639
            var connectionString = "Server=.;Database=EducationCenter;User ID=sa; Password=123456; TrustServerCertificate=True; Trusted_Connection=False; MultipleActiveResultSets=true;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        /// <summary>
        /// Cấu hình ràng buộc cho các Entity. Bao gồm:
        ///     + Composite Primary Keys
        ///     + MaxLength của String
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdministratorSalaryDetail>()
                .HasKey(c => new { c.AdministratorId, c.SalaryId });

            modelBuilder.Entity<StudentSubjectDetail>()
                .HasKey(c => new { c.StudentId, c.SubjectId });

            modelBuilder.Entity<TeacherSalaryDetail>()
                .HasKey(c => new { c.TeacherId, c.SalaryId });

            modelBuilder.Entity<TeacherSubjectDetail>()
                .HasKey(c => new { c.TeacherId, c.SubjectId });
        }

        //=== Step 2: DbSet
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<AdministratorSalaryDetail> AdministratorSalaryDetails { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentSubjectDetail> StudentSubjectDetails { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherSalaryDetail> TeacherSalaryDetails { get; set; }
        public DbSet<TeacherSubjectDetail> TeacherSubjectDetails { get; set; }
        //=== Step 3: Add-Migration (Microsoft.EntityFrameworkCore.Tools)
        //Mở Package Manager Console và chạy lệnh add-migration + [Name] sau đó chạy update-database 
    }
}
