using System.ComponentModel.DataAnnotations;
using University_Chain_Management_System.ModelsValidations;

namespace University_Chain_Management_System.Models
{
    public class Position
    {
        [Key]
        public int Id { get; set; }
        [NameValidation]
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}
