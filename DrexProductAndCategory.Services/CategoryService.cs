using DrexProductAndCategory.Models;
using DrexProductAndCategory.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrexProductAndCategory.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await Task.FromResult(_categoryRepository.All().ToList());
        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await Task.FromResult(_categoryRepository.Find(c => c.Id == id).FirstOrDefault());
        }

        public async Task AddAsync(Category category)
        {
            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _categoryRepository.Update(category);
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var category = _categoryRepository.Find(c => c.Id == id).FirstOrDefault();
            if (category != null)
            {
                _categoryRepository.Delete(category);
                await _categoryRepository.SaveChangesAsync();
            }
        }
    }
}
