using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSD_20
{
    class SearchService
    {


        public static List<string> GetSearchTermsFromConsole()
        {
            while (true)
            {
                Console.WriteLine("Пожалуйста, введите список пользователей, которых вы хотите найти, через запятую:\n");
                string input = Console.ReadLine();
                // TODO: проверка на "нужный" сепаратор; уточнить - нужна ли?
                if (input.Contains(','))
                {
                    string[] separated = input.Split(',', StringSplitOptions.TrimEntries);
                    return separated.ToList();
                } else
                {
                    Console.WriteLine("Если пользователь всего один, поставьте после него запятую, пока я не уточню ТЗ.");
                    continue;
                }
            }
        }

        // TODO: decouple from User (interface & generic) (а что с параметром для LINQ?)
        public static List<User> GetUsersBySearchTerms(List<User> users, List<string> terms)
        {
            var results = users.Where(u => terms.Contains(u.Username)).ToList();
            return results;

        }
    }
}
