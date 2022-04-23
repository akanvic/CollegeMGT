using CollegeMGT.Repo.Dapper.Interface;
using CollegeMGT.Repo.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMGT.Repo.Data.GenericRepository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository CourseRepository { get; }
        ISubjectRepository SubjectRepository { get; }
        ITeacherRepository TeacherRepository { get; }
        IStudentRepository StudentRepository { get; }
        IStudentGradeRepository StudentGradeRepository { get; }
        IGradeRepository GradeRepository { get; }
        Task Save();
    }
}
