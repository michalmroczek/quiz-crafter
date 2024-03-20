using QuizCrafter.Modules.Quizzes.Domain.Quizzes.Entities;
using QuizCrafter.Shared.Contracts.Quizzes.Dto;

namespace QuizCrafter.Modules.Quizzes.Application.Extensions
{
    public static class EntitiesMappingExtensions
    {
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

        public static QuizItem AsEntity(this QuizDto quizDto)
        {
            return new()
            {
                Id = quizDto.Id,
                Questions = quizDto.Questions,
                Tags = quizDto.Tags,
                Title = quizDto.Title,
                UserCreatorId = quizDto.UserCreatorId
            };
        }
    }
}
