using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University_Chain_Management_System.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Image { get; set; }
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
        public Position? Position { get; set; }
        [ForeignKey("University")]
        public int? UniversityId { get; set; }
        public University? University { get; set; }
        public ICollection<Subject>? Subjects { get; set; }
    }
}
