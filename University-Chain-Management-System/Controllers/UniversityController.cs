using Microsoft.AspNetCore.Mvc;
using University_Chain_Management_System.Models;
using University_Chain_Management_System.Repositories;

namespace University_Chain_Management_System.Controllers
{
    public class UniversityController : Controller
    {
        private readonly IUniversityRepository _universityRepository;

        public UniversityController(IUniversityRepository universityRepository)
        {
            _universityRepository = universityRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<University> universities = await _universityRepository.GetAll();
            return View(universities);
        }

        public async Task<IActionResult> Details(int id)
        {
            University university = await _universityRepository.GetById(id);
            return View(university);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(University university)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Fill all fields with valid data.");
                return View(university);
            }

            _universityRepository.Add(university);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            University university = await _universityRepository.GetById(id);

            if (university == null) { return View("Error"); }

            return View(university);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(University university)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Fill all fields with valid data.");
                return View(university);
            }

            _universityRepository.Update(university);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            University university = await _universityRepository.GetById(id);

            if (university == null) { return View("Error"); }

            return View(university);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteUniversity(int id)
        {

            University university = await _universityRepository.GetById(id);

            if (university == null) { return View("Error"); }

            _universityRepository.Delete(university);
            return RedirectToAction("Index");
        }
    }
}
