using QuizCrafter.Modules.Quizzes.Domain.Quizzes.Entities;

namespace QuizCrafter.Modules.Quizzes.Domain.Quizzes.Repositories
{
    public interface IQuizRepository
    {
        Task<IEnumerable<QuizItem>> BrowseByUserAsync(Guid userId);
        Task<QuizItem> GetAsync(Guid Id);
        Task AddAsync(QuizItem item);
        Task UpdateAsync(QuizItem item);
        Task DeleteAsync(QuizItem item);
    }
}
