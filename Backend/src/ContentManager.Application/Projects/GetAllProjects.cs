using ContentManager.Domain.Projects;
using MediatR;

namespace ContentManager.Application.Projects;

public record GetAllProjects() : IRequest;

public class GetAllProjectsHandler : IRequestHandler<GetAllProjects>
{
    private readonly IProjectRepository _projectRepository;

    public GetAllProjects(IProjectRepository projectsRepository)
    {
        _projectRepository = projectsRepository;
    }
    
    public Task Handle(GetAllProjects request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}