namespace Cw49_1.DTOs
{
    public class AuthDto
    {
        public string Token { get; set; } = string.Empty;
        public UserDto User { get; set; } = new UserDto();
    }
}
