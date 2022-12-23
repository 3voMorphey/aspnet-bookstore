using UdemyCourse.Models;

namespace UdemyCourse.DataAccess.Repository.IRepository;

public interface ICoverTypeRepository: IRepository<CoverType>
{
    void Update(CoverType obj);
}