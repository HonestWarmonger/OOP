using System.Collections.Generic;
using System.Linq;
using StudentSystem.Core;
using StudentSystem.DAL;

namespace StudentSystem.BLL
{
    public class StudentService
    {
        private readonly FileRepository? _repository;
        private List<Student> _students;

        public StudentService()
        {
            _repository = new FileRepository();
            _students = _repository.Load();
        }

        public StudentService(List<Student> testData)
        {
            _repository = null;
            _students = testData;
        }

        public List<Student> GetAll() => _students;

        public void AddStudent(Student student)
        {
            _students.Add(student);
            if (_repository != null) _repository.Save(_students);
        }

        public Student? FindStudent(string ticketId)
        {
            return _students.FirstOrDefault(s => s.StudentTicketId == ticketId);
        }

        public int CountMale3rdYearInDorm()
        {
            return _students.Count(s =>
                s.Gender == Gender.Male &&
                s.Course == 3 &&
                !string.IsNullOrEmpty(s.Residence));
        }

        public bool RelocateStudent(string ticketId, string newRoom)
        {
            var student = FindStudent(ticketId);
            if (student == null) return false;

            student.Residence = newRoom;
            if (_repository != null) _repository.Save(_students);
            return true;
        }
    }
}