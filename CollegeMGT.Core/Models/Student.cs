using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMGT.Core.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Birth")]
        public DateTime StudentBirthDate { get; set; }
        public string? StudentRegistrationNumber { get; set; }
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course? Course { get; set; }

    }
}
