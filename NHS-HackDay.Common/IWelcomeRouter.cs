using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Mvc;
using Twilio.TwiML;

namespace NHS_HackDay.Common
{
  public interface IWelcomeRouter
  {
    TwilioResponse Greet(VoiceRequest request);
    TwilioResponse InitialOptions(VoiceRequest request);
  }
}
