using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsTopScores
{
    internal class TopStudents
    {
        public List<Student> FindtopStudetns(List<Student> scoredStudents, int numberOfStudents)
        {
            List<Student> topStudents = scoredStudents.OrderByDescending(s => s.AverageScore).Take(numberOfStudents).ToList();
            return topStudents;
        }
    }
}
