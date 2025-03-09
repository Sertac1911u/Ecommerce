using Ecommerce.Order.Application.Features.CQRS.Result.AddressResults;
using Ecommerce.Order.Application.Interfaces;
using Ecommerce.Order.Domain.Entities;

namespace Ecommerce.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAddressQueryResult>> Handler()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAddressQueryResult
            {
                AddressId = x.AddressId,
                City = x.City,
                Detail = x.Detail,
                District = x.District,
                UserId = x.UserId
            }).ToList();
        }
    }
}
