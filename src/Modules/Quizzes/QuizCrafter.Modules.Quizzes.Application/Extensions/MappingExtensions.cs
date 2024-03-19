using QuizCrafter.Modules.Quizzes.Domain.Quizzes.Entities;
using QuizCrafter.Shared.Contracts.Quizzes.Contracts.Responses;
using QuizCrafter.Shared.Contracts.Quizzes.Dto;

namespace QuizCrafter.Modules.Quizzes.Application.Extensions
{
    public static class MappingExtensions
    {
        public static GetMyQuizzesResponse AsResponse(this IEnumerable<QuizItem> quizItems)
        {
            return new()
            {
                Quizzes = quizItems.Select(q => q.AsDto())
            };
        }

        public static QuizDto AsDto(this QuizItem quizItem)
        {
            return new()
            {
                Id = quizItem.Id,
                Questions = quizItem.Questions,
                Tags = quizItem.Tags,
                Title = quizItem.Title,
                UserCreatorId = quizItem.UserCreatorId
            };
        }
    }
}
