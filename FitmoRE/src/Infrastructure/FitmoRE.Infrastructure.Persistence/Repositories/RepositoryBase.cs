using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FitmoRE.Infrastructure.Persistence.Repositories;

public abstract class RepositoryBase<TEntity> where TEntity : class
{
    private readonly DbContext _context;

    protected RepositoryBase(DbContext context)
    {
        _context = context;
    }

    protected abstract DbSet<TEntity> DbSet { get; }

    public void Add(TEntity entity)
    {
        DbSet.Add(entity);
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
        DbSet.AddRange(entities);
    }

    public void Update(TEntity entity)
    {
        EntityEntry<TEntity> entry = GetEntry(entity);
        entry.State = EntityState.Modified;
    }

    public void Remove(TEntity entity)
    {
        EntityEntry<TEntity> entry = GetEntry(entity);
        entry.State = entry.State is EntityState.Added ? EntityState.Detached : EntityState.Deleted;
    }

    public IEnumerable<TEntity> GetAll()
    {
        return DbSet.ToList();
    }

    public TEntity GetById(int id)
    {
        return DbSet.Find(id) ?? throw new Exception("Entity not found");
    }

    protected abstract bool Equal(TEntity entity1, TEntity entity2);

    private EntityEntry<TEntity> GetEntry(TEntity entity)
    {
        TEntity? existing = DbSet.Local.FirstOrDefault(e => Equal(entity, e));

        return existing != null
            ? _context.Entry(existing)
            : DbSet.Attach(entity);
    }
}
