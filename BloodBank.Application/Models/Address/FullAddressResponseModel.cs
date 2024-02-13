namespace BloodBank.Application.Models.Address
{
    public class FullAddressResponseModel
    {
        public string Cep { get; init; }
        public string Logradouro { get; init; }
        public string Localidade { get; init; }
        public string Uf { get; init; }

        public FullAddressResponseModel(string cep, string logradouro, string localidade, string uf)
        {
            Cep = cep;
            Logradouro = logradouro;
            Localidade = localidade;
            Uf = uf;
        }
    }
}
