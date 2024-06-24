using System.ComponentModel.DataAnnotations;

namespace backend_dotnet7.Core.Entities
{
    public class ProjectTask
    {
        [Key]
        public int ProjectTaskId { get; set; }
        public int ProjectId { get; set; } //ForeignKey
        public string TaskName { get; set; }
        public string AssignedTo { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }

        public Project Project { get; set; }

    }
}
