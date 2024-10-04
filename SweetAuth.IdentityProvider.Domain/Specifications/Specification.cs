using SweetAuth.IdentityProvider.Domain.Entities;
using System.Linq.Expressions;

namespace SweetAuth.IdentityProvider.Domain.Specifications;

public abstract class Specification<TEntity>
    where TEntity : BaseEntity
{
    public Expression<Func<TEntity, bool>>? Criteria { get; }
    public Expression<Func<TEntity, object>>? OrderBy { get; private set; }
    public List<Expression<Func<TEntity, object>>>? Includes { get; } = new List<Expression<Func<TEntity, object>>>();


    public Specification()
    {
        
    }

    public Specification(Expression<Func<TEntity, bool>> criteria)
    {
        this.Criteria = criteria;
    }

    protected void AddInclude(Expression<Func<TEntity, object>> include)
    {
        this.Includes?.Add(include);
    }
    
    protected void AddOrderBy(Expression<Func<TEntity, object>> orderExpression)
    {
        this.OrderBy = orderExpression;
    }
}