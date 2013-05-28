using NHS_HackDay.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Mvc;
using Twilio.TwiML;

namespace NHS_HackDay.Routing
{
  public class ConnecterRouter : IConnecterRouter
  {
    private IContactDirectory directory;

    public ConnecterRouter(IContactDirectory contactDirectory)
    {
      this.directory = contactDirectory;
    }

    public TwilioResponse InitiatePing(VoiceRequest request, string callingPartyId)
    {
      TwilioResponse response = new TwilioResponse();

      var callingParty = directory.GetContact(callingPartyId);

      //if the digits starts with a * then they are trying to call a group
      if (request.Digits.StartsWith("*"))
      {
        var teamId = request.Digits.Substring(1);

        return PingTeamMember(teamId, callingPartyId, 0);
      }
      else
      {
        return PingPerson(request, callingPartyId);
      }
    }

    public TwilioResponse PingTeamMember(string teamId, string callingPartyId, int idx)
    {
      var response = new TwilioResponse();

      Contact contact = directory.GetTeamMember(teamId, idx);
      Team team = directory.GetTeam(teamId);

      if (contact != null)
      {
        if (idx == 0)
        {
          response.Say(string.Format("Now attempting to connect you to {0}", team.Name));
        }
        else
        {
          response.Say("Trying next team member...");
        }

        response.Say("We are now contacting " + contact.Name + ", please hold the line");
        response.Dial(new Number(contact.MobileNumber, new { url = string.Format("/Router/PreConnect?callingPartyId={0}", callingPartyId) }), 
          new { callerId = "+442033229301", timeLimit = 5, action = string.Format("/Router/NextTeamMember?callingPartyId={0}&TeamId={1}&Idx={2}", callingPartyId, teamId, idx) });
      }
      else
      {
        response.Say("Couldn't find a team member...");
        response.Hangup();
      }

      return response;
    }

    private TwilioResponse PingPerson(VoiceRequest request, string callingPartyId)
    {
      TwilioResponse response = new TwilioResponse();

      var person = directory.GetContact(request.Digits);

      if (person != null)
      {
        if (person.AcceptCalls)
        {
          response.Say("We are now contacting " + person.Name + ", please hold the line");
          response.Dial(new Number(person.MobileNumber, new { url = string.Format("/Router/PreConnect?callingPartyId={0}", callingPartyId) }), new { callerId = "+442033229301" });
        }
        else
        {
          var divertedTo = directory.GetContact(person.DivertToId);

          if (divertedTo != null)
          {
            response.Say(person.Name + " is not currently accepting calls. Diverting you to " + divertedTo.Name);
            response.Dial(new Number(divertedTo.MobileNumber, new { url = string.Format("/Router/PreConnect?callingPartyId={0}", callingPartyId) }), new { callerId = "+442033229301" });
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

    public TwilioResponse PreConnect(VoiceRequest request, string callingPartyId)
    {
      var response = new TwilioResponse();

      var callingParty = directory.GetContact(callingPartyId);

      response.BeginGather(new { numDigits = 1, action = "/Router/RespondToPreConnect" });
      response.Say(string.Format("You have an incoming call from {0}", callingParty.Name));
      response.Say("Press 1 to be connected");
      response.Say("Press 2 to hangup");
      response.EndGather();
      response.Hangup();

      return response;
    }

    public TwilioResponse RespondToPreConnect(VoiceRequest request)
    {
      var response = new TwilioResponse();

      if (request.Digits == "1")
      {
        response.Say("You are now being connected.");
      }
      else
      {
        response.Hangup();
      }

      return response;
    }
  }
}
