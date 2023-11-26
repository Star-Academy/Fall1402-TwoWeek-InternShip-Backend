using System;

namespace StudentsTopScores
{
    class Printer
    {
        public static void PrintTopStudents(List<Student> students, int numberOfStudents)
        {
            int count = 1;
            foreach (var student in students)
            {
                if (count > numberOfStudents) 
                {
                    break;
                }
                Console.WriteLine("Stage " + count.ToString() + ": " + student.FirstName + " " + student.LastName + " with Average of: " + student.AverageScore.ToString());
                count++;
            }
        }
    }
}