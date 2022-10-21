using Ardalis.Specification;
using Cdr.ContactMicroservice.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdr.ContactMicroservice.Domain.Services
{
    public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class 
    {
    }
}
