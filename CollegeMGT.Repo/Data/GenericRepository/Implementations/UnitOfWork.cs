using CollegeMGT.Repo.Data.GenericRepository.Interfaces;
using CollegeMGT.Repo.Data.Repository.Implementation;
using CollegeMGT.Repo.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CollegeMGT.Repo.Data.GenericRepository.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CollegeDbContext _context;

        public UnitOfWork(CollegeDbContext context)
        {
            _context = context;
            CourseRepository = new CourseRepository(_context);
            SubjectRepository = new SubjectRepository(_context);
            TeacherRepository = new TeacherRepository(_context);
            StudentRepository = new StudentRepository(_context);
            StudentGradeRepository = new StudentGradeRepository(_context);
            GradeRepository = new GradeRepository(_context);
        }
        public ICourseRepository CourseRepository { get; private set; }
        public ISubjectRepository SubjectRepository { get; private set; }
        public ITeacherRepository TeacherRepository { get; private set; }
        public IStudentRepository StudentRepository { get; private set; }
        public IStudentGradeRepository StudentGradeRepository { get; private set; }
        public IGradeRepository GradeRepository { get; private set;}
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
