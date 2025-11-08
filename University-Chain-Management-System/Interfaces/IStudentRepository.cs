using University_Chain_Management_System.Models;
using University_Chain_Management_System.Models.ViewModels;

namespace University_Chain_Management_System.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Student> GetById(int id);
        Task<IEnumerable<Student>> GetEnrolledByYear(int year);
        Task<IEnumerable<Student>> GetGraduatedByYear(int year);
        Task<StudentViewModel> GetViewModelById(int id);
        bool Add(Student student);
        bool Update(Student student);
        bool Delete(Student student);
        bool Save();
    }
}
