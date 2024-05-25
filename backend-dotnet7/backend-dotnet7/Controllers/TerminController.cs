using AutoMapper;
using backend_dotnet7.Core.DbContext;
using backend_dotnet7.Core.Dtos.Product;
using backend_dotnet7.Core.Dtos.termine;
using backend_dotnet7.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerminController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public TerminController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }
        //CRUD

        //Create
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateTermin([FromBody] termineDto dto)
        {
            Termin newTermin = _mapper.Map<Termin>(dto);
            await _context.Termins.AddAsync(newTermin);
            await _context.SaveChangesAsync();

            return Ok("Termin Created Successfully");

        }

        //Read
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<termineDto>>> GetAllTermins()
        {
            var termins = await _context.Termins.ToListAsync();
            var convertedTermins = _mapper.Map<IEnumerable<termineDto>>(termins);

            return Ok(convertedTermins);
        }

        [HttpGet]
        [Route("{id}")]

        public async Task<ActionResult<Product>> GetProductById([FromRoute] long id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(q => q.Id == id);

            if (product is null)
            {
                return NotFound("Product Not Found");
            }

            return Ok(product);
        }



        //Update

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTermin([FromRoute] long id, [FromBody] termineDto dto)
        {
            var termin = await _context.Termins.FirstOrDefaultAsync(q => q.Id == id);
            if (termin is null)
            {
                return NotFound("Termin Not Found");
            }
            termin.Time = dto.Time;
            termin.Location = dto.Location;
            termin.ClientName = dto.ClientName;
            termin.Description= dto.Description;
            termin.Date= dto.Date;

            await _context.SaveChangesAsync();
            return Ok("Termin Updated Successfully");
        }

        //Delete
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTermin([FromRoute] long id)
        {
            var termin = await _context.Termins.FirstOrDefaultAsync(q => q.Id == id);
            if (termin is null)
            {
                return NotFound("Termin Not Found");
            }
            _context.Termins.Remove(termin);
            await _context.SaveChangesAsync();
            return Ok("Termin Deleted");
        }
    }
    
}
