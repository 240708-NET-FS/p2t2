using Pawsonality.API.Models;

namespace Pawsonality.API.DAO;

public interface IQuestionRepo 
{
    public Task<Question> CreateQuenstion(Question question);
    public Task<ICollection<Question>> GetQuestions();
    public Task<Question?> GetQuestionByID(int ID);
    public Task<Question> DeleteQuestion(int ID);
    public Task<Question?> UpdateQuestion(int ID, Question updatedQuestion);

}