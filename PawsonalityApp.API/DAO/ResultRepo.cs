
using Pawsonality.API.Models;

namespace Pawsonality.API.DAO;

public class ResultRepo : IResultRepo
{
    public Task<Result> CreateResult()
    {
        throw new NotImplementedException();
    }

    public Task<Result> DeleteAnswer()
    {
        throw new NotImplementedException();
    }

    public Task<Result> GetResultByID()
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Result>> GetResults()
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Result>> GetResultsByUserID()
    {
        throw new NotImplementedException();
    }

    public Task<Result> UpdateAnswer()
    {
        throw new NotImplementedException();
    }
}