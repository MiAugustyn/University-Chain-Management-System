using Microsoft.EntityFrameworkCore;
using University_Chain_Management_System.Data;
using University_Chain_Management_System.Models;
using University_Chain_Management_System.Models.ViewModels;

namespace University_Chain_Management_System.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _context;

        public StudentRepository(DataContext context)
        {
            _context = context;
        }

        public bool Add(Student student)
        {
            _context.Add(student);
            return Save();
        }

        public bool Delete(Student student)
        {
            _context.Remove(student);
            return Save();
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetById(int id)
        {
            return await _context.Students
                .Include(s => s.Majors).Include(s => s.Grades)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Student>> GetEnrolledByYear(int year)
        {
            return await _context.StudentsMajors
                .Include(sm => sm.Student)
                .Where(sm => sm.EnrollmentDate.Year == year)
                .Select(sm => sm.Student).ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetGraduatedByYear(int year)
        {
            return await _context.StudentsMajors
                .Include(sm => sm.Student)
                .Where(sm => sm.GraduationDate.Year == year)
                .Select(sm => sm.Student).ToListAsync();
        }

        // Gets student with all their majors, subjects linked to those majors, and grades
        public async Task<StudentViewModel> GetViewModelById(int id)
        {
            var student = await _context.Students
                .Include(s => s.Majors)
                    .ThenInclude(sm => sm.Major)
                .Include(s => s.Grades)
                    .ThenInclude(g => g.Subject)
                .FirstOrDefaultAsync(s => s.Id == id);

            var majors = student.Majors?.Select(sm => sm.Major).ToList();
            var majorIds = majors.Select(m => m.Id).ToList();

            var subjects = await _context.Subjects
                .Where(s => s.MajorId.HasValue && majorIds.Contains(s.MajorId.Value))
                .ToListAsync();

            var grades = student.Grades?.ToList();

            return new StudentViewModel()
            {
                Student = student,
                Majors = majors,
                Subjects = subjects,
                Grades = grades
            };
        }

          public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool Update(Student student)
        {
            _context.Update(student);
            return Save();
        }
    }
}
