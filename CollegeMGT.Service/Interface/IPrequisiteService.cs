using CollegeMGT.Core.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMGT.Service.Interface
{
    public interface IPrequisiteService
    {
        Task<IEnumerable<SecondPrequisiteVw>> GetSubjectsAndTeacherInformation();
        Task<IEnumerable<ThirdPrequisiteVw>> GetStudentsAndRespectiveGrades();
        Task<IEnumerable<FirstPrequisiteVw>> GetCoursesAndNoOfTeachersAnStudents();
    }
}
