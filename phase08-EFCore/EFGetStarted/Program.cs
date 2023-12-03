using System;
using System.Text.Json;
using EFGetStarted.Models;
using Newtonsoft.Json;

namespace EFGetStarted
{
    class Program
    {
        public static void Main(string[] args)
        {
            string studentsFilePath = UserInput.GetInput("Enter students data file path: ");
            string scoresFilePath = UserInput.GetInput("Enter scores data file path: ");
            int topStudentsNum = int.Parse(UserInput.GetInput("Enter number of top students to print: "));

            StudentsInformation students = new(studentsFilePath, scoresFilePath);
            List<JsonStudentModel> scoredStudents = students.ConstructStudentsInformation();

            DBWriter dbWriter = new DBWriter(scoredStudents);
            dbWriter.Write();

            TopStudents topStudents = new();
            List<Student> topNStudents = topStudents.FindtopStudetns(topStudentsNum);

            Printer.PrintTopStudents(topNStudents, topStudentsNum);

            Console.ReadKey();
        }
    }
}