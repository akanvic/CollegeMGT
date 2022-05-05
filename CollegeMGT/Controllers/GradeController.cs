using CollegeMGT.Core.Dtos;
using CollegeMGT.Core.Models;
using CollegeMGT.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CollegeMGT.Controllers
{
    public class GradeController : Controller
    {
        private readonly IGradeService _gradeService;
        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> Upsert(int? id)
        {
            var grade = new Grade();

            if (id == null)
            {
                //For Create
                return View(grade);
            }

            //This is for edit
            grade = await _gradeService.GetGradeById(id.GetValueOrDefault());//This Id could be null so we use the GetValueOrDefault method

            if (grade == null)
            {
                return NotFound();
            }
            return View(grade);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(GradeDto gradeDto)
        {
            if (ModelState.IsValid)
            {
                if (gradeDto.GradeId == 0)
                {
                    await _gradeService.AddGrade(gradeDto);
                }
                else
                {
                    await _gradeService.UpdateGrade(gradeDto);
                }
                return RedirectToAction(nameof(Index));
            }

            return View(gradeDto);
        }

        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAllGrades()
        {
            var grades = await _gradeService.GetAllGrades();
            return Json(new { data = grades });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            var grade = await _gradeService.GetGradeById(id);

            if (grade == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            await _gradeService.DeleteGrade(id);
            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion
    }
}
