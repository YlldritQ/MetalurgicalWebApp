using AutoMapper;
using backend_dotnet7.Core.DbContext;
using backend_dotnet7.Core.Dtos.Project;
using backend_dotnet7.Core.Dtos.ProjectTask;
using backend_dotnet7.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTaskController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper { get; }

        public ProjectTaskController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //CRUD


        //Create
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateProjectTask([FromBody] ProjectTaskDto dto)
        {

            ProjectTask newProjectTask = _mapper.Map<ProjectTask>(dto);


            await _context.ProjectTasks.AddAsync(newProjectTask);
            await _context.SaveChangesAsync();

            return Ok("ProjectTask Created Successfully");

        }

        //Read
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<ProjectTaskDto>>> GetAllProjectsTask()
        {
            var projectsTask = await _context.ProjectTasks.ToListAsync();
            var convertedProjectsTask = _mapper.Map<IEnumerable<ProjectTaskDto>>(projectsTask);

            return Ok(convertedProjectsTask);
        }

        [HttpGet]
        [Route("{id}")]

        public async Task<ActionResult<ProjectTask>> GetProjectTaskById([FromRoute] long id)
        {
            var projectTask = await _context.ProjectTasks.FirstOrDefaultAsync(q => q.ProjectTaskId == id);

            if (projectTask is null)
            {
                return NotFound("ProjectTask Not Found");
            }

            return Ok(projectTask);
        }



        //Update

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProjectTask([FromRoute] long id, [FromBody] ProjectTaskDto dto)
        {
            var projectTask = await _context.ProjectTasks.FirstOrDefaultAsync(q => q.ProjectTaskId == id);
            if (projectTask is null)
            {
                return NotFound("ProjectTask Not Found");
            }
            _mapper.Map(dto, projectTask);


            await _context.SaveChangesAsync();
            return Ok("ProjectTask Updated Successfully");
        }

        //Delete
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProjectTask([FromRoute] long id)
        {
            var projectTask = await _context.ProjectTasks.FirstOrDefaultAsync(q => q.ProjectTaskId == id);
            if (projectTask is null)
            {
                return NotFound("ProjectTask Not Found");
            }
            _context.ProjectTasks.Remove(projectTask);
            await _context.SaveChangesAsync();
            return Ok("ProjectTask Deleted");
        }
    }
}
