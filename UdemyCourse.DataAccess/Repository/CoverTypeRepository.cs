using System.Runtime.InteropServices.ComTypes;
using UdemyCourse.DataAccess.Data;
using UdemyCourse.DataAccess.Repository.IRepository;
using UdemyCourse.Models;

namespace UdemyCourse.DataAccess.Repository;

public class CoverTypeRepositoryRepository : Repository<CoverType>, ICoverTypeRepository
{
    private AppDbContext _db;
    public CoverTypeRepositoryRepository(AppDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(CoverType obj)
    {
        _db.CoverTypes.Update(obj);
    }
}