using System;
using System.Collections.Generic;
using System.Linq;
using EFGetStarted.Models;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted.DataBaseContext
{
    public class StudentRepository
    {
        private readonly StudentTopScoresContext _context;

        public StudentRepository(StudentTopScoresContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public Student GetStudentById(int studentId)
        {
            return _context.Students.Find(studentId);
        }

        public bool DoesStudentNumberExist(int studentNumber)
        {
            return _context.Students.Any(s => s.StudentNumber == studentNumber);
        }

        public Student AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            _context.Students.Add(student);
            _context.SaveChanges();
            _context.Entry(student).Reload();

            return student;
        }

        public void AddStudentList(IEnumerable<Student> students)
        {
            if (students == null)
            {
                throw new ArgumentNullException(nameof(students));
            }

            _context.Students.AddRange(students);
            _context.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            _context.Entry(student).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteStudent(int studentId)
        {
            var student = _context.Students.Find(studentId);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }

        public List<Student> GetTopStudents(int number)
        {
            return _context.Students.OrderByDescending(s => s.AverageScore).Take(number).ToList();
        }
    }
}