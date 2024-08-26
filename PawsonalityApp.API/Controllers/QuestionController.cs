namespace Pawsonality.API.Controllers;

using Microsoft.AspNetCore.Mvc;

using Pawsonality.API.Models;
using PawsonalityApp.API.Exceptions;
using PawsonalityApp.API.Services;

[ApiController]
[Route("api/questions")]
public class QuestionController : ControllerBase
{

    private readonly IQuestionService _questionService;

    public QuestionController (IQuestionService questionService)
    {
        _questionService = questionService;
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {

        try
        {
            ICollection<Question> questions = await _questionService.GetQuestions();

            return Ok(questions.ToList());

        }
        catch (InvalidQuestionException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetQuestionByID(int id)
    {
        try
        {
            Question question = await _questionService.GetQuestionByID(id);
            return Ok(question);

        }
        catch (InvalidQuestionException e)
        {
            return NotFound(e.Message);
        }

    }

    [HttpPost]

    public async Task<IActionResult> CreateQuestion([FromBody] QuestionDTO question)
    {

        try
        {
            Question newQuestion = await _questionService.CreateQuenstion(question);

            return Ok(newQuestion);

        }
        catch (InvalidQuestionException e)
        {
            return NotFound(e.Message);
        }

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateQuestion(int id, [FromBody] QuestionDTO question)
    {

        try
        {
            Question? updatedQuestion = await _questionService.UpdateQuestion(id, question);

            return Ok(updatedQuestion);

        }
        catch (InvalidQuestionException e)
        {
            return NotFound(e.Message);
        }

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteQuestion(int id)
    {
        try
        {
            Question? deleteQ = await _questionService.DeleteQuestion(id);

            return Ok(deleteQ);
        }
        catch (InvalidQuestionException e)
        {
            return NotFound(e.Message);
        }

    }
}