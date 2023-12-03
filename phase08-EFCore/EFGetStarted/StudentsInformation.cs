using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EFGetStarted
{
    internal class StudentsInformation
    {
        private readonly string StudentsFilePath;
        private readonly string ScoresFilePath;

        public StudentsInformation(string studentsFilePath, string scoresFilePath)
        {
            this.StudentsFilePath = studentsFilePath;
            this.ScoresFilePath = scoresFilePath;
        }

        public List<JsonStudentModel> ConstructStudentsInformation()
        {
            List<JsonStudentModel> scoredStudents = new();

            try
            {
                List<JsonStudentModel> students = FileReader<JsonStudentModel>.ReadFromFile(StudentsFilePath);
                List<JsonStudentScoreModel> scores = FileReader<JsonStudentScoreModel>.ReadFromFile(ScoresFilePath);

                foreach (var student in students)
                {
                    student.Scores = new List<JsonStudentScoreModel>();
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
