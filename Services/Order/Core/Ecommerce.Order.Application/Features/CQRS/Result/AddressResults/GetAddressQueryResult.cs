﻿namespace Ecommerce.Order.Application.Features.CQRS.Result.AddressResults
{
    public class GetAddressQueryResult
    {
        public int AddressId { get; set; }
        public string UserId { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
    }
}
