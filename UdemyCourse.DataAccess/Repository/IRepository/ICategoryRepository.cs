using UdemyCourse.Models;

namespace UdemyCourse.DataAccess.Repository.IRepository;

public interface ICategoryRepository : IRepository<Category>
{
    void Update(Category obj);
}