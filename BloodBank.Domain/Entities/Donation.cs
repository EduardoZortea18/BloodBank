namespace BloodBank.Domain.Entities
{
    public class Donation : BaseEntity
    {
        public int DonatorId { get; private set; }
        public DateTime Date { get; private set; }
        public int Quantity { get; private set; }

        public Donator Donator { get; private set; }

        public Donation(int donatorId, DateTime date, int quantity)
        {
            DonatorId = donatorId;
            Date = date;
            Quantity = quantity;
        }
    }
}
