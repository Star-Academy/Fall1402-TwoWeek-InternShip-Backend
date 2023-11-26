using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentsTopScores
{
    internal class StudentsInformation
    {
        private readonly string studentsFilePath;
        private readonly string scoresFilePath;

        public StudentsInformation(string studentsFilePath, string scoresFilePath)
        {
            this.studentsFilePath = studentsFilePath;
            this.scoresFilePath = scoresFilePath;
        }

        public List<Student> ConstructStudentsInformation()
        {
            List<Student> scoredStudents = new();

            try
            {
                List<Student> students = FileReader<Student>.ReadFromFile(studentsFilePath);
                List<StudentScore> scores = FileReader<StudentScore>.ReadFromFile(scoresFilePath);

                foreach (var student in students)
                {
                    student.Scores = new List<StudentScore>();
                    student.Scores.AddRange(scores.FindAll(s => s.StudentNumber == student.StudentNumber).ToList());
                    student.AverageScore = AverageCalculator.CalculateAvgForStudent(student);
                    scoredStudents.Add(student);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return scoredStudents;
        }
    }
}
