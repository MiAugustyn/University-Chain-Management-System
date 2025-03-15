using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University_Chain_Management_System.Data;
using University_Chain_Management_System.Models;

namespace University_Chain_Management_System.Controllers
{
    public class MajorController : Controller
    {
        private readonly DataContext _context;

        public MajorController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Major> majors = _context.Majors.ToList();
            return View(majors);
        }

        public IActionResult Details(int id)
        {
            Major major = _context.Majors.Include(m => m.Students).Include(m => m.University).Include(m => m.Subjects)
                .FirstOrDefault(m => m.Id == id);

            return View(major);
        }
    }
}
