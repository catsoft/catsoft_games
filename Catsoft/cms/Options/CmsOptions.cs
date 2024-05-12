using App.cms.Options;

namespace App.cms
{
    public class CmsOptions
    {
        public string SmptClientServer { get; set; } = "smtp.gmail.com";

        public int SmptClientPort { get; set; } = 587;

        public string SmptCredentialsMail { get; set; }

        public string SmptCredentialsPassword { get; set; }

        public string AppName { get; set; } = CompanyName.Name;
    }
}