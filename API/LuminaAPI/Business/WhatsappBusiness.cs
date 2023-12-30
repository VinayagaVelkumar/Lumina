using LuminaAPI.Model.Config;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML.Voice;
using Twilio.Types;

namespace LuminaAPI.Business
{
    public class WhatsappBusiness
    {
        private readonly TwilioConfig _twilioConfig;

        public WhatsappBusiness(TwilioConfig twilioConfig)
        {
            this._twilioConfig = twilioConfig;
        }

        public async Task<bool> SendMessage(string messageBody, string fileURL ="")
        {
            try
            {
                string accountSid = this._twilioConfig.AccountSID;
                string authToken = this._twilioConfig.AuthToken;

                TwilioClient.Init(accountSid, authToken);
                foreach(string phoneNumber in this._twilioConfig.ToNumbers)
                {
                    var messageOptions = new CreateMessageOptions(
                    new PhoneNumber(phoneNumber));
                    messageOptions.From = new PhoneNumber(this._twilioConfig.FromNumber);
                    messageOptions.Body = messageBody;
                    if(!string.IsNullOrEmpty(fileURL))
                    {
                        messageOptions.MediaUrl.Add(new Uri(fileURL));
                    }
                    var message = MessageResource.Create(messageOptions);
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
