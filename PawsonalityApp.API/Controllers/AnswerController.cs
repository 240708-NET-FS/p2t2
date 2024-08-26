namespace Pawsonality.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Pawsonality.API.Models;
using PawsonalityApp.API.Exceptions;
using PawsonalityApp.API.Services;

[ApiController]
[Route("api/answers")]
public class AnswerController : ControllerBase
{
    private readonly IAnswerService _answerServices;

    public AnswerController(IAnswerService answerServices)
    {
        _answerServices = answerServices;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        ICollection<Answer> answers = await _answerServices.GetAnswers();

        if (answers.IsNullOrEmpty())
        {
            return NotFound("Not answer found.");
        }

        return Ok(answers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAnswersByQuestionID(int id)
    {
        try
        {
            ICollection<Answer> answers = await _answerServices.GetAnswersByQuestionID(id);
            return Ok(answers);

        }
        catch (InvalidAnswerException e)
        {
            return NotFound(e.Message);
        }

    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AnswerDTO answer)
    {

        try
        {
            Answer createdAnswer = await _answerServices.CreateAnswer(answer);
        
            return Ok(createdAnswer);

        }
        catch (InvalidAnswerException e)
        {
            return NotFound(e.Message);
        }

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAnswer(int id, [FromBody] AnswerDTO answer)
    {

        try
        {
            Answer? updatedAnswer = await _answerServices.UpdateAnswer(id, answer);
        
            return Ok(updatedAnswer);

        }
        catch (InvalidAnswerException e)
        {
            return NotFound(e.Message);
        }

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            Answer? deletedAnswer = await _answerServices.DeleteAnswer(id);
            
            return Ok(deletedAnswer);
        }
        catch (InvalidAnswerException e)
        {
            return NotFound(e.Message);
        }
    }
}