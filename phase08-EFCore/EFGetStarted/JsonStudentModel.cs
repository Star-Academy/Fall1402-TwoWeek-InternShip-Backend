using System;
using System.Text.Json;
using System.IO;

namespace EFGetStarted
{
    public class JsonStudentModel
    {
        public int StudentNumber { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public float AverageScore;
        public required List<JsonStudentScoreModel> Scores { get; set; }
    }
}