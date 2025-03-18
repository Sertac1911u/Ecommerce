using Ecommerce.Catalog.Dtos.SpecialOfferDtos;

namespace Ecommerce.Catalog.Services.SpecialOfferServices
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync();
        Task CreateSpecialOfferAsync(CreateSpecialOfferDto SpecialOfferDto);
        Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto SpecialOfferDto);
        Task DeleteSpecialOfferAsync(string id);
        Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id);
    }
}
