using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHS_HackDay.Common
{
  public interface IContactDirectory
  {
    List<Contact> GetAll();
    Contact GetContact(string id);
    void UpdateContact(Contact contact);
    List<Contact> FindContact(string contactName);
    bool ExtensionExists(string id);

    Contact GetTeamMember(string teamId, int idx);

    Team GetTeam(string teamId);
  }
}
