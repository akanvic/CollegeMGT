using CollegeMGT.Core.Views;
using CollegeMGT.Repo.Dapper.Implementation;
using CollegeMGT.Repo.Dapper.Infrastructure;
using CollegeMGT.Repo.Data.GenericRepository.Interfaces;
using CollegeMGT.Service.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CollegeMGT.Repo.Dapper.Infrastructure.Connectionfactory;

namespace CollegeMGT.Service.Implementation
{
    public class PrequisiteService : IPrequisiteService
    {
        private readonly GenericRepository<SecondPrequisiteVw> _secondprequisiteVw;
        private readonly GenericRepository<ThirdPrequisiteVw> _thirdprequisiteVw;
        private readonly GenericRepository<FirstPrequisiteVw> _firstprequisiteVw;

        public PrequisiteService(IConnectionFactory connectionfactory)
        {
            _secondprequisiteVw = new GenericRepository<SecondPrequisiteVw>(connectionfactory);
            _thirdprequisiteVw = new GenericRepository<ThirdPrequisiteVw>(connectionfactory);
            _firstprequisiteVw = new GenericRepository<FirstPrequisiteVw>(connectionfactory);
        }
        public async Task<IEnumerable<ThirdPrequisiteVw>> GetStudentsAndRespectiveGrades()
        {
            var response = await _thirdprequisiteVw.QueryAsyncSp(StoredProcedures.uspGetStudentsAndRespectiveGrades, 
                CommandType.StoredProcedure);
            return response;
        }
        public async Task<IEnumerable<SecondPrequisiteVw>> GetSubjectsAndTeacherInformation()
        {
            var response = await _secondprequisiteVw.QueryAsyncSp(StoredProcedures.uspGetSubjectAndTeacherInformation,
                            CommandType.StoredProcedure);
            return response;
        }
        public async Task<IEnumerable<FirstPrequisiteVw>> GetCoursesAndNoOfTeachersAnStudents()
        {
            var response = await _firstprequisiteVw.QueryAsyncSp(StoredProcedures.uspGetCoursesAndNoOfTeachersAndStudents,
                            CommandType.StoredProcedure);
            return response;
        }
    }
}
