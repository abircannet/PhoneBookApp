using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdr.ContactMicroservice.Domain.Core
{
    public abstract class BaseEntity<T>
    {
        public virtual T Id { get;protected set; }
    }
    public abstract class BaseEntity:BaseEntity<Guid>
    {
        public BaseEntity()
        {
            Id= Guid.NewGuid();
        }
    }
}
