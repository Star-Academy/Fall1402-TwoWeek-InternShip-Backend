using System;

namespace StudentsTopScores
{
    class Printer
    {
        public static void PrintTopStudents(int numberOfStudents, List<Student> students)
        {
            List<Student> topStudents = students.OrderByDescending(s => s.Average).Take(numberOfStudents).ToList();
            int count = 1;
                foreach (var student in topStudents)
                {
                    Console.WriteLine("Stage " + count.ToString() + ": " + student.FirstName + " " + student.LastName + " with Average of: " + student.Average.ToString());
                    count++;
                }
        }
    }
}