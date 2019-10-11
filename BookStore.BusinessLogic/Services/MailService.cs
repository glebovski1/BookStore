using System;
using System.Collections.Generic;
using System.Text;
using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using System.Configuration;

namespace BookStore.BusinessLogic.Services
{
    public class MailService
    {
        
            public async Task SendEmailAsync(string email, string subject, string message)
            {
                var emailMessage = new MimeMessage();
                
                emailMessage.From.Add(new MailboxAddress("", "BookStoreGlebvoski@Gmail.com"));
                emailMessage.To.Add(new MailboxAddress("", email));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = message
                };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.gmail.com", 465, true);
                    await client.AuthenticateAsync("BookStoreGlebvoski@Gmail.com", "123xxx123");
                    await client.SendAsync(emailMessage);

                    await client.DisconnectAsync(true);
                }
            }
        
    }
}
