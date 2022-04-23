using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMGT.Core.Dtos
{
    public class TeacherDto
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public DateTime TeacherBirthDate { get; set; }
        public decimal TeacherSalary { get; set; }
        public int CourseId { get; set; }
    }
}
