using CollegeMGT.Core.Dtos;
using CollegeMGT.Core.Models;
using CollegeMGT.Core.View_Models;
using CollegeMGT.Repo.Data.GenericRepository.Interfaces;
using CollegeMGT.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMGT.Service.Implementation
{
    public class SubjectService : ISubjectService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Subject> AddSubject(SubjectViewModel subjectVm)
        {
            var subject = new Subject
            {
                SubjectName = subjectVm.Subject.SubjectName,
                CourseId = subjectVm.Subject.CourseId,
                TeacherId = subjectVm.Subject.TeacherId,
            };
            await _unitOfWork.SubjectRepository.CreateAsync(subject);
            await _unitOfWork.Save();
            return subject;
        }
        public async Task<IEnumerable<Subject>> GetSubjectsByCourseId(int courseId)
        {
            var subjects = await _unitOfWork.SubjectRepository.FindByConditionAsync(c => c.CourseId == courseId, true);
            return subjects;
        }
        public async Task<int> GetCourseIdBySubjectId(int? subjectId)
        {
            var subject = await _unitOfWork.SubjectRepository.GetCourseIdBySubjectId(subjectId);
            return subject.CourseId;
        }

        public async Task DeleteSubject(int subjectId)
        {
            _unitOfWork.SubjectRepository.Remove(subjectId);
            await _unitOfWork.Save();
        }

        public async Task<IEnumerable<Subject>> GetAllSubjects()
        {
            var subjects = await _unitOfWork.SubjectRepository.GetMultiple(IncludeProperties: "Course,Teacher");
            return subjects;
        }
        
        
        public async Task<Subject> GetSubjectById(int subjectId)
        {
            var subject = await _unitOfWork.SubjectRepository.Get(subjectId);
            return subject;
        }

        public async Task<Subject> UpdateSubject(SubjectViewModel subjectVm)
        {
            var subject = await _unitOfWork.SubjectRepository.UpdateSubject(subjectVm);
            await _unitOfWork.Save();
            return subject;
        }
    }
}
