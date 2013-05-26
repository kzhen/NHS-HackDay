using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHS_HackDay.Common;
using NHS_HackDay.Web.Models;

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

    public ActionResult FindContact()
    {
      return View();
    }

    [HttpPost]
    public ActionResult FindContact(ContactSearchRequest request)
    {
      var results = directory.FindContact(request.ContactName);

      var model = new SearchResultsViewModel() { Results = results, SearchedValue = request.ContactName };

      return View("SearchResults", model);
    }
  }
}
