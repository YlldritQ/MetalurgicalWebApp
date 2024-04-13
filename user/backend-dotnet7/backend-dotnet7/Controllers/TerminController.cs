using backend_dotnet7.Core.DbContext;
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

        public TerminController(ApplicationDbContext context)
        {
            _context = context;
        }
        //crud

        //create 

        [HttpPost]

        public async Task <IActionResult> CreateTermin([FromBody]termineDto dto)
        {
            var newTermin = new Termin()
            {
                ClientName = dto.ClientName,
                AppointmentTime = dto.AppointmentTime
            };
            await _context.Termins.AddAsync(newTermin);
            await _context.SaveChangesAsync();
            return Ok("Termin saved successfully");
        }

        //read
        [HttpGet]

        public async Task<ActionResult<List<Termin>>> GetAllTermins() { 
            
            var termins = await _context.Termins.ToListAsync();
            return Ok(termins);
        
        }
        [HttpGet]
        [Route("{id}")]

        public async Task<ActionResult<Termin>> GetTerminById([FromRoute] long id) {

            var termins = await _context.Termins.FirstOrDefaultAsync(q => q.ID == id);

            if (termins is null) {
                return NotFound("Termin not Found!");
            }
            return Ok(termins);
            
        }

        //update

        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> UpdateTermin([FromRoute] long id, [FromBody] termineDto dto)
        {
            var termin = await _context.Termins.FirstOrDefaultAsync(q =>q.ID == id);

            if (termin is null) {
                return NotFound("Termin not Found!");
            }
            
            termin.AppointmentTime = dto.AppointmentTime;
            termin.ClientName = dto.ClientName;

            await _context.SaveChangesAsync();
            return Ok("Termins are updated!");


        }

        //delete

        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> DeleteTermin([FromRoute] long id)
        {
            var termin = await _context.Termins.FirstOrDefaultAsync(q =>q.ID == id);
            if (termin is null)
            {
                return NotFound("Termin not Found");
            }
            _context.Termins.Remove(termin);
            await _context.SaveChangesAsync();
            return Ok("Termin Deleted!");
        }
    }
}
