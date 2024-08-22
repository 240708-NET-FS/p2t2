
namespace Pawsonality.API.Models;

public class AnswerDTO 
{
    public string AnswerText {get; set;} = null!;

    public string AnswerType {get; set;} = null!;

    public int QuestionID {get; set;}
}