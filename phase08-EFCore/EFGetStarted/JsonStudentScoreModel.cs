using System;

namespace EFGetStarted
{
    public class JsonStudentScoreModel
    {
        public int StudentNumber { get; set; }
        public required string Lesson { get; set; }
        public float Score { get; set; }
    }
}