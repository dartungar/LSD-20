using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;


namespace LSD_20
{
    /// <summary>
    /// Генерация фейковых данных
    /// </summary>
    class UsersDataGenerator
    {
        /// <summary>
        /// Инициализирует статический список пользователей,
        /// наполняя его случайно сгенерированными данными.
        /// </summary>
        /// <param name="numOfUsers">Число пользователей в созданном списке</param>
        public static List<User> GenerateFakeUsers(int numOfUsers)
        {
            var fakeUserGenerator = new Faker<User>(locale: "ru")
                .RuleFor(u => u.Id, f => f.UniqueIndex)
                .RuleFor(u => u.Sex, f => f.PickRandom<Sex>())
                .RuleFor(u => u.Username, (f, u) => f.Internet.UserName())
                .RuleFor(u => u.Birthday, f => f.Person.DateOfBirth);

            return fakeUserGenerator.Generate(numOfUsers).ToList();
        }
    }
}
