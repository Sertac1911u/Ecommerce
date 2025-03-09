using Ecommerce.Order.Application.Features.CQRS.Queries.AddressQueries;
using Ecommerce.Order.Application.Features.CQRS.Result.AddressResults;
using Ecommerce.Order.Application.Interfaces;
using Ecommerce.Order.Domain.Entities;

namespace Ecommerce.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByIdQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetAddressByIdQueryResult
            {
                AddressId = values.AddressId,
                City = values.City,
                Detail = values.Detail,
                District = values.District,
                UserId = values.UserId
            };
        }
    }
}
