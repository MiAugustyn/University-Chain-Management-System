using System.ComponentModel.DataAnnotations;
using University_Chain_Management_System.Models.JoinTables;
using University_Chain_Management_System.ModelsValidations;

namespace University_Chain_Management_System.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [NameValidation]
        public string FirstName { get; set; }
        [NameValidation]
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        [EmailValidation]
        public string Email { get; set; }
        public string? Image { get; set; }
        public ICollection<StudentMajor>? Majors { get; set; }
        public ICollection<Grade>? Grades { get; set; }
    }
}
