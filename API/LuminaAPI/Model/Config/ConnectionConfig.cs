namespace LuminaAPI.Model.Config
{
    public class ConnectionConfig
    {
        public string ConnectionString { get; set; }

        public string DBName { get; set; }


        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string SecretKey { get; set; }
    }
}
