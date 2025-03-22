using Microsoft.AspNetCore.Mvc;
using University_Chain_Management_System.Models;
using University_Chain_Management_System.Models.ViewModels;
using University_Chain_Management_System.Repositories;

namespace University_Chain_Management_System.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMajorRepository _majorRepository;

        public SubjectController(ISubjectRepository subjectRepository, 
            IEmployeeRepository employeeRepository, IMajorRepository majorRepository)
        {
            _subjectRepository = subjectRepository;
            _employeeRepository = employeeRepository;
            _majorRepository = majorRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Subject> subjects = await _subjectRepository.GetAll();

            return View(subjects);
        }

        public async Task<IActionResult> Details(int id)
        {
            Subject subject = await _subjectRepository.GetById(id);
            return View(subject);
        }

        public async Task<IActionResult> Create()
        {
            IEnumerable<Employee> employees = await _employeeRepository.GetAll();
            IEnumerable<Major> majors = await _majorRepository.GetAll();

            SubjectViewModel viewModel = new SubjectViewModel()
            {
                Subject = new Subject(),
                Majors = majors,
                Employees = employees
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Subject subject)
        {

            IEnumerable<Employee> employees = await _employeeRepository.GetAll();
            IEnumerable<Major> majors = await _majorRepository.GetAll();

            SubjectViewModel viewModel = new SubjectViewModel()
            {
                Subject = subject,
                Majors = majors,
                Employees = employees
            };

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            _subjectRepository.Add(subject);
            return RedirectToAction("Index");
        }
    }
}
