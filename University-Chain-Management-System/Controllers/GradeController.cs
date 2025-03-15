using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University_Chain_Management_System.Data;
using University_Chain_Management_System.Models;

namespace University_Chain_Management_System.Controllers
{
    public class GradeController : Controller
    {
        private readonly DataContext _context;

        public GradeController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Grade> grades = _context.Grades.Include(g => g.Student).Include(g => g.Subject).ToList();

            return View(grades);
        }

        public IActionResult Details(int id)
        {
            Grade grade = _context.Grades.Include(g => g.Student).Include(g => g.Subject)
                .FirstOrDefault(g => g.Id == id);

            return View(grade);
        }
    }
}
