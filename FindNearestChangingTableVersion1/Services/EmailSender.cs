using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FindNearestChangingTableVersion1.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            smtpClient.Credentials = new System.Net.NetworkCredential("nearestchangingtable@gmail.com", "Abc1234!");
            //smtpClient.UseDefaultCredentials = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            MailMessage mail = new MailMessage();

            //Setting From , To and CC
            mail.IsBodyHtml = true;
            mail.Subject = subject;
            mail.Body = message;
            mail.From = new MailAddress("nearestchangingtable@gmail.com", "Sköt dig själv");
            mail.To.Add(new MailAddress(email));

            smtpClient.Send(mail);

            return Task.CompletedTask;
        }
    }
}
