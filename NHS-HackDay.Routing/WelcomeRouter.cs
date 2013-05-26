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
      
      response.BeginGather(new { finishOnKey = "#", action = "/Router/PingPerson" });
      response.Say("Please enter the 4 digit identifier for the person you wish to contact, followed by the hash button.");
      response.EndGather();

      return response;
    }


    public TwilioResponse PingPerson(VoiceRequest request)
    {
      TwilioResponse response = new TwilioResponse();

      var person = directory.GetContact(request.Digits);

      if (person != null)
      {
        if (person.AcceptCalls)
        {

          response.Say("We are now contacting " + person.Name + ", please hold the line");
          response.Dial(new Number(person.MobileNumber, new { url = "/Router/PreConnect" }), new { callerId = "+442033229301" });
        }
        else
        {
          var divertedTo = directory.GetContact(person.DivertToId);

          if (divertedTo != null)
          {
            response.Say(person.Name + " is not currently accepting calls. Diverting you to " + divertedTo.Name);
            response.Dial(new Number(divertedTo.MobileNumber, new { url = "/Router/PreConnect" }), new { callerId = "+442033229301" });
          }
          else
          {
            response.Say("Unable to find someone to divert to...");
            response.Hangup();
          }

        }
      }
      else
      {
        response.Say("Person not found");
      }

      return response;
    }

    public TwilioResponse PreConnect(VoiceRequest request)
    {
      var response = new TwilioResponse();

      response.BeginGather(new { numDigits = 1, action = "/Router/RespondToPreConnect" });
      response.Say("You have an incoming call...");
      response.Say("Press 1 to be connected");
      response.Say("Press 2 to hangup");
      response.EndGather();
      response.Hangup();

      return response;
    }

    public TwilioResponse RespondToPreConnect(VoiceRequest request)
    {
      var response = new TwilioResponse();

      if (request.Digits != "1")
      {
        response.Hangup();
      }
      else
      {
        response.Say("Connecting...");
      }

      return response;
    }
  }
}
