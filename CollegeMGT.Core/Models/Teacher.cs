using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMGT.Core.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Birth")]
        public DateTime TeacherBirthDate { get; set; }
        public decimal TeacherSalary { get; set; }

        //public int CourseId { get; set; }

        //[ForeignKey("CourseId")]
        //public Course Course { get; set; }
    }
}
