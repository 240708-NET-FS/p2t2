using System.ComponentModel.DataAnnotations;

namespace Pawsonality.API.Models;

public class Question
{
    [Key]
    public int QuestionID { get; set; }

    public string QuestionText { get; set; }

    // One-to-Many Relationship between Question and Answers
    public ICollection<Answer>? Answer { get; set; }

}