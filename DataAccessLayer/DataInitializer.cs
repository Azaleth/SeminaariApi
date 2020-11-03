using Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class DataInitializer : IDataInitializer
    {
        protected static readonly Random RNG = new Random();

        #region identifiers
        public static readonly Guid classId1 = new Guid("77ac6d84-4d07-4e2e-a2dc-00476630723f");
        public static readonly Guid classId2 = new Guid("7f6a8b71-5b22-4d7e-bcc0-e50bfb24dc5b");
        public static readonly Guid classId3 = new Guid("f42dc39c-b105-4024-8eba-85af33c32bb6");
        public static readonly Guid classId4 = new Guid("c60e5a2f-1b10-48dc-b865-2d600bc0f6fa");
        public static readonly Guid classId5 = new Guid("d2b3c471-7fbe-4f13-a3fa-480157a5364a");
        public static readonly Guid classId6 = new Guid("6414957c-0ca6-40b6-a95e-8e742517dbf5");

        public static readonly Guid gradeId1 = new Guid("8664de12-7f26-4d1a-9a8b-43c85484e39f");
        public static readonly Guid gradeId2 = new Guid("cfab4f44-90c6-41b8-91fd-a9c905b86c8e");
        public static readonly Guid gradeId3 = new Guid("b6a55588-7875-4abb-9634-bf79a8e394f8");
        public static readonly Guid gradeId4 = new Guid("4a00c05d-b600-41f4-b743-d21b54d47e0b");
        public static readonly Guid gradeId5 = new Guid("e635acba-61db-45dd-a7c5-60d147eb08c5");
        public static readonly Guid gradeId6 = new Guid("3a0e4f2d-1be8-48b4-a6eb-d22ec4903df0");

        public static readonly Guid studentId1 = new Guid("649e1a5a-49d5-47c8-9ad0-abb82dc3c4b5");
        public static readonly Guid studentId2 = new Guid("037f72c6-e229-4518-9696-80ecd3d0b317");
        public static readonly Guid studentId3 = new Guid("32f39469-8db8-4bfe-b697-5ed4083664c4");
        public static readonly Guid studentId4 = new Guid("e83bc875-d26e-4d73-9152-82e734a0928d");
        public static readonly Guid studentId5 = new Guid("9707b7ed-0847-433d-affe-651e8160fb0b");
        public static readonly Guid studentId6 = new Guid("25d2e0c5-8545-478c-a0fe-e9a10038ea8b");

        public static readonly Guid teacherId1 = new Guid("e6863990-8292-48a5-bbe1-3cb6d28a95d1");
        public static readonly Guid teacherId2 = new Guid("fa1aea83-2e22-4d80-82a3-6c64d3849991");
        public static readonly Guid teacherId3 = new Guid("490e5d0c-1684-41b1-8fb4-4b9ca83699f5");
        public static readonly Guid teacherId4 = new Guid("383ec7ff-c337-49af-a1a8-1c686ec67516");
        public static readonly Guid teacherId5 = new Guid("c8ca22f1-fd85-4839-86fb-1b61f1525281");
        public static readonly Guid teacherId6 = new Guid("311592c7-dc3d-4f0a-9f0d-2853be45e899");
        #endregion identifiers
        #region names 
        private static string[] _randomNames = new string[]
        {
           "Dorothea Escalera",
            "Anne Jackson",
            "Madge Kerfien",
            "Brittney Beer",
            "Lillian Busse",
            "Daisy Hendrix",
            "Tyson Ballantine",
            "Melany Devereux",
            "Victor Ver",
            "Candis Heck",
            "Ophelia Nuttall",
            "Fredia Chancellor",
            "Bailey Corprew",
            "Allegra Stlaurent",
            "Whitney Grace",
            "Sandi Launius",
            "June Styron",
            "Alysha Hiler",
            "Junko Docherty",
            "Flavia Haug",
            "Rodolfo Seagraves",
            "Esta Arend",
            "Krystyna Daub",
            "Jimmy Thomas",
            "Jeff Holley",
            "Corey Defazio",
            "Lilla Balliet",
            "Yoko Lorch",
            "Jerrold Girard",
            "Gale Hollars",
        };
        protected string GetRandomName()
        {
            int index = RNG.Next(_randomNames.Count());
            return _randomNames[index];
        }
        protected string GetFirstName()
        {
            return GetRandomName().Split(' ')[0];
        }
        protected string GetLastName()
        {
            return GetRandomName().Split(' ')[1];
        }
        #endregion
        protected DateTime GetRandomDateTime()
        {
            DateTime start = new DateTime(1964, 1, 1);
            DateTime end = new DateTime(1995, 1, 1);
            int range = (end - start).Days;
            return start.AddDays(RNG.Next(range));
        }
        public virtual void Initialize(SchoolDbContext context)
        {
            context.Database.EnsureCreated();
            InitTeachers(context);
            InitClasses(context);
            InitStudents(context);
            InitGrades(context);
            InitLinkStudentClass(context);
            context.SaveChanges();
        }
        protected virtual void InitTeachers(SchoolDbContext context)
        {
            if (context.Teachers.Any())
            {
                return;   // Data was already seeded
            }
            context.Teachers.AddRange(
                new Teacher
                {
                    Id = teacherId1,
                    BirthDay = GetRandomDateTime(),
                    FirstNames = $@"{GetFirstName()} {GetFirstName()}",
                    LastName = GetLastName()
                },
                new Teacher
                {
                    Id = teacherId2,
                    BirthDay = GetRandomDateTime(),
                    FirstNames = $@"{GetFirstName()} {GetFirstName()}",
                    LastName = GetLastName()
                },
                new Teacher
                {
                    Id = teacherId3,
                    Classes = context.Classes.Where(c => c.Id == classId3).ToList(),
                    BirthDay = GetRandomDateTime(),
                    FirstNames = $@"{GetFirstName()} {GetFirstName()}",
                    LastName = GetLastName()
                },
                new Teacher
                {
                    Id = teacherId4,
                    BirthDay = GetRandomDateTime(),
                    FirstNames = $@"{GetFirstName()} {GetFirstName()}",
                    LastName = GetLastName()
                },
                new Teacher
                {
                    Id = teacherId5,
                    BirthDay = GetRandomDateTime(),
                    FirstNames = $@"{GetFirstName()} {GetFirstName()}",
                    LastName = GetLastName()

                },
                new Teacher
                {
                    Id = teacherId6,
                    BirthDay = GetRandomDateTime(),
                    FirstNames = $@"{GetFirstName()} {GetFirstName()}",
                    LastName = GetLastName()
                });
        }
        protected virtual void InitClasses(SchoolDbContext context)
        {
            if (context.Classes.Any())
            {
                return;   // Data was already seeded
            }
            context.Classes.AddRange(
                new Class
                {
                    Id = classId1,
                    Identifier = "kooodaus-101",
                    Subject = "Ohjelmoinnin Alkeet",
                    TeacherId = teacherId1,
                },
                new Class
                {
                    Id = classId2,
                    Identifier = "kooodaus-201",
                    Subject = "Ohjelmoinnin jatkeet",
                    TeacherId = teacherId2,
                },
                new Class
                {
                    Id = classId3,
                    Identifier = "kooodaus-301",
                    Subject = "Ohjelmoinnin loput",
                    TeacherId = teacherId3,
                },
                new Class
                {
                    Id = classId4,
                    Identifier = "kooodaus-404",
                    Subject = "Ohjelmoinnin ?",
                    TeacherId = teacherId4,
                },
                new Class
                {
                    Id = classId5,
                    Identifier = "SWE-666",
                    Subject = "virkamiesruotsi",
                    TeacherId = teacherId5,

                },
                new Class
                {
                    Id = classId6,
                    Identifier = "math-101",
                    Subject = "Diskreetti laskenta",
                    TeacherId = teacherId6,
                });
        }
        protected virtual void InitGrades(SchoolDbContext context)
        {
            if (context.Grades.Any())
            {
                return;   // Data was already seeded
            }
            context.Grades.AddRange(
                new Grade
                {
                    Id = gradeId1,
                    ClassId = classId1,
                    StudentId = studentId1,
                    TeacherId = teacherId1,
                    Score = 6
                },
                new Grade
                {
                    Id = gradeId2,
                    ClassId = classId2,
                    StudentId = studentId2,
                    TeacherId = teacherId2,
                    Score = 5
                },
                new Grade
                {
                    Id = gradeId3,
                    ClassId = classId3,
                    StudentId = studentId3,
                    TeacherId = teacherId3,
                    Score = 7
                },
                new Grade
                {
                    Id = gradeId4,
                    ClassId = classId4,
                    StudentId = studentId4,
                    TeacherId = teacherId4,
                    Score = 9
                },
                new Grade
                {
                    Id = gradeId5,
                    ClassId = classId5,
                    StudentId = studentId5,
                    TeacherId = teacherId5,
                    Score = 10
                },
                new Grade
                {
                    Id = gradeId6,
                    ClassId = classId6,
                    StudentId = studentId6,
                    TeacherId = teacherId6,
                    Score = 8
                });
        }
        protected virtual void InitStudents(SchoolDbContext context)
        {
            if (context.Students.Any())
            {
                return;   // Data was already seeded
            }
            context.Students.AddRange(
                new Student
                {
                    Id = studentId1,
                    FirstNames = $@"{GetFirstName()} {GetFirstName()}",
                    LastName = GetLastName()
                },
                new Student
                {
                    Id = studentId2,
                    FirstNames = $@"{GetFirstName()} {GetFirstName()}",
                    LastName = GetLastName()
                },
                new Student
                {
                    Id = studentId3,
                    FirstNames = $@"{GetFirstName()} {GetFirstName()}",
                    LastName = GetLastName()
                },
                new Student
                {
                    Id = studentId4,
                    FirstNames = $@"{GetFirstName()} {GetFirstName()}",
                    LastName = GetLastName()
                },
                new Student
                {
                    Id = studentId5,
                    FirstNames = $@"{GetFirstName()} {GetFirstName()}",
                    LastName = GetLastName()

                },
                new Student
                {
                    Id = studentId6,
                    FirstNames = $@"{GetFirstName()} {GetFirstName()}",
                    LastName = GetLastName()
                });
        }
        protected virtual void InitLinkStudentClass(SchoolDbContext context)
        {
            if (context.LinkStudentClasses.Any())
            {
                return;   // Data was already seeded
            }
            context.LinkStudentClasses.AddRange(
                new LinkStudentClass
                {
                    Id = Guid.NewGuid(),
                    ClassId = classId1,
                    StudentId = studentId1,
                },
                new LinkStudentClass
                {
                    Id = Guid.NewGuid(),
                    ClassId = classId2,
                    StudentId = studentId2,
                },
                new LinkStudentClass
                {
                    Id = Guid.NewGuid(),
                    ClassId = classId3,
                    StudentId = studentId3,
                },
                new LinkStudentClass
                {
                    Id = Guid.NewGuid(),
                    ClassId = classId4,
                    StudentId = studentId4,
                },
                new LinkStudentClass
                {
                    Id = Guid.NewGuid(),
                    ClassId = classId5,
                    StudentId = studentId5,
                },
                new LinkStudentClass
                {
                    Id = Guid.NewGuid(),
                    ClassId = classId6,
                    StudentId = studentId6,
                },
                new LinkStudentClass
                {
                    Id = Guid.NewGuid(),
                    ClassId = classId5,
                    StudentId = studentId1,
            });
        }
    }
}
