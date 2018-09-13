using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using FindNearestChangingTableVersion1.Services;

namespace FindNearestChangingTableVersion1.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Bekräfta ditt lösenord",
                $"Var vänlig att bekräfta din E-post genom att klicka på <a href='{link}'>länken</a>");
        }
    }
}
