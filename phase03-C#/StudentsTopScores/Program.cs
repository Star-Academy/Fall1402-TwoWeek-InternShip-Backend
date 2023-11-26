﻿using System;
using System.Text.Json;
using Newtonsoft.Json;

namespace StudentsTopScores
{
    class Program
    {
        public static void Main(string[] args)
        {
            string studentsFilePath = UserInput.GetInput("Enter students data file path: ");
            string scoresFilePath = UserInput.GetInput("Enter scores data file path: ");
            int topStudentsNum = int.Parse(UserInput.GetInput("Enter number of top students to print: "));

            StudentsInformation students = new(studentsFilePath, scoresFilePath);
            List<Student> scoredStudents = students.ConstructStudentsInformation();
            TopStudents topStudents = new();
            List<Student> topNStudents = topStudents.FindtopStudetns(scoredStudents, topStudentsNum);

            Printer.PrintTopStudents(topStudentsNum, topNStudents);

            Console.ReadKey();
        }
    }
}