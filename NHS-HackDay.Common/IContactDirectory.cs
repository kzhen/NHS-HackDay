using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHS_HackDay.Common
{
  public interface IContactDirectory
  {
    string GetActualNumber(string identifier);
    void SetActualNumber(string identifier, string number);

    Contact FindPerson(string id);

    void UpdateContact(Contact contact);
  }
}
