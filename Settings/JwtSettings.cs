namespace ContactAPI.Settings
{
    public class JwtSettings
    {
        public JwtSettings(string secret)
        {
            Secret = secret;
        }

        public string Secret { get; set; }
    }
}
