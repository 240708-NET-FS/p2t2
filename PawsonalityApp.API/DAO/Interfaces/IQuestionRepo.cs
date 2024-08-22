using Pawsonality.API.Models;

namespace Pawsonality.API.DAO;

public interface IQuestionRepo 
{
    public Task<Question> CreateQuenstion();
    public Task<ICollection<Question>> GetQuestions();
    public Task<Question> GetQuestionByID();
    public Task<Question> DeleteQuestion();
    public Task<Question> UpdateQuestion();

}