﻿using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ArticleWeb.Auth.Service
{
    /// <summary>
    /// Represents email service.
    /// </summary>
    public class EmailService
    {
        /// <summary>
        /// Sends the email asynchronous.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="message">The message.</param>
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            MailAddress from = new MailAddress("testarticlemail@rambler.ru");
            MailAddress to = new MailAddress(email);
            MailMessage mailMessage = new MailMessage(from, to);
            mailMessage.Subject = subject;
            mailMessage.Body = message;

            using (SmtpClient client = new SmtpClient("smtp.rambler.ru ", 587))
            {
                client.Credentials = new NetworkCredential("testarticlemail@rambler.ru", "Zd+@Wf9+LS7nsgV");
                client.EnableSsl = true;
                client.Send(mailMessage);
            }
        }
    }
}