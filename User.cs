using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
 

namespace LSD_20
{
    public enum Sex{
      Male,
      Female
    }

    /// <summary>
    /// Модель пользователя, статический список пользователей, 
    /// метод для наполнения этого списка случайно сгенерированными данными
    /// и метод для фильтрации списка на основе поискового запроса
    /// </summary>
    public class User {
        // Статический список пользователей
        public static List<User> Users { get; set; }

        public int Id {get;set;}
        public string Username {get;set;}
        public DateTime Birthday {get;set;}
        public Sex Sex {get;set;}


        /// <summary>
        /// Инициализирует статический список пользователей,
        /// наполняя его случайно сгенерированными данными.
        /// </summary>
        /// <param name="numOfUsers">Число пользователей в созданном списке</param>
        public static void GenerateFakeUsers(int numOfUsers)
        {
            var fakeUserGenerator = new Faker<User>(locale: "ru")
                .RuleFor(u => u.Id, f => f.UniqueIndex)
                .RuleFor(u => u.Sex, f => f.PickRandom<Sex>())
                .RuleFor(u => u.Username, (f, u) => f.Internet.UserName())
                .RuleFor(u => u.Birthday, f => f.Person.DateOfBirth);

            Users = fakeUserGenerator.Generate(numOfUsers).ToList();
        }

        /// <summary>
        /// Возвращает копию списка Users, 
        /// где User.Username совпадает с одним из переданных в метод usernames
        /// </summary>
        /// <param name="terms">Список строк - username, испольуемых для поиска</param>
        /// <returns>Отфильтрованный список пользователей</returns>
        public static List<User> GetUsersFilteredByUsernames(List<string> usernames)
        {
            var results = Users.Where(u => usernames.Contains(u.Username)).ToList();
            return results;

        }


        public override string ToString()
        {
            return $"{Id}: {Username}";
        }
    }
}
