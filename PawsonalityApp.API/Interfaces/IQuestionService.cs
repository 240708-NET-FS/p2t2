namespace Pawsonality.API.Interfaces;

using Pawsonality.API.Models;


public interface IQuestionService
{
    public Question GetById(int id);
    public ICollection<Question> GetAll();
    public Question Add(Question q);
    public Question RemoveById(int id);
}