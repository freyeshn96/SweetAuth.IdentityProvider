using Microsoft.EntityFrameworkCore;
using SweetAuth.IdentityProvider.Domain.Entities;
using SweetAuth.IdentityProvider.Domain.Interfaces;

namespace SweetAuth.IdentityProvider.Infrastructure.Repositories
{
    public class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        private readonly TContext _dbContext;
        private bool _trackingEntities = true;
        
        public Repository(TContext dbContext) {
            this._dbContext = dbContext;
        }

        public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            DbSet<TEntity> entity = this._dbContext.Set<TEntity>();

            if (!this._trackingEntities)
            {
                IQueryable<TEntity> queryable =
                    this._dbContext.Set<TEntity>().AsNoTracking();
                
                return await queryable.ToListAsync(cancellationToken); 
            }
            
            return await entity.ToListAsync(cancellationToken);
        }
        
        public List<TEntity> GetAll()
        {
            DbSet<TEntity> entity = this._dbContext.Set<TEntity>();

            if (!this._trackingEntities)
            {
                IQueryable<TEntity> queryable =
                    this._dbContext.Set<TEntity>().AsNoTracking();
                
                return queryable.ToList(); 
            }
            
            return entity.ToList();
        }

        public async Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            if (!this._trackingEntities)
            {
                IQueryable<TEntity> queryable =
                    this._dbContext.Set<TEntity>().AsNoTracking();
                
                return await queryable.FirstOrDefaultAsync(q => q.Id == id, cancellationToken); 
            }
            
            return await this._dbContext.Set<TEntity>().FindAsync(id, cancellationToken);
        }
        
        public TEntity? GetById(int id)
        {
            if (!this._trackingEntities)
            {
                IQueryable<TEntity> queryable =
                    this._dbContext.Set<TEntity>().AsNoTracking();
                
                return queryable.FirstOrDefault(q => q.Id == id); 
            }
            
            return this._dbContext.Set<TEntity>().Find(id);
        }
        
        public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken)
        {
            return await this._dbContext.Set<TEntity>().AnyAsync(e => e.Id == id, cancellationToken);
        }
        
        public bool Exists(int id)
        {
            return this._dbContext.Set<TEntity>().Any(e => e.Id == id);
        }
        
        public IRepository<TEntity> WithTrackingValue(bool trackingValue)
        {
            this._trackingEntities = trackingValue;

            return this;
        }

        public async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await this._dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);

            return entity;
        }
        
        public TEntity Insert(TEntity entity)
        {
            this._dbContext.Set<TEntity>().Add(entity);

            return entity;
        }

        public async Task<List<TEntity>> InsertRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
        {
            List<TEntity> entitiesList = entities.ToList();
            await this._dbContext.Set<TEntity>().AddRangeAsync(entitiesList, cancellationToken);

            return entitiesList;
        }
        
        public List<TEntity> InsertRange(IEnumerable<TEntity> entities)
        {
            List<TEntity> entitiesList = entities.ToList();
            this._dbContext.Set<TEntity>().AddRangeAsync(entitiesList);

            return entitiesList;
        }


        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await this._dbContext.SaveChangesAsync(cancellationToken);
        }
        
        public int SaveChanges()
        {
            return this._dbContext.SaveChanges();
        }

        public TEntity SoftDelete(TEntity entity)
        {
            entity.IsDeleted = true;
            
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            this._dbContext.Set<TEntity>().Update(entity);

            return entity;
        }

        public List<TEntity> UpdateRange(IEnumerable<TEntity> entities)
        {
            List<TEntity> entitiesList = entities.ToList();
            this._dbContext.Set<TEntity>().UpdateRange(entitiesList);

            return entitiesList;
        }
    }
}
