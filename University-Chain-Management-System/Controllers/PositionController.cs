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

        public async Task<IActionResult> Edit(int id)
        {
            Position position = await _positionRepository.GetById(id);

            if (position == null) { return View("Error");  }

            return View(position);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Position position)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit");
                return View("Edit", position);
            }

            _positionRepository.Update(position);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Position position = await _positionRepository.GetById(id);

            if (position == null) { return View("Error"); }

            return View(position);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePosition(int id)
        {
            Position position = await _positionRepository.GetById(id);

            if (position == null) { return View("Error"); }

            _positionRepository.Delete(position);
            return RedirectToAction("Index");
        }
    }
}
