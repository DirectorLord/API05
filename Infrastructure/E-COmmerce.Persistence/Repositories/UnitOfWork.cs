

namespace E_Commerce.Persistence.Repositories;

internal class UnitOfWork(ApplicationDbContext context)
    : IUnitOfWork
{
    private readonly Dictionary<string, object> _repositories = [];
    public IRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : Entity<TKey>
    {
        var typeName = typeof(TEntity).Name;
        if (_repositories.ContainsKey(typeName))
            return (_repositories[typeName] as IRepository<TEntity, TKey>)!;
        var repo = new Repository<TEntity, TKey>(context);
        _repositories.Add(typeName, repo);
        return repo;
    }

    public async Task<int> SaveCHangesAsync(CancellationToken cancellationToken = default)
    => await context.SaveChangesAsync(cancellationToken);
}
