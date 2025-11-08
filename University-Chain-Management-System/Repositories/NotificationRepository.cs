using Microsoft.EntityFrameworkCore;
using University_Chain_Management_System.Data;
using University_Chain_Management_System.Interfaces;
using University_Chain_Management_System.Models;

namespace University_Chain_Management_System.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly DataContext _context;

        public NotificationRepository(DataContext context)
        {
            _context = context;
        }

        public bool Add(Notification notification)
        {
            _context.Add(notification);
            return Save();
        }

        public bool Delete(Notification notification)
        {
            _context.Remove(notification);
            return Save();
        }

        public async Task<IEnumerable<Notification>> GetAll()
        {
            return await _context.Notifications.ToListAsync();
        }

        public async Task<IEnumerable<Notification>> GetLatest(int count)
        {
            return await _context.Notifications
                .OrderByDescending(n => n.PublishDate)
                .Take(count).ToListAsync();
        }

        public async Task<Notification> GetById(int id)
        {
            return await _context.Notifications.FirstOrDefaultAsync(n => n.Id == id);
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool Update(Notification notification)
        {
            _context.Update(notification);
            return Save();
        }
    }
}
