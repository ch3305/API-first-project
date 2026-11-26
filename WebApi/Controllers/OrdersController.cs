using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class OrdersController: ControllerBase
    {     
            IOrdersService ordersService;
            public OrdersController(IOrdersService ordersService)
            {
                this.ordersService = ordersService;
            }


            // GET: api/<OrdersController>
            [HttpGet]
            public IEnumerable<string> Get()
            {
                return new string[] { "value1", "value2" };
            }

            // GET api/<OrdersController>/5
            [HttpGet("{id}")]
            public async Task<Order> Get(int id)
            {
                return await ordersService.GetOrderById(id);
            }

            // POST api/<OrdersController>
            [HttpPost]
            public async Task<ActionResult<Order>> Post([FromBody] Order order)
            {
                await ordersService.PostOrder(order);
                return CreatedAtAction(nameof(Get), new { id = order.Id }, order);

            }

            // PUT api/<OrdersController>/5
            [HttpPut("{id}")]
            public void Put(int id, [FromBody] string value)
            {
            }

            // DELETE api/<OrdersController>/5
            [HttpDelete("{id}")]
            public void Delete(int id)
            {
            }
        
    }
}
