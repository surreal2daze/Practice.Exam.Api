using MediatR;
using Microsoft.AspNetCore.Mvc;
using Practice.Exam.Shared;
using System.IO;

namespace Practice.Exam.Api.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly IMediator _mediator;

        protected BaseController(IMediator mediator) => _mediator = mediator;

        protected async Task<IActionResult> SendAsync<TResponse>(IRequest<CommandResult<TResponse>> request)
        {
            var commandResult = await _mediator.Send(request);
            return ProcessResponse(commandResult);
        }

        private ActionResult ProcessResponse<TData>(CommandResult<TData> result)
        {
            switch (result.ProcessResult)
            {
                case ProcessResult.Ok:
                    return Ok(result.Data);
                case ProcessResult.NotFound:
                    return NotFound(result.ErrorDetails);
                case ProcessResult.BadRequest:
                    return BadRequest(result.ErrorDetails);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}