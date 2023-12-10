using EFGetStarted.DataBaseContext;
using EFGetStarted.Model;
using EFGetStarted.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGetStarted
{
    public class DBWriter
    {
        List<JsonStudentModel> _students;

        public DBWriter(List<JsonStudentModel> givenStudents)
        {
            _students = givenStudents;
        }

        public void Write()
        {
            StudentTopScoresContext context = new StudentTopScoresContext();
            StudentRepository studentRepository = new StudentRepository(context);

            foreach (JsonStudentModel student in _students)
            {
                var isStudnetNumberExist = studentRepository.DoesStudentNumberExist(student.StudentNumber);

                if(!isStudnetNumberExist)
                {
                    var newStudent = studentRepository.AddStudent(new Student { FirstName = student.FirstName, LastName = student.LastName, AverageScore = student.AverageScore, StudentNumber = student.StudentNumber });

                    StudentScoreRepository studentScoreRepository = new StudentScoreRepository(context);

                    foreach (JsonStudentScoreModel score in student.Scores)
                    {
                        studentScoreRepository.AddStudentScore(new StudentScore { Lesson = score.Lesson, StudentId = newStudent.ID, Score = score.Score });
                    }
                }   
            }
        }
    }
}
