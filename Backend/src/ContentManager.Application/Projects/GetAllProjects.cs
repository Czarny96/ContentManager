using ContentManager.Domain.Projects;
using ContentManager.Domain.Users;
using MediatR;

namespace ContentManager.Application.Projects;

public record GetAllProjects : IRequest<IReadOnlyCollection<GetAllProjectsResponse>;

public record GetAllProjectsResponse(
    Guid Id,
    string Name,
    ProjectStatus Status
);

public class GetAllProjectsHandler : IRequestHandler<GetAllProjects, IReadOnlyCollection<GetAllProjectsResponse>
{
    private readonly IProjectRepository _projectRepository;

    public GetAllProjectsHandler(IProjectRepository projectsRepository)
    {
        _projectRepository = projectsRepository;
    }
    
    public async Task<IReadOnlyCollection<GetAllProjectsResponse>> Handle(GetAllProjects request, CancellationToken cancellationToken)
    {
        // ToDo: Get current user
        var projects =  _projectRepository.GetAll(new UserId(Guid.NewGuid()), cancellationToken);

        if (projects.Count == 0)
        {
            return Array.Empty<GetAllProjectsResponse>();
        }

        return projects.Select(x =>
            new GetAllProjectsResponse(
                x.Id.Id,
                x.Name.Value,
                (ProjectStatus)x.Status.Id
            )
        )
        .ToList()
        .AsReadOnly();
    }
}