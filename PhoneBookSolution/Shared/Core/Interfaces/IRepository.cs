using Ardalis.Specification;
using Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRepository<T>  : IRepositoryBase<T> where T : class ,IEntity
    { 
    }
}
