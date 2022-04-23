using CollegeMGT.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyHelpers.EntityFrameworkCore.Extensions;

namespace CollegeMGT.Repo.Data
{
    public class CollegeDbContext : DbContext
    {

        public CollegeDbContext(DbContextOptions<CollegeDbContext> options)
            : base(options)
        {
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<StudentGrade> StudentGrades { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Teacher>(builder =>
        //    {
        //        // Date is a DateOnly property and date on database
        //        builder.Property(x => x.TeacherBirthDate)
        //            .HasDateOnlyConversion();
        //    });
        //}

    }
}
