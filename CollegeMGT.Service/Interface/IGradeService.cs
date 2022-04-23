using CollegeMGT.Core.Dtos;
using CollegeMGT.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMGT.Service.Interface
{
    public interface IGradeService
    {
        Task<Grade> AddGrade(GradeDto gradeDto);
        Task<IEnumerable<Grade>> GetAllGrades();

        Task<Grade> UpdateGrade(GradeDto gradeDto);
        Task<Grade> GetGradeById(int gradeId);
        Task DeleteGrade(int gradeId);
    }
}
