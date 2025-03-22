using Microsoft.AspNetCore.Mvc;
using University_Chain_Management_System.Models;
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

            return View(student);
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
                return View();
            }

            _studentRepository.Add(student);
            return RedirectToAction("Index");
        }
    }
}
