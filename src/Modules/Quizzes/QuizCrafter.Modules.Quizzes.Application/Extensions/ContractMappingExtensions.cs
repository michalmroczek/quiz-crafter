using QuizCrafter.Modules.Quizzes.Domain.Quizzes.Entities;
using QuizCrafter.Shared.Contracts.Quizzes.Contracts.Responses;

namespace QuizCrafter.Modules.Quizzes.Application.Extensions
{
    public static class ContractMappingExtensions
    {
        public static GetMyQuizzesResponse AsResponse(this IEnumerable<QuizItem> quizItems)
        {
            return new()
            {
                Quizzes = quizItems.Select(q => q.AsDto())
            };
        }

        public static GetQuizResponse AsResponse(this QuizItem quizItem)
        {
            return new()
            {
               Quiz = quizItem.AsDto()
            };
        }
    }
}
