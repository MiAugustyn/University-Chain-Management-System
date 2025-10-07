using System.ComponentModel.DataAnnotations;
using University_Chain_Management_System.ModelsValidations;

namespace University_Chain_Management_System.Models
{
    public class University
    {
        [Key]
        public int Id { get; set; }
        [NameValidation]
        public string Name { get; set; }
        [NameValidation]
        public string City { get; set; }
        public ICollection<Major>? Majors { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}
