namespace Pawsonality.API.Interfaces;

using Pawsonality.API.Models;


public interface IQuestionService
{
    public Task<Question?> GetById(int id);
    public Task<ICollection<Question>> GetAll();
    public Task<Question> Add(Question q);
    public Task<Question?> RemoveById(int id);
}