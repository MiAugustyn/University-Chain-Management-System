using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using University_Chain_Management_System.Models.JoinTables;

namespace University_Chain_Management_System.Models
{
    public class Major
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("University")]
        public int? UniversityId { get; set; }
        public University? University { get; set; }
        public ICollection<StudentMajor>? Students { get; set; }
        public ICollection<Subject>? Subjects { get; set; }
    }
}
