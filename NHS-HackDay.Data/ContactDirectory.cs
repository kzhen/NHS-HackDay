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
    private static List<Contact> contacts;
    private static List<Team> teams;

    public ContactDirectory()
    {
      teams = new List<Team>();

      contacts = DemoData.GetRandomContacts(5000);

      var t1 = new Team()
      {
        Name = "X Ray",
        Id = "8888",
        TeamMembers = new List<Contact>()
      };

      t1.TeamMembers.Add(contacts.Single(m => m.Id == "1111"));
      t1.TeamMembers.Add(contacts.Single(m => m.Id == "2222"));

      teams.Add(t1);
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
        //contacts.Remove(found);
        //contacts.Add(contact);
        int idx = contacts.IndexOf(found);
        //found = contact;
        contacts[idx] = contact;

        teams = new List<Team>();
        
        var t1 = new Team()
        {
          Name = "X Ray",
          Id = "8888",
          TeamMembers = new List<Contact>()
        };

        t1.TeamMembers.Add(contacts.Single(m => m.Id == "1111"));
        t1.TeamMembers.Add(contacts.Single(m => m.Id == "2222"));

        teams.Add(t1);
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


    public bool ExtensionExists(string id)
    {
      return contacts.Exists(m => m.Id == id);
    }

    public Team GetTeam(string teamId)
    {
      return teams.SingleOrDefault(m => m.Id == teamId);
    }

    public Contact GetTeamMember(string teamId, int idx)
    {
      var team = GetTeam(teamId);
      var members = team.TeamMembers.Where(m => m.AcceptCalls).ToList();

      if (team != null)
      {
        if (idx < members.Count)
        {
          return members[idx];
        }
      }

      return null;
    }
  }
}