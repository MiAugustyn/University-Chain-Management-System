using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University_Chain_Management_System.Data;
using University_Chain_Management_System.Models;

namespace University_Chain_Management_System.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DataContext _context;

        public EmployeeController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Employee> employees = _context.Employees.ToList();
            return View(employees);
        }
        
        public IActionResult Details(int id)
        {
            Employee employee = _context.Employees.Include(e => e.University).Include(u => u.Subjects)
                .FirstOrDefault(s => s.Id == id);

            return View(employee);
        }
    }
}
