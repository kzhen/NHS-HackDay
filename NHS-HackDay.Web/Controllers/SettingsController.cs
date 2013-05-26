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
    private IContactDirectory directory;

    public SettingsController(IContactDirectory directory)
    {
      this.directory = directory;
    }

    public ActionResult Index()
    {
      return View();
    }

    public ActionResult Me(string id)
    {
      var contact = directory.GetContact(id);

      if (contact != null)
      {
        return View(contact);
      }

      return View();
    }

    [HttpPost]
    public ActionResult Me(Contact contact)
    {
      directory.UpdateContact(contact);

      return View();
    }
  }
}
