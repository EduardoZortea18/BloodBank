using BloodBank.Domain.Entities;
using BloodBank.Domain.Repositories;
using BloodBank.Infra.Extensions;
using MediatR;

namespace BloodBank.Infra.Repositories
{
    public class BloodStockRepository : BaseRepository<BloodStock>, IBloodStockRepository
    {
        private readonly BloodBankContext _context;
        private readonly IMediator _mediator;

        public BloodStockRepository(BloodBankContext context, IMediator mediator) : base(context)
        {
            _context = context;
            _mediator = mediator;
        }

        public async override Task Update(BloodStock entity)
        {
            _context.BloodStocks.Update(entity);

            await _mediator.DispatchDomainEventsAsync(_context);

            await SaveChangesAsync();
        }
    }
}
