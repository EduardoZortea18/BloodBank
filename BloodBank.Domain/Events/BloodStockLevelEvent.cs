using BloodBank.Domain.Enums;
using MediatR;

namespace BloodBank.Domain.Events
{
    public class BloodStockLevelEvent : INotification
    {
        public int BloodStockId { get; private set; }
        public BloodType BloodType { get; private set; }
        public RhFactorEnum RhFactor { get; private set; }

        public BloodStockLevelEvent(int bloodStockId, BloodType bloodType, RhFactorEnum rhFactor)
        {
            BloodStockId = bloodStockId;
            BloodType = bloodType;
            RhFactor = rhFactor;
        }
    }
}
