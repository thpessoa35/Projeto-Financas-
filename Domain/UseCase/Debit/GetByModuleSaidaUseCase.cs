
using idebitRepository;
using ProjectFinancas.Controllers.Dtos;
using sumvalue;

namespace getBySaidaUseCase
{
    public class GetBySaidaModuleUseCase
    {
        private readonly IDebitRepository _IdebitRepository;


        public GetBySaidaModuleUseCase(IDebitRepository idebitRepository)
        {
            _IdebitRepository = idebitRepository;

        }

        public async Task<object> getByModuleUseCase(DataDto dataDto)
        {
            try
            {

                var finModule = await _IdebitRepository.GetFunctionBySaida(dataDto.iduser, dataDto.Module ,dataDto.StartDate, dataDto.EndDate);

                var sumValue = new SumValue();

                var total = sumValue.FilterValue(finModule, "Saida");

                return new { Find = finModule, Total = total };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
