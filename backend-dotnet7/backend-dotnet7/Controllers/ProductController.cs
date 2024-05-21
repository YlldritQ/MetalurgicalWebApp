using AutoMapper;
using backend_dotnet7.Core.DbContext;
using backend_dotnet7.Core.Dtos.Product;
using backend_dotnet7.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace backend_dotnet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper { get; }

        public ProductController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //CRUD


        //Create
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateUpdateProductDto dto)
        {

            Product newProduct = _mapper.Map<Product>(dto);
            

            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            return Ok("Product Created Successfully");

        }

        //Read
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<CreateUpdateProductDto>>> GetAllProducts() {
            var products =await _context.Products.ToListAsync();
            var convertedProducts = _mapper.Map<IEnumerable<CreateUpdateProductDto>>(products);

            return Ok(convertedProducts);
        }

        [HttpGet]
        [Route("{id}")]

        public async Task<ActionResult<Product>> GetProductById([FromRoute]long id) {
            var product = await _context.Products.FirstOrDefaultAsync(q => q.Id == id);

            if (product is null) {
                return NotFound("Product Not Found");
            }

            return Ok(product);
        }



        //Update

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute]long id, [FromBody]CreateUpdateProductDto dto)
        {
            var product = await _context.Products.FirstOrDefaultAsync(q => q.Id == id);
            if (product is null)
            {
                return NotFound("Product Not Found");
            }
            product.Brand = dto.Brand;
            product.Title = dto.Title;
           

            await _context.SaveChangesAsync();
            return Ok("Product Updated Successfully");
        }

        //Delete
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] long id) {
            var product = await _context.Products.FirstOrDefaultAsync(q => q.Id == id);
            if (product is null) {
                return NotFound("Product Not Found");
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Ok("Product Deleted");
        }
    }
    
}
