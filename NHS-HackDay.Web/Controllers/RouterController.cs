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
    private IWelcomeRouter router;

    public RouterController(IWelcomeRouter welcomeRouter)
    {
      this.router = welcomeRouter;
    }

    [HttpPost]
    public ActionResult Index(VoiceRequest request)
    {
      var response = router.Greet(request);

      Response.ContentType = "text/xml";
      return Content(response.Element.ToString());
    }

    [HttpPost]
    public ActionResult PingPerson(VoiceRequest request)
    {
      var response = router.PingPerson(request);

      Response.ContentType = "text/xml";
      return Content(response.Element.ToString());
    }

    [HttpPost]
    public ActionResult PreConnect(VoiceRequest request)
    {
      var response = router.PreConnect(request);

      Response.ContentType = "text/xml";
      return Content(response.Element.ToString());
    }

    [HttpPost]
    public ActionResult RespondToPreConnect(VoiceRequest request)
    {
      var response = router.RespondToPreConnect(request);

      Response.ContentType = "text/xml";
      return Content(response.Element.ToString());
    }
    
  }
}
