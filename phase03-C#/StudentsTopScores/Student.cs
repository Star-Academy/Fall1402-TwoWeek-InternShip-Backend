using System;
using System.Text.Json;
using System.IO;

namespace StudentsTopScores
{
    class Student
    {
        public int StudentNumber { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public float AverageScore;
        required public List<StudentScore> Scores { get; set; }
    }
}