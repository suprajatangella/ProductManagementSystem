using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.Models;
using ProductManagementSystem.Service;

namespace ProductManagementSystem.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _service;
        public ProductsController(IProductService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _service.GetAllProducts();
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            await _service.AddProduct(product);
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            var product = await _service.GetProductById(Id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Product product)
        {
            await _service.UpdateProduct(product);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var product = await _service.GetProductById(Id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Product product)
        {
            await _service.DeleteProduct(product);
            return View();
        }
    }
}
