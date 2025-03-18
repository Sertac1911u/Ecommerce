using Ecommerce.Catalog.Dtos.ProductDtos;

namespace Ecommerce.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto ProductDto);
        Task UpdateProductAsync(UpdateProductDto ProductDto);
        Task DeleteProductAsync(string id);
        Task<GetByIdProductDto> GetByIdProductAsync(string id);

        Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryAsync();
    }
}
