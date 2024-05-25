using AutoMapper;
using backend_dotnet7.Core.DbContext;
using backend_dotnet7.Core.Dtos.Product_Order;
using backend_dotnet7.Core.Dtos.TerminLocation;
using backend_dotnet7.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerminLocationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper { get; }

        public TerminLocationController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateTerminLocation([FromBody] TerminLocationDto dto)
        {
            var newTerminLocation = _mapper.Map<TerminLocation>(dto);

            await _context.TerminLocations.AddAsync(newTerminLocation);
            await _context.SaveChangesAsync();

            return Ok("TerminLocation Created Successfully");
        }

        // Read
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<TerminLocationDto>>> GetAllTerminLocation()
        {
            var terminLocation = await _context.TerminLocations.Include(tl=>tl.Termin).Include(tl=>tl.Location).ToListAsync();
            var convertedTerminLocation = _mapper.Map<IEnumerable<CreateUpdateProductOrderDto>>(terminLocation);

            return Ok(convertedTerminLocation);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<TerminLocation>> GetTerminLocationById([FromRoute] long id)
        {
            var terminLocation = await _context.TerminLocations.Include(tl => tl.Termin).Include(tl => tl.Location).FirstOrDefaultAsync(tl=>tl.Id == id);

            if (terminLocation == null)
            {
                return NotFound("Product_Order Not Found");
            }

            return Ok(terminLocation);
        }

        // Update
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTerminLocation([FromRoute] long id, [FromBody] TerminLocationDto dto)
        {
            var terminLocation = await _context.TerminLocations.FindAsync(id);
            if (terminLocation == null)
            {
                return NotFound("terminLocation Not Found");
            }

            _mapper.Map(dto, terminLocation);

            await _context.SaveChangesAsync();
            return Ok("terminLocation Updated Successfully");
        }

        // Delete
        [HttpDelete]
        [Route("{terminId}/{locationId}")]
        public async Task<IActionResult> DeleteTerminLocation([FromRoute] long terminId, [FromRoute] long locationId)
        {
            var terminLocation = await _context.Product_Orders.FindAsync(terminId, locationId);
            if (terminLocation == null)
            {
                return NotFound("Product_Order Not Found");
            }

            _context.Product_Orders.Remove(terminLocation);
            await _context.SaveChangesAsync();
            return Ok("Product_Order Deleted");
        }
    }
}
