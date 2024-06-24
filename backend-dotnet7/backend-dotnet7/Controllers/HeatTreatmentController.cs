using AutoMapper;
using backend_dotnet7.Core.DbContext;
using backend_dotnet7.Core.Dtos.Corrosion;
using backend_dotnet7.Core.Dtos.HeatTreatment;
using backend_dotnet7.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeatTreatmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper { get; }

        public HeatTreatmentController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //CRUD


        //Create
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateHeatTreatment([FromBody] HeatTreatmentDto dto)
        {

            HeatTreatment newHeatTreatment = _mapper.Map<HeatTreatment>(dto);


            await _context.HeatTreatments.AddAsync(newHeatTreatment);
            await _context.SaveChangesAsync();

            return Ok("HeatTreatment Created Successfully");

        }

        //Read
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<HeatTreatmentDto>>> GetAllHeatTreatment()
        {
            var heatTreatment = await _context.HeatTreatments.ToListAsync();
            var convertedHeatTreatment = _mapper.Map<IEnumerable<HeatTreatmentDto>>(heatTreatment);

            return Ok(convertedHeatTreatment);
        }

        [HttpGet]
        [Route("{id}")]

        public async Task<ActionResult<HeatTreatment>> GetHeatTreatmentById([FromRoute] int id)
        {
            var heatTreatment = await _context.HeatTreatments.FirstOrDefaultAsync(q => q.Id == id);

            if (heatTreatment is null)
            {
                return NotFound("HeatTreatment Not Found");
            }

            return Ok(heatTreatment);
        }



        //Update

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateHeatTreatment([FromRoute] int id, [FromBody] HeatTreatmentDto dto)
        {
            var heatTreatment = await _context.HeatTreatments.FirstOrDefaultAsync(q => q.Id == id);
            if (heatTreatment is null)
            {
                return NotFound("HeatTreatment Not Found");
            }
            heatTreatment.TimeDuration = dto.TimeDuration;
            heatTreatment.Temperature = dto.Temperature;
            heatTreatment.CoolingMethod = dto.CoolingMethod;
            heatTreatment.ProcessName = dto.ProcessName;
            heatTreatment.Purpose = dto.Purpose;


            await _context.SaveChangesAsync();
            return Ok("HeatTreatment Updated Successfully");
        }

        //Delete
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteHeatTreatment([FromRoute] int id)
        {
            var heatTreatment = await _context.HeatTreatments.FirstOrDefaultAsync(q => q.Id == id);
            if (heatTreatment is null)
            {
                return NotFound("HeatTreatment Not Found");
            }
            _context.HeatTreatments.Remove(heatTreatment);
            await _context.SaveChangesAsync();
            return Ok("HeatTreatment Deleted");
        }
    }
}
