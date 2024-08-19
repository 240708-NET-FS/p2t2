namespace Pawsonality.API.Models;

public class Question 
{
    [key]
    public int QuestionID {get; set;}

    public string QuestionText {get; set;}
   
    // One-to-Many Relationship between Question and Answers
    public ICollection<Answer>? Answer  { get; set; }

}