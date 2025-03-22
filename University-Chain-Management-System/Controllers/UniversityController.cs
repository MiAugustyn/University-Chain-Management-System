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
                return View(university);
            }

            _universityRepository.Add(university);
            return RedirectToAction("Index");
        }
    }
}
