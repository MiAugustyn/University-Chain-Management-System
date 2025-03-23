using Microsoft.AspNetCore.Mvc;
using University_Chain_Management_System.Models;
using University_Chain_Management_System.Models.ViewModels;
using University_Chain_Management_System.Repositories;
using University_Chain_Management_System.Repository;

namespace University_Chain_Management_System.Controllers
{
    public class GradeController : Controller
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ISubjectRepository _subjectRepository;

        public GradeController(IGradeRepository gradeRepository, 
            IStudentRepository studentRepository, ISubjectRepository subjectRepository )
        {
            _gradeRepository = gradeRepository;
            _studentRepository = studentRepository;
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

            return View(grade);
        }

        public async Task<IActionResult> Create()
        {
            IEnumerable<Student> students = await _studentRepository.GetAll();
            IEnumerable<Subject> subjects = await _subjectRepository.GetAll();

            GradeViewModel viewModel = new GradeViewModel()
            {
                Grade = new Grade(),
                Students = students,
                Subjects = subjects
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Grade grade)
        {
            IEnumerable<Student> students = await _studentRepository.GetAll();
            IEnumerable<Subject> subjects = await _subjectRepository.GetAll();

            GradeViewModel viewModel = new GradeViewModel()
            {
                Grade = grade,
                Students = students,
                Subjects = subjects
            };

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            _gradeRepository.Add(grade);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Grade grade = await _gradeRepository.GetById(id);

            if (grade == null) { return View("Error"); }

            IEnumerable<Student> students = await _studentRepository.GetAll();
            IEnumerable<Subject> subjects = await _subjectRepository.GetAll();

            GradeViewModel viewModel = new GradeViewModel()
            {
                Grade = grade,
                Students = students,
                Subjects = subjects
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Grade grade)
        {
            IEnumerable<Student> students = await _studentRepository.GetAll();
            IEnumerable<Subject> subjects = await _subjectRepository.GetAll();

            GradeViewModel viewModel = new GradeViewModel()
            {
                Grade = grade,
                Students = students,
                Subjects = subjects
            };

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit");
                return View("Edit", viewModel);
            }

            _gradeRepository.Update(grade);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Grade grade = await _gradeRepository.GetById(id);

            if (grade == null) { return View("Error"); }

            IEnumerable<Student> students = await _studentRepository.GetAll();
            IEnumerable<Subject> subjects = await _subjectRepository.GetAll();

            GradeViewModel viewModel = new GradeViewModel()
            {
                Grade = grade,
                Students = students,
                Subjects = subjects
            };

            return View(viewModel);
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
