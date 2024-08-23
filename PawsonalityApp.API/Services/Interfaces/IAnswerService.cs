
using Pawsonality.API.Models;

namespace PawsonalityApp.API.Services;

public interface IAnswerService 
{
    public Task<Answer> CreateAnswer (AnswerDTO answerDTO);
    public Task<Answer> GetAnswerByID (int ID);
    public Task<ICollection<Answer>> GetAnswersByQuestionID(int questionID);
    public Task<Answer?> UpdateAnswer(int ID, AnswerDTO updatedAnswer);
    public Task<Answer?> DeleteAnswer(int ID);
}