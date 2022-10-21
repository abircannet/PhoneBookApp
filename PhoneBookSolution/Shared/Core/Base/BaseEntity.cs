using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Base
{
    
    public abstract class BaseEntity<T>:IEntity
    {
        public virtual T Id { get;protected set; }
    }
    public abstract class BaseEntity:BaseEntity<Guid>
    { 
    }
}
