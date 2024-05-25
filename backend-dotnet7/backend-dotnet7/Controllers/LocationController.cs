using AutoMapper;
using backend_dotnet7.Core.DbContext;
using backend_dotnet7.Core.Dtos.Location;
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
    public class LocationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public LocationController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        //CRUD

        //Create
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateLocation([FromBody] LocationDto dto)
        {
            Location newLocation = _mapper.Map<Location>(dto);
            await _context.Locations.AddAsync(newLocation);
            await _context.SaveChangesAsync();

            return Ok("Location Created Successfully");

        }

        //Read
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<LocationDto>>> GetAllLocation()
        {
            var locations = await _context.Locations.ToListAsync();
            var convertedLocations = _mapper.Map<IEnumerable<LocationDto>>(locations);

            return Ok(convertedLocations);
        }

        [HttpGet]
        [Route("{id}")]

        public async Task<ActionResult<Location>> GetLocationById([FromRoute] long id)
        {
            var location = await _context.Locations.FirstOrDefaultAsync(q => q.Id == id);

            if (location is null)
            {
                return NotFound("Location Not Found");
            }

            return Ok(location);
        }



        //Update

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateLocation([FromRoute] long id, [FromBody] LocationDto dto)
        {
            var location = await _context.Locations.FirstOrDefaultAsync(q => q.Id == id);
            if (location is null)
            {
                return NotFound("Location Not Found");
            }
            location.LocationName = dto.LocationName;
            location.StreetAddress = dto.StreetAddress;
            location.City = dto.City;
            location.Date = dto.Date;
            location.Time = dto.Time;

            await _context.SaveChangesAsync();
            return Ok("Location Updated Successfully");
        }

        //Delete
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteLocation([FromRoute] long id)
        {
            var location = await _context.Locations.FirstOrDefaultAsync(q => q.Id == id);
            if (location is null)
            {
                return NotFound("Location Not Found");
            }
            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();
            return Ok("Location Deleted");
        }
    }

}