namespace Amaggi.Blog.API.Extensions
{
    public class JWTSettings
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpirationInHours { get; set; }
    }
}
