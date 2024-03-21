using Microsoft.EntityFrameworkCore;
using QuizCrafter.Modules.Quizzes.Domain.Quizzes.Entities;
using QuizCrafter.Modules.Quizzes.Domain.Quizzes.Repositories;

namespace QuizCrafter.Modules.Quizzes.Infrastructure.EF.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly QuizzesDbContext _context;

        public QuizRepository(QuizzesDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(QuizItem item)
        {
            _context.Quizzes.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<QuizItem>> BrowseByUserAsync(Guid userId)
        {
            return await _context.Quizzes.Where(t=>t.UserCreatorId == userId).ToListAsync();
        }

        public Task DeleteAsync(QuizItem item)
        {
            throw new NotImplementedException();
        }

        public Task<QuizItem> GetAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(QuizItem item)
        {
            throw new NotImplementedException();
        }
    }
}
