using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University_Chain_Management_System.Data;
using University_Chain_Management_System.Models;

namespace University_Chain_Management_System.Controllers
{
    public class SubjectController : Controller
    {
        private readonly DataContext _context;

        public SubjectController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Subject> subjects = _context.Subjects.ToList();
            return View(subjects);
        }

        public IActionResult Details(int id)
        {
            Subject subject = _context.Subjects.Include(s => s.Employee).Include(s => s.Major)
                .FirstOrDefault(s => s.Id == id);

            return View(subject);
        }
    }
}
