using University_Chain_Management_System.Models;

namespace University_Chain_Management_System.Repositories
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> GetAll();
        Task<Subject> GetById(int id);
        bool Add(Subject subject);
        bool Update(Subject subject);
        bool Delete(Subject subject);
        bool Save();
    }
}
