namespace LuminaAPI.Model.Config
{
    public class TwilioConfig
    {
        public string AccountSID { get; set; }

        public string AuthToken { get; set; }

        public string FromNumber { get; set; }

        public List<string> ToNumbers { get; set; }
    }
}
