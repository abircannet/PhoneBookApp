using Ardalis.Specification;
using Core.Base;

namespace Core.Interfaces
{
    public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IEntity
    {
    }
}
