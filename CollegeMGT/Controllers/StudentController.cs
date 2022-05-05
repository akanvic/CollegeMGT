using CollegeMGT.Core.Models;
using CollegeMGT.Core.View_Models;
using CollegeMGT.Core.Views;
using CollegeMGT.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeMGT.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;
        private readonly ISubjectService _subjectService;
        private readonly IGradeService _gradeService;
        private readonly IStudentGradeService _studentGradeService;


        [BindProperty]
        public StudentViewModel StudentVM { get; set; }

        [BindProperty]
        public RecordStudentGradeVm RecordStudentGradeVm { get; set; }
        public StudentController(IStudentService studentService, 
                                ICourseService courseService, 
                                ISubjectService subjectService, 
                                IGradeService gradeService,
                                IStudentGradeService studentGradeService)
        {
            _studentService = studentService;
            _courseService = courseService;
            _subjectService = subjectService;
            _gradeService = gradeService;
            _studentGradeService = studentGradeService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Upsert(int? id)
        {
            StudentViewModel studentVM = new StudentViewModel()
            {
                Student = new Student(),
                CourseList = _courseService.GetAllCourses().Result.Select(i => new SelectListItem
                {
                    Text = i.CourseName,
                    Value = i.CourseId.ToString()
                }),
            };
            if (id == null)
            {
                //this is for create
                return View(studentVM);
            }
            //this is for edit
            studentVM.Student = await _studentService.GetStudentById(id.GetValueOrDefault());
            if (studentVM.Student == null)
            {
                return NotFound();
            }
            return View(studentVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert()
        {
            if (ModelState.IsValid)
            {
                if (StudentVM.Student!.StudentId == 0)
                {
                    await _studentService.AddStudent(StudentVM);
                }
                else
                {
                    await _studentService.UpdateStudent(StudentVM);
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                StudentVM.CourseList = _courseService.GetAllCourses().Result.Select(i => new SelectListItem
                {
                    Text = i.CourseName,
                    Value = i.CourseId.ToString()
                });
                if (StudentVM.Student!.StudentId != 0)
                {
                    StudentVM.Student = await _studentService.GetStudentById(StudentVM.Student.StudentId);
                }
            }
            return View(StudentVM);
        }
        public async Task<IActionResult> RecordStudentGrade(int? id)
        {

            RecordStudentGradeVm studentVM = new RecordStudentGradeVm()
            {
                SubjectList = _subjectService.GetSubjectsByCourseId(_studentService.GetCourseIdByStudentId(id).Result).Result.Select(i => new SelectListItem
                {
                    Text = i.SubjectName,
                    Value = i.SubjectId.ToString()
                }),
                GradeList = _gradeService.GetAllGrades().Result.Select(i => new SelectListItem
                {
                    Text = i.GradeName,
                    Value = i.GradeId.ToString()
                }),
            };
            studentVM.StudentGradeVw = _studentService.GetStudentByStudentId(id).Result;
            if (studentVM.StudentGradeVw.StudentGradeId == 0)
            {
                //this is for create
                return View(studentVM);
            }
            //this is for edit
            studentVM.StudentGradeVw = await _studentGradeService.GetStudentGradeByStudentId(id.GetValueOrDefault());
            if (studentVM.StudentGradeVw == null)
            {
                return NotFound();
            }
            return View(studentVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RecordStudentGrade()
        {
            if (ModelState.IsValid)
            {
                if (RecordStudentGradeVm.StudentGradeVw!.StudentGradeId == 0)
                {
                    await _studentGradeService.AddStudentGrade(RecordStudentGradeVm);
                }
                else
                {
                    await _studentGradeService.UpdateStudentGrade(RecordStudentGradeVm);
                }
                return RedirectToAction(nameof(GetAllStudentGrades));
            }
            else
            {
                RecordStudentGradeVm.SubjectList = _subjectService.GetAllSubjects().Result.Select(i => new SelectListItem
                {
                    Text = i.SubjectName,
                    Value = i.SubjectId.ToString()
                });
                if (RecordStudentGradeVm.StudentGradeVw!.StudentId != 0)
                {
                    RecordStudentGradeVm.Student = await _studentService.GetStudentById(RecordStudentGradeVm.Student!.StudentId);
                }
            }
            return View(RecordStudentGradeVm);
        }
        
        public IActionResult GetAllStudentGrades()
        {
            return View();
        }
        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudents();
            return Json(new { data = students });
        }
        [HttpGet]
        public async Task<IActionResult> GetStudentGrades()
        {
            var studentGrades = await _studentGradeService.GetAllStudentGrades();
            return Json(new { data = studentGrades });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudentGrade(int id)
        {
            var student = await _studentGradeService.GetStudentGradeByStudentGradeId(id);

            if (student == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            await _studentGradeService.DeleteStudentGrade(id);
            return Json(new { success = true, message = "Delete Successful" });
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _studentService.GetStudentById(id);

            if (student == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            await _studentService.DeleteStudent(id);
            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion

    }
}
