using Microsoft.EntityFrameworkCore;

namespace BloodBank.Domain.Entities.ValueObjects
{
    [Owned]
    public class Address
    {
        public string PublicArea { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }

        public Address(string publicArea, string city, string state, string zipCode)
        {
            PublicArea = publicArea;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public Address()
        {
        }
    }
}
