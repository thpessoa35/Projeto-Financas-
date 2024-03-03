
using idebitRepository;
using ProjectFinancas.Controllers.Dtos;

using sumvalue;

namespace getByModuleUseCase
{
    public class GetByModuleEntradaUseCase
    {
        private readonly IDebitRepository _debitRepository;

        public GetByModuleEntradaUseCase(IDebitRepository debitRepository)
        {
            _debitRepository = debitRepository;
        }

        public async Task<object> getByModuleUseCase( DataDto dataDto)
        {
            try
            {
               
                var finModule = await _debitRepository.GetFunctionEntradaModule(dataDto.iduser, dataDto.Module, dataDto.StartDate, dataDto.EndDate);

                var sumValue = new SumValue();

                var total = sumValue.FilterValue(finModule, "Entrada");

                return new { Data = finModule, Total = total };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
