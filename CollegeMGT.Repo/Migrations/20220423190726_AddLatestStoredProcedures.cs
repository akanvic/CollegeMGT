using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeMGT.Repo.Migrations
{
    public partial class AddLatestStoredProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROC usp_GetStudentByStudentId 
                                    @StudentId int
                                    AS 
                                    BEGIN 
		                                SELECT a.StudentId,StudentName,isnull(StudentGradeId,0)StudentGradeId from Students a left outer join StudentGrades b on a.StudentId=b.StudentId
		                                where a.StudentId = @StudentId
                                    END");
            migrationBuilder.Sql(@"CREATE PROC usp_GetStudentGradeByStudentId
                                    @StudentId int
                                    AS 
                                    BEGIN 
	                                    select * from StudentGrades a inner join Students b on a.StudentId=b.StudentId
	                                    where a.StudentId=@StudentId
                                    END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
