namespace University_Chain_Management_System.Models.ViewModels
{
    public class SubjectViewModel
    {
        public Subject Subject { get; set; }
        public IEnumerable<Major> Majors { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}
