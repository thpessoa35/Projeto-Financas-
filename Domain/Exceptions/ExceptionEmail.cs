using System.Text.RegularExpressions;

namespace exceptionEmail
{
    public class ExceptionEmail
    {
        public bool Validate(string email)
        {
            var regex = new Regex(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$");

            return regex.IsMatch(email);
        }
    }
}
