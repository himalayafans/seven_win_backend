namespace SevenWinBackend.Site.Library.Dto
{
    public class LoginResponse
    {
        public Guid id { get; set; }
        public string name { get; set; } = string.Empty;
        public string token { get; set; } = string.Empty;
    }
}
