using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using StudentSystem.Core;

namespace StudentSystem.DAL
{
    public class FileRepository
    {
        private readonly string _filePath = "students.json";

        public void Save(List<Student> students)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(students, options);
            File.WriteAllText(_filePath, json);
        }

        public List<Student> Load()
        {
            if (!File.Exists(_filePath)) return new List<Student>();
            string json = File.ReadAllText(_filePath);
            if (string.IsNullOrWhiteSpace(json)) return new List<Student>();
            return JsonSerializer.Deserialize<List<Student>>(json);
        }
    }
}