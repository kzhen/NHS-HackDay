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
    public TwilioResponse Greet(VoiceRequest request)
    {
      TwilioResponse response = new TwilioResponse();

      response.Say("Welcome to Saint Georges Hospital Directory.");
      
      response.BeginGather(new { finishOnKey = "#", action = "/api/Router/PingPerson" });
      //response.Say("Please enter your 4 digit identifier, followed by the hash button.");
      response.Say("Please enter the 4 digit identifier for the person you wish to contact, followed by the hash button.");
      response.EndGather();

      return response;
    }
  }
}
