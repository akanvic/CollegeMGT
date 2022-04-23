using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeMGT.Repo.Migrations
{
    public partial class usp_GenerateStoredProceduresInDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROC usp_GetStudentsAndRespectiveGrades 
                                    AS 
                                    BEGIN 
                                        	select StudentName,c.SubjectName,d.GradeValue from Students a 
	                                        inner join StudentGrades b on a.StudentId=b.StudentId
	                                        inner join Subjects c on b.SubjectId=c.SubjectId
	                                        inner join Grades d on b.GradeId=d.GradeId
                                    END");

            migrationBuilder.Sql(@"CREATE PROC usp_GetSubjectAndTeacherInformation
                                    AS 
                                    BEGIN 
	                                        select SubjectName,TeacherName,TeacherBirthDate,TeacherSalary,COUNT(c.StudentId)StudentCount,Avg(d.GradeValue)StudentGradeAverage 
	                                        from Subjects a inner join Teachers b on a.TeacherId=b.TeacherId
	                                        inner join StudentGrades c on a.SubjectId=c.SubjectId
	                                        inner join Grades d on c.GradeId=d.GradeId
	                                        group by c.SubjectId,SubjectName,TeacherName,TeacherBirthDate,TeacherSalary
                                    END ");

            migrationBuilder.Sql(@"CREATE PROC usp_GetCoursesAndNoOfTeachersAndStudents
                                    AS 
                                    BEGIN 
	                                        select a.CourseId, a.CourseName, Count(distinct(d.TeacherId))TeacherCount, Count(distinct(b.StudentId))StudentCount,
	                                        isnull(Avg(f.GradeValue),0)AvgGrade
	                                        from Courses a 
	                                        left outer join Students b on a.CourseId = b.CourseId 
	                                        left outer join Subjects c on c.CourseId = a.CourseId
	                                        left outer join Teachers d on c.TeacherId = d.TeacherId 
	                                        left outer join StudentGrades e on e.StudentId = b.StudentId
	                                        left outer join Grades f on f.GradeId = e.GradeId
	                                        group by a.CourseId, a.CourseName

	                                        order by a.CourseId
                                    END ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE usp_GetStudentsAndRespectiveGrades");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_GetSubjectAndTeacherInformation");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_GetCoursesAndNoOfTeachersAndStudents");
        }
    }
}
