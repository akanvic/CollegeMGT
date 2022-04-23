using CollegeMGT.Core.Models;
using CollegeMGT.Core.View_Models;
using CollegeMGT.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollegeMGT.Controllers
{
    public class StudentGradeController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ISubjectService _subjectService;
        private readonly IGradeService   _gradeService;
        private readonly IStudentGradeService _studentGradeService;


        [BindProperty]
        public StudentGradeViewModel StudentGradeVM { get; set; }
        public StudentGradeController(IStudentService studentService, ISubjectService subjectService, IGradeService gradeService, IStudentGradeService studentGradeService)
        {
            _studentService = studentService;
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
            StudentGradeViewModel studentGradeVM = new StudentGradeViewModel()
            {
                StudentGrade = new StudentGrade(),
                StudentList = _studentService.GetAllStudents().Result.Select(i => new SelectListItem
                {
                    Text = i.StudentName,
                    Value = i.StudentId.ToString()
                }),
                SubjectList = _subjectService.GetAllSubjects().Result.Select(i => new SelectListItem
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
            if (id == null)
            {
                //this is for create
                return View(studentGradeVM);
            }
            //this is for edit
            studentGradeVM.StudentGrade = await _studentGradeService.GetStudentGradeByStudentGradeId(id.GetValueOrDefault());
            if (studentGradeVM.StudentGrade == null)
            {
                return NotFound();
            }
            return View(studentGradeVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert()
        {
            if (ModelState.IsValid)
            {
                if (StudentGradeVM.StudentGrade.StudentGradeId == 0)
                {
                    await _studentGradeService.AddStudentGrade(StudentGradeVM);
                }
                else
                {
                    await _studentGradeService.UpdateStudentGrade(StudentGradeVM);
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                StudentGradeVM.StudentList = _studentService.GetAllStudents().Result.Select(i => new SelectListItem
                {
                    Text = i.StudentName,
                    Value = i.StudentId.ToString()
                });
                StudentGradeVM.SubjectList = _subjectService.GetSubjectsByCourseId(StudentGradeVM.StudentGrade.Student.CourseId).Result.Select(i => new SelectListItem
                {
                    Text = i.SubjectName,
                    Value = i.SubjectId.ToString()
                });
                StudentGradeVM.GradeList = _gradeService.GetAllGrades().Result.Select(i => new SelectListItem
                {
                    Text = i.GradeName,
                    Value = i.GradeId.ToString()
                });
                if (StudentGradeVM.StudentGrade.StudentGradeId != 0)
                {
                    StudentGradeVM.StudentGrade = await _studentGradeService.GetStudentGradeByStudentGradeId(StudentGradeVM.StudentGrade.StudentGradeId);
                }
            }
            return View(StudentGradeVM);
        }

        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAllStudentGrades()
        {
            var studentGrades = await _studentGradeService.GetAllStudentGrades();
            return Json(new { data = studentGrades });
        }

        //[HttpDelete]
        //public IActionResult Delete(int id)
        //{
        //    var objFromDb = _unitOfWork.Product.Get(id);
        //    if (objFromDb == null)
        //    {
        //        return Json(new { success = false, message = "Error while deleting" });
        //    }
        //    string webRootPath = _hostEnvironment.WebRootPath;
        //    var imagePath = Path.Combine(webRootPath, objFromDb.ImageUrl.TrimStart('\\'));
        //    if (System.IO.File.Exists(imagePath))
        //    {
        //        System.IO.File.Delete(imagePath);
        //    }
        //    _unitOfWork.Product.Remove(objFromDb);
        //    _unitOfWork.Save();
        //    return Json(new { success = true, message = "Delete Successful" });
        //}
        #endregion

    }
}
