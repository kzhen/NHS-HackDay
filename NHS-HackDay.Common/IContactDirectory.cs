using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHS_HackDay.Common
{
  public interface IContactDirectory
  {
    public string GetActualNumber(string identifier);
    public void SetActualNumber(string identifier, string number);
  }
}
