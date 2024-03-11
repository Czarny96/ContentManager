using ContentManager.Domain.Abstractions;
using ContentManager.Domain.Projects;
using ContentManager.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContentManager.Infrastructure.EntityFramework.DbModelConfiguration;

public class ProjectEntityConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder
            .Property(x => x.Id)
            .HasConversion(x => x.Id, x => new ProjectId(x))
            .IsRequired()
            .IsUnicode();

        builder
            .Property(x => x.Name)
            .HasConversion(x => x.Value, x => new ProjectName(x))
            .IsRequired()
            .IsUnicode();
        
        builder.OwnsMany(x => x.Permissions, permission =>
        {
            permission
                .Property(x => x.UserId)
                .HasConversion(x => x.Id, x => new UserId(x))
                .IsRequired();

            permission
                .Property(x => x.PermissionType)
                .HasConversion(x => x.Id, x => Enumeration.FromId<ProjectPermissionType>(x));
        });

        builder.HasKey(x => x.Id);
        builder.ToTable(nameof(Project), "Project");
    }
}