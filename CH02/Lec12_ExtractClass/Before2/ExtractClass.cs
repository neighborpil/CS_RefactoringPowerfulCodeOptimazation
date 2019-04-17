using System;
using System.IO;
using System.Net.Mail;

namespace ExtractClass
{
    public class Person
    {
        public string Name { get; }
        public int Age { get; }
        public string City { get; private set; }
        public string Address { get; private set; }
        public Email Email { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void SetAddress(string city, string address)
        {
            City = city;
            Address = address;
        }
    }

    public class PersonLists
    {
        private readonly IEmailSend _emailSend;
        const string FilePath = @"c:\log.txt";

        public PersonLists(IEmailSend emailSend)
        {
            _emailSend = emailSend;
        }

        public void SendMessage(Person sender, Person receiver, string subject, string text)
        {
            _emailSend.Send(sender.Email, receiver.Email.Address, subject, text);
        }
    }

    public class Email
    {
        public string UserName { get; }
        public string Address { get; }
        public string Password { get; }

        public Email(string userName, string address, string password)
        {
            UserName = userName;
            Address = address;
            Password = password;
        }
    }

    public interface IEmailSend
    {
        bool Send(Email sender, string receiverAddress, string subject, string text);
    }

    public class EmailSend : IEmailSend
    {
        private readonly ILogger _logger;

        public EmailSend(ILogger logger)
        {
            _logger = logger;
        }

        public bool Send(Email sender, string receiverAddress, string subject, string text)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(sender.Address);
                mail.To.Add(receiverAddress);
                mail.Subject = subject;
                mail.Body = text;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(sender.UserName, sender.Password);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Log(ex.Message);
                return false;
            }
        }
    }

    public interface ILogger
    {
        void Log(string message);
    }

    public class Logger : ILogger
    {
        private readonly string filePath;

        public Logger(string filePath)
        {
            this.filePath = filePath;
        }

        public void Log(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                streamWriter.WriteLine(message);
                streamWriter.Close();
            }
        }
    }
}