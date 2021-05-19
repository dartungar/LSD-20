using System;
using System.Collections.Generic;
using System.IO;

namespace LSD_20
{
    class Program
    {
        static void Main(string[] args)
        {
            User.GenerateFakeUsers(20);
            Console.WriteLine(User.Users[0]);
            Console.WriteLine(User.Users[1]);
            Console.WriteLine(User.Users[2]);
            Console.WriteLine(User.Users[3]);
            Console.WriteLine(User.Users[4]);

            var searchTerms = SearchService.GetSearchTermsFromConsole();
            List<User> results = SearchService.GetUsersBySearchTerms(User.Users, searchTerms);
            Console.WriteLine(results.Count);
            string resultsJsonified = FileService.ListOfObjectsToJsonString<User>(results);
            FileService.WriteTextToFile(@"C:\temp\results.json", resultsJsonified);
            Console.WriteLine("Отправить результаты на E-mail? Д/Н: ");
            string answer = Console.ReadLine();
            if (answer.Equals("Д"))
            {
                var emailService = new EmailService();
                emailService.GetEmailFromConsole();
                emailService.SendTextMessage(resultsJsonified, false);
            }

        }
    }
}
