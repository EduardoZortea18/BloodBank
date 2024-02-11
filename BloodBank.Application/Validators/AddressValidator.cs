using BloodBank.Application.Models.Address;
using FluentValidation;
using System.Text.RegularExpressions;

namespace BloodBank.Application.Validators
{
    public class AddressValidator : AbstractValidator<AddressRequestModel>
    {
        public AddressValidator()
        {
            RuleFor(x => x.ZipCode)
                .Must(IsValidBrazilZipCode);
        }

        private bool IsValidBrazilZipCode(string zipCode)
            => new Regex(@"^\d{8}").IsMatch(zipCode);
    }
}
