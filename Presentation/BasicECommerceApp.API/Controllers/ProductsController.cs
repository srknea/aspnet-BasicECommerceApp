using BasicECommerceApp.Application.Repositories;
using BasicECommerceApp.Application.Repositories.Product;
using BasicECommerceApp.Domain.Entities;
using BasicECommerceApp.Persistance.Repositories.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasicECommerceApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;
        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddRangeAsync()
        {
            await _productWriteRepository.AddRangeAsync(new List<Product>()
            {
                new() {Id = Guid.NewGuid(), Name = "Product 1", Stock=1000, Price = 100},
                new() {Id = Guid.NewGuid(), Name = "Product 2", Stock=2000, Price = 200},
                new() {Id = Guid.NewGuid(), Name = "Product 3", Stock=3000, Price = 300},
            });

            await _productWriteRepository.SaveAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productReadRepository.GetAll().ToListAsync();

            return Ok(products);
        }
    }
}
