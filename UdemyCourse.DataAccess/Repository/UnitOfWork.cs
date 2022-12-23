using UdemyCourse.DataAccess.Data;
using UdemyCourse.DataAccess.Repository.IRepository;


namespace UdemyCourse.DataAccess.Repository;

public class UnitOfWork : IUnitOfWork
{
    private AppDbContext _db;

    public UnitOfWork(AppDbContext db)
    {
        _db = db;
        Category = new CategoryRepository(_db);
        CoverType = new CoverTypeRepositoryRepository(_db);
        Product = new ProductRepository(_db);
    }
    public ICategoryRepository Category { get; private set; }
    public ICoverTypeRepository CoverType { get; private set; }
    public IProductRepository Product { get; private set; }
    public void Save()
    {
        _db.SaveChanges();
    }
}