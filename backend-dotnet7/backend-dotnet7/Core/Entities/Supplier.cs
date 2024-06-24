using System.ComponentModel.DataAnnotations;

namespace backend_dotnet7.Core.Entities
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }

        public ICollection<Material> Materials { get; set; }

    }
}
