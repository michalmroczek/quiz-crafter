using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using QuizCrafter.Modules.Quizzes.Application.Quizzes.Commands;
using QuizCrafter.Modules.Quizzes.Application.Quizzes.Queries;
using QuizCrafter.Shared.Contracts.Quizzes.Contracts.Requests;
using QuizCrafter.Shared.Contracts.Quizzes.Contracts.Responses;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetMyQuizzesResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<GetMyQuizzesResponse>> GetQuizzesAsync()
        {
            var userIdentity = User.FindFirst(ClaimTypes.NameIdentifier);
            var response = await _mediator.Send(new GetQuizzesByUserQuery(Guid.Parse(userIdentity.Value)));
            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetQuizResponse>> GetQuizAsync(Guid id)
        {
            var userIdentity = User.FindFirst(ClaimTypes.NameIdentifier);
            var response = await _mediator.Send(new GetQuizQuery(id, Guid.Parse(userIdentity.Value)));
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateQuiz(CreateQuizRequest createQuizRequest)
        {
            var userIdentity = User.FindFirst(ClaimTypes.NameIdentifier);
            createQuizRequest.Quiz.UserCreatorId = Guid.Parse(userIdentity.Value);
            await _mediator.Send(new AddQuizCommand(createQuizRequest.Quiz));
            return NoContent();
        }

    }
}

