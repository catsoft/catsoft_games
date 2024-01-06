using System.Net;
using System.Net.Mail;

namespace App.CMS.StaticHelpers
{
    public static class EmailService
    {
        public static void Send(EmailModel emailModel, CmsOptions cmsOptions)
        {
            var client = new SmtpClient(cmsOptions.SmptClientServer, cmsOptions.SmptClientPort);
            client.UseDefaultCredentials = true;
            client.Credentials = new NetworkCredential(cmsOptions.SmptCredentialsMail, cmsOptions.SmptCredentialsPassword);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(emailModel.From);
            mailMessage.To.Add(emailModel.To);
            mailMessage.Body = emailModel.Body;
            mailMessage.Subject = emailModel.Subject;
            client.Send(mailMessage);
        }
    }
}
