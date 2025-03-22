using University_Chain_Management_System.Models;

namespace University_Chain_Management_System.Repositories
{
    public interface IUniversityRepository
    {
        Task<IEnumerable<University>> GetAll();
        Task<University> GetById(int id);
        bool Add(University university);
        bool Update(University university);
        bool Delete(University university);
        bool Save();
    }
}
