using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using University_Chain_Management_System.Interfaces;
using University_Chain_Management_System.Models;
using University_Chain_Management_System.Models.ViewModels;
using University_Chain_Management_System.Repositories;

namespace University_Chain_Management_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INotificationRepository _notificationRepository;
        private readonly IGradeRepository _gradeRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(ILogger<HomeController> logger, 
            INotificationRepository notificationRepository, 
            IGradeRepository gradeRepository, 
            IStudentRepository studentRepository, 
            IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _notificationRepository = notificationRepository;
            _gradeRepository = gradeRepository;
            _studentRepository = studentRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Notification> latestNotifications = await _notificationRepository.GetLatest(5);
            IEnumerable<Grade> thisYearGrades = await _gradeRepository.GetByYear(DateTime.Now.Year);
            IEnumerable<Grade> lastYearGrades = await _gradeRepository.GetByYear(DateTime.Now.Year - 1);
            IEnumerable<Employee> thisYearEmployees = await _employeeRepository.GetByYear(DateTime.Now.Year);
            IEnumerable<Employee> lastYearEmployees = await _employeeRepository.GetByYear(DateTime.Now.Year - 1);
            IEnumerable<Student> thisYearEnrolledStudents = await _studentRepository.GetEnrolledByYear(DateTime.Now.Year);
            IEnumerable<Student> lastYearEnrolledStudents = await _studentRepository.GetEnrolledByYear(DateTime.Now.Year - 1);
            IEnumerable<Student> thisYearGraduatedStudents = await _studentRepository.GetEnrolledByYear(DateTime.Now.Year);
            IEnumerable<Student> lastYearGraduatedStudents = await _studentRepository.GetEnrolledByYear(DateTime.Now.Year - 1);

            float? gradesAverageThisYear = thisYearGrades?.Any() == true
                ? thisYearGrades.Average(g => g.Value)
                : null;

            float? gradesAverageLastYear = lastYearGrades?.Any() == true
                ? lastYearGrades.Average(g => g.Value)
                : null;

            HomeViewModel homeViewModel = new HomeViewModel()
            {
                GradesAverageThisYear = gradesAverageThisYear,
                GradesAverageLastYear = gradesAverageLastYear,
                EmployeesShift = thisYearEmployees?.Count() - lastYearEmployees?.Count(),
                EnrolledStudentsShift = thisYearEnrolledStudents?.Count() - lastYearEnrolledStudents?.Count(),
                GraduatedStudentsShift = thisYearGraduatedStudents?.Count() - lastYearGraduatedStudents?.Count(),
                Notifications = latestNotifications
            };

            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
