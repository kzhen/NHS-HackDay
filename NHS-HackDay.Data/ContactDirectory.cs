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
      teams = new List<Team>();

      contacts = DemoData.GetRandomContacts(5000);
    }

    public List<Contact> GetAll()
    {
      return contacts;
    }

    public Contact GetContact(string id)
    {
      return contacts.SingleOrDefault(m => m.Id == id);
    }

    public void UpdateContact(Contact contact)
    {
      var found = contacts.SingleOrDefault(m => m.Id == contact.Id);

      if (found != null)
      {
        contacts.Remove(found);
        contacts.Add(contact);
      }
      else
      {
        contacts.Add(contact);
      }
    }

    public List<Contact> FindContact(string contactName)
    {
      var results = contacts.Where(m => m.Name.Contains(contactName));

      return results.ToList();
    }
  }
}