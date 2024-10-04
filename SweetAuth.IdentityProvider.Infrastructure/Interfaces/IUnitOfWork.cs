namespace SweetAuth.IdentityProvider.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {   
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task RollbackAsync();
        Task CommitAsync();
    }
}
