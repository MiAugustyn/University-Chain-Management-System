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
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentMajor>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.Student)
                      .WithMany(s => s.Majors)
                      .HasForeignKey(e => e.StudentId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Major)
                      .WithMany(m => m.Students)
                      .HasForeignKey(e => e.MajorId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(e => new { e.StudentId, e.MajorId }).IsUnique();
            });
        }
    }
}
