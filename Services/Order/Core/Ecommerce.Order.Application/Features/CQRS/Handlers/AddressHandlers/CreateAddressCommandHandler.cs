using Ecommerce.Order.Application.Features.CQRS.Commands.AddressCommands;
using Ecommerce.Order.Application.Interfaces;
using Ecommerce.Order.Domain.Entities;

namespace Ecommerce.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateAddressCommand createAddressCommand)
        {
            await _repository.CrateAsync(new Address
            {
                City = createAddressCommand.City,
                Detail=createAddressCommand.Detail,
                District = createAddressCommand.District,
                UserId = createAddressCommand.UserId
            });
        }
    }
}
