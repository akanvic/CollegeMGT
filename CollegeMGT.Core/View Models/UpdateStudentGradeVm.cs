using CollegeMGT.Core.Models;
using CollegeMGT.Core.Views;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMGT.Core.View_Models
{
    public class UpdateStudentGradeVm
    {
        public StudentGradeVw StudentGradeVw { get; set; }
        public IEnumerable<SelectListItem> GradeList { get; set; }
    }
}
