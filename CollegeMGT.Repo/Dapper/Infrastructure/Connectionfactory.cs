//using Microsoft.CodeAnalysis.Options; //Microsoft.CodeAnalysis.CSharp
using CollegeMGT.Core.Models;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace CollegeMGT.Repo.Dapper.Infrastructure
{
    public class Connectionfactory : IConnectionFactory
    {
        IOptions<ConnectionStrings> _con;
        private readonly string connectionString;
        private static string dbSchema = "dbo";
        public Connectionfactory(IOptions<ConnectionStrings> con)
        {
            _con = con;
            connectionString = _con.Value.DefaultConnection;
        }
        public IDbConnection GetConnection
        {
            get
            {
                var conn = new SqlConnection(connectionString); //factory.CreateConnection(); //
                try
                {
                    //var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                    conn.ConnectionString = connectionString;
                    conn.Open();
                    return conn;
                }
                finally
                {
                    conn.Close();
                }
            }
        }



        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        public static class StoredProcedures
        {
            //Stored Procedures for Tb_Applicant
            public static string uspGetSubjectAndTeacherInformation = $"{dbSchema}.usp_GetSubjectAndTeacherInformation";
            public static string uspGetStudentsAndRespectiveGrades = $"{dbSchema}.usp_GetStudentsAndRespectiveGrades";
            public static string uspGetAvailableTeachers = $"{dbSchema}.usp_GetAvailableTeachers";
            public static string uspGetCoursesAndNoOfTeachersAndStudents = $"{dbSchema}.usp_GetCoursesAndNoOfTeachersAndStudents";
            public static string uspGetStudentGradeByStudentId = $"{dbSchema}.usp_GetStudentGradeByStudentId";
            public static string uspGetStudentByStudentId = $"{dbSchema}.usp_GetStudentByStudentId"; 
            public static string uspGetStudentGradeByStudentGradeId = $"{dbSchema}.usp_GetStudentGradeByStudentGradeId";

        }
    }
}
