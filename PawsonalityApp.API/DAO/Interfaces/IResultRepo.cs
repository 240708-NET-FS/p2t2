using Pawsonality.API.Models;

namespace Pawsonality.API.DAO;

public interface IResultRepo 
{
    public Task<Result> CreateResult();
    public Task<ICollection<Result>> GetResults();
    public Task<Result> GetResultByID();
    public Task<ICollection<Result>> GetResultsByUserID();
    public Task<Result> DeleteAnswer();
    public Task<Result> UpdateAnswer();

}