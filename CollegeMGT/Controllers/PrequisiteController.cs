using CollegeMGT.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CollegeMGT.Controllers
{
    public class PrequisiteController : Controller
    {
        private readonly IPrequisiteService _prequisiteService;
        public PrequisiteController(IPrequisiteService prequisiteService)
        {
            _prequisiteService = prequisiteService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetStudentsAndRespectiveGradesVw()
        {
            return View();
        }
        public IActionResult GetCoursesAndNoOfTeachersAnStudentsVw()
        {
            return View();
        }


        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetSubjectsAndTeacherInformation()
        {
            var serviceResponse = await _prequisiteService.GetSubjectsAndTeacherInformation();
            return Json(new { data = serviceResponse });
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentsAndRespectiveGrades()
        {
            var serviceResponse = await _prequisiteService.GetStudentsAndRespectiveGrades();
            return Json(new { data = serviceResponse });
        }

        [HttpGet]
        public async Task<IActionResult> GetCoursesAndNoOfTeachersAnStudents()
        {
            var serviceResponse = await _prequisiteService.GetCoursesAndNoOfTeachersAnStudents();
            return Json(new { data = serviceResponse });
        }
        #endregion
    }
}
