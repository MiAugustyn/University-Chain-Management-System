using University_Chain_Management_System.Models;
using University_Chain_Management_System.Models.ViewModels;

namespace University_Chain_Management_System.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(int id);
        bool Add(Employee employee);
        bool Update(Employee employee);
        bool Delete(Employee employee);
        bool Save();
    }
}
