using Microsoft.AspNetCore.Mvc;
using University_Chain_Management_System.Interfaces;
using University_Chain_Management_System.Models;

namespace University_Chain_Management_System.Controllers
{
    public class NotificationController : Controller
    {
        private INotificationRepository _notificationRepository;

        public NotificationController(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Notification> notifications = await _notificationRepository.GetAll();

            return View(notifications);
        }

        public async Task<IActionResult> Details(int id)
        {
            Notification notification = await _notificationRepository.GetById(id);

            if (notification == null) { return View("Error"); }

            return View(notification);
        }

        public async Task<IActionResult> Create()
        {
            Notification notification = new Notification()
            {
                PublishDate = DateTime.Today
            };

            return View(notification);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Notification notification)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Fill all fields with valid data.");
                return View(notification);
            }

            _notificationRepository.Add(notification);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Notification notification = await _notificationRepository.GetById(id);

            if (notification == null) { return View("Error"); }

            return View(notification);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Notification notification)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Fill all fields with valid data.");
                return View(notification);
            }

            _notificationRepository.Update(notification);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Notification notification = await _notificationRepository.GetById(id);

            if (notification == null) { return View("Error"); }

            return View(notification);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            Notification notification = await _notificationRepository.GetById(id);

            if (notification == null) { return View("Error"); }

            _notificationRepository.Delete(notification);
            return RedirectToAction("Index");
        }
    }
}
