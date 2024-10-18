using DrexProductAndCategory.Models;
using DrexProductAndCategory.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrexProductAndCategory.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await Task.FromResult(_productRepository.All().ToList());
        }

        
        public async Task<Product?> GetByIdAsync(Guid id) 
        {
            return await Task.FromResult(_productRepository.Find(p => p.Id == id).FirstOrDefault());
        }

        
        public async Task AddAsync(Product product)
        {
            await _productRepository.AddAsync(product);
            await _productRepository.SaveChangesAsync();
        }

        
        public async Task UpdateAsync(Product product)
        {
            _productRepository.Update(product);
            await _productRepository.SaveChangesAsync();
        }

        
        public async Task DeleteAsync(Guid id) 
        {
            var product = _productRepository.Find(p => p.Id == id).FirstOrDefault();
            if (product != null)
            {
                _productRepository.Delete(product);
                await _productRepository.SaveChangesAsync();
            }
        }
    }
}
