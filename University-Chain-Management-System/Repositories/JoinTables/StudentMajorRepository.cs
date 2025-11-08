using Microsoft.EntityFrameworkCore;
using University_Chain_Management_System.Data;
using University_Chain_Management_System.Repositories;
using University_Chain_Management_System.Models.JoinTables;

namespace University_Chain_Management_System.Repository.JoinTables
{
    public class StudentMajorRepository : IStudentMajorRepository
    {
        private readonly DataContext _context;

        public StudentMajorRepository(DataContext context) 
        {
            _context = context;
        }

        public bool Add(StudentMajor studentMajor)
        {
            _context.Add(studentMajor);
            return Save();
        }

        public bool Delete(StudentMajor studentMajor)
        {
            _context.Remove(studentMajor);
            return Save();
        }

        public async Task<IEnumerable<StudentMajor>> GetAll()
        {
            return await _context.StudentsMajors
                .Include(s => s.Student)
                .Include(s => s.Major)
                .ToListAsync();
        }

        public async Task<StudentMajor> GetById(int id)
        {
            return await _context.StudentsMajors
                .Include(s => s.Student)
                .Include(s => s.Major)
                .FirstOrDefaultAsync(i => i.Id  == id);
        }

        public async Task<IEnumerable<StudentMajor>> GetByMajorId(int id)
        {
            return await _context.StudentsMajors
                .Include(s => s.Student)
                .Include(s => s.Major)
                .Where(i => i.Major.Id == id)
                .ToListAsync();
        }

        public async Task<IEnumerable<StudentMajor>> GetByStudentId(int id)
        {
            return await _context.StudentsMajors
                .Include(s => s.Student)
                .Include(s => s.Major)
                .Where(i => i.Student.Id == id).ToListAsync();
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool Update(StudentMajor studentMajor)
        {
            _context.Update(studentMajor);
            return Save();
        }
    }
}
