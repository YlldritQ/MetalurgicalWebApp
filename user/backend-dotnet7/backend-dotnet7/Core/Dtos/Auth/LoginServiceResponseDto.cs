namespace backend_dotnet7.Core.Dtos.Auth
{
    public class LoginServiceResponseDto
    {
        public string NewToken { get; set; }

        //return to front-end
        public UserInfoResult UserInfo { get; set; }
    }
}