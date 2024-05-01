using backend_dotnet7.Core.DbContext;
using backend_dotnet7.Core.Dtos.Orders;
using backend_dotnet7.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }
        //CRUD

        //CREATE
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateUpdateOrderDto dto)
        {
            var newOrder = new OrderEntity()
            {
                Total = dto.Total,
                Address = dto.Address,
                PaymentMethod = dto.PaymentMethod,
            };
            await _context.Orders.AddAsync(newOrder);
            await _context.SaveChangesAsync();

            return Ok("Order Saved Successfully");
        }

        //READ
        [HttpGet]
        public async Task<ActionResult<List<OrderEntity>>> GetAllOrders()
        {
            var orders = await _context.Orders.ToListAsync();
            return Ok(orders);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<OrderEntity>> GetOrderByID([FromRoute] long id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(q => q.Id == id);
            if (order is null)
            {
                return NotFound("Order Not Fount");
            }
            return Ok(order);
        }

        //UPDATE
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateOrder([FromRoute] long id, [FromBody] CreateUpdateOrderDto dto)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(q => q.Id == id);
            if (order is null)
            {
                return NotFound("Order Not Fount");
            }

            order.Total = dto.Total;
            order.Address = dto.Address;
            order.PaymentMethod = dto.PaymentMethod;

            await _context.SaveChangesAsync();
            return Ok("Order Updated Successfully");
        }

        //DELETE
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] long id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(q => q.Id == id);
            if (order is null)
            {
                return NotFound("Product Not Fount");
            }
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return Ok("Product Deleted Successfully");
        }
    }
}

