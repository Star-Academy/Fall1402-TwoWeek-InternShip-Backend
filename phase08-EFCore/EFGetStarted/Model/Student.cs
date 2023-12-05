using EFGetStarted.Model;
using System.ComponentModel.DataAnnotations;

namespace EFGetStarted.Models;

public class Student
{
    [Key]
    public int ID { get; set; }

    [Required]
    public required string FirstName { get; set; }

    [Required]
    public required string LastName { get; set; }

    public float AverageScore { get; set; }

    [Required]
    public int StudentNumber { get; set; }

    public virtual ICollection<StudentScore> Scores { get; set; }
}