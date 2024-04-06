namespace backend_dotnet7.Core.Entities
{
    public class Message : BaseEntity<long>
    {
        public string SenderUserName { get; set; }
        public string RecieverUserName { get; set;}
        public string Text { get; set;}
    }
}
