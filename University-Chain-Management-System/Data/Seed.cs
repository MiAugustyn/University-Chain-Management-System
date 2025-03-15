using University_Chain_Management_System.Data.Enums;
using University_Chain_Management_System.Models.JoinTables;
using University_Chain_Management_System.Models;

namespace University_Chain_Management_System.Data
{
    public class Seed
    {
        private readonly DataContext _context;

        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedDataContext()
        {
            try
            {
                if (!_context.Positions.Any())
                {
                    var positions = new List<Position>
                    {
                        new Position { Name = "Professor", Description = "Senior academic position" },
                        new Position { Name = "Lecturer", Description = "Junior academic position" },
                        new Position { Name = "Researcher", Description = "Focuses on research" }
                    };
                    _context.Positions.AddRange(positions);
                    _context.SaveChanges();
                }

                if (!_context.Universities.Any())
                {
                    var positions = _context.Positions.ToList();

                    var universities = new List<University>
                    {
                         new University
                         {
                             Name = "Tech University",
                             City = "Innovation City",
                             Majors = new List<Major>
                             {
                                 new Major
                                 {
                                     Name = "Computer Science",
                                     Description = "Study of computational systems",
                                     Subjects = new List<Subject>
                                     {
                                         new Subject { Name = "Algorithms", Description = "Core algorithms course" },
                                         new Subject { Name = "Database Systems", Description = "Fundamentals of DBMS" }
                                     }
                                 },
                                 new Major
                                 {
                                     Name = "Electrical Engineering",
                                     Description = "Study of electrical systems",
                                     Subjects = new List<Subject>
                                     {
                                         new Subject { Name = "Circuit Analysis", Description = "Basic circuit theory" },
                                         new Subject { Name = "Graphic Design", Description = "Desktop publishing fundamentals" }
                                     }
                                 }
                             },
                             Employees = new List<Employee>
                             {
                                 new Employee
                                 {
                                     FirstName = "John",
                                     LastName = "Doe",
                                     Image = "https://images.unsplash.com/photo-1564564244660-5d73c057f2d2?q=80&w=2076&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                                     HireDate = new DateTime(2015, 1, 1),
                                     Position = positions[1]
                                 },
                                 new Employee
                                 {
                                     FirstName = "Joe",
                                     LastName = "Momma",
                                     Image = "https://images.unsplash.com/photo-1573496799652-408c2ac9fe98?q=80&w=2069&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%",
                                     HireDate = new DateTime(2020, 6, 1),
                                     Position = positions[0]
                                 }
                             }
                         },
                         new University
                         {
                            Name = "Tech Institute",
                            City = "Metropolis",
                            Majors = new List<Major>
                            {
                                new Major
                                {
                                    Name = "Mechanical Engineering",
                                    Description = "Design and analysis of mechanical systems",
                                    Subjects = new List<Subject>
                                    {
                                        new Subject { Name = "Thermodynamics", Description = "Energy transfer principles" },
                                        new Subject { Name = "Mechanics", Description = "Classical mechanics and dynamics" }
                                    }
                                },
                                new Major
                                {
                                    Name = "Business Administration",
                                    Description = "Management and organizational leadership",
                                    Subjects = new List<Subject>
                                    {
                                        new Subject { Name = "Marketing", Description = "Market research strategies" },
                                        new Subject { Name = "Corporate Finance", Description = "Financial management principles" }
                                    }
                                }
                            },
                            Employees = new List<Employee>
                            {
                                new Employee
                                {
                                    FirstName = "Bobby ",
                                    LastName = "Middleton",
                                    Image = "https://images.unsplash.com/photo-1601655781320-205e34c94eb1?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                                    HireDate = new DateTime(2018, 3, 15),
                                    Position = positions[2]
                                },
                                new Employee
                                {
                                    FirstName = "Michael",
                                    LastName = "Brown",
                                    Image = "https://images.unsplash.com/photo-1700616466971-a4e05aa89e7d?q=80&w=1943&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D\r\n",
                                    HireDate = new DateTime(2022, 9, 1),
                                    Position = positions[0]
                                }
                            }
                         }
                     };

                    _context.Universities.AddRange(universities);
                    _context.SaveChanges();

                    var subjects = _context.Subjects.ToList();
                    var employees = _context.Employees.ToList();

                    subjects[0].Employee = employees[0];
                    subjects[1].Employee = employees[1];
                    subjects[2].Employee = employees[0];
                    subjects[3].Employee = employees[0];

                    subjects[4].Employee = employees[2];
                    subjects[5].Employee = employees[2];
                    subjects[6].Employee = employees[3];
                    subjects[7].Employee = employees[3];

                    _context.SaveChanges();
                }

                if (!_context.Students.Any())
                {
                    var students = new List<Student>
                     {
                         new Student { FirstName = "Bianca", LastName = "Herrera", Image = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                         new Student { FirstName = "Kamiyah  ", LastName = "Bush", Image = "https://images.unsplash.com/photo-1509839862600-309617c3201e?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                         new Student { FirstName = "Forrest ", LastName = "Sullivan", Image = "https://images.unsplash.com/photo-1557862921-37829c790f19?q=80&w=2071&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                         new Student { FirstName = "Jakari  ", LastName = "Lozano", Image = "https://images.unsplash.com/photo-1604177091072-b7b677a077f6?q=80&w=2072&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                         new Student { FirstName = "Corey", LastName = "Casey", Image = "https://images.unsplash.com/photo-1496360784265-52a2509684f3?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                         new Student { FirstName = "Ronald  ", LastName = "Marks", Image = "https://images.unsplash.com/photo-1546525848-3ce03ca516f6?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                         new Student { FirstName = "Nolan  ", LastName = "Lamb", Image = "https://images.unsplash.com/photo-1489980557514-251d61e3eeb6?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                         new Student { FirstName = "Summer", LastName = "Hopkins", Image = "https://images.unsplash.com/photo-1612115958726-9af4b6bd28d1?q=80&w=1172&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                         new Student { FirstName = "Westley  ", LastName = "Yates", Image = "https://images.unsplash.com/photo-1610012524257-d8910048e208?q=80&w=1170&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                         new Student { FirstName = "Quinn", LastName = "Schaefer", Image = "https://images.unsplash.com/photo-1514355315815-2b64b0216b14?w=1000&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NDF8fHN0dWRlbnR8ZW58MHwwfDB8fHwy" },
                         new Student { FirstName = "Alivia", LastName = "Fuentes", Image = "https://images.unsplash.com/photo-1705753449583-90daa4d7ad91?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                         new Student { FirstName = "Nicolas", LastName = "Acevedo", Image = "https://images.unsplash.com/photo-1631131431211-4f768d89087d?q=80&w=1170&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                         new Student { FirstName = "Dakari", LastName = "Bosch", Image = "https://images.unsplash.com/photo-1608055997191-8f2ec8e27aee?w=1000&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTExfHxzdHVkZW50fGVufDB8MHwwfHx8Mg%3D%3D" },
                         new Student { FirstName = "Isaiah ", LastName = "Tapia", Image = "https://images.unsplash.com/photo-1492462543947-040389c4a66c?q=80&w=1170&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" }
                         //14
                     };

                    _context.Students.AddRange(students);
                    _context.SaveChanges();

                    var majors = _context.Majors.ToList();
                    var studentsMajors = new List<StudentMajor>
                     {
                         new StudentMajor
                         {
                             Student = students[0],
                             Major = majors[0],
                             EnrollmentDate = new DateTime(2022, 9, 1),
                             GraduationDate = new DateTime(2026, 6, 1),
                             StudentStatus = StudentStatus.Enrolled
                         },
                         new StudentMajor
                         {
                             Student = students[1],
                             Major = majors[1],
                             EnrollmentDate = new DateTime(2021, 9, 1),
                             GraduationDate = new DateTime(2025, 6, 1),
                             StudentStatus = StudentStatus.Enrolled
                         },
                         new StudentMajor
                         {
                             Student = students[2],
                             Major = majors[2],
                             EnrollmentDate = new DateTime(2022, 9, 1),
                             GraduationDate = new DateTime(2026, 6, 1),
                             StudentStatus = StudentStatus.Enrolled
                         },
                         new StudentMajor
                         {
                             Student = students[3],
                             Major = majors[3],
                             EnrollmentDate = new DateTime(2021, 9, 1),
                             GraduationDate = new DateTime(2025, 6, 1),
                             StudentStatus = StudentStatus.Enrolled
                         },
                         new StudentMajor
                         {
                             Student = students[4],
                             Major = majors[0],
                             EnrollmentDate = new DateTime(2022, 9, 1),
                             GraduationDate = new DateTime(2026, 6, 1),
                             StudentStatus = StudentStatus.Enrolled
                         },
                         new StudentMajor
                         {
                             Student = students[5],
                             Major = majors[1],
                             EnrollmentDate = new DateTime(2021, 9, 1),
                             GraduationDate = new DateTime(2025, 6, 1),
                             StudentStatus = StudentStatus.Enrolled
                         },
                         new StudentMajor
                         {
                             Student = students[6],
                             Major = majors[2],
                             EnrollmentDate = new DateTime(2022, 9, 1),
                             GraduationDate = new DateTime(2026, 6, 1),
                             StudentStatus = StudentStatus.Enrolled
                         },
                         new StudentMajor
                         {
                             Student = students[7],
                             Major = majors[3],
                             EnrollmentDate = new DateTime(2021, 9, 1),
                             GraduationDate = new DateTime(2025, 6, 1),
                             StudentStatus = StudentStatus.Enrolled
                         },
                         new StudentMajor
                         {
                             Student = students[8],
                             Major = majors[0],
                             EnrollmentDate = new DateTime(2022, 9, 1),
                             GraduationDate = new DateTime(2026, 6, 1),
                             StudentStatus = StudentStatus.Enrolled
                         },
                         new StudentMajor
                         {
                             Student = students[9],
                             Major = majors[1],
                             EnrollmentDate = new DateTime(2021, 9, 1),
                             GraduationDate = new DateTime(2025, 6, 1),
                             StudentStatus = StudentStatus.Enrolled
                         },
                         new StudentMajor
                         {
                             Student = students[10],
                             Major = majors[2],
                             EnrollmentDate = new DateTime(2022, 9, 1),
                             GraduationDate = new DateTime(2026, 6, 1),
                             StudentStatus = StudentStatus.Enrolled
                         },
                         new StudentMajor
                         {
                             Student = students[11],
                             Major = majors[3],
                             EnrollmentDate = new DateTime(2021, 9, 1),
                             GraduationDate = new DateTime(2025, 6, 1),
                             StudentStatus = StudentStatus.Enrolled
                         },
                         new StudentMajor
                         {
                             Student = students[12],
                             Major = majors[0],
                             EnrollmentDate = new DateTime(2022, 9, 1),
                             GraduationDate = new DateTime(2026, 6, 1),
                             StudentStatus = StudentStatus.Enrolled
                         },
                         new StudentMajor
                         {
                             Student = students[13],
                             Major = majors[1],
                             EnrollmentDate = new DateTime(2021, 9, 1),
                             GraduationDate = new DateTime(2025, 6, 1),
                             StudentStatus = StudentStatus.Enrolled
                         },



                     };

                    _context.StudentsMajors.AddRange(studentsMajors);

                    var subjects = _context.Subjects.ToList();
                    var grades = new List<Grade>
                     {
                         new Grade { Value = 4.5f, Student = students[0], Subject = subjects[0] },
                         new Grade { Value = 4.5f, Student = students[1], Subject = subjects[2] },
                         new Grade { Value = 4.5f, Student = students[2], Subject = subjects[4] },
                         new Grade { Value = 4.5f, Student = students[3], Subject = subjects[6] },
                         new Grade { Value = 5.0f, Student = students[4], Subject = subjects[1] },
                         new Grade { Value = 4.5f, Student = students[5], Subject = subjects[3] },
                         new Grade { Value = 4.5f, Student = students[6], Subject = subjects[5] },
                         new Grade { Value = 4.5f, Student = students[7], Subject = subjects[7] },
                         new Grade { Value = 4.5f, Student = students[8], Subject = subjects[0] },
                         new Grade { Value = 4.5f, Student = students[9], Subject = subjects[2] },
                         new Grade { Value = 4.5f, Student = students[10], Subject = subjects[4] },
                         new Grade { Value = 3.5f, Student = students[11], Subject = subjects[6] },
                         new Grade { Value = 4.5f, Student = students[12], Subject = subjects[0] },
                         new Grade { Value = 4.5f, Student = students[13], Subject = subjects[2] },
                         new Grade { Value = 4.5f, Student = students[0], Subject = subjects[4] },
                         new Grade { Value = 4.0f, Student = students[1], Subject = subjects[6] },
                         new Grade { Value = 4.5f, Student = students[2], Subject = subjects[0] },
                         new Grade { Value = 3.0f, Student = students[3], Subject = subjects[2] },
                         new Grade { Value = 4.5f, Student = students[4], Subject = subjects[4] },
                         new Grade { Value = 4.5f, Student = students[5], Subject = subjects[6] },
                         new Grade { Value = 4.5f, Student = students[6], Subject = subjects[1] },
                         new Grade { Value = 4.0f, Student = students[7], Subject = subjects[3] },
                         new Grade { Value = 3.5f, Student = students[8], Subject = subjects[5] },
                         new Grade { Value = 4.5f, Student = students[9], Subject = subjects[7] },
                         new Grade { Value = 4.5f, Student = students[10], Subject = subjects[1] },
                         new Grade { Value = 4.5f, Student = students[11], Subject = subjects[3] },
                         new Grade { Value = 4.5f, Student = students[12], Subject = subjects[5] },
                         new Grade { Value = 4.5f, Student = students[13], Subject = subjects[7] }
                     };

                    _context.Grades.AddRange(grades);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during seeding: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
            }
        }
    }
}
