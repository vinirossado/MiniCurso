using Microsoft.Extensions.Configuration;
using MyHome.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Services
{
    public class EmailService : IEmailService
    {

        public async Task Enviar(string emailDestinatario, string assunto, string mensagem)
        {
            var config = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile("appsettings.json")
                           .Build();

            //Valores Smtp
            var emailNome = config["email:nome"];
            var emailEndereco = config["email:endereco"];
            var emailSenha = config["email:senha"];
            var smtpHost = config["email:host"];
            var smtpPort = Convert.ToInt32(config["email:port"]);
            var smtpEnableSsl = Convert.ToBoolean(config["email:enableSsl"]);

            using (var smtp = new SmtpClient())
            {
                smtp.Host = smtpHost;
                smtp.Port = smtpPort;
                smtp.EnableSsl = smtpEnableSsl;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(emailEndereco, emailSenha);

                using (var mail = new MailMessage())
                {
                    mail.Sender = new MailAddress(emailEndereco, emailNome);
                    mail.From = new MailAddress(emailEndereco, emailNome);
                    mail.To.Add(new MailAddress(emailDestinatario));
                    mail.Subject = assunto;
                    mail.IsBodyHtml = true;
                    mail.Body = mensagem;

                    await smtp.SendMailAsync(mail);
                }
            }
        }
    }
}
