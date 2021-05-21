using System;
using System.Collections.Generic;
using System.IO;

namespace LSD_20
{
    class Program
    {
        static void Main(string[] args)
        {
            // Наполняем список пользователей - нашу "БД" для будущего поиска
            UsersData data = new UsersData();
            data.Data = UsersDataGenerator.GenerateFakeUsers(20);
            Console.WriteLine(data.Data[0]);
            Console.WriteLine(data.Data[1]);
            Console.WriteLine(data.Data[2]);
            Console.WriteLine(data.Data[3]);
            Console.WriteLine(data.Data[4]);

            // Получаем через консоль список пользователей для поиска
            var searchTerms = ConsoleService.GetSearchTermsFromConsole();


            // выполняем поиск
            List<User> results = data.GetUsersFilteredByUsernames(searchTerms);
            Console.WriteLine(results.Count);

            // сериализуем результаты поиска
            string resultsJsonified = FileService.ListOfObjectsToJsonString<User>(results);

            // пишем сериализованные результаты в файл
            FileService.WriteTextToFile(@"C:\temp\results.json", resultsJsonified);

            // спрашиваем пользователя - отправлять результаты по почте?
            Console.WriteLine("Отправить результаты на E-mail? Д/Н: ");
            string answer = Console.ReadLine();

            // если да - отправим
            if (answer.Equals("Д"))
            {
                // инициализируем сервис отправки сообщений
                var emailService = new EmailService();
                // получаем через консоль адрес для отправки сообщения, добавляем в список рассылки сервиса
                emailService.EmailReceivers.Add(ConsoleService.GetEmailFromConsole());
                // отправляем сообщение
                try
                {
                    emailService.SendTextMessage(resultsJsonified, false);
                    Console.WriteLine("Результаты отправлены по электронной почте.");
                }
                catch (Exception e)
                {

                    throw new Exception($"Ошибка при отправке сообщения: {e.Message}");
                }
            }   

        }
    }
}
