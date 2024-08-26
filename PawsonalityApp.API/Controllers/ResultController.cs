namespace Pawsonality.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Pawsonality.API.Models;
using PawsonalityApp.API.Exceptions;
using PawsonalityApp.API.Services;

[ApiController]
[Route("api/results")]
public class ResultController : ControllerBase
{
    private readonly IResultService _resultService;

    public ResultController(IResultService resultService)
    {
        _resultService = resultService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            ICollection<Result> results = await _resultService.GetResults();

            return Ok(results);
        }
        catch(InvalidResultException)
        {
            return NotFound("No results found. --test2");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        Result? r = await _resultService.GetResultByID(id);

        if(r is null)
            return NotFound($"Result with ID {id} not found.");

        return Ok(r);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ResultDTO resultDTO)
    {
        Result? r = await _resultService.CreateResult(resultDTO);

        if(r is null)
            return StatusCode(StatusCodes.Status500InternalServerError, "Creation failed.");

        return Created();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {

        try
        {
            Result? removed = await _resultService.DeleteResult(id);
            return Ok(removed);

        }
        catch(InvalidQuestionException)
        {
            return NotFound($"Result with ID {id} not found.");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ResultDTO resultDTO)
    {

        try
        {
            Result? r = await _resultService.UpdateResult(id, resultDTO);

            return Ok(r);

        }
        catch(InvalidResultException)
        {
            return NotFound($"Result with ID {id} not found.");
        }
    }

    [HttpGet("user/{userid}")]
    public async Task<IActionResult> GetByUserId(string userid)
    {
        try
        {
            ICollection<Result> results = await _resultService.GetResultsByUserID(userid);

            if(results is null)
                return NotFound($"No results for user with ID {userid} were found.");

            return Ok(results);
        }
        catch(InvalidResultException ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}