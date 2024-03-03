using EmailRepository;
using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ProjectFinancas.Domain.Service.SendEmail
{
    public class EmailService : IEmailRepository
    {
        private readonly EmailConfig _emailConfig;

        public EmailService(EmailConfig emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public async Task<string> SendEmail(string from, string to, string subject, string body)
        {
            try
            {
                using (var client = new SmtpClient(_emailConfig.SmtpServer, _emailConfig.SmtpPort))
                {
                    client.UseDefaultCredentials = false;
                    client.Credentials = _emailConfig.Credentials;
                    client.EnableSsl = true;

                    using (var mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress(from);
                        mailMessage.To.Add(to);
                        mailMessage.Subject = subject;
                        mailMessage.Body = body;
                        mailMessage.IsBodyHtml = true;

                        await client.SendMailAsync(mailMessage).ConfigureAwait(false);
                    }
                }

                return "Email sent successfully";
            }
            catch (Exception ex)
            {
                return $"Error sending email: {ex.Message}";
            }
        }
    }
}
