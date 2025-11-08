namespace University_Chain_Management_System.Models.ViewModels
{
    public class StudentViewModel
    {
        public Student Student { get; set; }
        public IEnumerable<Major>? Majors {  get; set; }
        public IEnumerable<Subject>? Subjects { get; set; }
        public IEnumerable<Grade>? Grades { get; set; }
    }
}
