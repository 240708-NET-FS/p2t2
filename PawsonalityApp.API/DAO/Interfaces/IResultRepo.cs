using Pawsonality.API.Models;

namespace Pawsonality.API.DAO;

public interface IResultRepo 
{
    public Task<Result> CreateResult(Result result);
    public Task<ICollection<Result>> GetResults();
    public Task<Result?> GetResultByID(int ID);
    public Task<ICollection<Result>> GetResultsByUserID(string userID);
    public Task<Result?> DeleteResult(int ID);
    public Task<Result?> UpdateResult(int ID, Result updatedResult);

}