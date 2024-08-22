
namespace Pawsonality.API.Models;

public class QuestionDTO
{
    
    public string QuestionText {get; set;} = null!;
   
    // One-to-Many Relationship between Question and Answers
    public ICollection<Answer>? Answer  { get; set; }

}