using Pawsonality.API.Models;

namespace PawsonalityApp.API.Services;

public interface IQuestionService
{
    public Task<Question> CreateQuenstion(QuestionDTO question);
    public Task<ICollection<Question>> GetQuestions();
    public Task<Question> GetQuestionByID(int ID);
    public Task<Question> DeleteQuestion(int ID);
    public Task<Question> UpdateQuestion(int ID, QuestionDTO updatedQuestion);
}