using Microsoft.AspNetCore.Mvc;
using Pawsonality.API.Models;


[ApiController]
[Route("api/questions")]
public class QuestionController : ControllerBase
{
    private string QuestionService { get; set; }

    [HttpGet]
    public ICollection<Question> GetAll()
    {
        // return Ok(QuestionService.GetAll());
        return null!;
    }

    [HttpGet("{id}")]
    public ICollection<Question> GetAll(int id)
    {
        // return Ok(QuestionService.GetById(id));
        return null!;

    }

    [HttpPost]
    public ICollection<Question> Post([FromBody] Question question)
    {
        // Question q = QuestionService.Add(question)
        Response.StatusCode = 201;
        // return q;
        return null!;

    }

    [HttpDelete("{id}")]
    public ICollection<Question> Delete(int id)
    {
        // Question q = QuestionService.Remove(id)
        Response.StatusCode = 204;
        // return q;
        return null!;
    }
}