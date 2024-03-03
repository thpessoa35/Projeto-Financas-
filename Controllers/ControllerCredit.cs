using getAllCreditUseCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [Authorize]
    [ApiController]
    [Route("/credit")]
    public class CreditController : ControllerBase
    {
        private readonly CreateCreditUseCase _createCreditUseCase;
        private readonly GetAllCreditUseCase _getAllCreditUseCase;


        public CreditController(
            CreateCreditUseCase createCreditUseCase,
            GetAllCreditUseCase getAllCreditUseCase


        )
        {
            _createCreditUseCase = createCreditUseCase;
            _getAllCreditUseCase = getAllCreditUseCase;

        }

        [HttpPost("{iduser}")]
        public async Task<IActionResult> Create([FromBody] CreditDto data, string iduser)
        {
            try
            {
                data.Iduser = iduser;
                await _createCreditUseCase.create(data);
                return Ok(new { Message = "Credit created successfully" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(new { Message = $"{ex.Message}" });
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> FindAll([FromRoute] string id)
        {
            try
            {

                var findall = await _getAllCreditUseCase.FindALL(id);
                return Ok(findall);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(new { Message = $"{ex.Message}" });
            }
        }
    };
};
