using CollegeMGT.Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMGT.Core.View_Models
{
    public class StudentGradeViewModel
    {
        public StudentGrade StudentGrade { get; set; }
        public IEnumerable<SelectListItem>? StudentList { get; set; }
        public IEnumerable<SelectListItem>? SubjectList { get; set; }
        public IEnumerable<SelectListItem>? GradeList { get; set; }
    }
}
