using MediatR;

namespace BloodBank.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; private set; }
        public bool Active { get; private set; } = true;


        private List<INotification> _events;
        public IReadOnlyCollection<INotification> Events => _events?.AsReadOnly();

        public void AddDomainEvent(INotification eventItem)
        {
            _events = _events ?? new List<INotification>();
            _events.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            _events?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _events?.Clear();
        }
        
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
