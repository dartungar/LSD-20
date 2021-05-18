using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;

namespace LSD_20
{
    class Data
    {
        public List<User> Users { get; set; }

        public void GenerateFakeUsers(int numOfUsers)
        {
            var fakeUserGenerator = new Faker<User>(locale: "ru");

            for (int i = 0; i < numOfUsers; i++)
            {
                Users.Add(fakeUserGenerator.Generate());
            }

            
        }
    }
}
