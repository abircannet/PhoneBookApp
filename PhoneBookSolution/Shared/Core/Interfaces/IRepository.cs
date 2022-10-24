using Ardalis.Specification;
using Core.Base;

namespace Core.Interfaces
{
    public interface IRepository<T> : IRepositoryBase<T> where T : class, IEntity
    {
    }
}
