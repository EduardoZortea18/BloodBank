using BloodBank.Domain.Entities;
using MediatR;

namespace BloodBank.Infra.Extensions
{
    public static class MediatrExtension
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, BloodBankContext context)
        {
            var entities = context.ChangeTracker
                .Entries<BaseEntity>()
                .Where(x => x.Entity.Events != null && x.Entity.Events.Any());

            var events = entities
                .SelectMany(x => x.Entity.Events)
                .ToList();

            entities.ToList().ForEach(x => x.Entity.ClearDomainEvents());

            foreach (var item in events)
            {
                await mediator.Publish(item);
            }
        }
    }
}
