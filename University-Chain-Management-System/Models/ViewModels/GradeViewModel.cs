namespace University_Chain_Management_System.Models.ViewModels
{
    public class GradeViewModel
    {
        public Grade Grade { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
    }
}
