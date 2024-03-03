using Microsoft.Extensions.Configuration;
using System.Net;

namespace ProjectFinancas.Domain.Service.SendEmail
{
    public class EmailConfig
    {
        public string SmtpServer { get; }
        public int SmtpPort { get; }
        public NetworkCredential Credentials { get; }

        public EmailConfig(IConfiguration config)
        {
            SmtpServer = "smtp.gmail.com";
            SmtpPort = 587;

            string email = config["Email"];
            string password = config["Password"];

            Credentials = new NetworkCredential(email, password);

        }
    }
}
