using System.Linq.Expressions;
using EmployeeAPI.Core.Entities;
using EmployeeAPI.DAL.Context;
using EmployeeAPI.DAL.Repositories.Ports;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.DAL.Repositories.Adapters;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
{
    private readonly EmployeeAPIDbContext _context;

    public Repository(EmployeeAPIDbContext context)
    {
        _context = context;
    }
    public DbSet<TEntity> Table => _context.Set<TEntity>();

    public async Task<TEntity> Create(TEntity entity)
    {
        await Table.AddAsync(entity);
        return entity;
    }

    public void Delete(TEntity entity)
    {
        Table.Remove(entity);
    }

    public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> expression = null, params string[] includes)
    {
        // Базовый запрос
        IQueryable<TEntity> query = Table.AsNoTracking();

        // Применяем связи из includes
        foreach (var include in includes)
        {
            if (!string.IsNullOrWhiteSpace(include))
            {
                query = query.Include(include);
            }
        }

        // Применяем фильтр, если он задан
        if (expression != null)
        {
            query = query.Where(expression);
        }

        return query;
    }

    public IQueryable<TEntity> GetAll(params string[] includes)
    {
        IQueryable<TEntity> query = Table.AsNoTracking();

        // Добавляем связи из includes
        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return query;
    }

    public async Task<TEntity?> GetById(Guid id)
    {
        return await Table.AsNoTracking().FirstOrDefaultAsync(x=>x.Id == id);
    }

    public async Task<bool> IsExsist(Expression<Func<TEntity, bool>> expression)
    {
        return await Table.AnyAsync(expression);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Update(TEntity entity)
    {
        Table.Update(entity);
    }
}