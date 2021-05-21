using System;
using System.Configuration;
using System.Collections.Generic;
using MailKit.Net.Smtp;
using MimeKit;

namespace LSD_20
{
    /// <summary>
    /// Функционал и настройки, связанные с отправкой e-mail.
    /// А также получение адресатов от пользователя через консоль
    /// </summary>
    class EmailService
    {
        // конфигурация сервиса отправки сообщения 
        string Host { get; set; }
        int Port { get; set; } = 587; // порт SMTP по умолчанию
        string Login { get; set; }
        string Password { get; set; }
        string ServiceName { get; set; }
        string ServiceEmailAddress { get; set; }

        // Адресаты
        public List<string> EmailReceivers { get; set; } = new List<string>();

        /// <summary>
        /// Конструктор по умолчанию - инициализирует настройки из App.config
        /// </summary>
        public EmailService()
        {
            ConfigFromAppConfig();
        }



        /// <summary>
        /// Инициализация настроек из App.config
        /// </summary>
        private void ConfigFromAppConfig()
        {
            try
            {
                Host = ConfigurationManager.AppSettings.Get("Host");
                string portRaw = ConfigurationManager.AppSettings.Get("Port");
                if (int.TryParse(portRaw, out int portParsed)) Port = portParsed;
                Login = ConfigurationManager.AppSettings.Get("Login");
                Password = ConfigurationManager.AppSettings.Get("Password");
                ServiceName = ConfigurationManager.AppSettings.Get("ServiceName");
                ServiceEmailAddress = ConfigurationManager.AppSettings.Get("ServiceEmailAddress");
                // TODO: обрабатывать кейсы, когда App.config пустой / не хватает настроек
            }
            catch (Exception)
            {
                throw new Exception("Ошибка установки настроек из файла конфигурации. Проверьте App.config");
            }
        }

        /// <summary>
        /// Отправка электронного письма, содержащего plain text 
        /// </summary>
        /// <param name="messageText">Текст сообщения</param>
        /// <param name="useAuth">Используется ли авторизация по логину и паролю</param>
        public void SendTextMessage(string messageText, bool useAuth)
        {
            // Создание и наполнение сообщения
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(ServiceName, ServiceEmailAddress));
            foreach (string address in EmailReceivers)
            {
                // за неимением имени получателя ставим его же эл.адрес
                message.To.Add(new MailboxAddress(address, address));
            }
            message.Subject = "Результаты поиска";
            message.Body = new TextPart("plain")
            {
                Text = @messageText
            };
            
            // Инициализация почтового клиента и отправка письма
            using var client = new SmtpClient();
            client.Connect(Host, Port);
            if (useAuth)
            {
                client.Authenticate(Login, Password);
            }
            client.Send(message);
            client.Disconnect(true);

        }
    }
}
