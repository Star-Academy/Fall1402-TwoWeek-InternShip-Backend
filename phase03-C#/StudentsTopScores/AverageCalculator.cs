using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsTopScores
{
    internal class AverageCalculator
    {
        public static float CalculateAvgForStudent(Student student)
        {
            return student.Scores.Average(s => s.Score);
        }
    }
}
