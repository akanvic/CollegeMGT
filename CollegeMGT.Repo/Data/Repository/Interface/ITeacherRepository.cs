using CollegeMGT.Core.Dtos;
using CollegeMGT.Core.Models;
using CollegeMGT.Core.View_Models;
using CollegeMGT.Repo.Data.GenericRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMGT.Repo.Data.Repository.Interface
{
    public interface ITeacherRepository : IGenericRepository<Teacher>
    {
        Task<Teacher> UpdateTeacher(TeacherViewModel teacher);
    }
}
