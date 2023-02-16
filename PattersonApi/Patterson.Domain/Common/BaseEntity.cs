namespace Patterson.Domain.Common
{
    public abstract class BaseEntity<PrimaryKeyType>
    {
        public virtual PrimaryKeyType Id { get; set; }
    }
}