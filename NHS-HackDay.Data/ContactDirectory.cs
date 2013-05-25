using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHS_HackDay.Common;

namespace NHS_HackDay.Data
{
  public class ContactDirectory : IContactDirectory
  {
    private List<Contact> contacts;

    public ContactDirectory()
    {
      contacts = new List<Contact>();
    }

    public string GetActualNumber(string identifier)
    {
      var contact = contacts.SingleOrDefault(m => m.Id.Equals(identifier));

      if (contact != null)
      {
        return contact.MobileNumber;
      }

      throw new ContactNotFoundException();
    }

    public void SetActualNumber(string identifier, string number)
    {
      var contact = contacts.SingleOrDefault(m => m.Id.Equals(identifier));

      if (contact == null)
      {
        contacts.Add(new Contact() { Id = identifier, MobileNumber = number });
      }
      else
      {
        contact.MobileNumber = number;
      }
    }
  }
}
