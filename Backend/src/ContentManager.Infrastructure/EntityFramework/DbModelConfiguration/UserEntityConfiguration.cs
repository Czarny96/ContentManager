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

        builder.OwnsOne(x => x.Password, x =>
        {
            x
                .Property(p => p.Value)
                .HasColumnType("nvarchar(max)")
                .HasColumnName("Password_Value")
                .IsRequired();
            
            x
                .Property(p => p.Salt)
                .HasColumnType("uniqueidentifier")
                .HasColumnName("Password_Salt")
                .IsRequired();
        });

        builder.HasKey(x => x.Id);
        builder.HasAlternateKey(x => x.Email);
        
        builder.ToTable(nameof(User), "User");
    }
}