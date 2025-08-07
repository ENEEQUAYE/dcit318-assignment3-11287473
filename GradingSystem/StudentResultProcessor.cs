using GradingSystem.Exceptions;
using GradingSystem.Models;

namespace GradingSystem
{
    public class StudentResultProcessor
    {
        public List<Student> ReadStudentsFromFile(string inputFilePath)
        {
            var students = new List<Student>();
            using var reader = new StreamReader(inputFilePath);
            
            int lineNumber = 0;
            while (!reader.EndOfStream)
            {
                lineNumber++;
                string? line = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;
                
                var parts = line.Split(',');
                if (parts.Length != 3)
                    throw new Exceptions.MissingFieldException($"Line {lineNumber}: Expected 3 fields, got {parts.Length}");
                
                if (!int.TryParse(parts[0].Trim(), out int id))
                    throw new InvalidScoreFormatException($"Line {lineNumber}: Invalid ID format");
                
                if (!int.TryParse(parts[2].Trim(), out int score))
                    throw new InvalidScoreFormatException($"Line {lineNumber}: Invalid score format");
                
                students.Add(new Student(id, parts[1].Trim(), score));
            }
            return students;
        }

        public void WriteReportToFile(List<Student> students, string outputFilePath)
        {
            using var writer = new StreamWriter(outputFilePath);
            foreach (var student in students)
                writer.WriteLine($"{student.FullName} (ID: {student.Id}): Score = {student.Score}, Grade = {student.GetGrade()}");
        }
    }
}