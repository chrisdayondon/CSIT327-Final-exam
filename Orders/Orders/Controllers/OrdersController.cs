using Microsoft.AspNetCore.Mvc;
using Orders.DTO;
using Orders.Model;
using Orders.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        // GET: api/<OrdersController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var orders = _service.GetAllOrder();
            if (orders.Any())
                return Ok(orders);
            else
                return NoContent();
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var desiredOrder = _service.GetOrder(id);

            if (desiredOrder != null)
                return Ok(desiredOrder);
            else
                return NotFound();
        }

        // POST api/<OrdersController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateOrderDto order)
        {
            if (order == null)
                return BadRequest();

            _service.AddOrder(order);

            return Ok(order);
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OrderDto order)
        {
            if (order == null)
                return BadRequest();

            var updatedOrCreatedOwner = _service.Update(order);

            return Ok(updatedOrCreatedOwner);

        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }

            return NoContent();
        }
        public OrdersController(IOrderService service)
        {
            _service = service;
        }

    }
}
