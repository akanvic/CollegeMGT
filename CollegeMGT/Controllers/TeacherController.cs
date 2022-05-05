using CollegeMGT.Core.Models;
using CollegeMGT.Core.View_Models;
using CollegeMGT.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeMGT.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly ICourseService _courseService;

        [BindProperty]
        public TeacherViewModel TeacherVM { get; set; }
        public TeacherController(ITeacherService teacherService, ICourseService courseService)
        {
            _teacherService = teacherService;
            _courseService = courseService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Upsert(int? id)
        {
            TeacherViewModel teacherVM = new TeacherViewModel()
            {
                Teacher = new Teacher(),
                CourseList = _courseService.GetAllCourses().Result.Select(i => new SelectListItem
                {
                    Text = i.CourseName,
                    Value = i.CourseId.ToString()
                })
            };
            if (id == null)
            {
                //this is for create
                return View(teacherVM);
            }
            //this is for edit
            teacherVM.Teacher = await _teacherService.GetTeacherById(id.GetValueOrDefault());
            if (teacherVM.Teacher == null)
            {
                return NotFound();
            }
            return View(teacherVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert()
        {
            if (ModelState.IsValid)
            {
                if (TeacherVM.Teacher.TeacherId == 0)
                {
                    await _teacherService.AddTeacher(TeacherVM);
                }
                else
                {
                    await _teacherService.UpdateTeacher(TeacherVM);
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TeacherVM.CourseList = _teacherService.GetAllTeacher().Result.Select(i => new SelectListItem
                {
                    Text = i.TeacherName,
                    Value = i.TeacherId.ToString()
                });
                if (TeacherVM.Teacher.TeacherId != 0)
                {
                    TeacherVM.Teacher = await _teacherService.GetTeacherById(TeacherVM.Teacher.TeacherId);
                }
            }
            return View(TeacherVM);
        }

        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAllTeachers()
        {
            var teachers = await _teacherService.GetAllTeacher();
            return Json(new { data = teachers });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var teacher = await _teacherService.GetTeacherById(id);

            if (teacher == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            await _teacherService.DeleteTeacher(id);
            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion
    }
}
