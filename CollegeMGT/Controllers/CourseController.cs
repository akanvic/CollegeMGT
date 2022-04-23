using CollegeMGT.Core.Dtos;
using CollegeMGT.Core.Models;
using CollegeMGT.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CollegeMGT.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [BindProperty]
        public CourseDto CourseDto { get; set; }
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> AddCourse(int? id)
        {
            var course = new Course();

            if (id == null)
            {
                //For Create
                return View(course);
            }

            //This is for edit
            course = await _courseService.GetCourseById(id.GetValueOrDefault());//This Id could be null so we use the GetValueOrDefault method

            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCourse()
        {
            if (ModelState.IsValid)
            {
                if (CourseDto.CourseId == 0)
                {
                    await _courseService.AddCourse(CourseDto);
                }
                else
                {
                    await _courseService.UpdateCourse(CourseDto);
                }
                return RedirectToAction(nameof(Index));
            }

            return View(CourseDto);
        }

        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _courseService.GetAllCourses();
            return Json(new { data = courses });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _courseService.GetCourseById(id);

            if (course == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            await _courseService.DeleteCourse(id);
            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion
    }
}
