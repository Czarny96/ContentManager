using ContentManager.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContentManager.Infrastructure.EntityFramework.DbModelConfiguration;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .Property(x => x.Id)
            .HasConversion(x => x.Id, x => new UserId(x))
            .IsUnicode();

        builder
            .Property(x => x.Email)
            .HasConversion(x => x.Email, x => new EmailAddress(x))
            .IsRequired()
            .IsUnicode();

        builder
            .Property(x => x.Password)
            .HasConversion(x => x.Value, x => new Password(x))
            .IsRequired();

        builder.HasKey(x => x.Id);
        builder.ToTable(nameof(User), "User");
    }
}