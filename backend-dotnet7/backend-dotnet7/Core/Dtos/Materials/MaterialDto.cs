

using backend_dotnet7.Core.Dtos.Supplier;

namespace backend_dotnet7.Core.Dtos.Materials
{
    public class MaterialDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SupplierId { get; set; }
       

    }
}
