using MediatR;
using QuizCrafter.Modules.Quizzes.Application.Extensions;
using QuizCrafter.Modules.Quizzes.Domain.Quizzes.Repositories;

namespace QuizCrafter.Modules.Quizzes.Application.Quizzes.Commands.Handlers
{
    public class AddQuizCommandHandler : IRequestHandler<AddQuizCommand, bool>
    {
        private readonly IQuizRepository _quizRepository;

        public AddQuizCommandHandler(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<bool> Handle(AddQuizCommand request, CancellationToken cancellationToken)
        {
            var quizEntity = request.quizDto.AsEntity();

            await _quizRepository.AddAsync(quizEntity);
            return true;
        }
    }
}
