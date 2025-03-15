using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University_Chain_Management_System.Data;
using University_Chain_Management_System.Models;

namespace University_Chain_Management_System.Controllers
{
    public class PositionController : Controller
    {
        private readonly DataContext _context;

        public PositionController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Position> positions = _context.Positions.ToList();
            return View(positions);
        }

        public IActionResult Details(int id)
        {
            Position position = _context.Positions.Include(p => p.Employees)
                .FirstOrDefault(p => p.Id == id);

            return View(position);
        }
    }
}
