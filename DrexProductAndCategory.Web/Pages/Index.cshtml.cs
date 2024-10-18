using DrexProductAndCategory.Contracts;
using DrexProductAndCategory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrexProductAndCategory.Web.Pages
{
    public class Index : PageModel
    {
        private readonly ILogger<Index> _logger;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public List<Product> Products { get; set; } = new List<Product>();
        public List<Category> Categories { get; set; } = new List<Category>();

        public Index(ILogger<Index> logger, IProductService productService, ICategoryService categoryService)
        {
            _logger = logger;
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task OnGetAsync()
        {
            Products = (await _productService.GetAllAsync()).ToList();
            Categories = (await _categoryService.GetAllAsync()).ToList();
        }
    }
}
