using CollegeMGT.Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMGT.Core.View_Models
{
    public class TeacherViewModel
    {
        public Teacher Teacher { get; set; }
        public IEnumerable<SelectListItem>? CourseList { get; set; }
    }
}
