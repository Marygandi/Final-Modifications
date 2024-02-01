using FeedBackAppA.Interfaces;
using System.Net.Mail;
using System.Net;

namespace FeedBackAppA.Services
{
    public class SmtpEmailService : IEmailService
    {
        private readonly string _smtpServer = "smtp.gmail.com";
        private readonly int _smtpPort = 587;
        private readonly string _smtpUsername = "sivakumari143256@gmail.com";
        private readonly string _smtpPassword = "jbnl vemj inml ehvd"; 

        public void SendEmail(string toEmail, string subject, string body)
        {
            using (var client = new SmtpClient(_smtpServer, _smtpPort))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);
                client.EnableSsl = true;

                var message = new MailMessage
                {
                    From = new MailAddress(_smtpUsername),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false
                };

                message.To.Add(toEmail);

                client.Send(message);
            }
        }
    }
}
