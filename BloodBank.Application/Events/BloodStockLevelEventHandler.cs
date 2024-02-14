using BloodBank.Domain.Events;
using MediatR;

namespace BloodBank.Application.Events
{
    public class BloodStockLevelEventHandler : INotificationHandler<BloodStockLevelEvent>
    {
        public Task Handle(BloodStockLevelEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("\n \n MINIMUM LEVEL REACHED \n \n" + notification);
            return Task.CompletedTask;
        }
    }
}
