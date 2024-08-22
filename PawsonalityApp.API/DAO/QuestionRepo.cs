
using Microsoft.EntityFrameworkCore;
using Pawsonality.API.Models;

namespace Pawsonality.API.DAO;

public class QuestionRepo : IQuestionRepo
{
    private readonly AppDbContext _context;

    public QuestionRepo(AppDbContext context) 
    {
        _context = context;
    }

    public async Task<Question> CreateQuenstion(Question question)
    {
        _context.Question.Add(question);
        await _context.SaveChangesAsync();

        return question;
    }

    public async Task<Question> DeleteQuestion(int ID)
    {
        Question question = _context.Question.Find(ID)!;

        _context.Question.Remove(question);
        await _context.SaveChangesAsync();

        return question;

    }

    public async Task<Question?> GetQuestionByID(int ID)
    {
        return await _context.Question.Include(a => a.Answer).FirstOrDefaultAsync(q => q.QuestionID == ID);
    }

    public async Task<ICollection<Question>> GetQuestions()
    {
        return await _context.Question.Include(a => a.Answer).ToListAsync();
    }

    public async Task<Question?> UpdateQuestion(int ID, Question updatedQuestion)
    {
        Question question = _context.Question.Find(ID)!;

        question.QuestionText = updatedQuestion.QuestionText;
        await _context.SaveChangesAsync();

        return question;
    }
}