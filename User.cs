using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSD_20
{
    public enum Sex{
      Male,
      Famale,
      Other // just kidding
    }

    public class User {
      public int Id {get;set;}
      public string Username {get;set;}
      public Datetime Birthday {get;set;}
      public Sex Sex {get;set;}
    }
}
