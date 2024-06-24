using AutoMapper;
using backend_dotnet7.Core.DbContext;
using backend_dotnet7.Core.Dtos.Materials;
using backend_dotnet7.Core.Dtos.Supplier;
using backend_dotnet7.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper { get; }

        public SupplierController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //CRUD


        //Create
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateSupplier([FromBody] SupplierDto dto)
        {

            Supplier newSupplier = _mapper.Map<Supplier>(dto);


            await _context.Suppliers.AddAsync(newSupplier);
            await _context.SaveChangesAsync();

            return Ok("Supplier Created Successfully");

        }

        //Read
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<SupplierDto>>> GetAllSuppliers()
        {
            var suppliers = await _context.Suppliers.ToListAsync();
            var convertedSuppliers = _mapper.Map<IEnumerable<SupplierDto>>(suppliers);

            return Ok(convertedSuppliers);
        }

        [HttpGet]
        [Route("{id}")]

        public async Task<ActionResult<Supplier>> GetSupplierById([FromRoute] int id)
        {
            var supplier = await _context.Suppliers.FirstOrDefaultAsync(q => q.Id == id);

            if (supplier is null)
            {
                return NotFound("Suppliers Not Found");
            }

            return Ok(supplier);
        }



        //Update

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateSupplier([FromRoute] int id, [FromBody] SupplierDto dto)
        {
            var supplier = await _context.Suppliers.FirstOrDefaultAsync(q => q.Id == id);
            if (supplier is null)
            {
                return NotFound("Supplier Not Found");
            }
            supplier.Info=dto.Info;
            supplier.Name=dto.Name;


            await _context.SaveChangesAsync();
            return Ok("Supplier Updated Successfully");
        }

        //Delete
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteSupplierl([FromRoute] int id)
        {
            var supplier = await _context.Suppliers.FirstOrDefaultAsync(q => q.Id == id);
            if (supplier is null)
            {
                return NotFound("Supplier Not Found");
            }
            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
            return Ok("Supplier Deleted");
        }
    }
}
