using University_Chain_Management_System.Models;

namespace University_Chain_Management_System.Repositories
{
    public interface IGradeRepository
    {
        Task<IEnumerable<Grade>> GetAll();
        Task<Grade> GetById(int id);
        Task<IEnumerable<Grade>> GetByYear(int year);
        bool Add(Grade grade);
        bool Update(Grade grade);
        bool Delete(Grade grade);
        bool Save();
    }
}