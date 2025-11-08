using Microsoft.EntityFrameworkCore;
using University_Chain_Management_System.Data;
using University_Chain_Management_System.Models;

namespace University_Chain_Management_System.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public bool Add(Employee employee)
        {
            _context.Add(employee);
            return Save();
        }

        public bool Delete(Employee employee)
        {
            _context.Remove(employee);
            return Save();
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            return await _context.Employees.Include(e => e.University).Include(u => u.Subjects)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Employee>> GetByYear(int year)
        {
            return await _context.Employees.Where(e => e.HireDate.Year == year).ToListAsync();
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool Update(Employee employee)
        {
            _context.Update(employee);
            return Save();
        }
    }
}
