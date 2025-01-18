namespace UserPhoneTest.Application.Services;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}
