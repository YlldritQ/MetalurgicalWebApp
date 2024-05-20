using backend_dotnet7.Core.Enum;
using System.Security.Cryptography;

namespace backend_dotnet7.Core.Dtos.Product
{
    public class CreateUpdateProductDto
    {
        public long Id { get; set; }
        public string Brand { get; set; }
        public string Title { get; set; }
        public ProductSize Size { get; set; }
    }
}
