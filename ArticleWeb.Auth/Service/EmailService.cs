using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ArticleWeb.Auth.Service
{
    public class EmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            MailAddress from = new MailAddress("testarticlemail@rambler.ru");
            MailAddress to = new MailAddress(email);
            MailMessage mailMessage = new MailMessage(from,to);
            mailMessage.Subject = subject;
            mailMessage.Body = message;

            using(SmtpClient client = new SmtpClient("smtp.rambler.ru ", 587))
            {
                client.Credentials = new NetworkCredential("testarticlemail@rambler.ru", "Zd+@Wf9+LS7nsgV");
                client.EnableSsl = true;
                client.Send(mailMessage);
            }


        }
    }
}
