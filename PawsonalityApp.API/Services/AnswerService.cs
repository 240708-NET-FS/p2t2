
using Microsoft.IdentityModel.Tokens;
using Pawsonality.API.DAO;
using Pawsonality.API.Models;
using PawsonalityApp.API.Exceptions;

namespace PawsonalityApp.API.Services;

public class AnswerServices : IAnswerService
{
    private readonly IAnswerRepo _answerRepo;

    public AnswerServices (IAnswerRepo answerRepo) 
    {   
        _answerRepo = answerRepo;
    }

    public async Task<Answer> CreateAnswer(AnswerDTO answerDTO)
    {

        Answer answer = Utility.AnswerUtility.AnswerDTOToAnswer(answerDTO);

        if(answer == null) 
        {
            throw new InvalidAnswerException("Answer is null.");
        }

       return await _answerRepo.CreateAnswer(answer);
    }

    public async Task<Answer?> DeleteAnswer(int ID)
    {
        Answer? answer = await _answerRepo.GetAnswerByID(ID);
        
        if(answer == null)
        {
            throw new InvalidAnswerException("Answer not found.");
        }

        return await _answerRepo.DeleteAnswer(ID);
    }

    public async Task<Answer> GetAnswerByID(int ID)
    {

         Answer? answer = await _answerRepo.GetAnswerByID(ID);
        
        if(answer == null)
        {
            throw new InvalidAnswerException($"Answer with ID {ID} not found");
        }

        return answer;
    }

    public async Task<ICollection<Answer>> GetAnswers()
    {
        return await _answerRepo.GetAnswers();
    }

    public async Task<ICollection<Answer>> GetAnswersByQuestionID(int questionID)
    {
        ICollection<Answer> answers = await _answerRepo.GetAnswersByQuestionID(questionID);

        if(answers.IsNullOrEmpty()) 
        {
            throw new InvalidAnswerException($"There no answer created for question ID {questionID}");
        }

        return answers.ToList();
    }

    public async Task<Answer?> UpdateAnswer(int ID, AnswerDTO updatedAnswer)
    {
        Answer updatedAns = Utility.AnswerUtility.AnswerDTOToAnswer(updatedAnswer);
        Answer? answer = await _answerRepo.GetAnswerByID(ID);

        if(updatedAns == null || answer == null) 
        {
            throw new InvalidAnswerException($"Answer with ID {ID} could not be found.");
        }

        return await _answerRepo.UpdateAnswer(ID, answer);
    }
}