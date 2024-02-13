using BloodBank.Domain.Enums;

namespace BloodBank.Domain.Entities
{
    public class BloodStock : BaseEntity
    {
        public BloodType BloodType { get; private set; }
        public RhFactorEnum RhFactor { get; private set; }
        public int Quantity { get; private set; }

        public BloodStock(BloodType bloodType, RhFactorEnum rhFactor, int quantity)
        {
            BloodType = bloodType;
            RhFactor = rhFactor;
            Quantity = quantity;
        }

        public void ChangeQuantity(int quantity)
        {
            Quantity = quantity;
        }
    }
}
