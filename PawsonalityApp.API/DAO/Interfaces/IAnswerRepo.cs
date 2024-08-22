
using Pawsonality.API.Models;

namespace Pawsonality.API.DAO;

public interface IAnswerRepo 
{
    public Task<Answer> CreateAnswer();
    public Task<ICollection<Answer>> GetAnswers();
    public Task<Answer> GetAnswerByID();
    public Task<ICollection<Answer>> GetAnswersByQuestionID();
    public Task<Answer> DeleteAnswer();
    public Task<Answer> UpdateAnswer();

}