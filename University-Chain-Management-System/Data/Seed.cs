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
                                        new Subject
                                        {
                                            Name = "Algorithms",
                                            Description = "Core algorithms course"
                                        },
                                        new Subject
                                        {
                                            Name = "Database Systems",
                                            Description = "Fundamentals of DBMS"
                                        }
                                    }
                                },
                                new Major
                                {
                                    Name = "Electrical Engineering",
                                    Description = "Study of electrical systems",
                                    Subjects = new List<Subject>
                                    {
                                        new Subject
                                        {
                                            Name = "Circuit Analysis",
                                            Description = "Basic circuit theory"
                                        },
                                        new Subject
                                        {
                                            Name = "Graphic Design",
                                            Description = "Desktop publishing fundamentals"
                                        }
                                    }
                                }
                            },
                            Employees = new List<Employee>
                            {
                                new Employee
                                {
                                    FirstName = "John",
                                    LastName = "Doe",
                                    Email = "john.doe@techuniversity.edu",
                                    Image =
                                        "https://images.unsplash.com/photo-1564564244660-5d73c057f2d2?q=80&w=2076&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                                    HireDate = new DateTime(2015, 1, 1),
                                    Position = positions[1]
                                },
                                new Employee
                                {
                                    FirstName = "Joe",
                                    LastName = "Momma",
                                    Email = "joe.momma@techuniversity.edu",
                                    Image =
                                        "https://images.unsplash.com/photo-1573496799652-408c2ac9fe98?q=80&w=2069&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%",
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
                                        new Subject
                                        {
                                            Name = "Thermodynamics",
                                            Description = "Energy transfer principles"
                                        },
                                        new Subject
                                        {
                                            Name = "Mechanics",
                                            Description = "Classical mechanics and dynamics"
                                        }
                                    }
                                },
                                new Major
                                {
                                    Name = "Business Administration",
                                    Description = "Management and organizational leadership",
                                    Subjects = new List<Subject>
                                    {
                                        new Subject
                                        {
                                            Name = "Marketing",
                                            Description = "Market research strategies"
                                        },
                                        new Subject
                                        {
                                            Name = "Corporate Finance",
                                            Description = "Financial management principles"
                                        }
                                    }
                                }
                            },
                            Employees = new List<Employee>
                            {
                                new Employee
                                {
                                    FirstName = "Bobby ",
                                    LastName = "Middleton",
                                    Email = "bobby.middleton@techinstitute.edu",
                                    Image =
                                        "https://images.unsplash.com/photo-1601655781320-205e34c94eb1?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                                    HireDate = new DateTime(2018, 3, 15),
                                    Position = positions[2]
                                },
                                new Employee
                                {
                                    FirstName = "Michael",
                                    LastName = "Brown",
                                    Email = "michael.brown@techinstitute.edu",
                                    Image =
                                        "https://images.unsplash.com/photo-1700616466971-a4e05aa89e7d?q=80&w=1943&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D\r\n",
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
                        new Student
                        {
                            FirstName = "Bianca",
                            LastName = "Herrera",
                            Email = "bianca.herrera@student.techuniversity.edu",
                            Image = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                        },
                        new Student
                        {
                            FirstName = "Kamiyah  ",
                            LastName = "Bush",
                            Email = "kamiyah.bush@student.techuniversity.edu",
                            Image = "https://images.unsplash.com/photo-1509839862600-309617c3201e?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                        },
                        new Student
                        {
                            FirstName = "Forrest ",
                            LastName = "Sullivan",
                            Email = "forrest.sullivan@student.techinstitute.edu",
                            Image = "https://images.unsplash.com/photo-1557862921-37829c790f19?q=80&w=2071&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                        },
                        new Student
                        {
                            FirstName = "Jakari  ",
                            LastName = "Lozano",
                            Email = "jakari.lozano@student.techinstitute.edu",
                            Image = "https://images.unsplash.com/photo-1604177091072-b7b677a077f6?q=80&w=2072&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                        },
                        new Student
                        {
                            FirstName = "Corey",
                            LastName = "Casey",
                            Email = "corey.casey@student.techuniversity.edu",
                            Image = "https://images.unsplash.com/photo-1496360784265-52a2509684f3?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                        },
                        new Student
                        {
                            FirstName = "Ronald  ",
                            LastName = "Marks",
                            Email = "ronald.marks@student.techuniversity.edu",
                            Image = "https://images.unsplash.com/photo-1546525848-3ce03ca516f6?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                        },
                        new Student
                        {
                            FirstName = "Nolan  ",
                            LastName = "Lamb",
                            Email = "nolan.lamb@student.techinstitute.edu",
                            Image = "https://images.unsplash.com/photo-1489980557514-251d61e3eeb6?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                        },
                        new Student
                        {
                            FirstName = "Summer",
                            LastName = "Hopkins",
                            Email = "summer.hopkins@student.techinstitute.edu",
                            Image = "https://images.unsplash.com/photo-1612115958726-9af4b6bd28d1?q=80&w=1172&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                        },
                        new Student
                        {
                            FirstName = "Westley  ",
                            LastName = "Yates",
                            Email = "westley.yates@student.techuniversity.edu",
                            Image = "https://images.unsplash.com/photo-1610012524257-d8910048e208?q=80&w=1170&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                        },
                        new Student
                        {
                            FirstName = "Quinn",
                            LastName = "Schaefer",
                            Email = "quinn.schaefer@student.techuniversity.edu",
                            Image = "https://images.unsplash.com/photo-1514355315815-2b64b0216b14?w=1000&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NDF8fHN0dWRlbnR8ZW58MHwwfDB8fHwy"
                        },
                        new Student
                        {
                            FirstName = "Alivia",
                            LastName = "Fuentes",
                            Email = "alivia.fuentes@student.techinstitute.edu",
                            Image = "https://images.unsplash.com/photo-1705753449583-90daa4d7ad91?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                        },
                        new Student
                        {
                            FirstName = "Nicolas",
                            LastName = "Acevedo",
                            Email = "nicolas.acevedo@student.techinstitute.edu",
                            Image = "https://images.unsplash.com/photo-1631131431211-4f768d89087d?q=80&w=1170&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                        },
                        new Student
                        {
                            FirstName = "Dakari",
                            LastName = "Bosch",
                            Email = "dakari.bosch@student.techuniversity.edu",
                            Image = "https://images.unsplash.com/photo-1608055997191-8f2ec8e27aee?w=1000&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTExfHxzdHVkZW50fGVufDB8MHwwfHx8Mg%3D%3D"
                        },
                        new Student
                        {
                            FirstName = "Isaiah ",
                            LastName = "Tapia",
                            Email = "isaiah.tapia@student.techuniversity.edu",
                            Image = "https://images.unsplash.com/photo-1492462543947-040389c4a66c?q=80&w=1170&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                        }
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

                if (!_context.Notifications.Any())
                {
                    var notifications = new List<Notification>
                    {
                        new Notification { NotificationType = NotificationType.Error, Title = "Payroll Processing Failure", Description = "Payroll run on October 10, 2025 failed due to data validation error. HR and IT teams: review timesheet imports and rerun batch.", PublishDate = new DateTime(2025, 10, 10) },
                        new Notification { NotificationType = NotificationType.Warning, Title = "HVAC Fluctuations Reported", Description = "Temperature control issues on 5th floor, room 502 reported on October 8, 2025. HVAC technicians: investigate and restore stable climate by October 12, 2025.", PublishDate = new DateTime(2025, 10, 8) },
                        new Notification { NotificationType = NotificationType.Information, Title = "Student Organization Fair", Description = "Student Org Fair held on September 20, 2025. Events team: confirm room setup, security, and AV support were completed.", PublishDate = new DateTime(2025, 9, 20) },
                        new Notification { NotificationType = NotificationType.Information, Title = "Research Grant Opportunities", Description = "New research grant applications opened September 15, 2025. Department admins: circulate application process and deadlines.", PublishDate = new DateTime(2025, 9, 15) },
                        new Notification { NotificationType = NotificationType.Information, Title = "Holiday Break Schedule", Description = "Offices will be closed from December 23, 2024 to January 2, 2025. Department managers: finalize on-call rosters and emergency contacts.", PublishDate = new DateTime(2025, 9, 1) },
                        new Notification { NotificationType = NotificationType.Information, Title = "Career Fair 2026", Description = "Career Fair scheduled for February 20–21, 2026. Career services staff: begin coordinating company logistics and booth assignments.", PublishDate = new DateTime(2025, 8, 25) },
                        new Notification { NotificationType = NotificationType.Information, Title = "Guest Lecture Series", Description = "Guest lectures planned for March 2026. Faculty liaisons: confirm room bookings and AV requirements.", PublishDate = new DateTime(2025, 8, 10) },
                        new Notification { NotificationType = NotificationType.Warning, Title = "Campus Wi-Fi Maintenance", Description = "Network maintenance scheduled for February 25, 2026 from 22:00 to 06:00. Critical services may be affected; IT staff should plan monitoring.", PublishDate = new DateTime(2025, 7, 30) },
                        new Notification { NotificationType = NotificationType.Information, Title = "Midterm Exam Schedule Released", Description = "Midterm schedules published for February 2026. Administrative staff: verify room allocations and proctoring assignments.", PublishDate = new DateTime(2025, 6, 18) },
                        new Notification { NotificationType = NotificationType.Error, Title = "Automated Backup System Error", Description = "Database backups for AllcampusDB failed on June 5, 2025. IT disaster recovery team: diagnose storage issues and restart backup jobs.", PublishDate = new DateTime(2025, 6, 5) },
                        new Notification { NotificationType = NotificationType.Information, Title = "Annual Science Fair 2026", Description = "Science Fair scheduled for March 15, 2026. Staff coordinators: confirm volunteer assignments and logistics.", PublishDate = new DateTime(2025, 5, 12) },
                        new Notification { NotificationType = NotificationType.Warning, Title = "Elevator Maintenance in Admin Building", Description = "Elevators 2 and 3 were out of service on May 2, 2025 from 08:00 to 18:00. Maintenance crew: coordinate with reception for freight deliveries.", PublishDate = new DateTime(2025, 5, 1) },
                        new Notification { NotificationType = NotificationType.Warning, Title = "Parking Garage C Closure", Description = "Parking Garage C closed due to structural inspection on April 20–21, 2025. Facilities team: arrange alternative parking and update signage.", PublishDate = new DateTime(2025, 4, 18) },
                        new Notification { NotificationType = NotificationType.Information, Title = "Library Hours Update", Description = "Library extended hours during finals week in January 2025. Staff schedules updated; check the staff roster.", PublishDate = new DateTime(2025, 3, 12) },
                        new Notification { NotificationType = NotificationType.Information, Title = "New Semester Registration Open", Description = "Registration for Spring 2025 opened January 5, 2025. Staff: review departmental enrollments via the staff portal.", PublishDate = new DateTime(2025, 1, 5) },

                    };

                    _context.Notifications.AddRange(notifications);
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
