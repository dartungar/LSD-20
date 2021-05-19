using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LSD_20
{
    /// <summary>
    /// Функции для взаимодействия с пользователем через консоль
    /// </summary>
    class ConsoleService
    {
        /// <summary>
        /// Получение и проверка "поискового запроса" от пользователя через консоль
        /// </summary>
        /// <returns>Список "поисковых слов"</returns>
        public static List<string> GetSearchTermsFromConsole()
        {
            while (true)
            {
                Console.WriteLine("Пожалуйста, введите список пользователей, которых вы хотите найти, через запятую:\n");
                string input = Console.ReadLine();
                if (input.Contains(','))
                {
                    string[] separated = input.Split(',', StringSplitOptions.TrimEntries);
                    return separated.ToList();
                }
                else if (input.Contains(' ') || input.Contains(';') || input.Contains('.') || input.Contains('\t') || input.Contains('\n'))
                {
                    Console.WriteLine("Пожалуйста, используйте запятую для разделения пользователей в списке.");
                    continue;
                } 
                // кейс, когда пользователь не ввёл ни одного разделителя
                // считаем, что это один пользователь
                else
                {
                    return new List<string>() { input.Trim() };
                }
            }
        }

        /// <summary>
        /// Получение и валидация e-mail от пользователя через консоль
        /// </summary>
        /// <returns>Строка email</returns>
        public static string GetEmailFromConsole()
        {

            Console.WriteLine("Введите адрес электронной почты:\n");
            while (true)
            {
                string email = Console.ReadLine();
                if (ValidateEmail(email))
                {
                    return email;
                }
                Console.WriteLine("Неверный формат адреса электронной почты. Попробуйте еще раз:\n");
            }

        }

        /// <summary>
        /// Валидация e-mail регулярным выражением
        /// </summary>
        /// <param name="email">Строка для валидации на соответствие формату e-mail</param>
        /// <returns>Признак успеха валидации</returns>
        public static bool ValidateEmail(string email)
        {
            Regex regex = new(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(email);
        }
    }
}
