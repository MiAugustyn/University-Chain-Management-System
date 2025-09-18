using Microsoft.EntityFrameworkCore;
using University_Chain_Management_System.Data;
using University_Chain_Management_System.Models;

namespace University_Chain_Management_System.Repositories
{
    public class MajorRepository : IMajorRepository
    {
        private readonly DataContext _context;

        public MajorRepository(DataContext context)
        {
            _context = context;
        }

        public bool Add(Major major)
        {
            _context.Add(major);
            return Save();
        }

        public bool Delete(Major major)
        {
            _context.Remove(major);
            return Save();
        }

        public async Task<IEnumerable<Major>> GetAll()
        {
            return await _context.Majors.ToListAsync();
        }

        public async Task<Major> GetById(int id)
        {
            return await _context.Majors.Include(m => m.Students)
                .Include(m => m.University).Include(m => m.Subjects)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool Update(Major major)
        {
            _context.Update(major);
            return Save();
        }
    }
}
