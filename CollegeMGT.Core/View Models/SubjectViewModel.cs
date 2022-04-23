using CollegeMGT.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollegeMGT.Core.View_Models
{
    public class SubjectViewModel
    {
        public Subject Subject { get; set; }
        public IEnumerable<SelectListItem>? CourseList { get; set; }
        public IEnumerable<SelectListItem>? TeacherList { get; set; }
    }
}
