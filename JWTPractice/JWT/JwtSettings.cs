namespace JWTPractice.JWT
{
    public class JwtSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }

        public string SecurityKey { get; set; }
        public double ExpiryTime { get; set; }
    }
}
