using Ecommerce.Order.Application.Features.CQRS.Commands.AddressCommands;
using Ecommerce.Order.Application.Interfaces;
using Ecommerce.Order.Domain.Entities;

namespace Ecommerce.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAddressCommand command)
        {
            var values = await _repository.GetByIdAsync(command.AddressId);
            values.Detail=command.Detail;
            values.District=command.District;
            values.City=command.City;
            values.UserId=command.UserId;
            await _repository.UpdateAsync(values);
        }
    }
}
