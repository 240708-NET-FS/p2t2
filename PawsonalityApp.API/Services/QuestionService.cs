
using Microsoft.IdentityModel.Tokens;
using Pawsonality.API.DAO;
using Pawsonality.API.Models;
using PawsonalityApp.API.Exceptions;

namespace PawsonalityApp.API.Services;

public class QuestionService : IQuestionService
{
    private readonly QuestionRepo _questionRepo;

    public QuestionService (QuestionRepo questionRepo) 
    {
        _questionRepo = questionRepo;
    }

    public async Task<Question> CreateQuenstion(QuestionDTO question)
    {   
        Question q = Utility.QuestionUtility.QuestionDTOToQuestion(question);

        if(q == null) 
        {
            throw new InvalidQuestionException("Error when creating question.");
        }

        return await _questionRepo.CreateQuenstion(q);
    }

    public async Task<Question> DeleteQuestion(int ID)
    {
        Question? question = await _questionRepo.GetQuestionByID(ID);

        Question? deletedQuestion = await _questionRepo.DeleteQuestion(ID);

        if(question == null || deletedQuestion == null) 
        {
            throw new InvalidQuestionException($"Question with ID {ID} could not be found");
        }

        return deletedQuestion;
    }

    public async Task<Question> GetQuestionByID(int ID)
    {
        Question? question = await _questionRepo.GetQuestionByID(ID);

        if(question == null) 
        {
            throw new InvalidQuestionException($"Question with ID {ID} could not be found");
        }

        return question;
    }

    public async Task<ICollection<Question>> GetQuestions()
    {
       ICollection<Question> questions = await _questionRepo.GetQuestions();

       if(questions.IsNullOrEmpty()) 
       {
            throw new InvalidQuestionException("Error when fetching questions");
       }

       return questions.ToList();
    }

    public async Task<Question> UpdateQuestion(int ID, QuestionDTO updatedQuestion)
    {
        Question question = Utility.QuestionUtility.QuestionDTOToQuestion(updatedQuestion);

        Question? updatedQ = await _questionRepo.UpdateQuestion(ID, question);

        if(question == null || updatedQ == null) 
        {
            throw new InvalidQuestionException($"Question with ID {ID} could not be found");
        }

        return updatedQ;
    }
}