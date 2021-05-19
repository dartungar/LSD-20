using System;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections.Generic;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;

namespace LSD_20
{
    class EmailService
    {

        string Host { get; set; }
        int Port { get; set; } = 587;
        string Login { get; set; }
        string Password { get; set; }
        string ServiceName { get; set; }
        string ServiceEmailAddress { get; set; }

        public List<string> EmailReceivers { get; set; }

        public EmailService()
        {
            ConfigFromAppConfig();
        }

        public void GetEmailFromConsole()
        {
            
            Console.WriteLine("Введите адрес электронной почты:\n");
            while (true)
            {
                string email = Console.ReadLine();
                if (ValidateEmail(email))
                {
                    if (EmailReceivers == null) EmailReceivers = new List<string>();
                    EmailReceivers.Add(email);
                    break;
                }
                Console.WriteLine("Неверный формат адреса электронной почты. Попробуйте еще раз:\n");
            }

        }

        public static bool ValidateEmail(string email)
        {
            Regex regex = new(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(email);
        }

        // check if there is valid e-mail server configuration
    
        public void ConfigFromAppConfig()
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
                // TODO: если конфиг пустой или неполный, выдавать ошибку
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SendTextMessage(string messageText, bool useAuth)
        {
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
