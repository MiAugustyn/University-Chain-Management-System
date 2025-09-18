using University_Chain_Management_System.Models.JoinTables;

namespace University_Chain_Management_System.Models.ViewModels
{
    public class StudentMajorViewModel
    {
        public StudentMajor StudentMajor { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Major> Majors { get; set; }
    }
}
