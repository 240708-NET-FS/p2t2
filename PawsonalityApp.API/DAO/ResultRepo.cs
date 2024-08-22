
using Microsoft.EntityFrameworkCore;
using Pawsonality.API.Models;

namespace Pawsonality.API.DAO;

public class ResultRepo : IResultRepo
{
    private readonly AppDbContext _context;

    public ResultRepo(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Result> CreateResult(Result result)
    {
        _context.Result.Add(result);
        await _context.SaveChangesAsync();

        return result;
    }

    public async Task<Result?> DeleteResult(int ID)
    {
        Result? result = await _context.Result.FirstOrDefaultAsync(r => r.ResultID == ID);

        if (result != null)
        {
            _context.Result.Remove(result);
            await _context.SaveChangesAsync();
        }


        return result;
    }

    public async Task<Result?> GetResultByID(int ID)
    {
        return await _context.Result.Include(r => r.User).FirstOrDefaultAsync(r => r.ResultID == ID);
    }

    public async Task<ICollection<Result>> GetResults()
    {
        return await _context.Result.Include(r => r.User).ToListAsync();
    }

    public async Task<ICollection<Result>> GetResultsByUserID(string userID)
    {
        return await _context.Result.Include(u => u.User).Where(u => u.UserId == userID).ToListAsync();
    }

    public async Task<Result?> UpdateResult(int ID, Result updatedResult)
    {
        Result? result = await _context.Result.FirstOrDefaultAsync(r => r.ResultID == ID);

        result!.ResultValue = updatedResult.ResultValue;

        await _context.SaveChangesAsync();

        return result;

    }
}