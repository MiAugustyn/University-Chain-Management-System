using University_Chain_Management_System.Models;

namespace University_Chain_Management_System.Interfaces
{
    public interface INotificationRepository
    {
        Task<IEnumerable<Notification>> GetAll();
        Task<Notification> GetById(int id);
        Task<IEnumerable<Notification>> GetLatest(int count);
        bool Add(Notification notification);
        bool Update(Notification notification);
        bool Delete(Notification notification);
        bool Save();
    }
}
