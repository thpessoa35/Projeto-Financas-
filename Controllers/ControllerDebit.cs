
using getByModuleUseCase;
using getBySaidaUseCase;
using getDebitUseCase;
using ihandleErrorcustom;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectFinancas.Controllers.Dtos;
using user;



namespace Controllers
{
    [Authorize]
    [ApiController]
    [Route("/debit")]
    public class DebitController : ControllerBase
    {
        private readonly CreateDebitUseCase _createDebitUseCase;
        private readonly GetDebitDataUseCase _getDebitUseCase;
        private readonly GetBySaidaUseCase _getBySaidaUseCase;
        private readonly GetByEntradaUseCase _getByEntradaUseCase;
        private readonly GetByModuleEntradaUseCase _getByModuleUseCase;
        private readonly GetBySaidaModuleUseCase _getBySaidaModuleUseCase;
        private readonly IHandleErrorCustom _handleErrorCustom;

        public DebitController(
            CreateDebitUseCase createDebitUseCase,
            GetDebitDataUseCase getDebitUseCase,
            GetBySaidaUseCase getBySaidaUseCase,
            GetByEntradaUseCase getByEntradaUseCase,
            GetByModuleEntradaUseCase getByModuleUseCase,
            GetBySaidaModuleUseCase getBySaidaModuleUseCase,
            IHandleErrorCustom handleErrorCustom


        )
        {
            _createDebitUseCase = createDebitUseCase;
            _getDebitUseCase = getDebitUseCase;
            _getBySaidaUseCase = getBySaidaUseCase;
            _getByEntradaUseCase = getByEntradaUseCase;
            _getByModuleUseCase = getByModuleUseCase;
            _getBySaidaModuleUseCase = getBySaidaModuleUseCase;
            _handleErrorCustom = handleErrorCustom;
        }

        [HttpPost("{Iduser}")]
        public async Task<IActionResult> Create([FromBody] DebitDto data, string Iduser)
        {
            try
            {
                data.Iduser = Iduser;
                await _createDebitUseCase.create(data);
                return Ok(new { Message = "Debit created successfully" });
            }
            catch (Exception ex)
            {
                return (ActionResult)_handleErrorCustom.HandleException(ex);
            }
        }

        [HttpGet("saida/{iduser}")]
        public async Task<IActionResult> FindBySaida([FromRoute] string idUser, [FromBody] DataDto dataDto)
        {
            try
            {
                dataDto.iduser = idUser;

                var total = await _getBySaidaUseCase.FindBySaida(dataDto);

                var response = new
                {
                    total.Get,
                    total.Total
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                // Trate exceções
                return (ActionResult)_handleErrorCustom.HandleException(ex);
            }
        }

        [HttpGet("entrada/{iduser}")]
        public async Task<IActionResult> FindByEntrada([FromRoute] string iduser, [FromBody] DataDto dataDto)
        {
            try
            {
                dataDto.iduser = iduser;

                var total = await _getByEntradaUseCase.FindByEntrada(dataDto);

                var response = new
                {
                    total.Get,
                    total.Total
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return (ActionResult)_handleErrorCustom.HandleException(ex);
            }
        }
        [HttpGet("entrada/{iduser}/{module}")]
        public async Task<IActionResult> getModuleEntrada([FromRoute] string iduser, [FromRoute] string module, [FromBody] DataDto dataDto)
        {
            try
            {
                dataDto.iduser = iduser;
                dataDto.Module = module;

                var total = await _getByModuleUseCase.getByModuleUseCase(dataDto);

                return Ok(new { Message = total });
            }
            catch (Exception ex)
            {
                return (ActionResult)_handleErrorCustom.HandleException(ex);
            }
        }
        [HttpGet("saida/{iduser}/{module}")]
        public async Task<IActionResult> GetBySaidaModuleUseCase([FromRoute] string iduser, [FromRoute] string module, [FromBody] DataDto dataDto)
        {
            try
            {
                dataDto.iduser = iduser;
                dataDto.Module = module;
                var total = await _getBySaidaModuleUseCase.getByModuleUseCase(dataDto);


                return Ok(new { Message = total });
            }
            catch (Exception ex)
            {
                return (ActionResult)_handleErrorCustom.HandleException(ex);
            }
        }
    };
};
