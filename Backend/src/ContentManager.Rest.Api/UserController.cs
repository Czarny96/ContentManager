using ContentManager.Application.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ContentManager.Rest.Api;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    private IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(CreateUserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<CreateUserResponse> CreateUser([FromBody] CreateUser command, CancellationToken cancellationToken)
    {
        return await _mediator.Send(command, cancellationToken);
    }
}