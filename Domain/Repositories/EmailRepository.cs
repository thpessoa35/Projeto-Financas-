namespace EmailRepository
{
    public interface IEmailRepository
    {
        Task<string> SendEmail(string from, string to, string subject, string body); 
    }
}
