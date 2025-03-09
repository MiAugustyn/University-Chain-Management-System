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
                                        new Subject { Name = "Circuit Analysis", Description = "Basic circuit theory" }
                                    }
                                }
                            },
                            Employees = new List<Employee>
                            {
                                new Employee
                                {
                                    FirstName = "John",
                                    LastName = "Doe",
                                    HireDate = new DateTime(2015, 1, 1),
                                    Position = positions[1]
                                },
                                new Employee
                                {
                                    FirstName = "Jane",
                                    LastName = "Smith",
                                    HireDate = new DateTime(2020, 6, 1),
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

                    _context.SaveChanges();
                }

                if (!_context.Students.Any())
                {
                    var students = new List<Student>
                    {
                        new Student { FirstName = "Alice", LastName = "Johnson" },
                        new Student { FirstName = "Bob", LastName = "Smith" }
                    };

                    _context.Students.AddRange(students);
                    _context.SaveChanges();

                    // Enroll students in majors
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
                        }
                    };

                    _context.StudentsMajors.AddRange(studentsMajors);

                    // Add grades
                    var subjects = _context.Subjects.ToList();
                    var grades = new List<Grade>
                    {
                        new Grade { Value = 4.5f, Student = students[0], Subject = subjects[0] },
                        new Grade { Value = 3.8f, Student = students[0], Subject = subjects[1] },
                        new Grade { Value = 4.2f, Student = students[1], Subject = subjects[2] }
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
