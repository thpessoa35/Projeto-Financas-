using ProjectFinancas.Domain.UseCase.EmailAuth;
using ProjectFinancas.Domain.Validations.UserCase;

namespace ProjectFinancas.Domain.Service.SendEmail
{
    public class EmailSendClient
    {
        private readonly EmailService _emailService;
        private readonly EmailAuthUseCase _emailAuthUseCase;

        public EmailSendClient(EmailService emailService, EmailAuthUseCase emailAuthUseCase)
        {
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _emailAuthUseCase = emailAuthUseCase;
        }

        public async Task<string> EmailSend(string to)
        {
            try
            {
                var validateEmail = new ValidateUser();

                validateEmail.ValidateEmailFormat(to);
                string from = "tmp10123025007@gmail.com";
                string codigo = GerarCodigo();
                string subject = "codigo de verificaçao";
                string body = codigo;
                string result = await _emailService.SendEmail(from, to, subject, body);

                _emailAuthUseCase.GerarCodigo(to, codigo);
                return result;
            }
            catch (Exception)
            {
                throw;
            }


        }
        private string GerarCodigo()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 6);
        }
    }
}
