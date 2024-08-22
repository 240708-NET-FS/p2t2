
using Pawsonality.API.Models;

namespace Pawsonality.API.DAO;

public interface IAnswerRepo 
{
    public Task<Answer> CreateAnswer(Answer answer);
    public Task<ICollection<Answer>> GetAnswers();
    public Task<Answer?> GetAnswerByID(int ID);
    public Task<ICollection<Answer>> GetAnswersByQuestionID(int questionID);
    public Task<Answer?> DeleteAnswer(int ID);
    public Task<Answer?> UpdateAnswer(int ID, Answer updatedAnswer);

}