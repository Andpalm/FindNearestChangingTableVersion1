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
            return emailSender.SendEmailAsync(email, "Bekr�fta ditt l�senord",
                $"Var v�nlig att bekr�fta din E-post genom att klicka p� <a href='{link}'>l�nken</a>");
        }
    }
}
