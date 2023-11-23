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
        required public List<StudentScore> Scores { get; set; }

        public float Average
        {
            get
            {
                float totalScore = 0;
                if (this.Scores != null)
                {
                    foreach (var score in this.Scores)
                    {
                        totalScore += score.Score;
                    }

                    return totalScore / Scores.Count();
                }

                return totalScore;
            }
        }
    }
}