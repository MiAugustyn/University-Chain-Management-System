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
                .ThenInclude(sm => sm.Student)
                .Include(m => m.University).Include(m => m.Subjects)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Major> GetBySubjectId(int subjectId)
        {
            return await _context.Subjects
                .Where(s => s.Id == subjectId)
                .Include(s => s.Major)
                    .ThenInclude(m => m.Students)
                        .ThenInclude(sm => sm.Student)
                .Select(s => s.Major)
                .FirstOrDefaultAsync();
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
