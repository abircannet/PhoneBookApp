using Ardalis.Specification.EntityFrameworkCore;
using Core.Base;
using Core.Interfaces;

namespace Cdr.ContactMicroservice.Persistence.Postgre
{
    public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IEntity
    {
        public EfRepository(ContactDbContext dbContext) : base(dbContext)
        {
        }
    }
}
