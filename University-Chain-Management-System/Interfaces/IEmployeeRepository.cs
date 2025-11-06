using University_Chain_Management_System.Models;

namespace University_Chain_Management_System.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task<IEnumerable<Employee>> GetByYear(int year);
        bool Add(Employee employee);
        bool Update(Employee employee);
        bool Delete(Employee employee);
        bool Save();
    }
}
