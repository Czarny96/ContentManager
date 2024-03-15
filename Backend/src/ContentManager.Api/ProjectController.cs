using ContentManager.Application.Projects;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContentManager.Api;

[ApiController]
[Route("projects")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class ProjectController : ControllerBase
{
    private IMediator _mediator;

    public ProjectController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IEnumerable<GetAllProjectsResponse>> GetAll(CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetAllProjects(), cancellationToken);
    }
}