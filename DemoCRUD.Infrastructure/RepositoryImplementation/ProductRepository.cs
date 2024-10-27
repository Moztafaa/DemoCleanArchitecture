using DemoCRUD.Domain.ProductEntity;
using DemoCRUD.Domain.RepositoryInterface;
using DemoCRUD.Infrastructure.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace DemoCRUD.Infrastructure.RepositoryImplementation;

public class ProductRepository(AppDbContext context) : IProductRepository
{
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await context.Products.AsNoTracking().ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await context.Products.FindAsync(id);
    }

    public async Task AddAsync(Product product)
    {
        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();
        
    }

    public async Task UpdateAsync(Product product)
    {
        context.Products.Update(product);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = await context.Products.FindAsync(id);
        if (product is not null)
        {
            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }
    }
}