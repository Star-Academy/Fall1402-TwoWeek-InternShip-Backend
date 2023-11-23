using System;

namespace StudentsTopScores
{
    class StudentScore
    {
        public int StudentNumber { get; set; }
        public required string Lesson { get; set; }
        public float Score { get; set; }
    }
}