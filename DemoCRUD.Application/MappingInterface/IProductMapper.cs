using DemoCRUD.Application.ProductDTOs;
using DemoCRUD.Domain.ProductEntity;

namespace DemoCRUD.Application.MappingInterface;

public interface IProductMapper
{
    ProductDto MapToDto(Product product);
    Product MapToEntity(CreateProductDto createDto);
    Product MapToEntity(UpdateProductDto updateDto);
    
    
}