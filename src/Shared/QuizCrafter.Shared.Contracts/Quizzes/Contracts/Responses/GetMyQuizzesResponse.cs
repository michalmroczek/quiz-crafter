using QuizCrafter.Shared.Contracts.Quizzes.Dto;

namespace QuizCrafter.Shared.Contracts.Quizzes.Contracts.Responses
{
    public class GetMyQuizzesResponse
    {
        public IEnumerable<QuizDto> Quizzes { get; set; }
    }
}
