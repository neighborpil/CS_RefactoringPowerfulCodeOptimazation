using System;
using System.IO;
using System.Net.Mail;

namespace ExtractClass
{
    public class Logger
    {
        const string FilePath = @"c:\log.txt";

        public void Log(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(FilePath))
            {
                streamWriter.WriteLine(message);
                streamWriter.Close();
            }
        }
    }

    public class Email
    {
        public string UserName { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }


        public bool Send(string address, string subject, string text, Logger logger)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(Address);
                mail.To.Add(address);
                mail.Subject = subject;
                mail.Body = text;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(UserName, Password);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                logger.Log(ex.Message);
                return false;
            }
        }
    }

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

    public class PersonList
    {
        public bool SendMail(Person firstPerson, Person secondPerson, string subject, string text)
        {
            Logger logger = new Logger();
            return firstPerson.Email.Send(secondPerson.Email.Address, subject, text, logger);
        }
    }
}