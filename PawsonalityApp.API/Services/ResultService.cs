using Microsoft.IdentityModel.Tokens;
using Pawsonality.API.DAO;
using Pawsonality.API.Models;
using PawsonalityApp.API.Exceptions;

namespace PawsonalityApp.API.Services;

public class ResultService : IResultService
{
    private readonly IResultRepo _resultRepo;

    public ResultService(IResultRepo resultRepo)
    {
        _resultRepo = resultRepo;
    }

    public async Task<Result> CreateResult(ResultDTO result)
    {
        Result resultFromDto = Utility.ResultUtility.ResultDTOToResult(result);

        return await _resultRepo.CreateResult(resultFromDto);
    }

    public async Task<Result?> DeleteResult(int ID)
    {
        Result? result = await _resultRepo.GetResultByID(ID);

        if (result == null)
        {
            throw new InvalidResultException($"Result with ID {ID} could not be found.");
        }

        return await _resultRepo.DeleteResult(ID);
    }

    public async Task<Result?> GetResultByID(int ID)
    {
        return await _resultRepo.GetResultByID(ID);
    }

    public async Task<ICollection<Result>> GetResults()
    {
        ICollection<Result> results = await _resultRepo.GetResults();

        if (results.IsNullOrEmpty())
        {
            throw new InvalidResultException($"Error when fetching results");
        }

        return results.ToList();
    }

    public async Task<ICollection<Result>> GetResultsByUserID(string userID)
    {
        ICollection<Result> results = await _resultRepo.GetResultsByUserID(userID);

        if (results.IsNullOrEmpty())
        {
            throw new InvalidResultException($"Error when fetching results for UserID {userID}");
        }

        return results.ToList();
    }

    public async Task<Result?> UpdateResult(int ID, ResultDTO updatedResult)
    {
        Result resultFromDto = Utility.ResultUtility.ResultDTOToResult(updatedResult);

        Result? resultExist = await _resultRepo.GetResultByID(ID);

        if (resultExist == null || resultFromDto == null)
        {
            throw new InvalidResultException($"Result with ID {ID} could not be found.");
        }

        return await _resultRepo.UpdateResult(ID, resultFromDto);
    }
}