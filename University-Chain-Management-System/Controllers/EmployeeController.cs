using Microsoft.AspNetCore.Mvc;
using University_Chain_Management_System.Models;
using University_Chain_Management_System.Models.ViewModels;
using University_Chain_Management_System.Repositories;

namespace University_Chain_Management_System.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUniversityRepository _universityRepository;
        private readonly IPositionRepository _positionRepository;

        public EmployeeController(IEmployeeRepository employeeRepository, 
            IUniversityRepository universityRepository, IPositionRepository positionRepository)
        {
            _employeeRepository = employeeRepository;
            _universityRepository = universityRepository;
            _positionRepository = positionRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Employee> employees = await _employeeRepository.GetAll();

            return View(employees);
        }
        
        public async Task<IActionResult> Details(int id)
        {
            Employee employee = await _employeeRepository.GetById(id);

            if (employee == null) { return View("Error"); }

            return View(employee);
        }

        public async Task<IActionResult> Create()
        {
            IEnumerable<University> universities = await _universityRepository.GetAll();
            IEnumerable<Position> positions = await _positionRepository.GetAll();

            EmployeeViewModel viewModel = new EmployeeViewModel()
            {
                Employee = new Employee(),
                Universities = universities,
                Positions = positions
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Fill all fields with valid data.");

                IEnumerable<University> universities = await _universityRepository.GetAll();
                IEnumerable<Position> positions = await _positionRepository.GetAll();

                EmployeeViewModel viewModel = new EmployeeViewModel()
                {
                    Employee = employee,
                    Universities = universities,
                    Positions = positions
                };

                return View(viewModel);
            }

            _employeeRepository.Add(employee);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Employee employee = await _employeeRepository.GetById(id);

            if (employee == null) { return View("Error"); }

            IEnumerable<University> universities = await _universityRepository.GetAll();
            IEnumerable<Position> positions = await _positionRepository.GetAll();

            EmployeeViewModel viewModel = new EmployeeViewModel()
            {
                Employee = employee,
                Universities = universities,
                Positions = positions
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {


            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Fill all fields with valid data.");

                IEnumerable<University> universities = await _universityRepository.GetAll();
                IEnumerable<Position> positions = await _positionRepository.GetAll();

                EmployeeViewModel viewModel = new EmployeeViewModel()
                {
                    Employee = employee,
                    Universities = universities,
                    Positions = positions
                };

                return View(viewModel);
            }

            _employeeRepository.Update(employee);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Employee employee = await _employeeRepository.GetById(id);

            if (employee == null) { return View("Error"); }

            IEnumerable<University> universities = await _universityRepository.GetAll();
            IEnumerable<Position> positions = await _positionRepository.GetAll();

            EmployeeViewModel viewModel = new EmployeeViewModel()
            {
                Employee = employee,
                Universities = universities,
                Positions = positions
            };

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            Employee employee = await _employeeRepository.GetById(id);

            if (employee == null) { return View("Error"); }

            _employeeRepository.Delete(employee);
            return RedirectToAction("Index");
        }
    }
}
