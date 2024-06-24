using System.ComponentModel.DataAnnotations;

namespace backend_dotnet7.Core.Entities
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ProjectManager { get; set; }
        public float Budget { get; set; }
        public string Status { get; set; }

        public ICollection<ProjectTask> ProjectTasks { get; set; }
    }
}
