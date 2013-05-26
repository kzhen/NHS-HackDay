using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHS_HackDay.Common;
using Twilio.Mvc;
using Twilio.TwiML;

namespace NHS_HackDay.Routing
{
  public class WelcomeRouter : IWelcomeRouter
  {
    private IContactDirectory directory;

    public WelcomeRouter(IContactDirectory contactDirectory)
    {
      this.directory = contactDirectory;
    }

    public TwilioResponse Greet(VoiceRequest request)
    {
      TwilioResponse response = new TwilioResponse();

      response.Say("Welcome to Saint Georges Hospital Directory.");

      response.BeginGather(new { finishOnKey = "#", action = "/Router/InitialOptions" });
      response.Say("Please enter your four digit I D then press the hash button");
      response.EndGather();

      return response;
    }

    public TwilioResponse InitialOptions(VoiceRequest request)
    {
      TwilioResponse response = new TwilioResponse();

      var id = request.Digits;

      if (!directory.ExtensionExists(id))
      {
        response.Say("We couldn't find your I D.");
        response.Hangup();
      }

      response.BeginGather(new { finishOnKey = "#", action = string.Format("/Router/PingInital?callingPartyId={0}", id) });
      response.Say("To contact an individual, enter their 4 digit I D and then press the hash button");
      response.Say("To contact a team, enter star followed by the 4 digit I D and then press the hash button");
      response.EndGather();

      return response;
    }
  }
}
