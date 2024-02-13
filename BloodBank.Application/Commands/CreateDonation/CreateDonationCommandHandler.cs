using BloodBank.Application.Commands.CreateBloodStock;
using BloodBank.Application.Commands.UpdateBloodStock;
using BloodBank.Application.Models;
using BloodBank.Domain.Entities;
using BloodBank.Domain.Enums;
using BloodBank.Domain.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.CreateDonation
{
    public class CreateDonationCommandHandler : IRequestHandler<CreateDonationCommand, Result<int>>
    {
        private readonly IDonationRepository _donationRepository;
        private readonly IBloodStockRepository _bloodStockRepository;
        private readonly IDonatorRepository _donatorRepository;
        private readonly IMediator _mediator;

        private const int MINIMUN_WEIGHT = 50;
        private const int MINIMUN_MALE_DONATION_PERIOD = 60;
        private const int MINIMUN_FEMALE_DONATION_PERIOD = 90;

        public CreateDonationCommandHandler(
            IDonationRepository repository,
            IBloodStockRepository bloodStockRepository,
            IDonatorRepository donatorRepository,
            IMediator mediator)
        {
            _donationRepository = repository;
            _bloodStockRepository = bloodStockRepository;
            _donatorRepository = donatorRepository;
            _mediator = mediator;

        }

        public async Task<Result<int>> Handle(CreateDonationCommand command, CancellationToken cancellationToken)
        {
            var donator = await _donatorRepository.GetOneWithIncludes(x => x.Id == command.DonatorId, it => it.Donations);

            if (!IsValid(donator))
            {
                return new Result<int>("Your donation is not valid", true);
            }

            var bloodStock = await _bloodStockRepository.GetOne(x => x.BloodType == donator.BloodType
              && x.RhFactor == donator.RhFactor);

            if (bloodStock is null)
            {
                var bloodStockCommand = new CreateBloodStockCommand(donator.BloodType, donator.RhFactor, command.Quantity, donator);
                _ = await _mediator.Send(bloodStockCommand);
            }

            if (bloodStock is not null)
            {
                var bloodStockCommand = new UpdateBloodStockCommand(donator.BloodType, donator.RhFactor, command.Quantity, bloodStock.Id);
                _ = await _mediator.Send(bloodStockCommand);
            }

            var newDonation = new Donation(donator.Id, command.Date, command.Quantity);
            await _donationRepository.Create(newDonation);

            return new Result<int>(newDonation.Id, string.Empty);
        }

        private bool IsValid(Donator donator)
            => !(donator == null || donator.Weight < MINIMUN_WEIGHT
                || !IsOfAge(donator.BirthDate) || !CanDonateAgain(donator));

        private bool IsOfAge(DateTime birthDate) => DateTime.Today.Year - birthDate.Year > 18;

        private bool CanDonateAgain(Donator donator)
        {
            var lastDonationDate = donator.Donations.OrderByDescending(x => x.Date).FirstOrDefault();

            if (lastDonationDate == null) return true;

            return donator.Gender switch
            {
                Gender.Male => IsMaleDonationValid(lastDonationDate.Date),
                Gender.Female => IsFemaleDonationValid(lastDonationDate.Date),
                _ => false
            };
        }

        private bool IsMaleDonationValid(DateTime lastDonationDate)
          => DateTime.Today.DayOfYear - lastDonationDate.DayOfYear > MINIMUN_MALE_DONATION_PERIOD;

        private bool IsFemaleDonationValid(DateTime lastDonationDate)
           => DateTime.Today.DayOfYear - lastDonationDate.DayOfYear > MINIMUN_FEMALE_DONATION_PERIOD;
    }
}
