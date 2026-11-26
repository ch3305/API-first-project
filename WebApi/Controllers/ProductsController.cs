using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{ 
     [Route("api/[controller]")]
        [ApiController]

    public class ProductsController:ControllerBase
    {
            IProductsService productsService;

            public ProductsController(IProductsService productsService)
            {
                this.productsService = productsService;
            }

            // GET: api/<ProductsController>
            [HttpGet]

            public async Task<ActionResult<IEnumerable<Product>>> Get()
            {
                IEnumerable<Product> products = await productsService.GetProductsAsync();
                if (products != null)
                    return Ok(products);
                else
                    return NotFound();
            }

            // GET api/<ProductsController>/5
            [HttpGet("{id}")]
            public string Get(int id)
            {
                return "value";
            }

            // POST api/<ProductsController>
            [HttpPost]
            public void Post([FromBody] string value)
            {
            }

            // PUT api/<ProductsController>/5
            [HttpPut("{id}")]
            public void Put(int id, [FromBody] string value)
            {
            }

            // DELETE api/<ProductsController>/5
            [HttpDelete("{id}")]
            public void Delete(int id)
            {
            }
        
    }
}
