using Xunit;
using System.Collections.Generic;
using StudentSystem.BLL;
using StudentSystem.Core;

namespace StudentSystem.Tests
{
    public class StudentServiceTests
    {
        [Fact]
        public void CountMale3rdYearInDorm_WorksCorrectly()
        {
            var data = new List<Student>
            {
                new Student { Gender = Gender.Male, Course = 3, Residence = "101" },
                new Student { Gender = Gender.Female, Course = 3, Residence = "101" },
                new Student { Gender = Gender.Male, Course = 2, Residence = "101" },
                new Student { Gender = Gender.Male, Course = 3, Residence = null }
            };
            var service = new StudentService(data);

            Assert.Equal(1, service.CountMale3rdYearInDorm());
        }

        [Fact]
        public void FindStudent_ReturnsCorrectStudent()
        {
            var s = new Student { StudentTicketId = "TEST_ID", LastName = "Test" };
            var service = new StudentService(new List<Student> { s });

            var result = service.FindStudent("TEST_ID");

            Assert.NotNull(result);
            Assert.Equal("Test", result.LastName);
        }

        [Fact]
        public void Student_SleepAbility_ChangesWithCourse()
        {
            var young = new Student { FirstName = "Ivan", Course = 1 };
            var old = new Student { FirstName = "Petro", Course = 4 };

            Assert.Contains("занадто молодий", young.Sleep());
            Assert.Contains("вміє спати", old.Sleep());
        }
    }
}