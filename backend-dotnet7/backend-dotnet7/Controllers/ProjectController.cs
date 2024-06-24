using AutoMapper;
using backend_dotnet7.Core.DbContext;
using backend_dotnet7.Core.Dtos.Product;
using backend_dotnet7.Core.Dtos.Project;
using backend_dotnet7.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper { get; }

        public ProjectController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //CRUD


        //Create
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateProject([FromBody] ProjectDto dto)
        {

            Project newProject = _mapper.Map<Project>(dto);


            await _context.Projects.AddAsync(newProject);
            await _context.SaveChangesAsync();

            return Ok("Project Created Successfully");

        }

        //Read
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetAllProjects()
        {
            var projects = await _context.Projects.ToListAsync();
            var convertedProjects = _mapper.Map<IEnumerable<ProjectDto>>(projects);

            return Ok(convertedProjects);
        }

        [HttpGet]
        [Route("{id}")]

        public async Task<ActionResult<Project>> GetProjectById([FromRoute] long id)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(q => q.ProjectId == id);

            if (project is null)
            {
                return NotFound("Project Not Found");
            }

            return Ok(project);
        }



        //Update

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProject([FromRoute] long id, [FromBody] ProjectDto dto)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(q => q.ProjectId == id);
            if (project is null)
            {
                return NotFound("Project Not Found");
            }
            _mapper.Map(dto, project);


            await _context.SaveChangesAsync();
            return Ok("Project Updated Successfully");
        }

        //Delete
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProject([FromRoute] long id)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(q => q.ProjectId == id);
            if (project is null)
            {
                return NotFound("Project Not Found");
            }
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return Ok("Project Deleted");
        }
    }
}
