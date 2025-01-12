using System.Linq.Expressions;
using EmployeeAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.DAL.Repositories.Ports;

public interface IRepository<TEntity>where TEntity : BaseEntity,new()
{
    public DbSet<TEntity> Table { get; } 
    public Task<TEntity?> GetById(Guid id, params string[] includes);
    public IQueryable<TEntity> GetAll(params string[] includes);
    public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> expression = null, params string[] includes);
    public IQueryable<TEntity> FindAllTracking(Expression<Func<TEntity, bool>> expression = null, params string[] includes);
    public Task<TEntity> Create(TEntity entity);
    public void Update(TEntity entity);
    public void Delete(TEntity entity);
    public Task<int> SaveChangesAsync();
    public Task<bool> IsExist(Expression<Func<TEntity, bool>> expression);
}