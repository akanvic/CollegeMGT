using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeMGT.Repo.Migrations
{
    public partial class InitializeDBWithTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"insert into Courses(CourseName)
                                    Values('Computer Science'),
                                    ('Micro Biology'),
                                    ('Mass Communication'),
                                    ('Petroleum Engineering'),
                                    ('Software Engineering')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
