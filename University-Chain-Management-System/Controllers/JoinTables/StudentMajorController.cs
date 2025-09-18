using Microsoft.AspNetCore.Mvc;
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
            if (!ModelState.IsValid)
            {
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

            _studentMajorRepository.Add(studentMajor);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            StudentMajor studentMajor = await _studentMajorRepository.GetById(id);
            IEnumerable<Student> students = await _studentRepository.GetAll();
            IEnumerable<Major> majors = await _majorRepository.GetAll();

            StudentMajorViewModel viewModel = new StudentMajorViewModel()
            {
                StudentMajor = studentMajor,
                Students = students,
                Majors = majors
            };

            if (studentMajor == null) { return View("Error"); }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudentMajor studentMajor)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<Student> students = await _studentRepository.GetAll();
                IEnumerable<Major> majors = await _majorRepository.GetAll();

                StudentMajorViewModel viewModel = new StudentMajorViewModel()
                {
                    StudentMajor = studentMajor,
                    Students = students,
                    Majors = majors
                };

                ModelState.AddModelError("", "Failed to edit");
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
    }
}
