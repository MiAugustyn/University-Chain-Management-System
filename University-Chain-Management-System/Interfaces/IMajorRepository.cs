using University_Chain_Management_System.Models;

namespace University_Chain_Management_System.Repositories
{
    public interface IMajorRepository
    {
        Task<IEnumerable<Major>> GetAll();
        Task<Major> GetById(int id);
        Task<Major> GetBySubjectId(int id);
        bool Add(Major major);
        bool Update(Major major);
        bool Delete(Major major);
        bool Save();
    }
}
