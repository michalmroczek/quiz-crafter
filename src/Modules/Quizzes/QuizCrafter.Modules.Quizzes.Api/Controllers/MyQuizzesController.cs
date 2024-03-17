using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using QuizCrafter.Modules.Quizzes.Application.Quizzes.Queries;
using System.Security.Claims;

namespace QuizCrafter.Modules.Quizzes.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route($"{QuizzesModule.BasePath}/me/quizzes")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class MyQuizzesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MyQuizzesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<QuizItemDto>>> GetQuizzesAsync()
        {
            var userIdentity = User.FindFirst(ClaimTypes.NameIdentifier);
            return Ok(_mediator.Send(new GetMyQuizzesQuery(userIdentity.Value)));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<QuizDto>> GetQuizAsync()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<QuizDto>> CreateQuiz()
        {
            return Ok();
        }

    }
    //To remove and create real dtos
    public class QuizItemDto{}
    public class QuizDto { }
}
