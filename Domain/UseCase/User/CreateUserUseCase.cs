using iUserRepository;
using ProjectFinancas.Controllers.Dtos;
using user;
using System;
using System.Threading.Tasks;
using ProjectFinancas.Domain.Validations.UserCase;

namespace createUserUseCase
{
    public class CreateUserUseCase
    {
        private readonly IUserRepository _userRepository;
        

        public CreateUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
           
        }

        public async Task Create(UserDto data)
        {
            try
            {
                var validateUser = new ValidateUser();

                await validateUser.CheckEmailExistence(_userRepository, data.Email);

                validateUser.ValidateEmailFormat(data.Email);

                var user = new User(
                    name: data.Name,
                    email: data.Email
                );
        
                await _userRepository.Create(user);
            }
          
            catch (Exception)
            {
                throw new CustomError("Erro ao criar Usuario");
            }
        }
    }
}
