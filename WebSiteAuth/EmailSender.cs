using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace WebSiteAuth
{
    public class EmailSender : IEmailSender
    {
        //非同步的傳回值要用Task
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var mail = new MailMessage();
            mail.From = new MailAddress("寄件者電子郵件");
            mail.To.Add(email);
            mail.Subject = subject;
            mail.IsBodyHtml = true;
            mail.Body = htmlMessage;
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com");
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(
                "登入SMTP伺服器帳號", "登入SMTP伺服器密碼");
            client.EnableSsl = true;
            client.Send(mail);
        }
    }
}
