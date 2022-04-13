using Microsoft.EntityFrameworkCore;
using MovieDatabase.API.Models.Database;
using MovieDatabase.API.Services.Interfaces;

namespace MovieDatabase.API.Services.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly MovieDatabaseContext _dbContext;

    public Repository(MovieDatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<TEntity> GetAll()
    {
        return _dbContext.Set<TEntity>().AsNoTracking();
    }

    public async Task<TEntity> GetById(int id)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id) ?? throw new InvalidOperationException();
    }
}