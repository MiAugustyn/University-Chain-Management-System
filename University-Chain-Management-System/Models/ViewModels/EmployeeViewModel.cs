namespace University_Chain_Management_System.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public Employee? Employee { get; set; }
        public IEnumerable<University>? Universities { get; set; }
        public IEnumerable<Position>? Positions { get; set; }
    }
}
