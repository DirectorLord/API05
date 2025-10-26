namespace E_Commerce.Persistence.Repositories;

internal static class SpecificationEvaluation
{
    public static IQueryable<TEntity> ApplySpecification<TEntity>(this IQueryable<TEntity> inputQuery,ISpecification<TEntity> specification)
        where TEntity : class
    {
        var query = inputQuery;
        foreach (var include in specification.Includes)
        {
            query = query.Include(include);
        }

        if(specification.Criteria is not null)
        {
             query = query.Where(specification.Criteria);
        }

        if(specification.OrderBy is not null)
             query = query.OrderBy(specification.OrderBy);
        else if(specification.OrderByDesc is not null)
            query = query.OrderByDescending(specification.OrderByDesc);

        if(specification.IsPaginated)
            query = query.Skip(specification.Skip).Take(specification.Take);
            return query;
    }
}
