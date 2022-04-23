using CollegeMGT.Core.Models;
using CollegeMGT.Core.View_Models;
using CollegeMGT.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollegeMGT.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;

        [BindProperty]
        public StudentViewModel StudentVM { get; set; }
        public StudentController(IStudentService studentService, ICourseService courseService)
        {
            _studentService = studentService;
            _courseService = courseService;
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
                })
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
                if (StudentVM.Student.StudentId == 0)
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
                if (StudentVM.Student.StudentId != 0)
                {
                    StudentVM.Student = await _studentService.GetStudentById(StudentVM.Student.StudentId);
                }
            }
            return View(StudentVM);
        }

        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudents();
            return Json(new { data = students });
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
