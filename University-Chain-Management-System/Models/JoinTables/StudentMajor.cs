using System.ComponentModel.DataAnnotations;
using University_Chain_Management_System.Data.Enums;

namespace University_Chain_Management_System.Models.JoinTables
{
    public class StudentMajor
    {
        public int StudentID { get; set; }
        public Student Student { get; set; }
        public int MajorID { get; set; }
        public Major Major { get; set; }
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime GraduationDate { get; set; }
        public StudentStatus StudentStatus { get; set; }
    }
}
