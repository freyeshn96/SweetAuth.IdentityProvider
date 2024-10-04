using SweetAuth.IdentityProvider.Domain.Entities;
using SweetAuth.IdentityProvider.Domain.Specifications;

namespace SweetAuth.IdentityProvider.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IRepository<TEntity> WithTrackingValue(bool trackingValue);
        Task<TEntity> InsertAsync(TEntity entity, CancellationToken token);
        TEntity Insert(TEntity entity);
        Task<List<TEntity>> InsertRangeAsync(IEnumerable<TEntity> entities, CancellationToken token);
        List<TEntity> InsertRange(IEnumerable<TEntity> entities);
        Task<List<TEntity>> GetAllAsync(CancellationToken token);
        List<TEntity> GetAll();
        Task<List<TEntity>> GetBySpecAsync(Specification<TEntity> spec, CancellationToken token);
        List<TEntity> GetBySpec(Specification<TEntity> spec);
        Task<TEntity?> FirstBySpecAsync(Specification<TEntity> spec, CancellationToken token);
        TEntity? FirstBySpec(Specification<TEntity> spec);
        Task<TEntity?> GetByIdAsync(int id, CancellationToken token);
        TEntity? GetById(int id);
        Task<bool> ExistsAsync(int id, CancellationToken cancellationToken);
        bool Exists(int id);
        Task<bool> ExistsBySpecAsync(Specification<TEntity> spec, CancellationToken cancellationToken);
        bool ExistsBySpec(Specification<TEntity> spec);
        Task<int> SaveChangesAsync(CancellationToken token);
        int SaveChanges();
        TEntity Update(TEntity entity);
        List<TEntity> UpdateRange(IEnumerable<TEntity> entities);
        TEntity SoftDelete(TEntity entity);
    }
}
