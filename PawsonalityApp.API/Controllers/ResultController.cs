namespace Pawsonality.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Pawsonality.API.Models;
using PawsonalityApp.API.Exceptions;
using PawsonalityApp.API.Services;

[ApiController]
[Route("api/results")]
public class ResultController : ControllerBase
{
    private readonly ResultService _resultService;

    public ResultController(ResultService resultService)
    {
        _resultService = resultService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        ICollection<Result> results = await _resultService.GetResults();

        if(results.IsNullOrEmpty())
            return NotFound("No results found.");

        return Ok(results);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        Result? r = await _resultService.GetResultByID(id);

        if(r is null)
            return NotFound($"Response with ID {id} not found.");

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
        catch(InvalidQuestionException ex)
        {
            return NotFound($"Result with ID {id} not found.");
        }
    }
}