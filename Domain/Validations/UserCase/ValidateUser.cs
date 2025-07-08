using exceptionEmail;
using ProjectFinancas.Domain.Repositories;

namespace ProjectFinancas.Domain.Validations.UserCase
{
    public class ValidateUser
    {

        public async Task CheckEmailExistence(IUserRepository userRepository, string email)
        {
            var findByEmail = await userRepository.FindByEmail(email);

            if (findByEmail)
            {
                throw new CustomError("Email Ja Cadastrado.");
            }
        }
        public void ValidateEmailFormat(string email)
        {
            var validateEmail = new ExceptionEmail();

            var ValidateEmail = validateEmail.Validate(email);

            if (!ValidateEmail)
            {
                throw new CustomError("Erro ao criar Email");
            }
        }
        public async Task CheckIdExistence(IUserRepository userRepository, string id)
        {
            var findById = await userRepository.FindByCpf(id);

            if (!findById)
            {
                throw new CustomError("Usuario nao encontrado.");
            }
        }
    }
}
