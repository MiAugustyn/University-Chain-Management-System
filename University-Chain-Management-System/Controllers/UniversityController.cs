using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using University_Chain_Management_System.Data;
using University_Chain_Management_System.Models;

namespace University_Chain_Management_System.Controllers
{
    public class UniversityController : Controller
    {
        private readonly DataContext _context;

        public UniversityController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<University> universities = _context.Universities.ToList();
            return View(universities);
        }

        public IActionResult Details(int id)
        {
            University university = _context.Universities.Include(u => u.Employees).Include(u => u.Majors)
                .FirstOrDefault(u => u.Id == id);

            return View(university);
        }
    }
}
