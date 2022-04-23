using CollegeMGT.Core.Dtos;
using CollegeMGT.Core.Models;
using CollegeMGT.Core.View_Models;
using CollegeMGT.Service.Interface;
using Microsoft.AspNetCore.Mvc;
//using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollegeMGT.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectService _subjectService;
        private readonly ICourseService _courseService;
        private readonly ITeacherService _teacherService;

        [BindProperty]
        public SubjectViewModel SubjectVM { get; set; }

        [BindProperty]
        public AddTeacherToSubjectVm AddTeacherToSubjectVm { get; set; }
        public SubjectController(ISubjectService subjectService, ICourseService courseService, ITeacherService teacherService)
        {
            _subjectService = subjectService;
            _courseService = courseService;
            _teacherService = teacherService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Upsert(int? id)
        {
            SubjectViewModel subjectVM = new SubjectViewModel()
            {
                Subject = new Subject(),
                CourseList = _courseService.GetAllCourses().Result.Select(i => new SelectListItem
                {
                    Text = i.CourseName,
                    Value = i.CourseId.ToString()
                }),
                TeacherList = _teacherService.GetAllTeacher().Result.Select(i => new SelectListItem
                {
                    Text = i.TeacherName,
                    Value = i.TeacherId.ToString()
                })
            };
            if (id == null)
            {
                //this is for create
                return View(subjectVM);
            }
            //this is for edit
            subjectVM.Subject = await _subjectService.GetSubjectById(id.GetValueOrDefault());
            if (subjectVM.Subject == null)
            {
                return NotFound();
            }
            return View(subjectVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert()
        {
            if (ModelState.IsValid)
            {
                if (SubjectVM.Subject.SubjectId == 0)
                {
                    await _subjectService.AddSubject(SubjectVM);
                }
                else
                {
                    await _subjectService.UpdateSubject(SubjectVM);
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                SubjectVM.CourseList = _courseService.GetAllCourses().Result.Select(i => new SelectListItem
                {
                    Text = i.CourseName,
                    Value = i.CourseId.ToString()
                });
                SubjectVM.TeacherList = _teacherService.GetAllTeacher().Result.Select(i => new SelectListItem
                {
                    Text = i.TeacherName,
                    Value = i.TeacherId.ToString()
                });
                if (SubjectVM.Subject.SubjectId != 0)
                {
                    SubjectVM.Subject = await _subjectService.GetSubjectById(SubjectVM.Subject.SubjectId);
                }
            }
            return View(SubjectVM);
        }


        public async Task<IActionResult> AddTeacherToSubject(int? id)
        {
            AddTeacherToSubjectVm addTeacherToSubjectVM = new AddTeacherToSubjectVm()
            {
                Subject = new Subject(),
                TeacherList = _teacherService.GetAvailableTeachers(_subjectService.GetCourseIdBySubjectId(id).Result).Result.Select(i => new SelectListItem
                {
                    Text = i.TeacherName,
                    Value = i.TeacherId.ToString()
                })
            };
            //this is for edit
            addTeacherToSubjectVM.Subject = await _subjectService.GetSubjectById(id.GetValueOrDefault());
            if (addTeacherToSubjectVM.Subject == null)
            {
                return NotFound();
            }
            return View(addTeacherToSubjectVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTeacherToSubject()
        {
            if (ModelState.IsValid)
            {
                await _subjectService.AddTeacherToSubject(AddTeacherToSubjectVm);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                AddTeacherToSubjectVm.TeacherList = _teacherService.GetAvailableTeachers(AddTeacherToSubjectVm.Subject.CourseId).Result.Select(i => new SelectListItem
                {
                    Text = i.TeacherName,
                    Value = i.TeacherId.ToString()
                });
                if (SubjectVM.Subject.SubjectId != 0)
                {
                    SubjectVM.Subject = await _subjectService.GetSubjectById(SubjectVM.Subject.SubjectId);
                }
            }
            return View(AddTeacherToSubjectVm);
        }

        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAllSubjects()
        {
            var subjects = await _subjectService.GetAllSubjects();
            return Json(new { data = subjects });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var subject = await _subjectService.GetSubjectById(id);

            if (subject == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            await _subjectService.DeleteSubject(id);
            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion
    }
}
