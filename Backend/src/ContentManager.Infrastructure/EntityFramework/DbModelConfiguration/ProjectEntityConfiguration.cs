using ContentManager.Domain.Projects;
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
        
        builder.OwnsMany(x => x.Permission, permission =>
        {
           permission
               .Property(p => p.)
        });
    }
}