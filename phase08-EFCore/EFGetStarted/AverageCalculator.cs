using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGetStarted
{
    internal class AverageCalculator
    {
        public static float CalculateAvgForStudent(JsonStudentModel student)
        {
            return student.Scores.Average(s => s.Score);
        }
    }
}
