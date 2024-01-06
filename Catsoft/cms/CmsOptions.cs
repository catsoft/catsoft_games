namespace App.CMS
{
    public class CmsOptions
    {
        public string SmptClientServer { get; set; } = "mail.hosting.reg.ru";

        public int SmptClientPort { get; set; } = 25;
        
        public string SmptCredentialsMail { get; set; }
        
        public string SmptCredentialsPassword { get; set; }

        public string AppName { get; set; } = "App";
    }
}