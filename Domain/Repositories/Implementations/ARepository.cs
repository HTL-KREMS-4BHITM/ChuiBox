using System.Linq.Expressions;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;

namespace Domain.Repositories.Implementations;

public abstract class ARepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly DishContext Context;
    protected readonly DbSet<TEntity> Table;

    
    protected ARepository(DishContext context)
    {
        Context = context;
        Table = context.Set<TEntity>();
    }
    
    public TEntity Create(TEntity t)
    {
        Table.Add(t);
        Context.SaveChanges();
        return t;;
    }

    public List<TEntity> CreateRange(List<TEntity> list)
    {
        Table.AddRange(list);
        Context.SaveChanges();
        return list;
    }

    public void Update(TEntity t)
    {
        Context.ChangeTracker.Clear();
        Table.Update(t);
        Context.SaveChanges();
    }

    public void UpdateRange(List<TEntity> list)
    {
        Table.UpdateRange(list);
        Context.SaveChanges();
    }

    public TEntity? Read(int id)
    {
        return Table.Find(id);
    }

    public List<TEntity> Read(Expression<Func<TEntity, bool>> filter)
    {
        return Table.Where(filter).ToList();
    }

    public List<TEntity> Read(int start, int count)
    {
        return Table.Skip(start).Take(count).ToList();
    }

    public List<TEntity> ReadAll()
    {
        return Table.ToList();
    }

    public void Delete(TEntity t)
    {
        Table.Remove(t);
        Context.SaveChanges();
    }
}