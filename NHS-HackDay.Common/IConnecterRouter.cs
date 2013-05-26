using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Mvc;
using Twilio.TwiML;

namespace NHS_HackDay.Common
{
  public interface IConnecterRouter
  {
    TwilioResponse InitiatePing(VoiceRequest request, string callingPartyId);

    TwilioResponse PreConnect(VoiceRequest request, string callingPartyId);

    TwilioResponse RespondToPreConnect(VoiceRequest request);

    TwilioResponse PingTeamMember(string teamId, string callingPartyId, int idx);
  }
}
