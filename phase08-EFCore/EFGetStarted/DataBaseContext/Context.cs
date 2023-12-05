using EFGetStarted.Model;
using EFGetStarted.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGetStarted.DataBaseContext
{
    public class StudentTopScoresContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentScore> StudentScores { get; set; }
        public string DbPath {  get; }

        public StudentTopScoresContext()
        {
            DbPath = "Server=127.0.0.1;Port=5432;Database=StudentTopScoreDB;User Id=postgres;Password=Mo@sh1380";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseNpgsql(DbPath);
    }
}
