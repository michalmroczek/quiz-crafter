using MediatR;
using QuizCrafter.Shared.Contracts.Quizzes.Dto;

namespace QuizCrafter.Modules.Quizzes.Application.Quizzes.Commands
{
    public record AddQuizCommand(QuizDto quizDto) : IRequest<bool>;
}
