using Api.Common.Exceptions;
using DataAccessLayer;
using Db.Entities;
using LogicLayer.Handlers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using API = Api.Entities;

namespace Api.UnitTests
{
    internal class StudentTests : UnitTestBase
    {
        private static readonly string testStudentFirstnames = "Testi testing";
        private static readonly string testStudentLastName = "Oppilas";        
        protected override IDataInitializer DataInitializer => new StudentDataInitializer();

        [Test]
        public void GetAll()
        {
            IEnumerable<API.Student> students = new StudentHandler().Get(0, 10);
            Assert.IsNotNull(students);
            Assert.AreEqual(StudentDataInitializer.TestStudents.Count, students.Count());
        }
        [Test]
        public void GetAll_Take2()
        {
            int take = 2;
            IEnumerable<API.Student> students = new StudentHandler().Get(0, take);
            Assert.IsNotNull(students);
            Assert.AreEqual(take, students.Count());
        }

        [Test]
        public void GetSingle()
        {
            API.Student student = new StudentHandler().Get(StudentDataInitializer.studentId4);
            Assert.IsNotNull(student);
            Assert.AreEqual(testStudentFirstnames, student.FirstNames);
            Assert.AreEqual(testStudentLastName, student.LastName);
            Assert.IsNull(student.Grades);
            Assert.IsNull(student.Classes);
        }
        [Test]
        public void GetSingle_KeyNotFound()
        {
            var handler = new StudentHandler();
            Assert.Throws(typeof(NotFoundException), () => { handler.Get(Guid.NewGuid()); });
        }

        internal class StudentDataInitializer : DataInitializer
        {
            public static List<Student> TestStudents { get; set; }
            public StudentDataInitializer()
            {
                TestStudents = new List<Student>()
                {
                    new Student
                    {
                        Id = studentId1,
                        FirstNames = $@"{GetFirstName()} {GetFirstName()}",
                        LastName = GetLastName()
                    }, new Student
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
                        FirstNames = testStudentFirstnames,
                        LastName = testStudentLastName
                    }
                };  
            }
            public override void Initialize(SchoolDbContext context)
            {
                context.Database.EnsureCreated();

                if (context.Students.Any())
                {
                    return;   // Data was already seeded
                }
                context.Students.AddRange(TestStudents);
                context.SaveChanges();
            }
        }
    }
}