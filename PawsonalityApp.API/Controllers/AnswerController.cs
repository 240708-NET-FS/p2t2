namespace Pawsonality.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using Pawsonality.API.Models;


[ApiController]
[Route("api/answers")]
public class AnswerController : ControllerBase
{
    private string AnswerService { get; set; }

    [HttpGet]
    public ICollection<Answer> GetAll()
    {
        // return Ok(QuestionService.GetAll());
        return null!;
    }

    [HttpGet("{id}")]
    public ICollection<Answer> GetAll(int id)
    {
        // return Ok(QuestionService.GetById(id));
        return null!;

    }

    [HttpPost]
    public ICollection<Answer> Post([FromBody] Answer answer)
    {
        // Question q = QuestionService.Add(question)
        Response.StatusCode = 201;
        // return q;
        return null!;

    }

    [HttpDelete("{id}")]
    public ICollection<Answer> Delete(int id)
    {
        // Question q = QuestionService.Remove(id)
        Response.StatusCode = 204;
        // return q;
        return null!;
    }
}