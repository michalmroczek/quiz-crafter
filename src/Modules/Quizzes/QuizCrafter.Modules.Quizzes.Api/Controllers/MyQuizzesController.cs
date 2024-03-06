using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace QuizCrafter.Modules.Quizzes.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route($"{QuizzesModule.BasePath}/me/quizzes")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class MyQuizzesController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<QuizItemDto>>> GetQuizzesAsync()
        {
            return Ok();
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
