using Microsoft.AspNetCore.Mvc;
using University_Chain_Management_System.Models;
using University_Chain_Management_System.Models.ViewModels;
using University_Chain_Management_System.Repositories;

namespace University_Chain_Management_System.Controllers
{
    public class MajorController : Controller
    {
        private readonly IMajorRepository _majorRepository;
        private readonly IUniversityRepository _universityRepository;

        public MajorController(IMajorRepository majorRepository,
            IUniversityRepository universityRepository)
        {
            _majorRepository = majorRepository;
            _universityRepository = universityRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Major> majors = await _majorRepository.GetAll();

            return View(majors);
        }

        public async Task<IActionResult> Details(int id)
        {
            Major major = await _majorRepository.GetById(id);

            return View(major);
        }

        public async Task<IActionResult> Create()
        {
            IEnumerable<University> universities = await _universityRepository.GetAll();

            MajorViewModel viewModel = new MajorViewModel()
            {
                Major = new Major(),
                Universities = universities
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Major major)
        {
            IEnumerable<University> universities = await _universityRepository.GetAll();

            MajorViewModel viewModel = new MajorViewModel()
            {
                Major = major,
                Universities = universities
            };

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            _majorRepository.Add(major);
            return RedirectToAction("Index");
        }
    }
}
