using AutoMapper;
using backend_dotnet7.Core.DbContext;
using backend_dotnet7.Core.Dtos.Product_Order;
using backend_dotnet7.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Product_OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper { get; }

        public Product_OrderController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateProductOrder([FromBody] CreateUpdateProductOrderDto dto)
        {
            var newProductOrder = _mapper.Map<Product_Order>(dto);

            await _context.Product_Orders.AddAsync(newProductOrder);
            await _context.SaveChangesAsync();

            return Ok("Product_Order Created Successfully");
        }

        // Read
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<CreateUpdateProductOrderDto>>> GetAllProductOrders()
        {
            var productOrders = await _context.Product_Orders.Include(po => po.Product).Include(po => po.Order).ToListAsync();
            var convertedProductOrders = _mapper.Map<IEnumerable<CreateUpdateProductOrderDto>>(productOrders);

            return Ok(convertedProductOrders);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Product_Order>> GetProductOrderById([FromRoute] long id)
        {
            var productOrder = await _context.Product_Orders.Include(po => po.Product).Include(po => po.Order).FirstOrDefaultAsync(po => po.Id == id);

            if (productOrder == null)
            {
                return NotFound("Product_Order Not Found");
            }

            return Ok(productOrder);
        }

        // Update
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProductOrder([FromRoute] long id, [FromBody] CreateUpdateProductOrderDto dto)
        {
            var productOrder = await _context.Product_Orders.FindAsync(id);
            if (productOrder == null)
            {
                return NotFound("Product_Order Not Found");
            }

            _mapper.Map(dto, productOrder);

            await _context.SaveChangesAsync();
            return Ok("Product_Order Updated Successfully");
        }

        // Delete
        [HttpDelete]
        [Route("{orderId}/{productId}")]
        public async Task<IActionResult> DeleteProductOrder([FromRoute] long orderId, [FromRoute] long productId)
        {
            var productOrder = await _context.Product_Orders.FindAsync(orderId, productId);
            if (productOrder == null)
            {
                return NotFound("Product_Order Not Found");
            }

            _context.Product_Orders.Remove(productOrder);
            await _context.SaveChangesAsync();
            return Ok("Product_Order Deleted");
        }

    }
}
