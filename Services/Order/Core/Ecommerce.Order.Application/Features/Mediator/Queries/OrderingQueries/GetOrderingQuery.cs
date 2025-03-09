using Ecommerce.Order.Application.Features.Mediator.Results.OrderingResults;
using MediatR;

namespace Ecommerce.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingQuery : IRequest<List<GetOrderingQuaryResult>>
    {

    }
}
