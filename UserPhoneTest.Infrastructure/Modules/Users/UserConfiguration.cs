using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserPhoneTest.Domain.Modules.Users;

namespace UserPhoneTest.Infrastructure.Modules.Users;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasMany(u => u.Phones)
            .WithOne(p => p.User);

        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(UserAttributeConstants.MaxNameLength);

        builder.Property(u => u.Email)
            .IsRequired();

        builder.HasIndex(u => u.Email)
            .IsUnique()
            .HasDatabaseName("IX_User_Email");

        builder.HasIndex(u => u.Name)
            .HasDatabaseName("IX_User_Name");
    }
}
