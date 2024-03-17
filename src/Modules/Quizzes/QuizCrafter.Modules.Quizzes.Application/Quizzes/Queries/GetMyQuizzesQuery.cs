using MediatR;
using QuizCrafter.Modules.Quizzes.Application.Quizzes.DTO;

namespace QuizCrafter.Modules.Quizzes.Application.Quizzes.Queries
{
    public record GetMyQuizzesQuery(string UserId) : IRequest<IEnumerable<QuizDto>>;
}
