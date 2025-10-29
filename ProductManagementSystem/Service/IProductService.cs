using ProductManagementSystem.Models;

namespace ProductManagementSystem.Service
{
    public interface IProductService
    {
        Task AddProduct(Product product);
        Task<Product> GetProductById(int id);
        Task UpdateProduct(Product product);
        Task DeleteProduct(Product product);

        Task<IEnumerable<Product>> GetAllProducts();
    }
}
