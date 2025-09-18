using System.ComponentModel.DataAnnotations;
using University_Chain_Management_System.Models.JoinTables;

namespace University_Chain_Management_System.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string? Image { get; set; }
        public ICollection<StudentMajor>? Majors { get; set; }
        public ICollection<Grade>? Grades { get; set; }
    }
}
