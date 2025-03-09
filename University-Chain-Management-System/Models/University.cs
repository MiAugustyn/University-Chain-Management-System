using System.ComponentModel.DataAnnotations;

namespace University_Chain_Management_System.Models
{
    public class University
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public ICollection<Major>? Majors { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}
