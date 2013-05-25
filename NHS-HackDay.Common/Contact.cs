using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHS_HackDay.Common
{
  public class Contact
  {
    public string Id { get; set; }
    public string Name { get; set; }

    public bool AcceptCalls { get; set; }

    public string MobileNumber { get; set; }
    public string DeskPhone { get; set; }
    public string DivertToId { get; set; }
    public List<Team> Teams { get; set; }
  }
}
