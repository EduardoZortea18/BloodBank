namespace BloodBank.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; private set; }
        public bool Active { get; private set; } = true;

        public void UpdateDate()
        {
            UpdatedAt = DateTime.UtcNow;
        }

        public void Delete()
        {
            Active = false;
        }
    }
}
