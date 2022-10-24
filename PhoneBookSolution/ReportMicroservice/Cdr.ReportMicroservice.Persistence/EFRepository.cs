using Ardalis.Specification.EntityFrameworkCore;
using Cdr.ReportMicroservice.Persistence;
using Core.Base;
using Core.Interfaces;

namespace Cdr.ContactMicroservice.Persistence
{
    public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IEntity
    {
        public EfRepository(ReportDbContext dbContext) : base(dbContext)
        {
        }
    }
}
