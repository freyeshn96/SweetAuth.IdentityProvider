using Microsoft.EntityFrameworkCore;
using SweetAuth.IdentityProvider.Domain.Entities;
using SweetAuth.IdentityProvider.Domain.Specifications;

namespace SweetAuth.IdentityProvider.Infrastructure.Specifications;

public static class SpecificationQueryBuilder
{
    public static IQueryable<TEntity> GetQuery<TEntity>(IQueryable<TEntity> inputQuery, Specification<TEntity> specification)
        where TEntity : BaseEntity
    {
        var query = inputQuery;

        if (specification.Criteria is not null)
        {
            query = query.Where(specification.Criteria);
        }
        
        if (specification.Includes is not null)
        {
            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));
        }

        return query;
    }
}