using Microsoft.EntityFrameworkCore;
using University_Chain_Management_System.Data;
using University_Chain_Management_System.Models;
using University_Chain_Management_System.Repositories;

namespace University_Chain_Management_System.Repository
{
    public class UniversityRepository : IUniversityRepository
    {
        private readonly DataContext _context;

        public UniversityRepository(DataContext context)
        {

            _context = context;
        }

        public bool Add(University university)
        {
            _context.Add(university);
            return Save();
        }

        public bool Delete(University university)
        {
            _context.Remove(university);
            return Save();
        }

        public async Task<IEnumerable<University>> GetAll()
        {
            return await _context.Universities.ToListAsync();
        }

        public async Task<University> GetById(int id)
        {
            return await _context.Universities
                .Include(u => u.Employees).Include(u => u.Majors)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool Update(Employee employee)
        {
            throw new NotImplementedException();
        }

        public bool Update(University university)
        {
            _context.Update(university);
            return Save();
        }
    }
}
