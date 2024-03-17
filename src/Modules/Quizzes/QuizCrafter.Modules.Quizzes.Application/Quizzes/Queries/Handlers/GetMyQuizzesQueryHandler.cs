using MediatR;
using QuizCrafter.Modules.Quizzes.Application.Quizzes.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCrafter.Modules.Quizzes.Application.Quizzes.Queries.Handlers
{
    internal class GetMyQuizzesQueryHandler : IRequestHandler<GetMyQuizzesQuery, IEnumerable<QuizDto>>
    {
        public Task<IEnumerable<QuizDto>> Handle(GetMyQuizzesQuery request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
