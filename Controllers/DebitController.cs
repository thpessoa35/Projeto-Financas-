using getByModuleUseCase;
using getBySaidaUseCase;
using getDebitUseCase;
using ihandleErrorcustom;
using Microsoft.AspNetCore.Mvc;
using ProjectFinancas.Controllers.Dtos;
using ProjectFinancas.Domain.UseCase;

namespace ProjectFinancas.Controllers
{
    
    [ApiController]
    [Route("debit")]
    public class DebitController : ControllerBase
    {
        private readonly CreateDebitUseCase _createDebitUseCase;
        private readonly GetDebitDataUseCase _getDebitUseCase;
        private readonly GetBySaidaUseCase _getBySaidaUseCase;
        private readonly GetByEntradaUseCase _getByEntradaUseCase;
        private readonly GetByModuleEntradaUseCase _getByModuleUseCase;
        private readonly GetBySaidaModuleUseCase _getBySaidaModuleUseCase;
        private readonly IHandleErrorCustom _handleErrorCustom;
        private readonly GetAll _getAll;

        public DebitController(
            CreateDebitUseCase createDebitUseCase,
            GetDebitDataUseCase getDebitUseCase,
            GetBySaidaUseCase getBySaidaUseCase,
            GetByEntradaUseCase getByEntradaUseCase,
            GetByModuleEntradaUseCase getByModuleUseCase,
            GetBySaidaModuleUseCase getBySaidaModuleUseCase,
            IHandleErrorCustom handleErrorCustom, GetAll getAll)
        {
            _createDebitUseCase = createDebitUseCase;
            _getDebitUseCase = getDebitUseCase;
            _getBySaidaUseCase = getBySaidaUseCase;
            _getByEntradaUseCase = getByEntradaUseCase;
            _getByModuleUseCase = getByModuleUseCase;
            _getBySaidaModuleUseCase = getBySaidaModuleUseCase;
            _handleErrorCustom = handleErrorCustom;
            _getAll = getAll;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DebitDto data)
        {
            try
            {
                
                await _createDebitUseCase.create(data);
                return Ok(new { Message = "Debit created successfully" });
            }
            catch (Exception ex)
            {
                return (ActionResult)_handleErrorCustom.HandleException(ex);
            }
        }

        [HttpPost("saida")]
        public async Task<IActionResult> FindBySaida([FromQuery] DataDto dataDto)
        {
            try
            {
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

        [HttpPost("entrada")]
        public async Task<IActionResult> FindByEntrada([FromQuery] DataDto dataDto)
        {
            try
            {
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
        [HttpPost("saida/{iduser}/{module}")]
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
        
        [HttpGet("entrada/get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var debits = await _getAll.GetAllAsync();
                var response = new
                {
                    debits.Get,
                    debits.Total
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return (ActionResult)_handleErrorCustom.HandleException(ex);
            }
        }
    };
};
