using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace PatientRegistry.Services
{
    public class SmsService
    {
        public IConfiguration Configuration { get; }

        private readonly string _accountSid;
        private readonly string _authToken;
        private readonly string _fromNumber;

        public SmsService(IConfiguration configuration)
        {
            _accountSid = configuration["Twilio:AccountSid"];
            _authToken = configuration["Twilio:AuthToken"];
            _fromNumber = configuration["Twilio:FromNumber"];
        }

        public void SendSms(string to, string message)
        {
            TwilioClient.Init(_accountSid, _authToken);
            MessageResource.Create(
                body: message,
                from: new Twilio.Types.PhoneNumber(_fromNumber),
                to: new Twilio.Types.PhoneNumber(to)
            );
        }
    }
}
