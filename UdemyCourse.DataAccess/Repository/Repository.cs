using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using UdemyCourse.DataAccess.Data;
using UdemyCourse.DataAccess.Repository.IRepository;

namespace UdemyCourse.DataAccess.Repository;

public class Repository<T> : IRepository<T> where T: class
{
    private readonly AppDbContext _db;
    internal DbSet<T> dbSet;

    public Repository(AppDbContext db)
    {
        _db = db;
        _db.Products.Include(u => u.Category);
        this.dbSet = _db.Set<T>();
    }
    //includeProp - "Category,CoverType"
    public T GetFirstOrDefault(Expression<Func<T, bool>> filter,string? includeProperties = null)
    {
        IQueryable<T> query = dbSet;
        query = query.Where(filter);
        if (includeProperties != null)
        {
            foreach (var includeProp in (includeProperties.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries)))
            {
                query = query.Include(includeProp);
            }
        }
        return query.FirstOrDefault();
    }

    public IEnumerable<T> GetAll(string? includeProperties = null)
    {
        IQueryable<T> query = dbSet;
        if (includeProperties != null)
        {
            foreach (var includeProp in (includeProperties.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries)))
            {
                query = query.Include(includeProp);
            }
        }
        return query.ToList();
    }

    public void Add(T entity)
    {
        dbSet.Add(entity);
    }

    public void Remove(T entity)
    {
        dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        dbSet.RemoveRange(entities);
    }
}