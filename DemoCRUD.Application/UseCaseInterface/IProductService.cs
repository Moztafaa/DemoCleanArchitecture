using DemoCRUD.Application.ProductDTOs;

namespace DemoCRUD.Application.UseCaseInterface;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllProductsAsync();
    Task<ProductDto?> GetProductByIdAsync(int id);
    Task AddProductAsync(CreateProductDto productDto);
    Task UpdateProduct(UpdateProductDto productDto);
    Task DeleteProductAsync(int id);
}