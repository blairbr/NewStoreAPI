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

            //whats the point of mapping it again?//why were the ids varchars? also why dont you do the identity thing?
        }

        // POST: api/Product
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product) 
        { //what shoudl the return type be here? like an async task? or void?
            //at this point the Id in the product will be null. we'll see how that works
            var response = await _productRepository.AddProductAsync(product);// why async?
            return Ok(response);
        }

        //when do you ever use a patch? i get that it's for updating but couldnt you just use a post?

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
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
