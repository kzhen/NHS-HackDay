using NHS_HackDay.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHS_HackDay.Web.Models
{
  public class SearchResultsViewModel
  {
    public string SearchedValue { get; set; }
    public List<Contact> Results { get; set; }
  }
}