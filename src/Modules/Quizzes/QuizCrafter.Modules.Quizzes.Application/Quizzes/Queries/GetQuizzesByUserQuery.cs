using MediatR;
using QuizCrafter.Shared.Contracts.Quizzes.Contracts.Responses;

namespace QuizCrafter.Modules.Quizzes.Application.Quizzes.Queries
{
    public record GetQuizzesByUserQuery(Guid UserId) : IRequest<GetMyQuizzesResponse>;
}
