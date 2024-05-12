using System.Net;
using System.Net.Mail;
using MimeKit;

namespace App.cms.StaticHelpers
{
    public static class EmailService
    {
        public static void Send(EmailModel emailModel, CmsOptions cmsOptions)
        {
            var client = new SmtpClient(cmsOptions.SmptClientServer, cmsOptions.SmptClientPort);
            client.UseDefaultCredentials = false;
            client.Credentials =
                new NetworkCredential(cmsOptions.SmptCredentialsMail, cmsOptions.SmptCredentialsPassword);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
        
            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(emailModel.From, cmsOptions.AppName);
            mailMessage.To.Add(emailModel.To);
            mailMessage.Body = emailModel.Body;
            mailMessage.Subject = emailModel.Subject;
            client.Send(mailMessage);
        }

        // works, but not getting any body
        // public static void Send(EmailModel emailModel, CmsOptions cmsOptions)
        // {
        //     var email = new MimeMessage();
        //
        //     email.From.Add(new MailboxAddress(cmsOptions.AppName, emailModel.From));
        //     email.To.Add(new MailboxAddress(cmsOptions.AppName, emailModel.To));
        //
        //     email.Subject = emailModel.Subject;
        //     email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { 
        //         Text = emailModel.Subject
        //     };
        //
        //     using (var smtp = new SmtpClient())
        //     {
        //         smtp.Connect(cmsOptions.SmptClientServer, cmsOptions.SmptClientPort, false);
        //
        //         smtp.Authenticate(cmsOptions.SmptCredentialsMail, cmsOptions.SmptCredentialsPassword);
        //
        //         smtp.Send(email);
        //         smtp.Disconnect(true);
        //     }
        // }
    }
}