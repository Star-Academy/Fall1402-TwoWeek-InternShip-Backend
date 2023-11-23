using System;
using System.Text.Json;
using Newtonsoft.Json;

namespace StudentsTopScores
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter students data file path: ");
            string studentsFilePath = Console.ReadLine() ?? "";
            Console.WriteLine("Enter scores data file path: ");
            string scoresFilePath = Console.ReadLine() ?? "";

            if (File.Exists(studentsFilePath) && File.Exists(scoresFilePath))
            {
                string studentsJsonContext = File.ReadAllText(studentsFilePath);
                string scoresJsonContext = File.ReadAllText(scoresFilePath);
                
                List<Student> students = FileReader<Student>.ReadFromFile(studentsFilePath);
                List<StudentScore> scores = FileReader<StudentScore>.ReadFromFile(scoresFilePath);

                foreach (var student in students)
                {
                    student.Scores = new List<StudentScore>();
                    student.Scores.AddRange(scores.FindAll(s => s.StudentNumber == student.StudentNumber).ToList());
                }

                Printer.PrintTopStudents(3, students);
            }
            else
            {
                Console.WriteLine("Files are missing");
            }

            Console.ReadKey();
        }
    }
}