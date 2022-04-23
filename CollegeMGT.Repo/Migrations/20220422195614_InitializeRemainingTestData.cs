using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeMGT.Repo.Migrations
{
    public partial class InitializeRemainingTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                            insert into Teachers(TeacherName,TeacherBirthDate,TeacherSalary)

                            Values
                            ('Dr Phil','1985-11-16',400000),
                            ('Dr Sheldon Cooper','1990-03-16',600000),
                            ('Dr Leonard Hoftstarder','1980-10-02',300000),
                            ('Howard Wolowits','1988-04-16',700000),
                            ('Dr Amy Farer Fowler','1995-01-16',600000),
                            ('Dr Benedette','1996-02-14',2000000),
                            ('Dr Raj Kotrapali','1989-11-11',500000)
                                ");
            migrationBuilder.Sql(@"
                                insert into Subjects(SubjectName,CourseId,TeacherId)
                                VALUES
                                    (
                                        'Numerical Computing',
                                        1,
                                        1
                                    ),
                                	('Data Structures',1,2),
                                	('Algorithm',1,3),
                                	('Anatomy',2,1),
                                	('Agriculture',2,2),
                                	('Social Influence',3,1),
                                	('Linear Alegbra',5,3)
                                ");

            migrationBuilder.Sql(@"
                            insert into Students(StudentName,StudentBirthDate,StudentRegistrationNumber,CourseId)

                            Values
                            ('Akaninyene Uwah','1999-11-16','REG345226735',1),
                            ('Clementine Jesse','2000-03-16','REG343176905',1),
                            ('Edosa Kelvin','2001-10-02','REG744726589',1),
                            ('Chude Okechukwu','1998-04-16','REG745766581',2),
                            ('Samira Baba','2002-01-16','REG524716583', 2),
                            ('Maryanne Iduh','2006-02-14','REG124724582',3),
                            ('Joachim Onyebuagu','2001-11-11','REG774326585',3)");

            migrationBuilder.Sql(@"
                            insert into Grades(GradeName,GradeValue)

                            Values
                            ('A',70),
                            ('B', 60),
                            ('C', 50),
                            ('D', 40),
                            ('E', 30),
                            ('F', 20)");

            migrationBuilder.Sql(@"
                     insert into StudentGrades(StudentId,SubjectId,GradeId)
                            
                            Values
                            (1,1,1),
                            (2,2,2),
                            (3,2,3),
                            (4,4,4),
                            (5,5,5),
                            (1,2,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
