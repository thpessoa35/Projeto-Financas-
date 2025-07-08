using createUserUseCase;
using ihandleErrorcustom;
using Microsoft.AspNetCore.Mvc;
using ProjectFinancas.Controllers.Dtos;
using ProjectFinancas.Domain.Service.SendEmail;
using ProjectFinancas.Domain.UseCase.Clients;
using ProjectFinancas.Domain.UseCase.EmailAuth;


namespace ProjectFinancas.Controllers
{
    [ApiController]
    [Route("/user")]
    public class ControllerUser : ControllerBase
    {
        private readonly CreateUserUseCase _createUserUseCase;
        private readonly EmailSendClient _emailSendClient;
        private readonly CreateClientsUseCase _createClients;
        private readonly IHandleErrorCustom _handleErrorCustom;
        private readonly EmailAuthUseCase _emailAuthUseCase;

        public ControllerUser(CreateUserUseCase createUserUseCase, IHandleErrorCustom handleErrorCustom,
            EmailSendClient emailSendClient, EmailAuthUseCase emailAuthUseCase, CreateClientsUseCase createClients)
        {
            _createUserUseCase = createUserUseCase;
            _handleErrorCustom = handleErrorCustom;
            _emailSendClient = emailSendClient;
            _emailAuthUseCase = emailAuthUseCase;
            _createClients = createClients;
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] UserDto data)
        {
            try
            {

                await _createUserUseCase.Create(data);
                return Ok(new { Message = "User Created Successfully" });
            }
            catch (Exception ex)
            {

                return (ActionResult)_handleErrorCustom.HandleException(ex);
            }
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromBody] EmailDto emailRequest)
        {
            try
            {
                string to = emailRequest.To;

                string result = await _emailSendClient.EmailSend(to);

                return Ok(new { Message = result });
            }
            catch (Exception ex)
            {
                return (ActionResult)_handleErrorCustom.HandleException(ex);
            }
        }

        [HttpPost("email/validate")]

        public IActionResult ValidateCode([FromBody] CodigoDto codigoDto)
        {
            try
            {
                string token = _emailAuthUseCase.ValidarEmail(codigoDto);

                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return (ActionResult)_handleErrorCustom.HandleException(ex);
            }
        }

        [HttpPost("create-client")]

        public async Task<IActionResult> CreateClient([FromBody] List<ClientsDto> client)
        {
            var users =  await _createClients.ExecuteAsync(client);

            return Ok(users);
        }

    }

}
