using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHS_HackDay.Common;
using Twilio.Mvc;

namespace NHS_HackDay.Web.Controllers
{
  public class RouterController : Controller
  {
    private IWelcomeRouter welcomeRouter;
    private IConnecterRouter connectorRouter;

    public RouterController(IWelcomeRouter welcomeRouter, IConnecterRouter connectorRouter)
    {
      this.welcomeRouter = welcomeRouter;
      this.connectorRouter = connectorRouter;
    }

    [HttpPost]
    public ActionResult Index(VoiceRequest request)
    {
      var response = welcomeRouter.Greet(request);

      Response.ContentType = "text/xml";
      return Content(response.Element.ToString());
    }

    [HttpPost]
    public ActionResult InitialOptions(VoiceRequest request)
    {
      var response = welcomeRouter.InitialOptions(request);

      Response.ContentType = "text/xml";
      return Content(response.Element.ToString());
    }

    [HttpPost]
    public ActionResult PingInital(VoiceRequest request, string callingPartyId)
    {
      var response = connectorRouter.InitiatePing(request, callingPartyId);

      Response.ContentType = "text/xml";
      return Content(response.Element.ToString());
    }

    [HttpPost]
    public ActionResult PreConnect(VoiceRequest request, string callingPartyId)
    {
      var response = connectorRouter.PreConnect(request, callingPartyId);

      Response.ContentType = "text/xml";
      return Content(response.Element.ToString());
    }

    [HttpPost]
    public ActionResult RespondToPreConnect(VoiceRequest request)
    {
      var response = connectorRouter.RespondToPreConnect(request);

      Response.ContentType = "text/xml";
      return Content(response.Element.ToString());
    }

    [HttpPost]
    public ActionResult NextTeamMember(string callingPartyId, string teamId, int idx)
    {
      var response = connectorRouter.PingTeamMember(teamId, callingPartyId, ++idx);

      Response.ContentType = "text/xml";
      return Content(response.Element.ToString());
    }
    
  }
}
