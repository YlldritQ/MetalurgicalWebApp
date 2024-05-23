using AutoMapper;
using backend_dotnet7.Core.DbContext;
using backend_dotnet7.Core.Dtos.Product;
using backend_dotnet7.Core.Dtos.Termin;
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
        private IMapper _mapper { get; }

        public TerminController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateTermin([FromBody] TerminDto dto)
        {
            Termin newTermin = _mapper.Map<Termin>(dto);


            await _context.Termins.AddAsync(newTermin);
            await _context.SaveChangesAsync();

            return Ok("Termin Created Successfully");

        }
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<TerminDto>>> GetAllTermins()
        {
            var termins = await _context.Termins.ToListAsync();
            var convertedTermins = _mapper.Map<IEnumerable<TerminDto>>(termins);

            return Ok(convertedTermins);
        }

        [HttpGet]
        [Route("{id}")]

        public async Task<ActionResult<Termin>> GetTerminById([FromRoute] long id)
        {
            var termin = await _context.Termins.FirstOrDefaultAsync(q => q.Id == id);

            if (termin is null)
            {
                return NotFound("Termin Not Found");
            }

            return Ok(termin);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTermin([FromRoute] long id, [FromBody] TerminDto dto)
        {
            var termin = await _context.Termins.FirstOrDefaultAsync(q => q.Id == id);
            if (termin is null)
            {
                return NotFound("Termin Not Found");
            }
            termin.EmriKlientit = dto.EmriKlientit;
            termin.Orari = dto.Orari;
            termin.Lokacioni = dto.Lokacioni;
            termin.IsActive = dto.IsActive;
            termin.IsDeleted = dto.IsDeleted;
            termin.UpdatedAt = DateTime.Now;
            termin.CreatedAt = dto.UpdatedAt;



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
