using ProductManagementSystem.Models;
using ProductManagementSystem.Repository;

namespace ProductManagementSystem.Service
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        public ProductService(IRepository<Product> productRepository)
        {
              _productRepository = productRepository;
        }
        public async Task AddProduct(Product product)
        {
            await _productRepository.AddAsync(product);
            await _productRepository.SaveAsync();
        }

        public async Task DeleteProduct(Product product)
        {
            _productRepository.Delete(product);
            await _productRepository.SaveAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task UpdateProduct(Product product)
        {
            _productRepository.Update(product);
            await _productRepository.SaveAsync();
        }
    }
}
