using DemoCRUD.Application.MappingInterface;
using DemoCRUD.Application.ProductDTOs;
using DemoCRUD.Application.UseCaseInterface;
using DemoCRUD.Domain.RepositoryInterface;

namespace DemoCRUD.Application.UseCaseImplementation;

public class ProductService(IProductRepository _productRepository, IProductMapper _productMapper) : IProductService
{
    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return products.Select(product => _productMapper.MapToDto(product)).ToList();
    }

    public async Task<ProductDto?> GetProductByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        return product == null ? null : _productMapper.MapToDto(product);
    }

    public async Task AddProductAsync(CreateProductDto productDto)
    {
        var product = _productMapper.MapToEntity(productDto);
        await _productRepository.AddAsync(product);
    }

    public async Task UpdateProduct(UpdateProductDto productDto)
    {
        var product = _productMapper.MapToEntity(productDto);
        await _productRepository.UpdateAsync(product);
    }

    public async Task DeleteProductAsync(int id) =>
        await _productRepository.DeleteAsync(id);
}