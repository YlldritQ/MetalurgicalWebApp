using System.ComponentModel.DataAnnotations;

namespace backend_dotnet7.Core.Entities
{
    public class Material
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

 
    }
}
