namespace SevenWinBackend.Site.Library.Dto
{
    public class LoginResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
