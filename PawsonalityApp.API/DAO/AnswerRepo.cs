
using Microsoft.EntityFrameworkCore;
using Pawsonality.API.Models;

namespace Pawsonality.API.DAO;

public class AnswerRepo : IAnswerRepo
{
    private readonly AppDbContext _context;

    public AnswerRepo (AppDbContext context) 
    {
        _context = context;
    }

    public async Task<Answer> CreateAnswer(Answer answer)
    {
        _context.Answer.Add(answer);
        await _context.SaveChangesAsync();

        return answer;
    }

    public async Task<Answer?> DeleteAnswer(int ID)
    {
        Answer? answer = await _context.Answer.FirstOrDefaultAsync(a => a.AnswerID == ID);
        if(answer != null)
        {
            _context.Answer.Remove(answer);
            await _context.SaveChangesAsync();
        } 
        

        return answer;
    }

    public async Task<Answer?> GetAnswerByID(int ID)
    {
        return await _context.Answer.FirstOrDefaultAsync(a => a.AnswerID == ID);
    }

    public async Task<ICollection<Answer>> GetAnswers()
    {
        return await _context.Answer.Include(q => q.Question).ToListAsync();
    }

    public async Task<ICollection<Answer>> GetAnswersByQuestionID(int questionID)
    {
        return await _context.Answer.Include(q => q.Question).Where(q => q.QuestionID == questionID).ToListAsync();
    }

    public Task<Answer?> UpdateAnswer(int ID, Answer updatedAnswer)
    {
        throw new NotImplementedException();
    }
}