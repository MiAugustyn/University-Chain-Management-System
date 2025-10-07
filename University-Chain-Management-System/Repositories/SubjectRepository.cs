using Microsoft.EntityFrameworkCore;
using University_Chain_Management_System.Data;
using University_Chain_Management_System.Models;
using University_Chain_Management_System.Models.ViewModels;

namespace University_Chain_Management_System.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly DataContext _context;

        public SubjectRepository(DataContext context)
        {
            _context = context;
        }

        public bool Add(Subject subject)
        {
            _context.Add(subject);
            return Save();
        }

        public bool Delete(Subject subject)
        {
            _context.Remove(subject);
            return Save();
        }

        public async Task<IEnumerable<Subject>> GetAll()
        {
            return await _context.Subjects.ToListAsync();
        }

        public async Task<Subject> GetById(int id)
        {
            return await _context.Subjects
                .Include(s => s.Employee)
                .Include(s => s.Major)
                    .ThenInclude(m => m.University)
                .Include(s => s.Grades)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Subject>> GetSubjectsWithAssignedUniversities()
        {
            return await _context.Subjects
               .Include(s => s.Employee)
               .Include(s => s.Major)
                   .ThenInclude(m => m.University)
               .Include(s => s.Grades)
               .Where(s => s.Major != null && s.Major.University != null)
               .ToListAsync();

        }

        public async Task<IEnumerable<Subject>> GetSubjectsByMajorId(int id)
        {
            return await _context.Subjects
            .Where(s => s.MajorId.HasValue && s.MajorId == id)
            .ToListAsync();
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool Update(Subject subject)
        {
            _context.Update(subject);
            return Save();
        }
    }
}
