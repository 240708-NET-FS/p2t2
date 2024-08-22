using Microsoft.AspNetCore.Mvc;
using Pawsonality.API.Models;


[ApiController]
[Route("api/results")]
public class ResultController : ControllerBase
{
    private string ResultService { get; set; }

    [HttpGet]
    public ICollection<Result> GetAll()
    {
        // return Ok(QuestionService.GetAll());
        return null!;
    }

    [HttpGet("{id}")]
    public ICollection<Result> GetAll(int id)
    {
        // return Ok(QuestionService.GetById(id));
        return null!;

    }

    [HttpPost]
    public ICollection<Result> Post([FromBody] Result result)
    {
        // Question q = QuestionService.Add(question)
        Response.StatusCode = 201;
        // return q;
        return null!;

    }

    [HttpDelete("{id}")]
    public ICollection<Result> Delete(int id)
    {
        // Question q = QuestionService.Remove(id)
        Response.StatusCode = 204;
        // return q;
        return null!;
    }
}