using EFGetStarted.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFGetStarted.Model;

public class StudentScore
{
    [Key]
    public int StudentScoreId { get; set; }

    [Required]
    public required string Lesson { get; set; }

    public float Score { get; set; }

    public int StudentId { get; set; }

    [ForeignKey("StudentId")]
    public virtual Student Student { get; set; }
}