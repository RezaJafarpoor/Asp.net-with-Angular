using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataBase
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext storeContext;

        public ProductRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetBrandAsync()
        {
            return await this.storeContext.ProductBrands
                .ToListAsync();
        }
        public async Task<IReadOnlyList<ProductType>> GetProductTypeAsync()
        {
            return await this.storeContext.ProductTypes.ToListAsync();
        }

        public async Task<IReadOnlyList<Product>> GetProductAsync()
        {
            return await this.storeContext.Products
                .Include(p =>p.ProductBrand)
                .Include(p =>p.ProductType)
                .ToListAsync();
        }
        

        public async Task<Product> GetProductByIdAsync(int id)
        {

            return await this.storeContext.Products
              .Include(p => p.ProductBrand)
              .Include(p => p.ProductType)
              .FirstAsync(p =>p.Id == id);
           
           
        }

       
    }
}
