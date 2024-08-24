using Exercise_1_BackgroundJobApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;

namespace Exercise_1_BackgroundJobApp
{
    public class BackgroundJob
    {
        public static async Task<List<User>> FetchUsersForPasswordUpdateAsync(ApplicationDbContext context)
        {
            string requirePasswordStatus = "REQUIRE_CHANGE_PWD";

            var sixMonthsAgo = DateTime.Now.AddMonths(-6);
            var users = await context.Users
                .Where(u =>
                       u.LastUpdatePwd < sixMonthsAgo &&
                       u.Status != requirePasswordStatus)
                .ToListAsync();

            foreach (var user in users)
                user.Status = requirePasswordStatus;

            context.UpdateRange(users);

            await context.SaveChangesAsync();

            return users;
        }

        public static async Task SendEmailNotificationsAsync(List<User> users)
        {
            using var smtpClient = new SmtpClient("smtp.your-email-provider.com");
            smtpClient.Credentials = new NetworkCredential("your-email@example.com", "your-password");

            foreach (var user in users)
            {
                var mailMessage = new MailMessage(
                    "your-email@example.com",
                    user.Email,
                    "Password Change Required",
                    "Please update your password. It has not been changed for more than six months.");

                await smtpClient.SendMailAsync(mailMessage);
            }
        }
    }
}
