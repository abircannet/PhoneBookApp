namespace Core.Base
{

    public abstract class BaseEntity<T> : IEntity
    {
        public virtual T Id { get; protected set; }
    }
    public abstract class BaseEntity : BaseEntity<Guid>
    {
    }
}
