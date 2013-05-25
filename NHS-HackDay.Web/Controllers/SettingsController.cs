using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHS_HackDay.Common;

namespace NHS_HackDay.Web.Controllers
{
  public class SettingsController : Controller
  {
    //
    // GET: /Settings/

    public ActionResult Index()
    {
      return View();
    }

    public ActionResult Me()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Me(MySettings settings)
    {
      return View();
    }
  }
}
