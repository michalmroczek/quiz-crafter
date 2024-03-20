using MediatR;
using QuizCrafter.Shared.Contracts.Quizzes.Contracts.Responses;

namespace QuizCrafter.Modules.Quizzes.Application.Quizzes.Queries
{
    public record GetQuizQuery(Guid QuizId, Guid UserId) : IRequest<GetQuizResponse>;
}
