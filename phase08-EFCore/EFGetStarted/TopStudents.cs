using EFGetStarted.DataBaseContext;
using EFGetStarted.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGetStarted
{
    internal class TopStudents
    {
        public List<Student> FindtopStudetns(int numberOfStudents)
        {
            StudentTopScoresContext studentTopScoresContext = new StudentTopScoresContext();
            StudentRepository studentRepository = new StudentRepository(studentTopScoresContext);
            List<Student> topStudents = studentRepository.GetTopStudents(numberOfStudents);
            return topStudents;
        }
    }
}
