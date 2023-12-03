using System;
using System.Collections.Generic;
using System.Linq;
using EFGetStarted.Model;
using EFGetStarted.Models;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted.DataBaseContext
{
    public class StudentScoreRepository
    {
        private readonly StudentTopScoresContext _context;

        public StudentScoreRepository(StudentTopScoresContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<StudentScore> GetAllStudentScores()
        {
            return _context.StudentScores.ToList();
        }

        public StudentScore GetStudentScoreById(int studentScoreId)
        {
            return _context.StudentScores.Find(studentScoreId);
        }

        public void AddStudentScore(StudentScore studentScore)
        {
            if (studentScore == null)
            {
                throw new ArgumentNullException(nameof(studentScore));
            }

            _context.StudentScores.Add(studentScore);
            _context.SaveChanges();
        }

        public void AddStudentScoreList(IEnumerable<StudentScore> scores)
        {
            if (scores == null)
            {
                throw new ArgumentNullException(nameof(scores));
            }

            _context.StudentScores.AddRange(scores);
            _context.SaveChanges();
        }

        public void UpdateStudentScore(StudentScore studentScore)
        {
            if (studentScore == null)
            {
                throw new ArgumentNullException(nameof(studentScore));
            }

            _context.Entry(studentScore).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteStudentScore(int studentScoreId)
        {
            var studentScore = _context.StudentScores.Find(studentScoreId);
            if (studentScore != null)
            {
                _context.StudentScores.Remove(studentScore);
                _context.SaveChanges();
            }
        }
    }
}