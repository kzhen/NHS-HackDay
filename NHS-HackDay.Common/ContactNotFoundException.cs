using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHS_HackDay.Common
{
  [Serializable]
  public class ContactNotFoundException : Exception
  {
    public ContactNotFoundException() { }
    public ContactNotFoundException(string message) : base(message) { }
    public ContactNotFoundException(string message, Exception inner) : base(message, inner) { }
    protected ContactNotFoundException(
    System.Runtime.Serialization.SerializationInfo info,
    System.Runtime.Serialization.StreamingContext context)
      : base(info, context) { }
  }
}
