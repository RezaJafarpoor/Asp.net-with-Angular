using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
       
        Task<IReadOnlyList<ProductBrand>> GetBrandAsync();
        Task<IReadOnlyList<ProductType>> GetProductTypeAsync();
        
    }
}
