using  University_Chain_Management_System.Models.JoinTables;

namespace University_Chain_Management_System.Repositories
{
    public interface IStudentMajorRepository
    {
        Task<IEnumerable<StudentMajor>> GetAll();
        Task<IEnumerable<StudentMajor>> GetByStudentId(int id);
        Task<IEnumerable<StudentMajor>> GetByMajorId(int id);
        Task<StudentMajor> GetById(int id);
        bool Add(StudentMajor studentMajor);
        bool Update(StudentMajor studentMajor);
        bool Delete(StudentMajor studentMajor);
        bool Save();
    }
}
