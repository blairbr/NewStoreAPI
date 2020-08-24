using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TotallyNewStoreAPI.Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository; //why private and why readonly?
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        // GET: api/Product
        [HttpGet]
        public async Task<IActionResult> Get()
        
        {
           var response = await _productRepository.GetAllProductsAsync();
           
           return Ok(response);

        }

        // POST: api/Product
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product) 
        {
            var response = await _productRepository.AddProductAsync(product);
            return Ok(response);
        }


        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var response = await _productRepository.GetProductByIdAsync(id);
            return Ok(response);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
