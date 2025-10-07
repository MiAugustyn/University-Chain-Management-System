using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using University_Chain_Management_System.ModelsValidations;

namespace University_Chain_Management_System.Models
{
    public class Employee
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
        [DataType(DataType.Date)]
        [DateValidation]
        public DateTime HireDate { get; set; }
        [ForeignKey("Position")]
        public int? PositionId { get; set; }
        public Position? Position { get; set; }
        [ForeignKey("University")]
        public int? UniversityId { get; set; }
        public University? University { get; set; }
        public ICollection<Subject>? Subjects { get; set; }
    }
}
