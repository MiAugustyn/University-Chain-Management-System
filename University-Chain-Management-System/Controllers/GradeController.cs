using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using University_Chain_Management_System.Models;
using University_Chain_Management_System.Models.ViewModels;
using University_Chain_Management_System.Repositories;
using University_Chain_Management_System.Repository;

namespace University_Chain_Management_System.Controllers
{
    public class GradeController : Controller
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly ISubjectRepository _subjectRepository;

        public GradeController(IGradeRepository gradeRepository, ISubjectRepository subjectRepository )
        {
            _gradeRepository = gradeRepository;
            _subjectRepository = subjectRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Grade> grades = await _gradeRepository.GetAll();

            return View(grades);
        }

        public async Task<IActionResult> Details(int id)
        {
            Grade grade = await _gradeRepository.GetById(id);

            if (grade == null) { return View("Error"); }

            return View(grade);
        }

        public async Task<IActionResult> Create()
        {
            IEnumerable<Subject> subjects = await _subjectRepository.GetSubjectsWithAssignedUniversities();

            GradeViewModel viewModel = new GradeViewModel()
            {
                Grade = new Grade(),
                Subjects = subjects
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Grade grade)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Fill all fields with valid data.");

                IEnumerable<Subject> subjects = await _subjectRepository.GetSubjectsWithAssignedUniversities();

                GradeViewModel viewModel = new GradeViewModel()
                {
                    Grade = grade,
                    Subjects = subjects
                };

                return View(viewModel);
            }

            _gradeRepository.Add(grade);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Grade grade = await _gradeRepository.GetById(id);

            if (grade == null) { return View("Error"); }

            IEnumerable<Subject> subjects = await _subjectRepository.GetSubjectsWithAssignedUniversities();

            GradeViewModel viewModel = new GradeViewModel()
            {
                Grade = grade,
                Subjects = subjects,
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Grade grade)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Fill all fields with valid data.");

                IEnumerable<Subject> subjects = await _subjectRepository.GetSubjectsWithAssignedUniversities();

                GradeViewModel viewModel = new GradeViewModel()
                {
                    Grade = grade,
                    Subjects = subjects
                };

                return View(viewModel);
            }

            _gradeRepository.Update(grade);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Grade grade = await _gradeRepository.GetById(id);

            if (grade == null) { return View("Error"); }

            return View(grade);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            Grade grade = await _gradeRepository.GetById(id);

            if (grade == null) { return View("Error"); }

            _gradeRepository.Delete(grade);
            return RedirectToAction("Index");
        }
    }
}
