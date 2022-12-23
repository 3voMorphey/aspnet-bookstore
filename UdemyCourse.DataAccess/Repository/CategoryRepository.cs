using UdemyCourse.DataAccess.Data;
using UdemyCourse.DataAccess.Repository.IRepository;
using UdemyCourse.Models;

namespace UdemyCourse.DataAccess.Repository;

public class CategoryRepository : Repository<Category>,ICategoryRepository
{
    private AppDbContext _db;
    public CategoryRepository(AppDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Category obj)
    {
        _db.Categories.Update(obj);
    }

   
}