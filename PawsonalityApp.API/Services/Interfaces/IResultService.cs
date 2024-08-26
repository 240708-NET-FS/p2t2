using Pawsonality.API.Models;

namespace PawsonalityApp.API.Services;

public interface IResultService
{

    public Task<Result> CreateResult(ResultDTO result);
    public Task<ICollection<Result>> GetResults();
    public Task<Result?> GetResultByID(int ID);
    public Task<ICollection<Result>> GetResultsByUserID(string userID);
    public Task<Result?> DeleteResult(int ID);
    public Task<Result?> UpdateResult(int ID, ResultDTO updatedResult);
}