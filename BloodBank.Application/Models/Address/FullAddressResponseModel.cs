using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Models.Address
{
    public class FullAddressResponseModel
    {
        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public string Localidade { get; private set; }
        public string Uf { get; private set; }
    }
}
