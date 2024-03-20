using QuizCrafter.Shared.Contracts.Quizzes.Dto;

namespace QuizCrafter.Shared.Contracts.Quizzes.Contracts.Requests
{
    public class CreateQuizRequest
    {
        public QuizDto Quiz { get; set; }
    }
}
