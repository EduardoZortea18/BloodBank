namespace BloodBank.Application.Models.Address
{
    public sealed record FullAddressResponseModel(string Cep, string Logradouro, string Localidade, string Uf);
}
