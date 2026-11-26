using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class CategoriesController:ControllerBase
    {

            ICategoryService categoryService;
            public CategoriesController(ICategoryService categoryService)
            {
                this.categoryService = categoryService;
            }
            // GET: api/<CategoryController>
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Category>>> Get()
            {


                IEnumerable<Category> categories = await categoryService.GetCategories();
                if (categories != null)
                    return Ok(categories);
                else
                    return NotFound();
            }

            // GET api/<CategoryController>/5
            [HttpGet("{id}")]
            public string Get(int id)
            {
                return "value";
            }

            // POST api/<CategoryController>
            [HttpPost]
            public void Post([FromBody] string value)
            {
            }

            // PUT api/<CategoryController>/5
            [HttpPut("{id}")]
            public void Put(int id, [FromBody] string value)
            {
            }

            // DELETE api/<CategoryController>/5
            [HttpDelete("{id}")]
            public void Delete(int id)
            {
            }
        
    }
}
