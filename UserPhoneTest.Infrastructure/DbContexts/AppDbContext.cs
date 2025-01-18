using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UserPhoneTest.Domain.Modules.Phones;
using UserPhoneTest.Domain.Modules.Users;

namespace UserPhoneTest.Infrastructure.DbContexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Phone> Phones => Set<Phone>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
