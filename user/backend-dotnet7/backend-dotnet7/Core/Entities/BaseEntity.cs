namespace backend_dotnet7.Core.Entities
{
    public class BaseEntity<TID>
    {
        public TID Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UdatedAt { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public bool isDeleted { get; set; } = false;
    }
}
