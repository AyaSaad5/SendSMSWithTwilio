using Microsoft.Extensions.Options;
using SendSMSWithTwilio.Helpers;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace SendSMSWithTwilio.Services
{
    public class SMSService : ISMSService
    {
        private readonly TwilioSettings _twilioSettings;

        public SMSService(IOptions<TwilioSettings> twilioSettings)
        {
            _twilioSettings = twilioSettings.Value;
        }
    
        public MessageResource Send(string mobileNumber, string body)
        {
            TwilioClient.Init(_twilioSettings.AccountSID, _twilioSettings.AuthToken);

            var result = MessageResource.Create(
                                         body:body,
                                         from : new Twilio.Types.PhoneNumber(_twilioSettings.TwilioPhoneNumber),
                                         to : mobileNumber
                                         );
            return result;
        }
    }
}
