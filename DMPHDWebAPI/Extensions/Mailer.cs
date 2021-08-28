using DMPHDWebAPI.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace DMPHDWebAPI.Extensions
{
    public class Mailer
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Password { get; set; }
        public string HostName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public void Send(bool isHTML = false)
        {
            if (this.Sender == null)
                this.Sender = SystemConfig.MAIL_HOST;

            if (this.Password == null)
                this.Password = SystemConfig.MAIL_PASS;

            if (this.HostName == null)
                this.HostName = SystemConfig.MAIL_NAME;

            var sender = new MailAddress(Sender, HostName);
            var receiver = new MailAddress(Receiver);

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(sender.Address, Password)
            };

            using (var mess = new MailMessage(sender, receiver))
            {
                mess.Subject = Title;
                mess.IsBodyHtml = isHTML;
                mess.Body = Content;
                smtp.SendMailAsync(mess);
            }

        }

        public void Send(List<string> emails, bool isHTML)
        {
            if (this.Sender == null)
                this.Sender = SystemConfig.MAIL_HOST;

            if (this.Password == null)
                this.Password = SystemConfig.MAIL_PASS;

            if (this.HostName == null)
                this.HostName = SystemConfig.MAIL_NAME;

            var sender = new MailAddress(Sender, HostName);


            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(sender.Address, Password)
            };

            using (var mess = new MailMessage())
            {
                mess.From = sender;
                foreach (var email in emails)
                {
                    mess.To.Add(new MailAddress(email));
                }
                mess.Subject = Title;
                mess.Body = Content;
                mess.IsBodyHtml = isHTML;
                smtp.SendMailAsync(mess);
            }
        }
    }
}