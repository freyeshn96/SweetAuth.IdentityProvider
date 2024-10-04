using Microsoft.EntityFrameworkCore.Storage;
using SweetAuth.IdentityProvider.Infrastructure.Contexts;
using SweetAuth.IdentityProvider.Infrastructure.Interfaces;

namespace SweetAuth.IdentityProvider.Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IDbContextTransaction? _transaction;


        public UnitOfWork(AppDbContext context) 
        {
            this._context = context;
        }

        public async Task RollbackAsync()
        {
            if (_transaction is not null)
            {
                await this._transaction.RollbackAsync();
            }
        }

        public async Task CommitAsync()
        {
            if (this._transaction is not null)
            {
                await this._transaction.CommitAsync();
            }
        }

        public async Task BeginTransactionAsync()
        {
            this._transaction = await this._context.Database.BeginTransactionAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this._context.SaveChangesAsync();    
        }
    }
}
