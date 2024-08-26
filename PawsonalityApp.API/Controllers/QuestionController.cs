namespace Pawsonality.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using Pawsonality.API.Interfaces;
using Pawsonality.API.Models;


[ApiController]
[Route("api/questions")]
public class QuestionController : ControllerBase
{
    private IQuestionService QuestionService { get; set; }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        ICollection<Question> questions = await QuestionService.GetAll();

        return Ok(questions);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        Question? q = await QuestionService.GetById(id);

        return Ok(q);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Question question)
    {
        Question q = await QuestionService.Add(question);

        return Created();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        Question removed = await QuestionService.RemoveById(id);

        Response.StatusCode = 204;

        return null;
    }
}