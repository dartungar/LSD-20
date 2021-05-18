using System;

namespace LSD_20
{
    class Program
    {
        static void Main(string[] args)
        {
            var fakeData = new Data();
            fakeData.GenerateFakeUsers(20);
            Console.WriteLine(fakeData.Users[5].Username);
        }
    }
}
