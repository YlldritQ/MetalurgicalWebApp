using AutoMapper;
using backend_dotnet7.Core.DbContext;
using backend_dotnet7.Core.Dtos.Corrosion;
using backend_dotnet7.Core.Dtos.Materials;
using backend_dotnet7.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorrosionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper { get; }

        public CorrosionController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //CRUD


        //Create
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateCorrosion([FromBody] CorrosionDto dto)
        {

            Corrosion newCorrosion = _mapper.Map<Corrosion>(dto);


            await _context.Corrosions.AddAsync(newCorrosion);
            await _context.SaveChangesAsync();

            return Ok("Corrosion Created Successfully");

        }

        //Read
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<CorrosionDto>>> GetAllCorrosion()
        {
            var corrosion = await _context.Corrosions.ToListAsync();
            var convertedCorrosion = _mapper.Map<IEnumerable<CorrosionDto>>(corrosion);

            return Ok(convertedCorrosion);
        }

        [HttpGet]
        [Route("{id}")]

        public async Task<ActionResult<Corrosion>> GetCorrosionById([FromRoute] int id)
        {
            var corrosion = await _context.Corrosions.FirstOrDefaultAsync(q => q.Id == id);

            if (corrosion is null)
            {
                return NotFound("Corrosion Not Found");
            }

            return Ok(corrosion);
        }



        //Update

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCorrosion([FromRoute] int id, [FromBody] CorrosionDto dto)
        {
            var corrosion = await _context.Corrosions.FirstOrDefaultAsync(q => q.Id == id);
            if (corrosion is null)
            {
                return NotFound("Corrosion Not Found");
            }
            corrosion.MaterialName = dto.MaterialName;
            corrosion.Environment = dto.Environment;
            corrosion.ProtectiveCoating = dto.ProtectiveCoating;
            corrosion.CorrosionRate = dto.CorrosionRate;
            corrosion.Notes = dto.Notes;


            await _context.SaveChangesAsync();
            return Ok("Corrosion Updated Successfully");
        }

        //Delete
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCorrosion([FromRoute] int id)
        {
            var corrosion = await _context.Corrosions.FirstOrDefaultAsync(q => q.Id == id);
            if (corrosion is null)
            {
                return NotFound("Corrosion Not Found");
            }
            _context.Corrosions.Remove(corrosion);
            await _context.SaveChangesAsync();
            return Ok("Corrosion Deleted");
        }
    }
}
