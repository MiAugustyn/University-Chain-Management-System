using Microsoft.AspNetCore.Mvc;
using System.Linq;
using University_Chain_Management_System.Models;
using University_Chain_Management_System.Models.JoinTables;
using University_Chain_Management_System.Models.ViewModels;
using University_Chain_Management_System.Repositories;

namespace University_Chain_Management_System.Controllers.JoinTables
{
    public class StudentMajorController : Controller
    {
        private readonly IStudentMajorRepository _studentMajorRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IMajorRepository _majorRepository;

        public StudentMajorController(IStudentMajorRepository studentMajorRepository, IStudentRepository studentRepository, IMajorRepository majorRepository)
        {
            _studentMajorRepository = studentMajorRepository;
            _studentRepository = studentRepository;
            _majorRepository = majorRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<StudentMajor> studentsMajors = await _studentMajorRepository.GetAll();

            return View(studentsMajors);
        }

        [NonAction]
        private async Task<IActionResult> Index(IEnumerable<StudentMajor> studentsMajors)
        {
            return View(studentsMajors);
        }

        [HttpGet("StudentMajor/ByStudentId/{id:int}")]
        public async Task<IActionResult> StudentIndex(int id)
        {
            IEnumerable<StudentMajor> studentsMajors = await _studentMajorRepository.GetByStudentId(id);

            return await Index(studentsMajors);
        }

        [HttpGet("StudentMajor/ByMajorId/{id:int}")]
        public async Task<IActionResult> MajorIndex(int id)
        {
            IEnumerable<StudentMajor> studentsMajors = await _studentMajorRepository.GetByMajorId(id);

            return await Index(studentsMajors);
        }

        public async Task<IActionResult> Details(int id)
        {
            StudentMajor studentsMajors = await _studentMajorRepository.GetById(id);

            return View(studentsMajors);
        }

        public async Task<IActionResult> Create()
        {
            IEnumerable<Student> students = await _studentRepository.GetAll();
            IEnumerable<Major> majors = await _majorRepository.GetAll();

            StudentMajorViewModel viewModel = new StudentMajorViewModel()
            {
                StudentMajor = new StudentMajor(),
                Students = students,
                Majors = majors
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentMajor studentMajor)
        {
            IEnumerable<Student> students = await _studentRepository.GetAll();
            IEnumerable<Major> majors = await _majorRepository.GetAll();

            StudentMajorViewModel viewModel = new StudentMajorViewModel()
            {
                StudentMajor = studentMajor,
                Students = students,
                Majors = majors
            };


            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Fill all fields with valid data.");
                return View(viewModel);
            }

            if (studentMajor.EnrollmentDate >= studentMajor.GraduationDate)
            {
                ModelState.AddModelError("StudentMajor.GraduationDate", "Graduation date must occur after enrollment date.");
                return View("Create", viewModel);
            }

            _studentMajorRepository.Add(studentMajor);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            StudentMajor studentMajor = await _studentMajorRepository.GetById(id);

            if (studentMajor == null) { return View("Error"); }

            IEnumerable<Student> students = await _studentRepository.GetAll();
            IEnumerable<Major> majors = await _majorRepository.GetAll();

            StudentMajorViewModel viewModel = new StudentMajorViewModel()
            {
                StudentMajor = studentMajor,
                Students = students,
                Majors = majors
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudentMajor studentMajor)
        {
            IEnumerable<Student> students = await _studentRepository.GetAll();
            IEnumerable<Major> majors = await _majorRepository.GetAll();

            StudentMajorViewModel viewModel = new StudentMajorViewModel()
            {
                StudentMajor = studentMajor,
                Students = students,
                Majors = majors
            };

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Fill all fields with valid data.");
                return View("Edit", viewModel);
            }

            if (studentMajor.EnrollmentDate >= studentMajor.GraduationDate)
            {
                ModelState.AddModelError("StudentMajor.GraduationDate", "Graduation date must occur after enrollment date.");
                return View("Edit", viewModel);
            }

            _studentMajorRepository.Update(studentMajor);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            StudentMajor studentMajor = await _studentMajorRepository.GetById(id);

            if (studentMajor == null) { return View("Error"); }

            return View(studentMajor);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteStudentMajor(int id)
        {
            StudentMajor studentMajor = await _studentMajorRepository.GetById(id);

            if (studentMajor == null) { return View("Error"); }

            _studentMajorRepository.Delete(studentMajor);

            return RedirectToAction("Index");
        }

        [HttpGet]
        // Get students not enrolled in a major.
        // Use currentStudentId to display current student as first option (for edit views)
        public async Task<IActionResult> GetAvailableStudents(int majorId, int? currentStudentId = null)
        {
            var enrolledStudentIds = (await _studentMajorRepository.GetByMajorId(majorId))
                .Select(sm => sm.StudentId)
                .ToList();

            var availableStudents = (await _studentRepository.GetAll())
                .Where(s => !enrolledStudentIds.Contains(s.Id) || (currentStudentId.HasValue && s.Id == currentStudentId.Value))
                .Select(s => new { s.Id, s.FullName })
                .ToList();

            return Json(availableStudents);
        }
    }
}
