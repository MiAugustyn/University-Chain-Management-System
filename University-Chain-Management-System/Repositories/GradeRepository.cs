using Microsoft.EntityFrameworkCore;
using University_Chain_Management_System.Data;
using University_Chain_Management_System.Models;

namespace University_Chain_Management_System.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly DataContext _context;

        public GradeRepository(DataContext context)
        {
            _context = context;
        }

        public bool Add(Grade grade)
        {
            _context.Add(grade);
            return Save();
        }

        public bool Delete(Grade grade)
        {
            _context.Remove(grade);
            return Save();
        }

        public async Task<IEnumerable<Grade>> GetAll()
        {
            return await _context.Grades
                .Include(g => g.Subject).Include(g => g.Student)
                .ToListAsync();
        }

        public async Task<Grade> GetById(int id)
        {
            return await _context.Grades
                .Include(g => g.Subject).Include(g => g.Student)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<IEnumerable<Grade>> GetByYear(int year)
        {
            return await _context.Grades.Where(g => g.IssuanceDate.Year == year).ToListAsync();
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool Update(Grade grade)
        {
            _context.Update(grade);
            return Save();
        }
    }
}
