using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHS_HackDay.Common;

namespace NHS_HackDay.Web.Controllers
{
  public class SearchController : Controller
  {
    private IContactDirectory directory;

    public SearchController(IContactDirectory directory)
    {
      this.directory = directory;
    }

    public ActionResult Index()
    {
      var contacts = directory.GetAll();
      return View(contacts);
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
