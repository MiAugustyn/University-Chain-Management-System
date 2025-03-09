using University_Chain_Management_System.Models.JoinTables;
using University_Chain_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace University_Chain_Management_System.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<StudentMajor> StudentsMajors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentMajor>()
                .HasKey(sm => new { sm.StudentId, sm.MajorId });
            modelBuilder.Entity<StudentMajor>()
                .HasOne(s => s.Student)
                .WithMany(sm => sm.Majors)
                .HasForeignKey(s => s.StudentId);
            modelBuilder.Entity<StudentMajor>()
                .HasOne(m => m.Major)
                .WithMany(sm => sm.Students)
                .HasForeignKey(m => m.MajorId);
        }
    }
}
