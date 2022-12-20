using AutoMapper;
using Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Sql;

internal abstract class RepositoryIdBase<TEntity, TEntityDb>
    where TEntityDb : class, IEntityDb
{
    private readonly DbContext _dbContext;
    private readonly DbSet<TEntityDb> _dbSet;
    private readonly IMapper _mapper;

    protected RepositoryIdBase(DbContext dbContext, DbSet<TEntityDb> dbSet, IMapper mapper)
    {
        _dbContext = dbContext;
        _dbSet = dbSet;
        _mapper = mapper;
    }

    public async Task CreateAsync(TEntity entity)
    {
        await DoAndSaveOrResetAsync(async () =>
        {
            var entityDb = _mapper.Map<TEntityDb>(entity);
            await _dbSet.AddAsync(entityDb);
        });
    }

    public async Task UpdateAsync(TEntity entity)
    {
        await DoAndSaveOrResetAsync(async () =>
        {
            var id = _mapper.Map<TEntityDb>(entity).Id;
            var entityDb = await GetIQueryable().SingleOrDefaultAsync(e => e.Id == id);
            _mapper.Map(entity, entityDb);
        });
    }

    public async Task<IList<TEntity>> GetAsync()
    {
        var entities = await GetIQueryable().AsNoTracking().ToListAsync();
        return _mapper.Map<IList<TEntity>>(entities);
    }

    public async Task<TEntity> GetAsync(Guid id)
    {
        var entity = await GetIQueryable().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        if (entity == null)
        {
            throw new EntityNotFoundException($"{typeof(TEntity).Name} with id {id} not found");
        }
        return _mapper.Map<TEntity>(entity);
    }

    public async Task<(TEntity entity, bool found)> TryGetAsync(Guid id)
    {
        var entity = await GetIQueryable().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        return (_mapper.Map<TEntity>(entity), entity != null);
    }

    public Task DeleteAsync(Guid id)
    {
        return DoAndSaveOrResetAsync(async () =>
        {
            var entity = await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
            _dbContext.Remove(entity);
        });
    }

    protected virtual IQueryable<TEntityDb> GetIQueryable() => _dbSet;

    protected async Task DoAndSaveOrResetAsync(Func<Task> action)
    {
        try
        {
            await action();
            await _dbContext.SaveChangesAsync();
        }
        catch
        {
            ResetChanges();
            throw;
        }
    }

    private void ResetChanges() => _dbContext.ChangeTracker.Entries()
        .Where(e => e.State != EntityState.Unchanged).ToList()
        .ForEach(e => e.State = EntityState.Detached);
}