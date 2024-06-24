namespace backend_dotnet7.Core.Dtos.ProjectTask
{
    public class ProjectTaskDto
    {
        public int ProjectTaskId { get; set; }
        public int ProjectId { get; set; }
        public string TaskName { get; set; }
        public string AssignedTo { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}
