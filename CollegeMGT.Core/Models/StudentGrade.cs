using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMGT.Core.Models
{
    public class StudentGrade
    {
        public int StudentGradeId { get; set; }

        [ForeignKey("StudentId")]
        public Student? Student { get; set; }
        public int StudentId { get; set; }

        [ForeignKey("SubjectId")]
        public Subject? Subject { get; set; }
        public int SubjectId { get; set; }


        [ForeignKey("GradeId")]
        public Grade? Grade { get; set; }
        public int GradeId { get; set; }
    }
}
