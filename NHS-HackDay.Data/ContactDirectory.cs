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
    private List<Team> teams;

    public ContactDirectory()
    {
      contacts = new List<Contact>();
      teams = new List<Team>();
    }

    public Contact FindContact(string id)
    {
      return contacts.SingleOrDefault(m => m.Id == id);
    }

    public void UpdateContact(Contact contact)
    {
      var found = contacts.SingleOrDefault(m => m.Id == contact.Id);

      if (found != null)
      {
        //found = contact;
        contacts.Remove(found);
        contacts.Add(contact);
      }
      else
      {
        contacts.Add(contact);
      }
    }
  }
}