using Microsoft.AspNetCore.Mvc;
using University_Chain_Management_System.Models;
using University_Chain_Management_System.Repositories;

namespace University_Chain_Management_System.Controllers
{
    public class PositionController : Controller
    {
        private readonly IPositionRepository _positionRepository;

        public PositionController(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Position> positions = await _positionRepository.GetAll();

            return View(positions);
        }

        public async Task<IActionResult> Details(int id)
        {
            Position position = await _positionRepository.GetById(id);
            return View(position);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Position position)
        {

            if (!ModelState.IsValid)
            {
                return View(position);
            }

            _positionRepository.Add(position);
            return RedirectToAction("Index");
        }
    }
}
