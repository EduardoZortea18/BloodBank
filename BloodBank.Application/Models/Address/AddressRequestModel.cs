namespace BloodBank.Application.Models.Address
{
    public class AddressRequestModel
    {
        public string ZipCode { get; private set; }

        public AddressRequestModel(string zipCode)
        {
            ZipCode = zipCode;
        }
    }
}
