using Pawsonality.API.DAO;
using Pawsonality.API.Interfaces;
using Pawsonality.API.Models;

public class QuestionService : IQuestionService
{
    private QuestionRepo QuestionRepo { get; set; }

    public async Task<Question> Add(Question q)
    {
        // validate input
        if(q is null)
            throw new ArgumentNullException("Question must not be null");

        // try to add a question
        Question addedQuestion = await QuestionRepo.CreateQuenstion(q);

        // check if we got a question back from DAO
        if(addedQuestion is null)
        {
            //throw new DAOException("Database could failed on persisting the question");
            return null!;
        }

        // return question object
        return addedQuestion;
    }

    public async Task<ICollection<Question>> GetAll()
    {
        // get questions
        ICollection<Question> questions = await QuestionRepo.GetQuestions();

        // return them
        return questions;
    }

    public async Task<Question?> GetById(int id)
    {
        // get question by id
        Question? q = await QuestionRepo.GetQuestionByID(id);

        return q;
    }

    public async Task<Question?> RemoveById(int id)
    {
        // delete question by id
        Question? q = await QuestionRepo.DeleteQuestion(id);

        return q;
    }
}