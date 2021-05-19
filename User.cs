using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
 

namespace LSD_20
{
    public enum Sex{
      Male,
      Famale,
      Other // just kidding
    }

    public class User {
        public static List<User> Users { get; set; }


        public int Id {get;set;}
        public string Username {get;set;}
        public DateTime Birthday {get;set;}
        public Sex Sex {get;set;}

        public static void GenerateFakeUsers(int numOfUsers)
        {
            var fakeUserGenerator = new Faker<User>(locale: "ru")
                .RuleFor(u => u.Id, f => f.UniqueIndex)
                .RuleFor(u => u.Sex, f => f.PickRandom<Sex>())
                .RuleFor(u => u.Username, (f, u) => f.Internet.UserName())
                .RuleFor(u => u.Birthday, f => f.Person.DateOfBirth);

            Users = fakeUserGenerator.Generate(numOfUsers).ToList();
        }

        public override string ToString()
        {
            return $"{Id}: {Username}";
        }
    }
}
