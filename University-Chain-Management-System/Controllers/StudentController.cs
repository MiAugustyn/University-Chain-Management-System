using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University_Chain_Management_System.Models;
using University_Chain_Management_System.Models.ViewModels;
using University_Chain_Management_System.Repositories;

namespace University_Chain_Management_System.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Student> students = await _studentRepository.GetAll();

            return View(students);
        }

        public async Task<IActionResult> Details(int id)
        {
            Student student = await _studentRepository.GetById(id);

            if (student == null) { return View("Error"); }

            StudentViewModel viewModel = await _studentRepository.GetViewModelById(id);

            return View(viewModel);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Fill all fields with valid data.");
                return View(student);
            }

            _studentRepository.Add(student);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Student student = await _studentRepository.GetById(id);

            if (student == null) { return View("Error");  }

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Fill all fields with valid data.");
                return View(student);
            }

            _studentRepository.Update(student);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Student student = await _studentRepository.GetById(id);

            if (student == null) { return View("Error"); }

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            Student student = await _studentRepository.GetById(id);

            if (student == null) { return View("Error"); }

            _studentRepository.Delete(student);
            return RedirectToAction("Index");
        }
    }
}
