using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NHS_HackDay.Web.Controllers
{
  public class SearchController : Controller
  {
    //
    // GET: /Search/

    public ActionResult Index()
    {
      return View();
    }

    public ActionResult FindPerson()
    {
      return View();
    }

    [HttpPost]
    public ActionResult FindPerson(FormCollection form)
    {
      return View();
    }
  }
}
