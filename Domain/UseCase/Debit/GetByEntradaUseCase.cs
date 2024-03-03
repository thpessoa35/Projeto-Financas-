
using debit;
using idebitRepository;
using ProjectFinancas.Controllers.Dtos;

using sumvalue;

namespace getBySaidaUseCase
{
    public class GetByEntradaUseCase
    {
        private readonly IDebitRepository _IdebitRepository;

        public GetByEntradaUseCase(IDebitRepository idebitRepository)
        {
            _IdebitRepository = idebitRepository;
        }

        public async Task<(IEnumerable<Debit> Get, decimal Total)> FindByEntrada( DataDto dataDto)
        {
            try
            {
                var debits = await _IdebitRepository.FindByEntrada(dataDto.iduser, dataDto.StartDate, dataDto.EndDate);

                var sumValue = new SumValue();

                var total = sumValue.FilterValue(debits, "Entrada");

                return (debits, total);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao consultar Dados: {ex}");
                throw;
            }
        }
    }
}
