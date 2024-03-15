using ContentManager.Domain.Projects;
using ContentManager.Domain.Users;
using MediatR;

namespace ContentManager.Application.Projects;

public record CreateProject(string Name) : IRequest;

internal class CreateProjectHandler : IRequestHandler<CreateProject>
{
    private readonly IProjectRepository _projectRepository;

    public CreateProjectHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }
    
    public async Task Handle(CreateProject request, CancellationToken cancellationToken)
    {
        // ToDo: Get current user
        var project =
            Project.Create(
                new ProjectName(request.Name),
                Domain.Projects.ProjectStatus.Activated,
                new ProjectPermission(new UserId(), ProjectPermissionType.Owner)
            );

        await _projectRepository.Add(project, cancellationToken);
    }
}