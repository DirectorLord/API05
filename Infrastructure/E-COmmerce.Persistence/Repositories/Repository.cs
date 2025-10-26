

namespace E_Commerce.Persistence.Repositories;

internal class Repository<TEntity, TKey>(ApplicationDbContext context)
    : IRepository<TEntity, TKey>
     where TEntity : Entity<TKey>
{
    public void Add(TEntity entity)
    => context.Set<TEntity>().Add(entity);

    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.Set<TEntity>().ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
    {
        return await context.Set<TEntity>().FindAsync(id, cancellationToken);
    }

    public void Remove(TEntity entity)
    => context.Set<TEntity>().Remove(entity);

    public void Update(TEntity entity)
    =>  context.Set<TEntity>().Update(entity);
    public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity> specification,CancellationToken cancellationToken = default)
    {
        return await context.Set<TEntity>().ApplySpecification(specification).ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> GetAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
    {
        return await context.Set<TEntity>().ApplySpecification(specification).FirstOrDefaultAsync(cancellationToken);
    }

    public Task<int> CountAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
    {
        return context.Set<TEntity>().ApplySpecification(specification).CountAsync(cancellationToken);
    }
}
