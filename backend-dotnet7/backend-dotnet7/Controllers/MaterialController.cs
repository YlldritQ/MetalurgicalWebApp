using AutoMapper;
using backend_dotnet7.Core.DbContext;
using backend_dotnet7.Core.Dtos.Materials;
using backend_dotnet7.Core.Dtos.Product;
using backend_dotnet7.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper { get; }

        public MaterialController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //CRUD


        //Create
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateMaterial([FromBody] MaterialDto dto)
        {

            Material newMaterial = _mapper.Map<Material>(dto);


            await _context.Materials.AddAsync(newMaterial);
            await _context.SaveChangesAsync();

            return Ok("MAterial Created Successfully");

        }

        //Read
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<MaterialDto>>> GetAllMaterials()
        {
            var materials = await _context.Materials.ToListAsync();
            var convertedMaterials = _mapper.Map<IEnumerable<MaterialDto>>(materials);

            return Ok(convertedMaterials);
        }

        [HttpGet]
        [Route("{id}")]

        public async Task<ActionResult<Product>> GetMaterialById([FromRoute] int id)
        {
            var material = await _context.Materials.FirstOrDefaultAsync(q => q.Id == id);

            if (material is null)
            {
                return NotFound("Material Not Found");
            }

            return Ok(material);
        }



        //Update

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateMaterial([FromRoute] int id, [FromBody] MaterialDto dto)
        {
            var material = await _context.Materials.FirstOrDefaultAsync(q => q.Id == id);
            if (material is null)
            {
                return NotFound("Material Not Found");
            }
            material.Description = dto.Description;
            material.Name=dto.Name;


            await _context.SaveChangesAsync();
            return Ok("Material Updated Successfully");
        }

        //Delete
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteMaterial([FromRoute] int id)
        {
            var material = await _context.Materials.FirstOrDefaultAsync(q => q.Id == id);
            if (material is null)
            {
                return NotFound("Material Not Found");
            }
            _context.Materials.Remove(material);
            await _context.SaveChangesAsync();
            return Ok("Material Deleted");
        }
    }
}
