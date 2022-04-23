using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMGT.Core.Views
{
    public class SecondPrequisiteVw
    {
        public string SubjectName { get; set; }
        public string TeacherName { get; set; }
        public DateTime TeacherBirthDate { get; set; }
        public decimal TeacherSalary { get; set; }
        public int StudentCount { get; set; }
        public int StudentGradeAverage { get; set; }
    }
}
