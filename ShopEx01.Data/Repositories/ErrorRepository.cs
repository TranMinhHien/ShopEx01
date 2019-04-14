using ShopEx01.Data.Infrastructure;
using ShopEx01.Model.Models;

namespace ShopEx01.Data.Repositories
{
    public interface IErrorRepository: IRepository<Error>
    {

    }
    public class ErrorRepository:RepositoryBase<Error>, IErrorRepository
    {
        public ErrorRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
