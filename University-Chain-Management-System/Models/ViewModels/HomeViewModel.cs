namespace University_Chain_Management_System.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Notification>? Notifications { get; set; }
        public int? EnrolledStudentsShift { get; set; }
        public int? GraduatedStudentsShift { get; set; }
        public int? EmployeesShift { get; set; }
        public float? GradesAverageThisYear { get; set; }
        public float? GradesAverageLastYear { get; set; }
    }
}
