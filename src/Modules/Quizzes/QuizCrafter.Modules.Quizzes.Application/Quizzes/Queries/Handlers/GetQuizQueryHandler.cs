using MediatR;
using QuizCrafter.Modules.Quizzes.Application.Extensions;
using QuizCrafter.Modules.Quizzes.Domain.Quizzes.Repositories;
using QuizCrafter.Shared.Contracts.Quizzes.Contracts.Responses;

namespace QuizCrafter.Modules.Quizzes.Application.Quizzes.Queries.Handlers
{
    public class GetQuizQueryHandler : IRequestHandler<GetQuizQuery, GetQuizResponse>
    {
        private readonly IQuizRepository _quizRepository;

        public GetQuizQueryHandler(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<GetQuizResponse> Handle(GetQuizQuery request, CancellationToken cancellationToken)
        {
            var quiz = await _quizRepository.GetAsync(request.QuizId);
            return quiz.AsResponse();
        }
    }
}
