using MediatR;
using QuizCrafter.Modules.Quizzes.Application.Extensions;
using QuizCrafter.Modules.Quizzes.Domain.Quizzes.Repositories;
using QuizCrafter.Shared.Contracts.Quizzes.Contracts.Responses;

namespace QuizCrafter.Modules.Quizzes.Application.Quizzes.Queries.Handlers
{
    public class GetMyQuizzesQueryHandler : IRequestHandler<GetMyQuizzesQuery, GetMyQuizzesResponse>
    {
        private readonly IQuizRepository _quizRepository;

        public GetMyQuizzesQueryHandler(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<GetMyQuizzesResponse> Handle(GetMyQuizzesQuery request, CancellationToken cancellationToken)
            => (await _quizRepository.BrowseByUserAsync(request.UserId)).AsResponse();
        
    }
}
