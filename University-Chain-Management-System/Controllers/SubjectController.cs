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
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentMajorRepository _studentMajorRepository;

       public SubjectController(ISubjectRepository subjectRepository, 
            IEmployeeRepository employeeRepository, 
            IMajorRepository majorRepository,
            IStudentRepository studentRepository,
            IStudentMajorRepository studentMajorRepository)
        {
            _subjectRepository = subjectRepository;
            _employeeRepository = employeeRepository;
            _majorRepository = majorRepository;
            _studentRepository = studentRepository;
            _studentMajorRepository = studentMajorRepository;
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
                ModelState.AddModelError("", "Fill all fields with valid data.");
                return View(viewModel);
            }

            _subjectRepository.Add(subject);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Subject subject = await _subjectRepository.GetById(id);

            if (subject == null) { return View("Error"); }

            IEnumerable<Employee> employees = await _employeeRepository.GetAll();
            IEnumerable<Major> majors = await _majorRepository.GetAll();

            SubjectViewModel viewModel = new SubjectViewModel()
            {
                Subject = subject,
                Majors = majors,
                Employees = employees
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Subject subject)
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
                ModelState.AddModelError("", "Fill all fields with valid data.");
                return View(viewModel);
            }

            _subjectRepository.Update(subject);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Subject subject = await _subjectRepository.GetById(id);

            if (subject == null) { return View("Error"); }

            IEnumerable<Employee> employees = await _employeeRepository.GetAll();
            IEnumerable<Major> majors = await _majorRepository.GetAll();

            SubjectViewModel viewModel = new SubjectViewModel()
            {
                Subject = subject,
                Majors = majors,
                Employees = employees
            };

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            Subject subject = await _subjectRepository.GetById(id);

            if (subject == null) { return View("Error"); }

            _subjectRepository.Delete(subject);
            return RedirectToAction("Index");
        }

        [HttpGet]
        // Get students enrolled in a major containing subject.
        // Use currentStudentId to display current student as first option (for edit views)
        public async Task<IActionResult> GetAvailableStudents(int subjectId, int? currentStudentId = null)
        {
            var subject = await _subjectRepository.GetById(subjectId);

            if (subject?.Major == null){ return Json(new List<object>()); }

            var enrolledStudents = (await _studentMajorRepository.GetByMajorId(subject.MajorId.Value))
                .Select(sm => new { Id = sm.Student.Id, FullName = sm.Student.FullName }).ToList();

            if (currentStudentId == null) { return Json(enrolledStudents); }

            var currentStudent = await _studentRepository.GetById(currentStudentId.Value);
            if (currentStudent != null) { enrolledStudents.Insert(1, new { Id = currentStudent.Id, FullName = currentStudent.FullName }); }

            return Json(enrolledStudents);
        }
    }
}
