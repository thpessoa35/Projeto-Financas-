using System.Collections.Generic;
using System.Threading.Tasks;
using debit;
using idebitRepository;
using ProjectFinancas.Controllers.Dtos;
using sumvalue;

namespace getBySaidaUseCase
{
    public class GetBySaidaUseCase
    {
        private IDebitRepository _debitRepository;

        public GetBySaidaUseCase(IDebitRepository idebitRepository)
        {
            _debitRepository = idebitRepository;
        }

        public async Task<(IEnumerable<Debit> Get, decimal Total)> FindBySaida(DataDto dataDto)
        {
            try
            {
                var debits = await _debitRepository.FindBySaida(dataDto.StartDate, dataDto.EndDate);

                var sumValue = new SumValue();

                var total = sumValue.FilterValue(debits, "Saida");

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
