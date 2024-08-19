
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pawsonality.API.Models;

public class Answer 
{
    [Key]
    public int AnswerID {get; set;}

    public string AnswerText {get; set;}

    public string AnswerType {get; set;}

    public int QuestionID {get; set;}

    [ForeignKey("QuestionID")]
    public Question? Question {get; set;}

}