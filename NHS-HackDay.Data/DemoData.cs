using NHS_HackDay.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHS_HackDay.Data
{
  internal class DemoData
  {
    private static Random rnd = new Random();

    public static List<Contact> GetRandomContacts(int length)
    {
      var results = new List<Contact>();

      for (int i = 0; i < length; i++)
      {
        results.Add(new Contact() { Id = (1000 + i).ToString(), Name = RandomName(), MobileNumber = RandomMobile() });
      }

      return results;
    }

    private static string RandomName()
    {
      var gender = rnd.Next(0, 1);
      var isDr = rnd.Next(0, 2);
      string name = string.Empty;
      string title = string.Empty;

      if (isDr == 0)
      {
        title = "Dr ";
      }
      else
      {
        title = "Nurse ";
      }

      if (gender == 0)
      {
        //male
        var fNameIdx = rnd.Next(0, FirstNames.Length);
        var sNameIdx = rnd.Next(0, Surnames.Length);
        name = string.Format("{0} {1} {2}", title, FirstNames[fNameIdx], Surnames[sNameIdx]);
      }
      else
      {
        //female
        var fNameIdx = rnd.Next(0, FemaleNames.Length);
        var sNameIdx = rnd.Next(0, Surnames.Length);
        name = string.Format("{0} {1} {2}", title, FirstNames[fNameIdx], Surnames[sNameIdx]);
      }

      return name;
    }

    private static string RandomMobile()
    {
      var num = rnd.Next(2000, 4000);

      return "_44790346" + num;
    }

    public readonly static string[] FemaleNames = {
        "Pameen",
        "Kelley",
        "Maya",
        "Rebora",
        "Giuliel",
        "Cassa",
        "Gina",
        "Marcian",
        "Mela",
        "Miciand",
        "Emily",
        "Nice",
        "Carah",
        "Barena",
        "Laurtne",
        "Aly",
        "Elerist",
        "Brol",
        "Rebora",
        "Chri",
        "Mary",
        "Viviani",
        "Caren",
        "Kria",
        "Sylvian",
        "Carbari",
        "Alistia"
      };

    public readonly static string[] Surnames = {
        "Sabacke",
        "Garry",
        "Crourg",
        "Fray",
        "Arey",
        "Degarch",
        "Wrick",
        "Sellay",
        "Kieni",
        "Trath",
        "Donds",
        "Forting",
        "Gir",
        "Galwool",
        "Scalle",
        "Fuer",
        "Carmide",
        "Byrd",
        "Ballums",
        "Jullman",
        "Frell",
        "Chey",
        "Maxwer",
        "Brein",
        "Oling",
        "Weir",
        "Bark",
        "Cumer",
        "Barza"
      };

    public readonly static string[] FirstNames = {
      "Rob",
      "Ricard",
      "Garry",
      "Joss",
      "Clay",
      "Andy",
      "Bred",
      "Garren",
      "Stevend",
      "Jusseph",
      "Kevin",
      "Scottha",
      "Eris",
      "Chade",
      "Jerremy",
      "Harry",
      "Dan",
      "Samin",
      "Dan",
      "Loger",
      "Carlose",
      "Jim",
      "Willip",
      "Robby",
      "Hun",
      "Art",
      "Stew",
      "Aley",
      "Brade",
      "Grew",
      "Mike",
      "Edwart",
      "Nat",
      "Bry",
      "Ric",
      "Marry",
      "Jos",
      "Juss",
      "Dart"
    };
  }
}
